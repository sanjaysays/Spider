using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using spiderchanged.Interface;
using spiderchanged.Model;
namespace spiderchanged
{
    public class ValidationService : IValidationService
    {

        
        /// <summary>
        /// Validate the Wall size coordinates
        /// </summary>
        /// <param name="splitGrid"></param>
        /// <returns></returns>
        public bool ValidateWallInput(string[] splitGrid)
        {
            int x;

            if (splitGrid.Length != 2)
            {
                Console.Write("The Grid X,Y cordinates' entry invalid, try again! ");
                return false;
            }

            else
            {
                if (string.IsNullOrEmpty(splitGrid[0]))
                {
                    Console.Write("The Grid X coordinate cannot be null or empty, try again! ");
                    return false;
                }
                else
                {
                    if (!int.TryParse(splitGrid[0], out x))
                    {
                        Console.Write("The Grid X coordinate must be in correct format, try again: ");
                        return false;
                    }
                    else
                    {
                        if (int.Parse(splitGrid[0]) < 0)
                        {
                            Console.Write("The Grid X coordinate must be +ve, try again: ");
                            return false;
                        }
                    }

                }

                if (string.IsNullOrEmpty(splitGrid[1]))
                {
                    Console.Write("The Grid Y coordinate cannot be null or empty, try again! ");
                    return false;
                }
                else
                {

                    if (!int.TryParse(splitGrid[1], out x))
                    {
                        Console.Write("The Grid Y coordinate must be in correct format, try again: ");
                        return false;
                    }
                    else
                    {
                        if (int.Parse(splitGrid[1]) < 0)
                        {
                            Console.Write("The Grid Y coordinate must be +ve, try again: ");
                            return false;
                        }

                    }

                }

            }

            return true;

        }

        /// <summary>
        /// Validate the starting coordinates and direction of Spider
        /// </summary>
        /// <param name="StartPoint"></param>
        /// <returns></returns>
        public bool ValidateSpiderStartInput(string StartPoint)
        {
            int x;
            string[] splitStartPoint = StartPoint.Split(' ');

            if (splitStartPoint.Length != 3)
            {
                Console.Write("Spider X,Y coordinate or Heading' entry invalid, try again! ");
                return false;
            }

            else
            {
                if (string.IsNullOrEmpty(splitStartPoint[0]))
                {
                    Console.Write("The Grid X coordinate cannot be null or empty, try again! ");
                    return false;

                }
                else
                {
                    if (!int.TryParse(splitStartPoint[0], out x))
                    {
                        Console.Write("The Grid X coordinate must be in correct format, try again: ");
                        return false;

                    }
                    else
                    {
                        if (int.Parse(splitStartPoint[0]) < 0)
                        {
                            Console.Write("The Grid X coordinate must be +ve, try again: ");
                            return false;
                        }

                      
                    }

                }

                if (string.IsNullOrEmpty(splitStartPoint[1]))
                {
                    Console.Write("The Grid Y coordinate cannot be null or empty, try again! ");
                    return false;

                }
                else
                {

                    if (!int.TryParse(splitStartPoint[1], out x))
                    {
                        Console.Write("The Grid Y coordinate must be in correct format, try again: ");
                        return false;

                    }
                    else
                    {
                        if (int.Parse(splitStartPoint[1]) < 0)
                        {
                            Console.Write("The Grid Y coordinate must be +ve, try again: ");
                            return false;
                        }

                        
                    }

                }
                if (string.IsNullOrEmpty(splitStartPoint[2]))
                {
                    Console.Write("Spider Direction coordinate cannot be null or empty, try again! ");
                    return false;

                }
                else
                {
                    if(splitStartPoint[2].ToLower()!="left" && splitStartPoint[2].ToLower() != "right")
                    {
                        Console.Write("Spider starting Direction should be Either Left or Right,enter value must be in correct format, try again: ");
                        return false;

                    }
                    

                }

            }


            return true;

        }


    }



}

