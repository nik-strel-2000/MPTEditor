using System.ComponentModel.DataAnnotations;

namespace MPTEditor.Models
{
    public class Position
    {
        [Key]
        public int ID_Position { get; set; }
        public string Name_position { get; set; }
       
    }
}
