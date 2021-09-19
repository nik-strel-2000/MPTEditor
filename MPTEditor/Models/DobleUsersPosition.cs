    using System.ComponentModel.DataAnnotations;

namespace MPTEditor.Models
{
    public class DobleUsersPosition
    {
        [Key]
        public int Id_User { get; set; }
        public string Email { get; set; }
        public string Name_position { get; set; }
        public DobleUsersPosition(){}
    }
}
