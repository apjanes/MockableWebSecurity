class MsBuild
  attr_accessor :solution
  attr_reader :properties
 
  def initialize()
    @solution = nil;
    @properties = {}
    @frameworks = {
      '2.0' => Utils.to_rb("#{ENV['SYSTEMROOT']}/Microsoft.NET/Framework/v2.0.50727"),
      '3.0' => Utils.to_rb("#{ENV['SYSTEMROOT']}/Microsoft.NET/Framework/v3.0"),
      '3.5' => Utils.to_rb("#{ENV['SYSTEMROOT']}/Microsoft.NET/Framework/v3.5"),
      '4.0' => Utils.to_rb("#{ENV['SYSTEMROOT']}/Microsoft.NET/Framework/v4.0.30319"),
    }
    @framework = @frameworks['4.0']
  end
  
  def build
    cmd = Utils.to_win(path)
    if (@solution)
      cmd += " \"#{@solution}\""
    end
    
    @properties.keys.each do |key|
      cmd += " /p:#{key}=#{@properties[key]}"
    end
    exec cmd
  end
  
  def path
    File.join(@framework, 'msbuild.exe')
  end
end