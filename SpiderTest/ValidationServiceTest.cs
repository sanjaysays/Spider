using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using spiderchanged;
using spiderchanged.Interface;

namespace SpiderRoboticTest
{
    [TestClass]
    public class ValidationServiceTest
    {
        private IValidationService _validationService;


        [TestInitialize]
        public void SetUp()
        {

            _validationService = new ValidationService();
        }

        [TestMethod]
        public void ValidateWallInputTest()
        {
            // arrange
            string WallSize = "7 15";
            string[] splitGrid = WallSize.Split(' ');

            bool isValid=_validationService.ValidateWallInput(splitGrid);

            Assert.AreEqual(true, isValid);

        }

        [TestMethod]
        public void ValidateWallInvalidInputTest()
        {
            // arrange
            string WallSize = "7";
            string[] splitGrid = WallSize.Split(' ');

            bool isValid = _validationService.ValidateWallInput(splitGrid);

            Assert.AreEqual(false, isValid);

        }

        [TestMethod]
        public void ValidateSpiderStartInputTest()
        {
            // arrange
            string startpoint = "4 10 Left";

            bool isValid = _validationService.ValidateSpiderStartInput(startpoint);

            Assert.AreEqual(true, isValid);

        }

        [TestMethod]
        public void ValidateSpiderStartInvalidInputTest()
        {
            // arrange
            string startpoint = "4 10";

            bool isValid = _validationService.ValidateSpiderStartInput(startpoint);

            Assert.AreEqual(false, isValid);

        }
    }
}
