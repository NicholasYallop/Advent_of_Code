var readPath = args[0];
readPath = Environment.CurrentDirectory + "data/" + readPath;
var streamReader = new StreamReader(readPath);

Console.WriteLine();
