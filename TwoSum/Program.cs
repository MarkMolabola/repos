namespace TwoSum
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int[] nums = { 2, 7, 11, 15 };
            int target = 9;
            int[] result = TwoSum(nums, target);
            Console.WriteLine($"[{result[0]}, {result[1]}]");
        }
        static int[] TwoSum(int[] nums, int target)
        {
            
            int [] results = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                int x = target - nums[i];
                int index = Array.IndexOf(nums, x);
                if (nums.Contains(x))
                {
                   results[0] = i;
                   results[1] = index;
                    break;
                }

            }
            return results;
           

        }



    }
}
