using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Domain.DTO
{
    public class CreateStore
    {

        public string UserId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Logo { get; set; }
    }
}
