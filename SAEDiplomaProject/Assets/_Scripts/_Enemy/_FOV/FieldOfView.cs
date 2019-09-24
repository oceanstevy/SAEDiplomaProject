using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    #region Virables
    // View Radius from Enemy
    public float m_ViewRadius = 5.0f;
    [Range(0, 360)]
    // View Angle from Enemy, between 0 and 360
    public float m_ViewAngle;
    // Mask the Enemy should look for
    public LayerMask m_TargetMask;
    // Obstacle Mask, that could be between Enemey and Target
    public LayerMask m_ObstacleMask;
    // Target List from all Visible Targets
    public List<Transform> m_VisibleTargets;
    // if Enemy sees target
    [HideInInspector]
    public bool SeeTarget;
    #endregion Virables


    // Start is called before the first frame update
    void Start()
    {
        m_VisibleTargets = new List<Transform>();
        // Find Targets with 0.2 seconds Delay
        StartCoroutine("FindTargetsWithDelay", 0.2f);
    }

    /// <summary>
    /// Find Targets with Delay
    /// </summary>
    /// <param name="Delay">Dleay</param>
    private IEnumerator FindTargetsWithDelay(float Delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(Delay);
            FindVisibleTarget();
        }
    }

    /// <summary>
    /// Find Visible Target
    /// </summary>
    public void FindVisibleTarget()
    {
        // Clear List
        m_VisibleTargets.Clear();

        // Targets in view Radius
        Collider[] targetinViewRadius = Physics.OverlapSphere(transform.position,
                                                              m_ViewRadius,
                                                              m_TargetMask);
        // for every Target in Collider Array
        for (int i = 0; i < targetinViewRadius.Length; i++)
        {
            // Current Target in Radius
            Transform Target = targetinViewRadius[i].transform;
            // Direction to Target
            Vector3 DirToTarget = (Target.position - transform.position).normalized;

            // If the Target is between the View Angle
            if (Vector3.Angle(transform.forward, DirToTarget) < m_ViewAngle / 2)
            {
                // Distant to seen Target
                float DistantToTarget = Vector3.Distance(transform.position, Target.position);

                // if no Obstacle in View
                if (!Physics.Raycast(transform.position, DirToTarget, DistantToTarget, m_ObstacleMask) && Target.tag == "Player")
                {
                    // Target is visible and add to visibleTarget List
                    m_VisibleTargets.Add(Target);
                    SeeTarget = true;
                }
            }
            else
            {
                // Players not Visible set False
                SeeTarget = false;
            }
        }
    }

    public Vector3 DirFromAngle(float AngleInDegrees, bool AngleIsGlobal)
    {
        if (!AngleIsGlobal)
        {
            AngleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(AngleInDegrees * Mathf.Deg2Rad),
                           0,
                           Mathf.Cos(AngleInDegrees * Mathf.Deg2Rad));
    }
}
