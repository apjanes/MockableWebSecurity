class Manifest
  require 'yaml'
  def initialize(path)
    @data = YAML.load_file(path)
  end
  
  def solution
    unless @data['solution']
      @data['solution'] = "#{@data['code']}.sln"
    end
    @data['solution']
  end
end