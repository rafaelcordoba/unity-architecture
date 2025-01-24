using NUnit.Framework;
using UnityEngine;

namespace MyGame.Editor
{
    public class DummyTest
    {
        [Test]
        public void DummyTest_Only_To_Generate_Csproj_Files()
        {
            Debug.Log("DummyTest_Only_To_Generate_Csproj_Files");
            Assert.Pass();
        }
    }
}