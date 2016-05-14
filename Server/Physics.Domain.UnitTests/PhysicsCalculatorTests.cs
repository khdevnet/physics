using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Physics.Domain.UnitTests
{
    [TestClass]
    public class PhysicsCalculatorTests
    {
        [TestMethod]
        public void CalculateDensity_CalculateWithValidAluminiumOptions_ResultValue2720()
        {
            var calculator = GetCalculator();
            var aluminiumObject = new ObjectsFactory().AluminiumObject().Build();
            var actualDensity = calculator.CalculateDensity(weight: aluminiumObject.Weight, volume: aluminiumObject.Volume);
            Assert.AreEqual(aluminiumObject.Density, actualDensity);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "weight should be greater then 0")]
        public void CalculateDensity_CalculateWithInValidAluminiumWeightOptions_ThrowArgumentException()
        {
            var calculator = GetCalculator();
            var aluminiumObject = new ObjectsFactory().AluminiumObject().WithInvalidWeight().Build();
            var actualDensity = calculator.CalculateDensity(weight: aluminiumObject.Weight, volume: aluminiumObject.Volume);
            Assert.AreEqual(aluminiumObject.Density, actualDensity);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "volume should be greater then 0")]
        public void CalculateDensity_CalculateWithInValidAluminiumVolumeOptions_ThrowArgumentException()
        {
            var calculator = GetCalculator();
            var aluminiumObject = new ObjectsFactory().AluminiumObject().WithInvalidVolume().Build();
            var actualDensity = calculator.CalculateDensity(weight: aluminiumObject.Weight, volume: aluminiumObject.Volume);
            Assert.AreEqual(aluminiumObject.Density, actualDensity);

        }

        [TestMethod]
        public void CalculateVolume_CalculateWithValidAluminiumOptions_ResultValue000002()
        {
            var calculator = GetCalculator();
            var aluminiumObject = new ObjectsFactory().AluminiumObject().Build();
            var actualVolume = calculator.CalculateVolume(density: aluminiumObject.Density, weight: aluminiumObject.Weight);
            Assert.AreEqual(aluminiumObject.Volume, actualVolume);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "density should be greater then 0")]
        public void CalculateVolume_CalculateWithInvalidAluminiumDensityOption_ThrowArgumentException()
        {
            var calculator = GetCalculator();
            var aluminiumObject = new ObjectsFactory().AluminiumObject().WithInvalidDensity().Build();
            var actualVolume = calculator.CalculateVolume(density: aluminiumObject.Density, weight: aluminiumObject.Weight);
            Assert.AreEqual(aluminiumObject.Volume, actualVolume);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "weight should be greater then 0")]
        public void CalculateVolume_CalculateWithInvalidAluminiumWeightOption_ThrowArgumentException()
        {
            var calculator = GetCalculator();
            var aluminiumObject = new ObjectsFactory().AluminiumObject().WithInvalidWeight().Build();
            var actualVolume = calculator.CalculateVolume(density: aluminiumObject.Density, weight: aluminiumObject.Weight);
            Assert.AreEqual(aluminiumObject.Volume, actualVolume);
        }

        [TestMethod]
        public void CalculateWeight_CalculateWithValidAluminiumOptions_ResultValueIs00544()
        {
            var calculator = GetCalculator();
            var aluminiumObject = new ObjectsFactory().AluminiumObject().Build();
            var actualWeight = calculator.CalculateWeight(density: aluminiumObject.Density, volume: aluminiumObject.Volume);
            Assert.AreEqual(aluminiumObject.Weight, actualWeight);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "density should be greater then 0")]
        public void CalculateWeight_CalculateWithInvalidAluminiumDensityOption_ThrowArgumentException()
        {
            var calculator = GetCalculator();
            var aluminiumObject = new ObjectsFactory().AluminiumObject().WithInvalidDensity().Build();
            var actualWeight = calculator.CalculateWeight(density: aluminiumObject.Density, volume: aluminiumObject.Volume);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "volume should be greater then 0")]
        public void CalculateWeight_CalculateWithInvalidAluminiumVolumeOption_ThrowArgumentException()
        {
            var calculator = GetCalculator();
            var aluminiumObject = new ObjectsFactory().AluminiumObject().WithInvalidVolume().Build();
            var actualWeight = calculator.CalculateWeight(density: aluminiumObject.Density, volume: aluminiumObject.Volume);
        }

        PhysicsCalculator GetCalculator()
        {
            return new PhysicsCalculator();
        }
    }
}
