class AssemblyInfo
  def initialize(path = $manifest.assembly_info_path)
    @path = path
    @lines = []
    @by_key = {}
    File.open(path, 'r') do |f|
      @lines = f.readlines;
    end
    
    (0..@lines.length - 1).each do |i|
      @lines[i].strip!
      line = @lines[i]
      if (line =~ /^\s*\[assembly:\s*([^(]+)\("([^"]+)"\)\s*\]\s*$/) then
        value = $2
        key = $1
        @by_key[key] = {:key => key, :value => value, :index => i}
      end
    end
  end
  
  def save
    File.open(@path, 'w') do |f|
      f.write(self.to_s)
    end
  end

  def to_s
    @lines.map{|x| "#{x}\n"}.join
  end
  
  def method_missing(meth, *args, &block)
    key = to_prop(meth.to_s)
    if (key =~ /=$/) then
      key = key[0..-2]
      val = @by_key[key]
      if val then
        val[:value] = args[0]
        @lines[val[:index]] = to_asm(val[:key], val[:value])
      else
        index = @lines.length
        line = to_asm(key, args[0])
        
        @lines.push(line)
        @by_key[key] = {:key => key, :value => args[0], :index => index}
      end
    else
      val = @by_key[meth]
      return val[:value] if (val)
    end
  end

  private
  def to_asm(key, value)
    return "[assembly: #{key}(\"#{value}\")]"
  end
  
  def to_prop(key)
    "Assembly" + key.split('_').map {|x| "#{x[0].upcase}#{x[1..x.length-1]}"}.join
  end
end
