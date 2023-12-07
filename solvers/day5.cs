namespace day5;

public static class seed_mapper
{
    public static double part_one(StreamReader sr)
    {
        var seeds_line = sr.ReadLine();
        if (seeds_line == null)
        {
            throw new InvalidOperationException();
        }
        double[] seeds = seeds_line.Split(":")[1]
                                    .Trim(' ').Split(" ")
                                    .Select(str => double.Parse(str)).ToArray();

        List<Map> maps = new List<Map>();

        string? line;
        while ((line = sr.ReadLine()) != null)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                _ = sr.ReadLine(); // dispose title row
                seeds = seeds.apply_maps(maps);
                maps = new List<Map>();
            }
            else
            {
                var nums = line.Trim(' ').Split(" ");
                maps.Add(new Map(
                            double.Parse(nums[1]),
                            double.Parse(nums[0]),
                            double.Parse(nums[2])));
            }
        }
        if (maps.Count>0) { seeds = seeds.apply_maps(maps);}
        //Console.WriteLine(seeds.Aggregate("", (agg, val) => agg + "," + val));
        return seeds.Min();
    }

    public static double[] apply_maps(this double[] seeds, List<Map> maps)
    {
        var next_seeds = (double[])seeds.Clone();
        foreach (var map in maps)
        {
            for (int i = 0; i < seeds.Length; i++)
            {
                var seed = seeds[i];
                if (seed - map.source_start < map.range
                        && seed - map.source_start >= 0)
                {
                    //Console.WriteLine("seed: " + seed.ToString() + " | " + "diff: " + (map.target_start - map.source_start));
                    next_seeds[i] = seed + (map.target_start - map.source_start);
                }
            }
        }
        //Console.WriteLine(seeds.Aggregate("", (agg, val) => agg + "," + val));
        return next_seeds;
    }
}


public class Map
{
    public double source_start;
    public double target_start;
    public double range;

    public Map(double SourceStart, double TargetStart, double Range)
    {
        source_start = SourceStart;
        target_start = TargetStart;
        range = Range;
    }
}
