using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;

[CustomEditor(typeof(PlayerDataHandler))]
public class PlayerDataHandlerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        PlayerDataHandler playerDataHandler = (PlayerDataHandler)target;

        if(GUILayout.Button("Reset High Score"))
        {
            playerDataHandler.ResetHighScore();
            
        }

        if(GUILayout.Button("Reset Energy"))
        {
            playerDataHandler.ResetEnergy();
        }
    }
}
