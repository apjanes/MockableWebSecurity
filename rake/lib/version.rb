class Version
  def initialize(version)
    items = version ? version.split('.') : []
    @data = {}
    @keys = [:major, :minor, :build, :revision]
    @data[:major] = items[0].to_i || 0
    @data[:minor] = items[1].to_i || 0
    @data[:build] = items[2].to_i || 0
    @data[:revision] = items[3].to_i || 0
  end
  
  def major
    @data[:major]
  end
  
  def minor
    @data[:minor]
  end
  
  def build
    @data[:build]
  end
  
  def revision
    @data[:revision]
  end
  
  def assembly_version
    "#{major}.#{minor}.0.0"
  end
  
  def file_version
    "#{major}.#{minor}.#{build}.#{revision}"
  end
  
  def increment(part)
    part = part.to_sym
    found = false
    @keys.each do |key|
      @data[key] = 0 if found
      if key == part
        @data[key] = @data[key] + 1
        found = true
      end
    end
  end
end