var readPath = args[0];
readPath = Environment.CurrentDirectory + "/data/" + readPath;
var streamReader = new StreamReader(readPath);

var ans = day1.trebuchet_calibrator.part_two(streamReader);

Console.WriteLine(ans);
