﻿using Pancake;
using Pancake.ExLibEditor;
using UnityEditor;
using UnityEngine;

namespace PancakeEditor
{
    public class CompressOptionVerify : IVerifyBuildProcess
    {
        public bool OnVerify()
        {
            var s = AndroidBuildPipelineSettings.Instance;

            if (s.compressOption == AndroidBuildPipelineSettings.CompressOption.LZ4 && s.environment == AndroidBuildPipelineSettings.Environment.Production)
            {
                if (EditorUtility.DisplayDialog("CompressOption", "Compress option needs to be changed to LZ4HC when building for production!", "Change", "Cancel"))
                {
                    s.compressOption = AndroidBuildPipelineSettings.CompressOption.LZ4HC;
                }
                else return false;
            }

            return true;
        }

        public void OnComplete(bool status)
        {
            Debug.Log(status ? "[CompressOption] Verify Success".TextColor(Uniform.Green) : "[CompressOption] Verify Failure".TextColor(Uniform.Red));
        }
    }
}