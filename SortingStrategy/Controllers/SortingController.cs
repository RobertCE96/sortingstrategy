using Microsoft.AspNetCore.Mvc;
using SortingStrategy.Requests;
using SortingStrategy.Services;
using SortingStrategy.Services.Interfaces;
using SortingStrategy.Services.SortingAlgorithms;
using System.Net;

namespace SortingStrategy.Controllers
{
    [ApiController]
    [Route("sort")]
    public class SortingController : ControllerBase
    {
        private readonly ILogger<SortingController> _logger;
        private readonly IFileService _fileService;

        public SortingController(ILogger<SortingController> logger, IFileService fileService)
        {
            _logger = logger;
            _fileService = fileService;
        }

        [HttpPost]
        public IActionResult Sort(SortRequest request)
        {
            if(request?.List == null) {
                return BadRequest();
            }

            ISortingStrategy sortingStrategy = null;

            sortingStrategy = GetSortingOption(request.SortingOption);

            Console.WriteLine(request);

            var sortedList = sortingStrategy.Sort(request.List);

            _fileService.WriteLinesToFileAsync("result.txt", new string[] { string.Join(',', sortedList) }); ;

            return Ok(sortedList);
        }

        [HttpGet]
        [Route("load")]
        public IActionResult LoadFile()
        {
            try
            {
                var fileContent = _fileService.LoadFile("result.txt");

                var numbers = fileContent?.Split(',')?.Select(Int32.Parse)?.ToList();

                return Ok(numbers);
            }
            catch (Exception ex)
            {
                return BadRequest("No file");
            }
        }

        private static ISortingStrategy GetSortingOption(SortingAlgorithmEnum sortingAlgorithm)
        {
            ISortingStrategy sortingStrategy = null;

            switch (sortingAlgorithm)
            {
                case SortingAlgorithmEnum.Bubble:
                    sortingStrategy = new BubbleSortStrategy();
                    break;
                case SortingAlgorithmEnum.Merge:
                    sortingStrategy = new MergeSortStrategy();
                    break;
                case SortingAlgorithmEnum.Quick:
                    sortingStrategy = new QuickSortStrategy();
                    break;
                default:
                    break;
            }
            return sortingStrategy;
        }
    }
}