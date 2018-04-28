using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task_3_b.General_Model
{
    public abstract class FixedObject
    {
        protected FixedObject(Point position)
        {
            this.Position = position;
        }

        public Point Position { get; set; }
    }
}
