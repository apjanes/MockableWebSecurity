$base_dir = File.dirname(__FILE__)

# Configurable properties
$nuspec = {} 
$nuspec[:id] = "MockableWebSecurity"
$nuspec[:output] = "#{$nuspec[:id]}.nuspec"
$nuspec[:licenseUrl] = 'http://mockablewebsecurity.codeplex.com/license'
$nuspec[:projectUrl] = 'http://mockablewebsecurity.codeplex.com'


$nuget = {}
$nuget[:command] = 'C:/Apps/NuGet.exe'

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
require 'lib/utils'
$manifest = Manifest.new($manifest_path)

Dir.glob(File.join($task_dir, "*.task")).each do |x|
  load 'tasks/' + File.basename(x)
end



