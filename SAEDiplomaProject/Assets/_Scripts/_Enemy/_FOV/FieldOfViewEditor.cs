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
        FieldOfView fow = (FieldOfView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position,
                            Vector3.up,
                            Vector3.forward, 360, fow.m_ViewRadius);
        Vector3 viewAngleA = fow.DirFromAngle(-fow.m_ViewAngle / 2, false);
        Vector3 viewAngleB = fow.DirFromAngle(fow.m_ViewAngle / 2, false);

        Handles.DrawLine(fow.transform.position,
                         fow.transform.position + viewAngleA * fow.m_ViewRadius);
        Handles.DrawLine(fow.transform.position,
                         fow.transform.position + viewAngleB * fow.m_ViewRadius);

        Handles.color = Color.red;
        foreach (Transform visibleTarget in fow.m_VisibleTargets)
        {
            Handles.DrawLine(fow.transform.position, visibleTarget.transform.position);
        }
    }
}
