namespace day2;

public static class bag_solver{
    public static int part_one(StreamReader sr){
        var result = 0;
        
        string? line;
        var index = 0;
        while((line = sr.ReadLine()) != null){
            if (line.Length == 0){continue;}
            index++;

            var inputs = line.Split(":")[1]
                             .Split(";")
                             .SelectMany(str => str.Split(","));

            var possible = true;
            foreach (var input in inputs){
                var data = input.Trim(' ').Split(" ");
                if (Enum.TryParse(data[1], out Colour colour)
                    && int.TryParse(data[0], out int num)){
                        if (num > (int)colour){
                            possible = false;
                        }
                }
                else{
                    throw new InvalidOperationException("couldn't parse number/colour pair: " + data[0] + "|" + data[1]);
                }
            }

            if (possible) {
                result += index;
            }
        }

        return result;
    }

    public enum Colour{
        red = 12,
        green = 13,
        blue = 14
    }
}
