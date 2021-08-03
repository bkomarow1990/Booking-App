using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Rent
    {
        public int Id { get; set; }
        public bool IsAviable { get; set; }
        public string HouseName { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
        public virtual User users { get; set; }
        public virtual Department departments { get; set; }
    }
}
