namespace day1;

public static class trebuchet_calibrator
{
    public static int part_one(StreamReader sr)
    {
        string? line;

        int calibration_sum = 0;
        while ((line = sr.ReadLine()) != null)
        {
            char[] digits = new char[2];

            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsDigit(line[i]))
                {
                    digits[0] = line[i];
                    break;
                }
            }
            for (int i = line.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(line[i]))
                {
                    digits[1] = line[i];
                    break;
                }
            }


            if (int.TryParse(new string(digits), out var current_calibration))
            {
                calibration_sum += current_calibration;
            }
            else
            {
                throw new InvalidOperationException("couldn't parse digits");
            }
        }

        return calibration_sum;
    }

    public static int part_two(StreamReader sr)
    {
        var result = 0;
        string? line;

        while ((line = sr.ReadLine()) != null)
        {
            var number_indicies = new Dictionary<int, Range>();

            var window_size = 0;
            while (window_size < line.Length){
                for (int i=0 ; i<=line.Length-window_size ; i++){
                    var candidate = line.Substring(i, window_size);
                    if (Enum.TryParse(candidate, out digit num)){
                        var number = (int)num;
                        if (number_indicies.ContainsKey(number)){
                            number_indicies[number].start_index = Math.Min(
                                    number_indicies[number].start_index,
                                    i
                                    );
                            number_indicies[number].end_index = Math.Max(
                                    number_indicies[number].end_index,
                                    i+window_size
                                    );
                        }else{
                            number_indicies.Add(number, new Range(i, i+window_size));
                        }
                    }
                }

                if (int.TryParse(line[window_size].ToString(), out var digit)){
                    if (number_indicies.ContainsKey(digit)){
                        number_indicies[digit].start_index = Math.Min(
                                number_indicies[digit].start_index,
                                window_size
                                );
                        number_indicies[digit].end_index = Math.Max(
                                number_indicies[digit].end_index,
                                window_size
                                );
                    }else{
                        number_indicies.Add(digit, new Range(window_size, window_size));
                    }
                }
                window_size++;
            }
            var numbers = number_indicies.MinBy(num_range => num_range.Value.start_index).Key.ToString()
                    + number_indicies.MaxBy(num_range => num_range.Value.end_index).Key.ToString();
            // number_indicies.Print();
            // Console.WriteLine(numbers);
            result += int.Parse(numbers);
        }

        return result;
    }

    public enum digit{
        zero=0,
        one,
        two,
        three,
        four,
        five,
        six,
        seven,
        eight,
        nine
    }

    public static bool IsNumericWord(this string input){
        return Enum.IsDefined(typeof(digit), input);
    }

    public static void Print(this Dictionary<int, Range> dict){
        foreach (var entry in dict){
            Console.WriteLine(entry.Key + " | " + entry.Value.start_index + "->" + entry.Value.end_index);
        }
    }
}

public class Range{
    public int start_index;
    public int end_index;

    public Range(int start, int end){
        start_index = start;
        end_index = end;
    }
}
