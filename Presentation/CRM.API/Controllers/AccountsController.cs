using CRM.Application.DTOs.AccountDTOs;
using CRM.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController(IAccountService service) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDTO>>> GetAll()
        {
            var accounts = await service.GetAllAsync();
            if (accounts is null)
                return new List<AccountDTO>();
            return Ok(accounts);
        }






    }
}
