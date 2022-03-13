using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spiderchanged.Interface
{
    public interface IValidationService
    {
        bool ValidateWallInput(string[] splitGrid);

        bool ValidateSpiderStartInput(string StartPoint);

    }
}
