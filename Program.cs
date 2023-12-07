var readPath = args[0];
readPath = Environment.CurrentDirectory + "/data/" + readPath;
var streamReader = new StreamReader(readPath);

var ans = day5.seed_mapper.part_one(streamReader);

Console.WriteLine(ans);
