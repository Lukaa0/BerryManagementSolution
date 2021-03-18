using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Classes
{
    public class HarvesterRowViewModel
    {
        public string Id { get; set; }
        public string HarvesterBarCode { get; set; }

        public string RowBarCode { get; set; }

        public long PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime Date{ get; set; }


    }
}
