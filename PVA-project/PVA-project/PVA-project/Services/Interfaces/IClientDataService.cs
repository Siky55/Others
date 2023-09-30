using Microsoft.EntityFrameworkCore;
using PVA_project.Controllers;
using PVA_project.Data.Classes;
using PVA_project.Data.DataToObject;

namespace PVA_project.Services.Interfaces
{
    public interface IClientDataService
    {
        ClientDataResponse AddClientData(List<ClientDataDto> clientDataDto);

        List<ClientDataExport> GetClientData();

    }
}
