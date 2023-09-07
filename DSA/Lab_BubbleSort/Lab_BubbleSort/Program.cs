int[] nums = { 2, 48, 99, 23, 45, 12, 63, 4, 8, 93, 71, 38 };


bool swaps = false;
do
{
    swaps = false;
    for (int i = 1; i < nums.Length; i++)
    {
        if (nums[i - 1] > nums[i])
        {
            //int temp = nums[i - 1];
            //nums[i - 1] = nums[i];
            //nums[i] = temp;
            //swaps = true;
            (nums[i], nums[i - 1]) = (nums[i - 1], nums[i]); //now its leet
        }
    }
} while (swaps);

foreach (int item in nums)
{
    Console.Write(" " + item);
}
