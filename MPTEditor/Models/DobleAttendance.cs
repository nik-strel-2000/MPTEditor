using System.Collections.Generic;
namespace MPTEditor.Models
{
    public class DobleAttendance
    {
        public int Id_Record { get; set; }
        public int Contract_id { get; set; }
        public string Code_contract { get; set; }
        public string FIO { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }

        public List<int> dates;
        public DobleAttendance() {}
    }
}
