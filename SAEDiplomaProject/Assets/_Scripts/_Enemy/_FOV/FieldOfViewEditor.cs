using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Class to Visualise in Editor
/// </summary>
[CustomEditor(typeof(FieldOfView))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        FieldOfView FOV = (FieldOfView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(FOV.transform.position, Vector3.up, Vector3.forward, 360, FOV.m_ViewAngle);
        Vector3 ViewAngleA = FOV.DirFromAngle(-FOV.m_ViewAngle / 2, false);
        Vector3 ViewAngleB = FOV.DirFromAngle(FOV.m_ViewAngle / 2, false);

        Handles.DrawLine(FOV.transform.position, FOV.transform.position + ViewAngleA * FOV.m_ViewRadius);
        Handles.DrawLine(FOV.transform.position, FOV.transform.position + ViewAngleB * FOV.m_ViewRadius);

        Handles.color = Color.red;
        foreach (Transform VisibleTargets in FOV.m_VisibleTargets)
        {
            Handles.DrawLine(FOV.transform.position, VisibleTargets.transform.position);
        }
    }
}
