﻿using NUnit.Framework;
using SuccincT.PatternMatchers;

namespace SuccincTTests.PatternMatchers
{
    [TestFixture]
    public class ValueMatchTests
    {
        [Test]
        public void IntValue_CanBeMatched()
        {
            var result = 1.Match().To<bool>().With(1).Do(x => true).Result();
            Assert.IsTrue(result);
        }

        [Test]
        public void IntValue_CanBeMatchedViaOrWithExec()
        {
            var result = 1.Match().To<bool>().With(2).Or(1).Do(x => true).Result();
            Assert.IsTrue(result);
        }

        [Test, ExpectedException(ExpectedException = typeof(NoMatchException))]
        public void IntValue_ExceptionIfNoMatchWithExec()
        {
            3.Match().To<int>().With(2).Or(1).Do(x => x).Result();
        }

        [Test]
        public void IntValue_WhenNoMatchElseUsedWithExec()
        {
            var result = 1.Match().To<bool>().With(2).Do(x => true).Else(x => false).Result();
            Assert.IsFalse(result);
        }

        [Test]
        public void IntValue_CanBeMatchedViaWhereWithExec()
        {
            var result = 1.Match().To<bool>().Where(x => x == 1).Do(x => true)
                                             .Else(x => false).Result();
            Assert.IsTrue(result);
        }

        [Test]
        public void IntValue_WhenNoMatchViaWhereElseUsedWithExec()
        {
            var result = 1.Match().To<bool>().Where(x => x == 2).Do(x => true)
                                             .Else(x => false).Result();
            Assert.IsFalse(result);
        }

        [Test]
        public void IntValue_WithAndWhereDefinedWhereCorrectlyUsedWithExec()
        {
            var result = 5.Match().To<bool>().With(1).Or(2).Do(x => false)
                                            .Where(x => x == 5).Do(x => true).Result();
            Assert.IsTrue(result);
        }

        [Test]
        public void IntValue_WithAndWhereDefinedWithCorrectlyUsedWithExec()
        {
            var result = 2.Match().To<bool>().With(1).Or(2).Do(x => false)
                                             .Where(x => x == 5).Do(x => true).Result();
            Assert.IsFalse(result);
        }
    }
}