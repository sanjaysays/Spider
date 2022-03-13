using Ninject;
using spiderchanged.Configuration;
using spiderchanged.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spiderchanged
{
     class Program
    {
        [Inject]
        public static ICalcCordinateService Move { get; set; }

        static void Main(string[] args)
        {
            IKernel kernal = new StandardKernel(new NinjectConfiguration());

            Move = kernal.Get<CalcCordinateService>();

            bool isValid = Move.SetandValidateInputDetails();

            if (isValid)
            {
                Move.MoveSpiderAtInstruction();
            }
            Console.ReadKey();

        }

    }
}
