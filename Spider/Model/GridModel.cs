using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spiderchanged.Model
{
    public class GridModel
    {
        public int gridXCordinate { get; set; }
        public int gridYCordinate { get; set; }

        public int spiderStartPositionX { get; set; }

        public int spiderStartPositionY { get; set; }

        public string spiderStartDirection { get; set; }

        public char[] Instruction { get; set; }


    }
}
