using System.Collections;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ArrayModifier))]
public class ArrayModifierEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ArrayModifier arrayModifierScript = (ArrayModifier)target;
        
        // array vector
        DrawDefaultInspector();

        bool okBtn = GUILayout.Button("Array!");
        bool clearBtn = GUILayout.Button("Strip me of everything...");

        if (okBtn)
        {
           arrayModifierScript.Apply();
        }

        if (clearBtn)
        {
            arrayModifierScript.DestroyAllChildren();
        }
    }
}
