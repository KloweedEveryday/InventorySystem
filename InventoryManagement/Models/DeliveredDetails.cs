using System.ComponentModel.DataAnnotations.Schema;

namespace Beverages_Softdrinks_InventorySystem.Models
{
    public class DeliveredDetails
    {
        public int ID { get; set; }
        public string Brand { get; set; }
        public string Manufacturer { get; set; }
        public int Cases { get; set; }
        public int Quantity_Per_Case { get; set; }
        public string Personel { get; set; }
        public DateTime DateDelivered { get; set; }
    }
}
