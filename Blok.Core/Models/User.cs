using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok.Core.Models
{
    public class User :CRUD
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }

    }
}
