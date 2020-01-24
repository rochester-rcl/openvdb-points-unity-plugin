using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor.Experimental.AssetImporters;
using System.Linq;
using System;

// TODO make an abstract base class that this inherits from
namespace OpenVDBPointsUnity
{
    [ScriptedImporter(1, "vdb")]
    public class VDBImporter : BaseVDBImporter
    {

        public override void OnImportAsset(AssetImportContext ctx)
        {
            GetAbsoluteAssetPath(ctx);
            OpenVDBPoints points = new OpenVDBPoints(absoluteAssetPath);
            points.Load();
            uint count = points.Count;
            Debug.Log(string.Format("Total Points: {0}", count.ToString()));
        }
    }
}
