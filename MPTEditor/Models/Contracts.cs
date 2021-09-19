using System.ComponentModel.DataAnnotations;
namespace MPTEditor.Models
{
    public class Contracts
    {
        [Key]
        public int Id_Contract { get; set; }
        public int Listener_Id { get; set; }
        public string Code_contract { get; set;}
    }
}
