using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleETLJob.Operations;
using Rhino.Etl.Core;
using SampleETLJob.DataObjects;

namespace Test
{
    [TestClass]
    public class YieldReturnTest : BaseTestClass
    {
        private class NumberGenerator
        {
            public int NumbersGenerated { get; set; }

            public IEnumerable<int> GenerateNumbers()
            {
                for (int i = 1; i < int.MaxValue; i++)
                {
                    Console.WriteLine("NumberGenerator generated a number");
                    NumbersGenerated++;
                    yield return i;
                }
            }
        }

        [TestMethod]
        public void UnenumeratedDoesNoWork()
        {
            var generator = new NumberGenerator();

            generator.GenerateNumbers();

            Assert.AreEqual(0, generator.NumbersGenerated);
        }

        [TestMethod]
        public void GenerateFiveNumbers()
        {
            var generator = new NumberGenerator();
            
            foreach (int number in generator.GenerateNumbers())
            {
                Console.WriteLine(number);

                if (number == 5) break;
            }

            Assert.AreEqual(5, generator.NumbersGenerated);
        }

        private class ChainedNumberGenerator
        {
            public int NumbersGenerated { get; set; }

            public IEnumerable<int> GenerateNumbers(IEnumerable<int> inNumbers)
            {
                foreach(int i in inNumbers)
                {
                    Console.WriteLine("ChainedNumberGenerator generated a number");
                    NumbersGenerated++;
                    yield return i;
                }
            }
        }

        [TestMethod]
        public void ChainedNumberGeneratorsAreDependentOnEachOther()
        {
            var firstGenerator = new NumberGenerator();
            var lastGenerator = new ChainedNumberGenerator();

            foreach (int number in lastGenerator.GenerateNumbers(firstGenerator.GenerateNumbers()))
            {
                Console.WriteLine(number);

                if (number == 5) break;
            }

            Assert.AreEqual(5, lastGenerator.NumbersGenerated);
            Assert.AreEqual(5, firstGenerator.NumbersGenerated);
        }


    }
}
