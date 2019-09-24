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
    public float m_ViewAngle = 115.0f;

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

    private void FindVisibleTarget()
    {
        m_VisibleTargets.Clear();

        Collider[] TargetinViewRadius = Physics.OverlapSphere(transform.position, m_ViewRadius, m_TargetMask);

        for (int i = 0; i < TargetinViewRadius.Length; ++i)
        {
            Transform Target = TargetinViewRadius[i].transform;
            Vector3 DirToTarget = (Target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, DirToTarget) < m_ViewAngle / 2)
            {
                float DistantToTarget = Vector3.Distance(transform.position, Target.position);

                if (!Physics.Raycast(transform.position, DirToTarget, DistantToTarget, m_ObstacleMask))
                {
                    m_VisibleTargets.Add(Target);
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
