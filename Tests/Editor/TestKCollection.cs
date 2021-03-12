using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using kroon.Utils.Collections;

namespace kroon.Utils.Tests
{
    [TestFixture]
    public class TestKCollection
    {
        [Test]
        public void TestMinAndMax()
        {
            List<int> testList = new List<int> {
                10,
                9,
                8,
                7,
                6,
                5,
                4,
                3,
                2,
                1,
                -1,
                -2
            }.ShuffleNonAlloc();

            Assert.AreEqual(-2, testList.Min(i => (float)i));
            Assert.AreEqual(10, testList.Max(i => (float)i));
        }
    }
}
