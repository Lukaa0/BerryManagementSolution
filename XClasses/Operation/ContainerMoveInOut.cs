using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XClassess.Operation
{
    public class ContainerMoveInOut
    {
        public string ContainerMoveInOut_Id { set; get; }
        public bool Direction { get; set; }
        public string ContainerBarCode { get; set; }
        public string PointBarCode { get; set; }
        public System.DateTime Time { get; set; }
        public long PersonPostId { get; set; }
        public long Point_Id { get; set; }
        public bool IsComplete { get; set; }

    }
}
