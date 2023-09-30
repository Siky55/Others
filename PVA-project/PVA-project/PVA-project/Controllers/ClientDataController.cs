using Microsoft.AspNetCore.Mvc;
using PVA_project.Data.DataToObject;
using PVA_project.Data.Classes;
using PVA_project.Services;
using PVA_project.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PVA_project.Controllers
{


    [ApiController]
    [Route("Data")]
    public class ClientDataController : Controller
    {

        IClientDataService _clientDataService;
        public ClientDataController(IClientDataService clientDataService)
        {
            _clientDataService = clientDataService;
        }

        
        [HttpPost]
        [Route("Add")]
        public IActionResult PostData(List<ClientDataDto> ClientDataDto)
        {
            return Ok(_clientDataService.AddClientData(ClientDataDto));
        }

        
        [HttpGet]
        [Route("Get")]
        public IActionResult GetData()
        {
            return Ok(_clientDataService.GetClientData());
        }
    }
}
