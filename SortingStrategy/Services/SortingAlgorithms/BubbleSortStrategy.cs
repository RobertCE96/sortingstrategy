namespace SortingStrategy.Services.SortingAlgorithms
{
    public class BubbleSortStrategy : ISortingStrategy
    {
        public List<int> Sort(List<int> list)
        {
            var arr = list.ToArray();

            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                    {
                        // swap temp and arr[i]
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
            //list.MergeSort(); not-implemented
            Console.WriteLine("Bubble sorted list list ");
            printArray(arr);
            return arr.ToList();
        }

        static void printArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}
