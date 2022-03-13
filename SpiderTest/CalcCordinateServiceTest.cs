using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using spiderchanged;
using spiderchanged.Interface;

namespace SpiderRoboticTest
{
    [TestClass]
    public class CalcCordinateServiceTest
    {
        private CalcCordinateService _calcService;

        private IValidationService _validationService;


        [TestInitialize]
        public void SetUp()
        {
            _validationService = new ValidationService();

            _calcService = new CalcCordinateService(_validationService);

            
        }

        [TestMethod]
        public void MoveSpiderAtInstructionTest()
        {
            _calcService._gridmodel.gridXCordinate = 7;
            _calcService._gridmodel.gridYCordinate = 15;
            _calcService._gridmodel.spiderStartPositionX = 4;
            _calcService._gridmodel.spiderStartPositionY = 10;
            _calcService._gridmodel.spiderStartDirection = "Left";
            _calcService._gridmodel.Instruction = "FLFLFRFFLF".ToCharArray();

            _calcService.MoveSpiderAtInstruction();

            Assert.AreEqual(5, _calcService.currentx);
            Assert.AreEqual(7, _calcService.currenty);
            Assert.AreEqual("Right", _calcService.direction);

        }

    }
}
