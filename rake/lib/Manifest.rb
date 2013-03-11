class Manifest
  require 'yaml'
  require 'time'
  def initialize(path)
    @data = YAML.load_file(path)
    self.solution = self.solution || "#{self.code}.sln"
    self.title = self.title || self.name
    
    if self.copyright and self.copyright.start_year then
      unless self.copyright.end_year then
        self.copyright.end_year = Time.now.strftime('%Y')
      end
      self.copyright = "Copyright #{self.copyright.start_year} to #{self.copyright.end_year} by #{self.company}"
    end
    
    self.src_dir = self.src_dir || 'src'
    self.assembly_info_path = self.assembly_info_path || File.join(self.src_dir, 'Properties/AssemblyInfo.cs')
  end
  
  def method_missing(meth, *args, &block)
    meth = meth.to_s
    if (!args.empty? and meth =~ /=$/)
      meth = meth.chop
      @data[meth] = args[0]
    end
    @data[meth]
  end
end

class Hash
  def method_missing(meth, *args, &block)
    meth = meth.to_s
    if (!args.empty? and meth =~ /=$/)
      meth = meth.chop
      self[meth] = args[0]
    end
    self[meth]
  end
end