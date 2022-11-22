using Microsoft.VisualStudio.TestTools.UnitTesting;
using Свой_тип;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Свой_тип.Tests
{
    [TestClass()]
    public class LengthTests
    {
         [TestMethod()]
        public void VerboseTest()
        {

            var length = new Length(38, MeasureType.C);
            Assert.AreEqual("38 C", length.Verbose());

            length = new Length(38, MeasureType.F);
            Assert.AreEqual("38 F", length.Verbose());

            length = new Length(38, MeasureType.Ra);
            Assert.AreEqual("38 Ra", length.Verbose());

            length = new Length(38, MeasureType.K);
            Assert.AreEqual("38 K", length.Verbose());
        }
        [TestMethod()]
        public void AddNumberTest()
        {
            var length = new Length(1, MeasureType.C);
            length = length + 4.25;
            Assert.AreEqual("5,25 C", length.Verbose());
        }
        [TestMethod()]
        public void SubNumberTest()
        {
            var length = new Length(3, MeasureType.F);
            length = length - 1.75;
            Assert.AreEqual("1.25 F", length.Verbose());
        }

        [TestMethod()]
        public void MulByNumberTest()
        {
            var length = new Length(3, MeasureType.Ra);
            length = length * 3;
            Assert.AreEqual("9 Ra", length.Verbose());
        }

        [TestMethod()]
        public void DivByNumberTest()
        {
            var length = new Length(3, MeasureType.K);
            length = length / 3;
            Assert.AreEqual("1 K", length.Verbose());
        }
    }
}