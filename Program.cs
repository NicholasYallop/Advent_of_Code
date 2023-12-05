var readPath = args[0];
readPath = Environment.CurrentDirectory + "/data/" + readPath;
var streamReader = new StreamReader(readPath);

var ans = day3.schematic_analyser.part_one(streamReader);

Console.WriteLine(ans);
