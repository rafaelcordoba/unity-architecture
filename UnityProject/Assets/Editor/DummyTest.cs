using NUnit.Framework;
using UnityEngine;

namespace Editor
{
    public class DummyTest
    {
        [Test]
        public void DummyTesty()
        {
            Debug.Log("Just a dummy test for CI");
            Assert.IsTrue(true);
        }
    }
}
