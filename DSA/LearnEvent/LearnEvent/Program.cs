using System.Timers;
using LearnEvent;

NoisyListSample();

void NoisyListSample()
{
    NoisyList<string> list = new NoisyList<string>(new string[] { "Apple", "Banana", "Cherry" }) { Name = "StringList" };
    NoisyList<int> intList = new NoisyList<int>(new int[] {1, 2, 3}) { Name = "IntList" };
    list.OnItemAdded +=
        (l, arg) => Console.WriteLine($"{l.Name} added a new item: {arg.ItemAdded} in position {arg.ItemPositionInList} on {arg.InsertionTimestamp}");
    intList.OnItemRemoved += IntList_OnItemRemoved;

    list.Add("Peach");
    intList.Add(25);
    Console.WriteLine("Items added");
    list.Remove("Apple");
    intList.Remove(2);
    Console.WriteLine("Items removed");
    Console.WriteLine($"Clearing {list.Name}...");
    list.Clear();
    Console.WriteLine($"Clearing {intList.Name}...");
    intList.Clear();
}

void IntList_OnItemRemoved(NoisyList<int> arg1, (int CountBeforeRemove, int CountAfterRemove, int ItemRemoved, DateTime RemoveTimestamp) arg2)
{
    Console.WriteLine($"{arg2.ItemRemoved} was removed from {arg1.Name} on {arg2.RemoveTimestamp}, there are {arg2.CountAfterRemove} items now");
}

//FileSystemWatcherSample();

//void FileSystemWatcherSample()
//{
//    using var watcher = new FileSystemWatcher(@"C:\Test");
//    watcher.NotifyFilter = NotifyFilters.Attributes
//        | NotifyFilters.CreationTime
//        | NotifyFilters.DirectoryName
//        | NotifyFilters.FileName
//        | NotifyFilters.Size;
//    watcher.Changed += (s, arg) => Console.WriteLine($"{arg.Name} modified");
//    watcher.Created += (s, arg) => Console.WriteLine($"{arg.Name} created");
//    watcher.Deleted += (s, arg) => Console.WriteLine($"{arg.Name} deleted");
//    watcher.Renamed += (s, arg) => Console.WriteLine($"{arg.Name} renamed");
//    watcher.EnableRaisingEvents = true;
//    Console.WriteLine("Press any key to stop the program");
//    Console.ReadKey();
//}

//void Handler(object s, ElapsedEventArgs arg)
//{
//    Console.WriteLine($"Timer with the following interval: {(s as System.Timers.Timer).Interval}.. Last fired at: {arg.SignalTime}");
//}
