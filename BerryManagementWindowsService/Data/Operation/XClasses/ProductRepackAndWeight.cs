using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Operation.XClasses
{
    public class ProductRepackAndWeight
    {
        public System.Guid Id { get; set; }
        public System.Guid? ProductId { get; set; }
        public string ContainerBarCode { get; set; }
        public string OldContainerBarCode { get; set; }
        public long UserPersonPostId { get; set; }
        public string BreedName { set; get; }
        public System.DateTime? HarvestDate { get; set; }
        public System.DateTime Time { get; set; }
        public decimal? Net { get; set; }
        public decimal Gross { get; set; }
        public bool IsComplite { get; set; }
    }
}
