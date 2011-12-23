$base_dir = File.dirname(__FILE__)
def get_version
  File.read('version.txt').strip
end

def increment_version
  version = get_version
  regex = /(.*?)\.(\d+)$/
  if(version =~ regex)
    File.open('version.txt', 'w') do |f|
      f << "#{$1}.#{($2.to_i) + 1}"
    end
  end
  version
end

# Configurable properties
$solution = 'MockableWebSecurity.sln'
$asm = {}
$asm[:company] = 'Peppermint IT Limited'
$asm[:product] = 'Mockable Web Security'
$asm[:title] = $asm[:product]
$asm[:description] = "Many components of the System.Web.Security namespace are static methods that are difficult to mock or stub for testing. MockableWebSecurity wraps many of these classes in interfaces with proxy implementations allowing for more easy creation of testable code."
$asm[:copyright] = "Copyright 2011 by Peppermint IT Limited"
$asm[:output] = File.join($base_dir, "src/Properties/AssemblyInfo.cs")

$nuspec = {} 
$nuspec[:id] = "MockableWebSecurity"
$nuspec[:output] = "#{$nuspec[:id]}.nuspec"
$nuspec[:licenseUrl] = 'http://mockablewebsecurity.codeplex.com/license'
$nuspec[:projectUrl] = 'http://mockablewebsecurity.codeplex.com'


$nuget = {}
$nuget[:command] = 'C:/NuGet.exe'

# Directory configuration
$bin_dir = File.join($base_dir, 'bin')
$rake_dir = File.join($base_dir, 'rake')
$task_dir = File.join($rake_dir, 'tasks')
$LOAD_PATH << $rake_dir

# Requires
require 'rubygems'
require 'find'
unless require 'albacore'
  raise "Requires the 'albacore' gem"
end
require 'win32console'
require 'term/ansicolor'
include Term::ANSIColor

Dir.glob(File.join($task_dir, "*.task")).each do |x|
  load 'tasks/' + File.basename(x)
end



