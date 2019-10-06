
using UnityEngine;

using UnityEditor;
using UnityStandardAssets.Characters.FirstPerson;

[CustomEditor(typeof(FirstPersonController))]
public class FPSButtons : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        FirstPersonController myScript = (FirstPersonController)target;
        if (GUILayout.Button("Death"))
        {
            myScript.Death();
        }
    }
}
