
List<int> list1 = new List<int> { 1, 2, 4, 5 };
List<int> list2 = new List<int> { 1, 3, 4};

//find shorter list
//outerloop shorter list
//innerloop longer list
//add smaller item to list and never look at it again

var result = new List<int>(list1.Count + list2.Count());
List<int> longer = list1.Count > list2.Count ? longer = list1 : longer = list2;
List<int> shorter = list1.Count < list2.Count ? shorter = list1 : shorter = list2;
int shortCount = 0;
int longCount = 0;
while (shortCount < shorter.Count)
{
    if (shorter[shortCount] == longer[longCount])
    {
        result.Add(shorter[shortCount]);
        result.Add(longer[shortCount]);
        shortCount++;
        longCount++;
        continue;

    }
    if (shorter[shortCount] < longer[longCount])
    {
        result.Add(shorter[shortCount]);
        shortCount++;
        continue;
    }
    if (shorter[shortCount] > longer[longCount])
    {
        result.Add(longer[longCount]);
        longCount++;
        continue;
    }
}
while (longCount < longer.Count)
{
    result.Add(longer[longCount]);
    longCount++;
}

foreach (var e in result)
{
    Console.WriteLine(e);
}
