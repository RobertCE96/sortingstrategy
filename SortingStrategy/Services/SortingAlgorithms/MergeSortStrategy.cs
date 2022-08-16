namespace SortingStrategy.Services.SortingAlgorithms
{
    public class MergeSortStrategy : ISortingStrategy
    {
        public List<int> Sort(List<int> list)
        {
            //list.MergeSort(); not-implemented
            Console.WriteLine("MergeSorted list ");
            return list;
        }
    }
}
