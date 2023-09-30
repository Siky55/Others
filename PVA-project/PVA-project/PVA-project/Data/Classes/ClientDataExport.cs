namespace PVA_project.Data.Classes
{
    public class ClientDataExport
    {

        public PurchaseOrder PurchaseOrder { get; set; }
        public double TotalPrice { get; set; } = 0;

        public ClientDataExport(PurchaseOrder _purchaseOrderHeaders, double _totalPrice)
        {
            this.PurchaseOrder = _purchaseOrderHeaders;
            this.TotalPrice = _totalPrice;
        }
    }
}
