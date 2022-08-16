namespace SortingStrategy.Services
{
    /// <summary>
    /// The 'Strategy' abstract class
    /// </summary>
    public interface ISortingStrategy
    {
        List<int> Sort(List<int> dataToBeSorted);
    }
}
