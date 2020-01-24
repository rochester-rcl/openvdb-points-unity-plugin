using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEditor.Experimental.AssetImporters;
using System.Linq;
using System.IO;
namespace OpenVDBPointsUnity
{
    public abstract class BaseVDBImporter : ScriptedImporter
    {
        
        protected string absoluteAssetPath;

        protected void GetAbsoluteAssetPath(AssetImportContext ctx)
        {
            // TODO should probably repace with regex
            List<string> folders = Application.dataPath.Split('/').ToList();
            folders.RemoveAt(folders.Count - 1);
            string projectDir = string.Join("/", folders.ToArray());
            absoluteAssetPath = string.Format("{0}/{1}", projectDir, ctx.assetPath);
        }

        public virtual void LogMessage(string message)
        {
            Debug.Log(message);
        }
    }

}