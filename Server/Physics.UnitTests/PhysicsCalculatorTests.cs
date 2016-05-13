using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Physics.Api.Application.PhysicsCalculator;

namespace Physics.UnitTests
{
    [TestClass]
    public class PhysicsCalculatorTests
    {
        ObjectOptions _objectOptions = new ObjectOptionsFactory().Aluminium().Build();
        [TestMethod]
        public void ShouldCalculateDensityValue2720()
        {

            var calculator = GetCalculator();

            var actualDensity = calculator.CalculateDensity(weight: _objectOptions.Weight, volume: _objectOptions.Volume);
            var aluminiumDensity = _objectOptions.Density;
            Assert.AreEqual(aluminiumDensity, actualDensity);

        }
        [TestMethod]
        public void ShouldCalculateVolumeValue000002()
        {
            var calculator = GetCalculator();
            var actualVolume = calculator.CalculateVolume(density: _objectOptions.Density, weight: _objectOptions.Weight);
            var aluminiumVolume = _objectOptions.Volume;
            Assert.AreEqual(aluminiumVolume, actualVolume);
        }

        [TestMethod]
        public void ShouldCalculateWeightValue00544()
        {
            var calculator = GetCalculator();
            var actualWeight = calculator.CalculateWeight(density: _objectOptions.Density, volume: _objectOptions.Volume);
            var aluminiumWeight = _objectOptions.Weight;
            Assert.AreEqual(aluminiumWeight, actualWeight);
        }

        PhysicsCalculator GetCalculator()
        {
            return new PhysicsCalculator();
        }


    }
}
