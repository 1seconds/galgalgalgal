using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Path))]
public class PathEditor : Editor
{

    Path mPath;
    public void OnEnable()
    {
        mPath = (target as Path);       
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Add nodePositionsition"))
        {
            Vector3 nodePositionsition = (mPath.transform.position);
            float waitTime = 0f;
            ArrayUtility.Add(ref mPath.nodePositions, nodePositionsition);
            ArrayUtility.Add(ref mPath.waitTimes, waitTime);
        }
       
        int delete = -1;
        for (int i = 0; i < mPath.nodePositions.Length; ++i)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Node " + i, GUILayout.Width(220));
            if (i != 0 && GUILayout.Button("Delete", GUILayout.Width(100)))
            {
                delete = i;
            }
            EditorGUILayout.EndHorizontal();
            Vector3 newnodePositionsition;
            if (i == 0)
                newnodePositionsition = mPath.nodePositions[i];
            else
                newnodePositionsition = EditorGUILayout.Vector3Field("",mPath.nodePositions[i]);

            float newTime = EditorGUILayout.FloatField("Wait Time", mPath.waitTimes[i]);

        }
        if (delete != -1)
        {
            Undo.RecordObject(target, "Removed point moving platform");

            ArrayUtility.RemoveAt(ref mPath.nodePositions, delete);
            ArrayUtility.RemoveAt(ref mPath.waitTimes, delete);
        }

    }

    private void OnSceneGUI()
    {
        for (int i = 0; i < mPath.nodePositions.Length; ++i)
        {
            Vector3 worldnodePositions=(mPath.nodePositions[i]);
            Vector3 newWorld = worldnodePositions;
            if (i != 0) newWorld = Handles.PositionHandle(worldnodePositions, Quaternion.identity);
            if (!Application.isPlaying)
            {
                if (worldnodePositions != newWorld)
                {
                    Undo.RecordObject(target, "moved point");
                    mPath.nodePositions[i] = newWorld;// mPath.transform.InverseTransformPoint(newWorld);
                }
            }
        }
    }
 
  
}
