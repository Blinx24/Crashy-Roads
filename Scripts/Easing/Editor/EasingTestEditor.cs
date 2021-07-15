using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EasingTest))]
public class EasingTestEditor : Editor
{
    EasingTest ez;

    public override void OnInspectorGUI(){ 
        
        base.OnInspectorGUI();

        EditorGUI.BeginChangeCheck();
        
        using (new EditorGUI.DisabledScope(ez.Go)) {

            if(GUILayout.Button("Test easing")){ 
                
                Undo.RecordObject(ez,"Test easing");
                ez.EnableEasing = true;
            }

            if(GUILayout.Button("Reset Values")){ 
                
                Undo.RecordObject(ez,"Reset Values");
                ez.ResetValues();
            }
        }

    }

    void OnEnable() {
        
        ez=(EasingTest)target;
    }
}
