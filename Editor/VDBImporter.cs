using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEditor.Experimental.AssetImporters;
using System.Linq;
using System;

// TODO make an abstract base class that this inherits from
namespace OpenVDBPointsUnity
{
    [ScriptedImporter(1, "vdb")]
    public class VDBImporter : BaseVDBImporter
    {
        [DllImport("openvdb-points-unity", CallingConvention = CallingConvention.Cdecl)]
        private static extern System.IntPtr readPointGridFromFile(string filename, string gridName, LoggingCallback cb);
        [DllImport("openvdb-points-unity", CallingConvention = CallingConvention.Cdecl)]
        private static extern uint getPointCountFromGrid(IntPtr gridRef);
        [DllImport("openvdb-points-unity")]
        private static extern void destroySharedPointDataGridReference(IntPtr gridRef);
        public override void OnImportAsset(AssetImportContext ctx)
        {
            openvdbInitialize();
            GetAbsoluteAssetPath(ctx);
            IntPtr gridRef = readPointGridFromFile(absoluteAssetPath, "Points", LogMessage);
            uint count = getPointCountFromGrid(gridRef);
            Debug.Log(string.Format("Total Points: {0}", count.ToString()));
            destroySharedPointDataGridReference(gridRef);
        }
    }
}
