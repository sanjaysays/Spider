
using spiderchanged.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spiderchanged.Interface
{
    public interface ICalcCordinateService
    {
        bool SetandValidateInputDetails();
        void MoveSpiderAtInstruction();

    }
}
