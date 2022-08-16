using SortingStrategy.Services.SortingAlgorithms;

namespace SortingStrategy.Requests
{

    public class SortRequest
    {
        public List<int> List { get; set; }

        public SortingAlgorithmEnum SortingOption { get; set; } = SortingAlgorithmEnum.Bubble;
    }
}
