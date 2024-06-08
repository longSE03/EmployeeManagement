using EmployeeManagement.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleClaimController : ControllerBase
    {
        private readonly IRoleClaimService _roleClaimService;

        public RoleClaimController(IRoleClaimService roleClaimService)
        {
            _roleClaimService = roleClaimService;
        }

        [HttpPost("add-claim/{roleId}/{claimId}")]
        //[Authorize]
        //[AuthorizeClaim("Add claim for role")]
        public IActionResult AddClaimToRole(int roleId, int claimId)
        {
            try
            {
                _roleClaimService.AddClaimToRole(roleId, claimId);
                return Ok("Claim added to role successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Return specific error message from service
            }
        }

        [HttpDelete("remove-claims/{roleId}")]
        //[Authorize]
        //[AuthorizeClaim("Remove claim from role")]
        public IActionResult RemoveClaimFromRole(int roleId, int claimId)
        {
            try
            {
                _roleClaimService.RemoveClaimFromRole(roleId, claimId);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Return specific error message from service
            }
        }
    }
}
