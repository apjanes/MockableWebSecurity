class NuGet
  attr_accessor :id, :copyright, :description, :version, :require_acceptance
  attr_reader   :authors, :owners, :tags
  def initialize(path)
    @authors = []
    @owners = []
    raise "You must specify a nuget section in the manifest to run the nuget task" unless $manifest.nuget    
    
    if $manifest.nuget.tags then
      @tags = $manifest.nuget.tags.split(' ')
    end
    @tags = @tags || []
    
    @urls = $manifest.nuget.urls || []
    
    @files = $manifest.nuget.files || []
    @dependencies = $manifest.nuget.dependencies || []
    @references = $manifest.nuget.references || []
    @framework_references = $manifest.nuget.framework_references || []
    
    path = Utils.to_rb(path)
    if (File.directory?(path) or !(path =~ /NuGet(.exe)?$/i)) then
      path = File.join(path, 'NuGet.exe')
    end
    
    raise "Cannot find NuGet.exe at: #{Utils.to_win(path)}" unless File.exists?(path) and File.file?(path)
    
    @id = $manifest.code
    @version = $manifest.assembly_info.version
    @authors.push($manifest.company)
    @owners.push($manifest.company)
    @copyright = $manifest.copyright
    @description = $manifest.description
    @require_license_acceptance = $manifest.nuget.require_license_acceptance || false
    @release_notes = $manifest.nuget.release_notes
  end
  
  def spec
    check
    data = <<eos
<?xml version="1.0"?>
<package >
  <metadata>
    <id>#{@id}</id>
    <version>#{@version}</version>
    <authors>#{@authors.map{|x| x + ', '}.join.chop.chop}</authors>
    <owners>#{@owners.map{|x| x + ', '}.join.chop.chop}</owners>
    <description>
#{@description}
    </description>
    <copyright>#{@copyright}</copyright>
    <requireLicenseAcceptance>#{@require_license_acceptance}</requireLicenseAcceptance>%s
  </metadata>%s
</package>
eos
    other_meta = ''
    other_meta += "\n    <tags>%s</tags>" % @tags.map{|x| x + ' '}.join.chop unless @tags.empty?
    other_meta += "\n    <releaseNotes>\n#{@release_notes}\n    </releaseNotes>" if @release_notes
    other_meta += create_urls
    post_meta = create_files
    post_meta += create_deps
    post_meta += create_refs
    post_meta += create_frefs
    
    data = data % [other_meta, post_meta]
    data = data.gsub(/\r\n/, "\n")
    data = data.gsub(/\n/,"\r\n")
    
    File.open("#{@id}.nuspec", 'w') do |f|
      f.write(data)
    end
  end
  
  private
  def check
  
    missing = []
    missing.push('id') unless @id
    missing.push('version') unless @version
    missing.push('authors') if @authors.empty?
    missing.push('description') unless @description
    
    unless missing.empty?
      raise <<eos
Not all required elements have been specified.  Missing elements are:
  #{missing.map{|x| x + ", "}.join.chop.chop}
See: http://docs.nuget.org/docs/reference/nuspec-reference for details.

eos
    end
  end
  
  def create_files
    return '' if @files.empty?
    
    files = <<eos
  
  <files>
eos
    @files.each do |f|
      files += "    <file src=\"#{f.src}\" target=\"#{f.target}\" "
      files += "exclude=\"#{f.exclude}\" " if f.exclude
      files += "/>\n"
    end
    files += <<eos  
  </files>
eos
    files
  end
  
  def create_deps
    return '' if @dependencies.empty?
    deps = <<eos
    
  <dependencies>
eos
    @dependencies.each do |d|
      deps += "    <group"
      deps += " targetFramework=\"#{d.framework}\"" if d.framework
      deps +=">\n"
      
      d.items.each do |i|
        deps += "      <dependency id=\"#{i.id}\" "
        deps += "version=\"#{i.version}\" " if i.version
        deps += "/>\n"
      end
      
      deps += "    </group>\n"
    end    
    deps += <<eos
  </dependencies>
eos

    deps
  end
  
  def create_refs
    return '' if @references.empty?
    refs = <<eos
    
  <references>
eos

    @references.each do |r|
      refs += "    <references file=\"#{r.file}\" />\n"
    end
    
    refs += <<eos
  </references>
eos
  end

  def create_frefs
    return '' if @framework_references.empty?
    refs = <<eos
    
  <frameworkAssemblies>
eos

    @framework_references.each do |r|
      refs += "    <frameworkAssembly assemblyName=\"#{r.assembly}\" "
      refs += "targetFramework=\"#{r.framework} " if r.framework
      refs += "/>\n"
    end
    
    refs += <<eos
  </frameworkAssemblies>
eos
  end
  
  def create_urls
    result = ''
  
    @urls.keys.each do |key|
      result += "\r\n    <#{key}Url>#{@urls[key]}</#{key}Url>"
    end
  
    result
  end
end