using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace funcprog
{
    public class DateNotPastValidatorTest
    {
        static DateTime presentDate = DateTime.UtcNow;

        [TestCase(+1, ExpectedResult = true)]
        [TestCase(0, ExpectedResult = true)]
        [TestCase(-1, ExpectedResult = false)]
        public bool WhenTransferDateIsPast_ThenValidatorFails(int offset)
        {
            var validator = new DateNotPastValidator(presentDate);
            var cmd = new MakeTransfer { Date = presentDate.AddDays(offset) };
            return validator.IsValid(cmd);
        }
    }

    public class BicExistsValidatorTest {
        static string[] validCodes = { "ABCDEF" }; 

        [TestCase("ABCDEF", ExpectedResult = true)]
        [TestCase("XXXXXX", ExpectedResult = false)]
        public bool WhenBicNotFoundInTheList_ValidationFails(string bic)
            => new BicExistsValidator(() => validCodes)
                .IsValid(new MakeTransfer { Bic = bic });
    }

    class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

    }


}
