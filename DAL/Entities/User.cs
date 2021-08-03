using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User
    {
        public User()
        {
            this.Rents = new HashSet<Rent>();
        }
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Rent> Rents { get; set; }

        public static explicit operator string(User v)
        {
            throw new NotImplementedException();
        }
    }
}
