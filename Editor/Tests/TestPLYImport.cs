using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using System.IO;
namespace Tests
{
    public class TestPLYImport
    {
        private const string assetPath = "Assets/OpenVDBPoints/Editor/Tests/TestAssets/sphere.ply";
        private const string outPath = "Assets/sphere.vdb";
        // A Test behaves as an ordinary method
        [Test]
        public void TestPLYImportFile()
        {
            try
            {
                AssetDatabase.ImportAsset(assetPath);
                Assert.True(File.Exists(outPath));
            }
            catch (System.Exception e)
            {
                Debug.Log(e.Message);
                Assert.Fail();
            }
        }

        public void TearDown()
        {
            File.Delete(outPath);
        }

    }
}
