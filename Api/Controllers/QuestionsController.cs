using Core.BusinessServices;
using Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class QuestionsController : ControllerBase
{
    private readonly ILogger<QuestionsController> _logger;
    private readonly QuestionService _questionService;

    public QuestionsController(ILogger<QuestionsController> logger, QuestionService questionRepository )
    {
        _logger = logger;
        _questionService = questionRepository;
    }

    [HttpGet]
    public QuestionDto GetNextQuestion()
    {
        _logger.LogInformation("Get next question");
        throw new NotImplementedException();
    }
    
    [HttpPost(Name = "SaveAnswer")]
    public QuestionDto SaveAnswer([FromBody] string answer)
    {   
        _logger.LogInformation("Received answer: {Answer}", answer);
        _logger.LogInformation("Returning next question");
        throw new NotImplementedException();
    }
}