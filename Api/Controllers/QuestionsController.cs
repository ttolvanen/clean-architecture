using Core.BusinessServices;
using Core.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]/{studentId}")]
public class QuestionsController(ILogger<QuestionsController> logger, QuestionService questionService)
    : ControllerBase
{
    [HttpGet]
    public IActionResult GetNextQuestion(int studentId)
    {
        try
        {
            logger.LogInformation("Get next question: {Question}",
                questionService.GetNextQuestion(studentId.StudentId()).Question);
            return Ok(questionService.GetNextQuestion(studentId.StudentId()));
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("/answers", Name = "GetAnswers")]
    public IActionResult Answers(int studentId)
    {
        try
        {
            var answers = questionService.GetExamSubmission(studentId.StudentId()).Answers;
            logger.LogInformation("Student: {Student}, Answers: [\n{Answers}\n]",
                studentId.StudentId(), string.Join(",\n", answers.Select(a => a.ToString())));
            return Ok(answers);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost(Name = "SaveAnswer")]
    public IActionResult SaveAnswer(int studentId, [FromBody] string  answer)
    {
        try
        {
            logger.LogInformation("Save answer: {Answer}", answer);
            var nextQuestion = questionService.SaveAnswer(studentId.StudentId(), answer);
            logger.LogInformation("Next question: {Question}", nextQuestion.Question);
            
            return Ok(nextQuestion);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
    }
}