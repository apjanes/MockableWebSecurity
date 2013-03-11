class Utils
  def self.to_rb(path)
    path.gsub('\\','/')
  end
  
  def self.to_win(path)
    path.gsub('/','\\')
  end
end