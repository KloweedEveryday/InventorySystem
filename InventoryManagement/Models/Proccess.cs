using Beverages_Softdrinks_InventorySystem.Models;

namespace InventoryManagement.Models
{
    public class Proccess
    {
        private static List<string> _proccessList = new List<string>();

        public List<string> ProccessList { get => _proccessList; set => _proccessList = value; }
        public IList<Personel_Details> Personel_Details { get; set; } = default!;
    }

}
