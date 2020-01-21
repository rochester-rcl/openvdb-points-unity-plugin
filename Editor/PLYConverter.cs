using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEditor.Experimental.AssetImporters;
using System.Linq;
using System.IO;

namespace OpenVDBPointsUnity
{
    [ScriptedImporter(1, "ply")]
    public class PLYConverter : BaseVDBImporter
    {
        [DllImport("openvdb-points-unity", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool convertPLYToVDB(string filename, string outfile, LoggingCallback callback);
        public override void OnImportAsset(AssetImportContext ctx)
        {
            try
            {
                openvdbInitialize();
                GetAbsoluteAssetPath(ctx);
                string outPath = string.Format("{0}/{1}.vdb", Application.dataPath, Path.GetFileNameWithoutExtension(ctx.assetPath));
                if (!File.Exists(outPath))
                {
                    convertPLYToVDB(absoluteAssetPath, outPath, LogMessage);
                }
            }
            catch (System.Exception e)
            {
                Debug.Log(e);
            }
        }
    }
}

