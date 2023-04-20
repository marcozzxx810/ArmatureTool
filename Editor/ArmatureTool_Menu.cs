using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ArmatureTool.Tools
{
    public class ArmatureTool_Menu
    {
        [MenuItem("ArmatureTool/Rename Armature")]
        public static void renameArmature() {
            ArmatureTool_Editor.LaunchEditor();
        }
    }
}
