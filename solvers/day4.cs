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

    public static int part_two(StreamReader sr){
        var result = 0;

        var card_number = 1;
        var extra_card_counts = new Dictionary<int, int>(){
            {1,0}
        };

        string? line;
        while ((line = sr.ReadLine()) != null)
        {
            var card_count = 1;
            if (extra_card_counts.TryGetValue(card_number, out var extras)){
                card_count += extras;
            }
            
            result += card_count;

            var input = line.Split(':')[1].Split('|')
                            .Select(numbers => numbers.Trim(' ').Split(' ')
                                        .Where(number => !string.IsNullOrWhiteSpace(number))
                                        .Select(number_string => int.Parse(number_string))
                                        .ToList()
                            ).ToList();

            var winning_numbers = input[0];
            var my_numbers = input[1];
            
            var winners = winning_numbers.Count(winner => my_numbers.Contains(winner));
            
            for (int i=card_number ; i<=card_number+winners ; i++){
                if (extra_card_counts.ContainsKey(i)){
                    extra_card_counts[i] += card_count;
                }else{
                    extra_card_counts.Add(i,card_count);
                }
            }

            card_number++;
        }
        return result;
    }
}
