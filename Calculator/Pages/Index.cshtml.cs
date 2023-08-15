using Calculator.Domain.Interfaces;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Calculator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICalculatorService _calculatorService;

        public IndexModel(ILogger<IndexModel> logger, ICalculatorService calculatorService)
        {
            _logger = logger;
            _calculatorService = calculatorService;
        }

        public int? Result { get; private set; }
        public string Error { get; private set; }

        public void OnGet()
        {
        }

        public void OnPost(int left, string operation, int right)
        {


            Result<int> result;
    switch (operation)
    {
        case "+":
            result = _calculatorService.Add(left, right);
            break;
        case "-":
            result = _calculatorService.Subtract(left, right);
            break;
        case "*":
            result = _calculatorService.Multiply(left, right);
            break;
        case "/":
            result = _calculatorService.Divide(left, right);
            break;
        default:
            throw new ArgumentOutOfRangeException();
    }

    if (result.IsSuccess)
    {
        Result = result.Value;
    }
    else
    {
        Error = result.Error;
    } 
        }
    }
}