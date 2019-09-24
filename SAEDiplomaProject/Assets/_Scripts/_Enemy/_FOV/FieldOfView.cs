using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    #region MemberVirables
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
    public List<Transform> m_VisibleTargets = new List<Transform>();
    #endregion MemberVirables

    // Start is called before the first frame update
    void Start()
    {
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
            Transform target = targetinViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, dirToTarget) < m_ViewAngle / 2)
            {
                float distantToTarget = Vector3.Distance(transform.position, target.position);

                // if no Obstacle in View
                if (!Physics.Raycast(transform.position, dirToTarget, distantToTarget, m_ObstacleMask))
                {
                    // Target is visible and add to visibleTarget List
                    m_VisibleTargets.Add(target);
                }
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
