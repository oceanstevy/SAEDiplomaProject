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

    private int CurrentWaypoint;

    private FieldOfView FoV;

    private bool GoingForward = false;
    #endregion PrivateVariables

    // Start is called before the first frame update
    void Start()
    {
        FoV = new FieldOfView();
        Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(FoV.HitsTarget);
        //Debug.Log(GameManager.Instance.Character.transform.position);
        // Move Enemy
        Movement();
    }

    // Movement 
    private void Movement()
    {
        // Find Player
        if (FoV.HitsTarget)
        {
            Vector3 Dir = GameManager.Instance.Character.transform.position - transform.position;

            Dir = Dir.normalized;
            Dir = Dir * Time.deltaTime * m_Movementspeed;

            transform.Translate(Dir, Space.World);
            transform.forward = Vector3.RotateTowards(transform.forward, Dir.normalized, Mathf.PI * Time.deltaTime, 0);
        }
        else
        {
            Vector3 Direction = m_Waypoints[CurrentWaypoint].position - transform.position;

            Direction = Direction.normalized;
            Direction = Direction * Time.deltaTime * m_Movementspeed;
            if (Direction.magnitude > Vector3.Distance(m_Waypoints[CurrentWaypoint].position, transform.position))
            {
                CurrentWaypoint = (CurrentWaypoint +
                                        (GoingForward ? 1 : -1) +
                                        m_Waypoints.Length)
                                % m_Waypoints.Length;
            }
            transform.Translate(Direction, Space.World);
            transform.forward = Vector3.RotateTowards(transform.forward, Direction.normalized, Mathf.PI * Time.deltaTime, 0);
        }
    }
}
