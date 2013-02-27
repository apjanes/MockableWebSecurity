$base_dir = File.dirname(__FILE__)

# Configurable properties
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

$manifest_path = File.join($base_dir, 'manifest.yml')

# Requires
require 'rubygems'
require 'find'
require 'lib/manifest'
$manifest = Manifest.new($manifest_path)

unless require 'albacore'
  raise "Requires the 'albacore' gem"
end

Dir.glob(File.join($task_dir, "*.task")).each do |x|
  load 'tasks/' + File.basename(x)
end



