using System;

namespace BerryManagementWindowsService.Data.Operation.XClasses
{
    public class SaleContainer
    {
        public Guid Id { get; set; }
        public string Error { get; set; }
        public bool Direction { get; set; }
        public string ContainerBarCode { get; set; }
        public DateTime Time { get; set; }
        public long PersonPostId { get; set; }
        public long Company_Id { get; set; }
        public Guid Identifier { get; set; }
        public bool IsComplete { get; set; }
        public string CompanyName { get; set; }
        public string SaleUserFullName { get; set; }
    }
}
