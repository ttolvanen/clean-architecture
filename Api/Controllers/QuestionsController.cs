using Core.BusinessServices;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]/{studentId}")]
public class QuestionsController : ControllerBase
{
    private readonly QuestionService _questionService;
    private readonly ILogger<QuestionsController> _logger;

    public QuestionsController(ILogger<QuestionsController> logger, QuestionService questionService)
    {
        _logger = logger;
        _questionService = questionService;
    }

    [HttpGet]
    public IActionResult GetNextQuestion(int studentId)
    {
        //TODO: Implement support for student numbers
        _logger.LogInformation("Get next question: {Question}",  _questionService.GetNextQuestion().Question);
        return Ok(_questionService.GetNextQuestion());
    }

    [HttpPost(Name = "SaveAnswer")]
    public IActionResult SaveAnswer(int studentId, [FromBody] string  answer)
    {
        try
        {
            //TODO: Implement support for student numbers
            _logger.LogInformation("Save answer: {Answer}", answer);
            var nextQuestion = _questionService.SaveAnswer(answer);
            _logger.LogInformation("Next question: {Question}", nextQuestion.Question);
            return Ok(nextQuestion);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
    }
}