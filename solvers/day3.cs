namespace day3;

public static class schematic_analyser{
    public static int part_one(StreamReader sr){
        var result = 0;

        var lines = new List<string>();

        string? input;
        while ((input=sr.ReadLine()?.Trim(' ')) != null){
            lines = lines.Append(input).ToList();
        }
        
        for (int i=0 ; i<lines.Count ; i++){
            var line = lines[i];

            var candidate = "";
            var candidate_StartIndex = 0;
            var candidate_EndIndex = 0;
            for (int j=0 ; j<=line.Length ; j++){
                if (j!=line.Length && Char.IsDigit(line[j])){
                    if (candidate.Length == 0){
                        candidate_StartIndex = j;
                    }
                    candidate += line[j];
                    candidate_EndIndex = j;
                }else if (candidate.Length > 0){
                    // analyse candidate
                    var symbol_found = false;
                    for (int k=Math.Max(candidate_StartIndex-1, 0) 
                            ; k<=Math.Min(candidate_EndIndex+1, line.Length-1) 
                            ; k++){
                        for (int l=Math.Max(i-1, 0) ; l<=Math.Min(i+1, lines.Count-1) ; l++){
                            if (!(Char.IsDigit(lines[l][k]) || lines[l][k] == '.')){
                                symbol_found = true;
                                break;
                            }
                        }
                        if (symbol_found) {break;}
                    }

                    if (symbol_found){
                        if (int.TryParse(candidate, out int number)){
                            result += number;
                        }else{
                            throw new InvalidCastException("Could not parse candidate: \"" + candidate + "\"");
                        }
                    }
                    // reset candidate
                    candidate = "";
                }
            }
        }

        return result;
    }
}
