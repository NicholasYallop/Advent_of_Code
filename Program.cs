var readPath = args[0];
readPath = Environment.CurrentDirectory + "/data/" + readPath;
var streamReader = new StreamReader(readPath);

var ans = day2.bag_solver.part_one(streamReader);

Console.WriteLine(ans);
