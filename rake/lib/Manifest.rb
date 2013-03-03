class Manifest
  require 'yaml'
  def initialize(path)
    @data = YAML.load_file(path)
    self.solution = self.solution || "#{self.code}.sln"
    self.title = self.title || self.name
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