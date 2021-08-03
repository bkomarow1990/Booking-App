using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Department
    {
        public Department()
        {
            this.Rents = new HashSet<Rent>();
        }
        public int Id { get; set; }
        public float Area { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Rent> Rents { get; set; }
    }
}
