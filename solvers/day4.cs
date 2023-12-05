namespace day4;

public static class card_analyzer
{
    public static int part_one(StreamReader sr)
    {
        var result = 0;

        string? line;
        while ((line = sr.ReadLine()) != null)
        {
            var input = line.Split(':')[1].Split('|')
                            .Select(numbers => numbers.Trim(' ').Split(' ')
                                        .Where(number => !string.IsNullOrWhiteSpace(number))
                                        .Select(number_string => int.Parse(number_string))
                                        .ToList()
                            ).ToList();

            var winning_numbers = input[0];
            var my_numbers = input[1];
            
            var pow = winning_numbers.Count(winner => my_numbers.Contains(winner));
            if (pow>0){
                result += (int)Math.Pow(2, pow-1);
            }
        }
        return result;
    }
}
