using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region MemberVirabels
    private int m_Health;
    private int m_Shield;
    #endregion MemberVirabels
    #region Properties
    /// <summary>
    /// Enemy Health
    /// </summary>
    public int Health { get => m_Health; set => m_Health = value; }
    /// <summary>
    /// Shield power from Enemy
    /// </summary>
    public int Shield { get => m_Shield; set => m_Shield = value; }
    #endregion Properties
    #region PrivateVariables
    /// <summary>
    /// Enemy position
    /// </summary>
    private Vector3 Position;
    /// <summary>
    /// Enemy Rigidbody
    /// </summary>
    private Rigidbody Rigidbody;
    /// <summary>
    /// Enemy Movementspeed
    /// </summary>
    private int m_Movementspeed = 2;
    /// <summary>
    /// Idle Waypoints for Enemy
    /// </summary>
    [SerializeField]
    private Transform[] m_Waypoints;
    // Current Waypoint
    private int CurrentWaypoint;
    // Enemy FieldOfView
    private FieldOfView FoV;
    // if Enemy is Going Forward
    private bool GoingForward = false;
    #endregion PrivateVariables

    private void Awake()
    {
        // Get the FieldOfView Component
        FoV = GetComponent<FieldOfView>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(FoV.SeeTarget);
        // Move Enemy
        Movement();
    }

    // Enemy Movement
    private void Movement()
    {
        // If target seen
        if (FoV.SeeTarget)
        {
            // Direction from Player to Enemy Postion
            Vector3 Dir = GameManager.Instance.Character.transform.position - transform.position;

            Dir = Dir.normalized;
            Dir = Dir * Time.deltaTime * m_Movementspeed;

            // Move to Player
            transform.Translate(Dir, Space.World);
            transform.forward = Vector3.RotateTowards(transform.forward, Dir.normalized, Mathf.PI * Time.deltaTime, 0);
        }
        // else if target not seen
        else if(!FoV.SeeTarget)
        {
            // Current Waypoint Postion from own Postition
            Vector3 dir = m_Waypoints[CurrentWaypoint].position - transform.position;

            dir = dir.normalized;
            dir = dir * Time.deltaTime * m_Movementspeed;
            if (dir.magnitude > Vector3.Distance(m_Waypoints[CurrentWaypoint].position, transform.position))
            {
                // Modulo hilft hier um kein out of range zu bekommen
                CurrentWaypoint = (CurrentWaypoint +
                                        (GoingForward ? 1 : -1) +
                                        m_Waypoints.Length)
                                % m_Waypoints.Length;
            }

            // Move to Waypoint
            transform.Translate(dir, Space.World);
            transform.forward = Vector3.RotateTowards(transform.forward, dir.normalized, Mathf.PI * Time.deltaTime, 0);
        }
    }
}
