namespace PVA_project.Data.Classes;
public class PurchaseOrder
{
    public int Id { get; set; }
    public string PoNumber { get; set; }
    public string CustomerName { get; set; }
    public string CustomerLastName { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsPaid { get; set; }
    public string CustomerEmail { get; set; }
}

