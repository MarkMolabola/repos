namespace Single_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = new int[] { 4, 1, 2, 1, 2 };
            SingleNumber(ints);
        }
        static int SingleNumber(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (dict.ContainsKey(num))
                {
                    dict.Remove(num);
                }
                else
                {
                    dict[num] = 1;
                }
            }
            return dict.Keys.First();
        }
    }
}
