using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task1.Tests
{
    [TestFixture]
    public class CustomerTests
    {
        [TestCase("nnRRcc","en-US" , ExpectedResult = "Customer record: Jeffrey Richter, 1000000, +1(425) 555 - 0100")]
        [TestCase("nnRR","en-GB", ExpectedResult = "Customer record: Jeffrey Richter, £1,000,000.00")]
        [TestCase("RR","fr-FR", ExpectedResult = "Customer record: 1 000 000,00 €")]
        public string Customer_ToStringRepresentation(string format,string culture)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            return string.Format(new BestFormatProvider(),"{0:" + format +"}", new Customer("Jeffrey Richter", "+1(425) 555 - 0100",1000000));
        }
  
        [TestCase("{0:nncc}", ExpectedResult = "Customer record: Jeffrey Richter, +1(425) 555 - 0100")]
        [TestCase("{0:ccRR}", ExpectedResult = "Customer record: +1(425) 555 - 0100, 1 000 000,00 ₽")]
        public string CustomerFormatterTests(string format)
        {
            return new Customer("Jeffrey Richter", "+1(425) 555 - 0100", 1000000).ToString(format);
        }

        public void Customer_TestForFormatException()
        {
            Assert.Throws(typeof(FormatException),
                () => new Customer("Jeffrey Richter", "+1(425) 555 - 0100", 1000000).ToString("MyFormat", null));
        }

    }
}

