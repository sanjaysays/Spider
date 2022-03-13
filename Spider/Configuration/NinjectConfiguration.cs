using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using spiderchanged.Interface;

namespace spiderchanged.Configuration
{
    class NinjectConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<IValidationService>().To<ValidationService>();
            Bind<ICalcCordinateService>().To<CalcCordinateService>();
        }
    }
}
