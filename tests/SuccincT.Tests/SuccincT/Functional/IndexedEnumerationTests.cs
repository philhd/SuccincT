﻿using NUnit.Framework;
using SuccincT.Functional;
using System.Collections.Generic;
using System.Linq;
using static NUnit.Framework.Assert;

namespace SuccincTTests.SuccincT.Functional
{
    [TestFixture]
    public class IndexedEnumerationTests
    {
        [Test]
        public void ForEmptyEnumeration_EmptyIndexEnumerationReturned()
        {
            var emptyList = new List<string>();
            var indexedList = emptyList.Indexed().ToList();
            AreEqual(0, indexedList.Count);
        }

        [Test]
        public void ForList_IndexedEnumerationReturned()
        {
            var list = new List<int> { 1, 2, 3 };
            var indexedList = list.Indexed();
            foreach (var (index, item) in indexedList)
            {
                AreEqual(index + 1, item);
            }
        }

        [Test]
        public void ForEnumeration_IndexedEnumerationReturned()
        {
            var indexedEnumeration = StringEnumeration().Indexed();
            foreach (var (index, item) in indexedEnumeration)
            {
                AreEqual($"{index}", item);
            }
        }

        private static IEnumerable<string> StringEnumeration()
        {
            yield return "0";
            yield return "1";
            yield return "2";
        }
    }
}
