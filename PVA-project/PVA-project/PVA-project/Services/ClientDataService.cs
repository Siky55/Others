using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PVA_project.Controllers;
using PVA_project.Data;
using PVA_project.Data.Classes;
using PVA_project.Data.DataToObject;
using PVA_project.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace PVA_project.Services
{

    public class ClientDataService : MasterService, IClientDataService
    {
        public ClientDataService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public List<ClientDataExport> GetClientData() {

            List<ClientDataExport> clientDataExports = new List<ClientDataExport>();

            var headers = _context.PurchaseOrder.ToList();
            foreach (var header in headers) {

                double totalPrice = 0;
                var purchaseOrder = _context.PurchaseOrderItems.SingleOrDefault(x => x.PurchaserOrderId == header.Id);
                if (purchaseOrder != null)
                {
                    totalPrice = purchaseOrder.Amount * purchaseOrder.PricePerUnit;
                }

                clientDataExports.Add(new ClientDataExport(header, totalPrice));
            }

            return clientDataExports;
        }

        public ClientDataResponse AddClientData(List<ClientDataDto> clientDataDto) {

            ClientDataResponse responseDto = new ClientDataResponse();

            foreach (var dataRow in clientDataDto)
            {

                if (_context.PurchaseOrder.Any(x => x.PoNumber == dataRow.poid))
                {
                    responseDto.Failed++;
                    responseDto.Message = "Duplicate POIDs!";
                    continue;
                }

                var purchaseOrder = new PurchaseOrder()
                {
                    PoNumber = dataRow.poid,
                    CustomerName = dataRow.first_name,
                    CustomerLastName = dataRow.last_name,
                    CreatedOn = DateTime.ParseExact(dataRow.createdon, "M/dd/yyyy", CultureInfo.InvariantCulture),
                    CustomerEmail = dataRow.email
                };

                _context.PurchaseOrder.Add(purchaseOrder);
                _context.SaveChanges();

                var purchaseOrderItems = new PurchaseOrderItems()
                {
                    PurchaserOrderId = purchaseOrder.Id,
                    ShopItemTitle = dataRow.item,
                    Amount = dataRow.amount,
                    PricePerUnit = dataRow.price
                };

                responseDto.Success++;

                _context.PurchaseOrderItems.Add(purchaseOrderItems);
                _context.SaveChanges();
            }

            return responseDto;
        }
    }
}
