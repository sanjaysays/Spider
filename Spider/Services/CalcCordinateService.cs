using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using spiderchanged.Interface;
using spiderchanged.Model;
namespace spiderchanged
{
     public class CalcCordinateService : ICalcCordinateService
    {
        public GridModel _gridmodel=new GridModel ();
        public string direction;
        public char orientation;
        public int currentx, currenty;

        [Inject]
        private readonly IValidationService _validationService;

        public CalcCordinateService(IValidationService validationService)
        {
          //  _gridmodel = new GridModel();
            this._validationService = validationService;

        }

        /// <summary>
        /// This method is used to Validate input request and set the model
        /// </summary>
        /// <returns></returns>
        public bool SetandValidateInputDetails()
        {
          

            // 1. Define Grid/wall Size

            Console.WriteLine("Please Enter Grid size seprated by space e.g (7 15)");
            string WallSize = Console.ReadLine();
            string[] splitGrid = WallSize.Split(' ');

            if (_validationService.ValidateWallInput(splitGrid))
            {
                _gridmodel.gridXCordinate = int.Parse(splitGrid[0]);
                _gridmodel.gridYCordinate = int.Parse(splitGrid[1]);

                // 2. Entry for Spider Satrting Location and direction

                Console.WriteLine("Please Enter the Spider's Start Location & Direction seprated by space e.g (4 10 Left/Right)");

                string StartPoint = Console.ReadLine();

                if (_validationService.ValidateSpiderStartInput(StartPoint))
                {
                    string[] splitStartPoint = StartPoint.Split(' ');
                    _gridmodel.spiderStartPositionX = int.Parse(splitStartPoint[0]);
                    _gridmodel.spiderStartPositionY = int.Parse(splitStartPoint[1]);
                    _gridmodel.spiderStartDirection = (splitStartPoint[2]).ToString();

                    Console.WriteLine("Please Enter the Orientation Command in follwing format e.g (FLRFLR)");
                    string instructions = Console.ReadLine();
                    _gridmodel.Instruction = new char[instructions.Length];
                    for (int i = 0; i < instructions.Length; i++)
                    {
                        char ch = Convert.ToChar(instructions[i]);
                        if (!char.IsWhiteSpace(ch) && (ch.Equals('F') || ch.Equals('L') || ch.Equals('R')))
                        {
                            _gridmodel.Instruction[i] = instructions[i];

                        }
                        else
                        {
                            Console.WriteLine("Invalid Character '{0}' ", ch);
                            return false;
                        }
                    }

                }
                else
                {
                    return false;
                }


            }
            else
            {
                return false;
            }

            return true;

        }

        /// <summary>
        /// This method is used to move the spider and change (x,y) cordinates as per Instruction given
        /// </summary>
        public void MoveSpiderAtInstruction()
        {
            this.currentx = _gridmodel.spiderStartPositionX;
            this.currenty = _gridmodel.spiderStartPositionY;
            this.direction = _gridmodel.spiderStartDirection;

            try
            {
                foreach (char value in _gridmodel.Instruction)
                {

                    ProcessInstruction(value);

                    if (currentx > _gridmodel.gridXCordinate || currenty > _gridmodel.gridYCordinate)
                    {
                        throw new ArgumentOutOfRangeException("Orientation Commands leads to out of range grid area !");

                    }

                }
            }

            catch (ArgumentOutOfRangeException outOfRange)
            {

                Console.WriteLine("Error: {0}", outOfRange.Message);
            }


            Console.WriteLine("Current Coordinates are :" + currentx + " " + currenty + " " + direction);

        }

        private void ProcessInstruction(char _o)
        {

            this.orientation = _o;
            string switchExpression = direction + "->" + orientation;
            switch (switchExpression)
            {
                // A switch section contains case lables for changing spider postion and headings direction by giving orientation command.
                case "Left->F":

                    this.direction = "Left";
                    this.currentx = currentx - 1;

                    break;


                case "Left->L":
                    this.direction = "Down";

                    break;

                case "Left->R":
                    this.direction = "Up";
                    break;

                case "Right->F":
                    this.direction = "Right";
                    this.currentx = currentx + 1;

                    break;

                case "Right->L":
                    this.direction = "Up";
                    break;

                case "Right->R":
                    this.direction = "Down";
                    break;


                case "Down->F":

                    this.direction = "Down";
                    this.currenty = currenty - 1;

                    break;


                case "Down->L":
                    this.direction = "Right";

                    break;

                case "Down->R":
                    this.direction = "Left";
                    break;


                case "Up->F":

                    this.direction = "Up";
                    this.currenty = currenty + 1;

                    break;


                case "Up->L":
                    this.direction = "Left";

                    break;

                case "Up->R":
                    this.direction = "Right";
                    break;

                default:
                    Console.WriteLine("Wrong Direction/Orientation given!");
                    break;
            }
        }



    }
}
