namespace day3;

public static class schematic_analyser
{
    public static int part_one(StreamReader sr)
    {
        var result = 0;

        var lines = new List<string>();

        string? input;
        while ((input = sr.ReadLine()?.Trim(' ')) != null)
        {
            lines = lines.Append(input).ToList();
        }

        for (int i = 0; i < lines.Count; i++)
        {
            var line = lines[i];

            var candidate = "";
            var candidate_StartIndex = 0;
            var candidate_EndIndex = 0;
            for (int j = 0; j <= line.Length; j++)
            {
                if (j != line.Length && Char.IsDigit(line[j]))
                {
                    if (candidate.Length == 0)
                    {
                        candidate_StartIndex = j;
                    }
                    candidate += line[j];
                    candidate_EndIndex = j;
                }
                else if (candidate.Length > 0)
                {
                    // analyse candidate
                    var symbol_found = false;
                    for (int k = Math.Max(candidate_StartIndex - 1, 0)
                            ; k <= Math.Min(candidate_EndIndex + 1, line.Length - 1)
                            ; k++)
                    {
                        for (int l = Math.Max(i - 1, 0); l <= Math.Min(i + 1, lines.Count - 1); l++)
                        {
                            if (!(Char.IsDigit(lines[l][k]) || lines[l][k] == '.'))
                            {
                                symbol_found = true;
                                break;
                            }
                        }
                        if (symbol_found) { break; }
                    }

                    if (symbol_found)
                    {
                        if (int.TryParse(candidate, out int number))
                        {
                            result += number;
                        }
                        else
                        {
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

    public static int part_two(StreamReader sr)
    {
        var result = 0;

        var lines = new List<string>();

        string? input;
        while ((input = sr.ReadLine()?.Trim(' ')) != null)
        {
            lines = lines.Append(input).ToList();
        }


        for (int i = 0; i < lines.Count; i++)
        {
            var line = lines[i];

            for (int j = 0; j < line.Length; j++)
            {
                if (line[j] == '*')
                {
                    var adjacent_int_buffer = new List<int>();

                    for (int k = Math.Max(i - 1, 0)
                            ; k <= Math.Min(i + 1, lines.Count - 1)
                            ; k++)
                    {

                        for (int l = Math.Max(j - 1, 0)
                                ; l <= Math.Min(j + 1, line.Length - 1)
                                ; l++)
                        {
                            if (Char.IsDigit(lines[k][l])){
                                var char_buffer = lines[k][l].ToString();

                                int digit_search = 1;
                                while(l-digit_search>=0 &&
                                        Char.IsDigit(lines[k][l-digit_search])){
                                    char_buffer = lines[k][l-digit_search].ToString() + char_buffer;
                                    digit_search++;
                                }

                                while(l+1 < line.Length &&
                                        Char.IsDigit(lines[k][l+1])){
                                    l++;
                                    char_buffer = char_buffer +  lines[k][l].ToString();
                                }

                                adjacent_int_buffer.Add(int.Parse(char_buffer));
                            }
                        }
                    }
                    if (adjacent_int_buffer.Count == 2){
                        //Console.WriteLine(adjacent_int_buffer.Aggregate("", (agg, val) => agg + "," + val.ToString()));
                        result += adjacent_int_buffer.Aggregate(1, (agg, val) => agg * val);
                    }
                }
            }
        }

        return result;
    }
}
