var readPath = args[0];
readPath = Environment.CurrentDirectory + "/data/" + readPath;
var streamReader = new StreamReader(readPath);

var ans = day4.card_analyzer.part_one(streamReader);

Console.WriteLine(ans);
