using Core.BusinessServices;
using Domain.Exams;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]/{studentId}")]
public class ExamController(ILogger<ExamController> logger, QuestionService questionService)
    : ControllerBase
{
    [HttpGet]
    public IActionResult GetNextQuestion(int studentId)
    {
        try
        {
            var question = questionService.GetNextQuestion(studentId.StudentId());
            logger.LogInformation("Get next question: {Question}", question.Question);
            return Ok(question);
        }
        catch (ArgumentException e)
        {
            return  BadRequest(e.Message);
        }
    }

    [HttpGet("/answers", Name = "GetAnswers")]
    public IActionResult Answers(int studentId)
    {
        try
        {
            var examDto = questionService.GetExamSubmission(studentId.StudentId());
            logger.LogInformation("Student: {Student}, Answers: [\n{Answers}\n]",
                studentId.StudentId(), examDto.ToString());
            return Ok(examDto);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("/answers", Name = "SaveAnswer")]
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