using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XClassess.Operation
{
    public class TakeRowInOut
    {
        public Guid Id { get; set; }
        public long? BrigadeId { get; set; }
        public DateTime Time { get; set; }
        public bool Direction { get; set; }
        public bool IsComplete { get; set; }
        public string RowBarCode { get; set; }
        public long PersonPostId { get; set; }
    }
}
