namespace SortingStrategy.Services.SortingAlgorithms
{
    public class QuickSortStrategy : ISortingStrategy
    {
        public List<int> Sort(List<int> list)
        {
            list.Sort();  // Default is Quicksort
            return list;
            Console.WriteLine("QuickSorted list ");
        }
    }
}