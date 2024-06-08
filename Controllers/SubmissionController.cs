using EmployeeManagement.DataAccess.DTOs;
using EmployeeManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionService _submissionService;
        private readonly IUserService _userService;
        private readonly IAttachedFileService _attachedFileService;
        private readonly IActualSalaryService _actualSalaryService;
        private readonly IAuthenticationService _authenticationService;

        public SubmissionController(ISubmissionService submissionService,
        IAuthenticationService authenticationService,
        IUserService userService,
        IAttachedFileService attachedFileService,
        IActualSalaryService actualSalaryService)
        {
            _submissionService = submissionService;
            _authenticationService = authenticationService;
            _userService = userService;
            _attachedFileService = attachedFileService;
            _actualSalaryService = actualSalaryService;
        }

        [HttpPost("PostSubmission"), Authorize]
        public ActionResult PostSubmission([FromForm] SubmissionDTO dto, IFormFile fileData)
        {
            try
            {
                var userName = _authenticationService.GetUserName();
                var user = _userService.GetUserByUserName(userName);
                _submissionService.CreateSubmission(dto, fileData, user.UserId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error uploading file: {ex.Message}");
            }
        }

        [HttpPut("change-status-submission")] //, Authorize(Roles = "1")
        //[AuthorizeClaim("Change status of submission")]
        public ActionResult ChangeStatusSubmission(int id)
        {
            try
            {
                var submission = _submissionService.GetSubmissionById(id);

                if (submission.Status == true)
                {
                    submission.Status = false;
                }
                else
                {
                    submission.Status = true;
                    if (submission.SubmissionTypeId == 1)
                    {
                        var salaryUser = _actualSalaryService.GetActualSalaryByUserId(submission.UserId);
                        var user = _userService.GetUser(submission.UserId);
                        user.DaysOff += 1;
                        salaryUser.DaysOff += 1;
                        double deductionAmount = salaryUser.ContractSalary * 0.05 * salaryUser.DaysOff;

                        salaryUser.FinalSalary = salaryUser.ContractSalary - deductionAmount;
                        _userService.UpdateUser(user);
                        _submissionService.UpdateSubmission(submission);
                    }
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        [HttpGet("download-file")] //, Authorize
        public IActionResult DownloadFile(int id)
        {
            if (id < 1)
            {
                return BadRequest("Invalid file ID");
            }

            try
            {
                _attachedFileService.DownloadFileById(id);
                return Ok("File download successful!");
            }
            catch (FileNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error downloading file: {ex.Message}");
                return StatusCode(500, "An error occurred while downloading the file.");
            }
        }
    }
}
