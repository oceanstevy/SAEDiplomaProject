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
    private int m_Movementspeed = 10;
    /// <summary>
    /// Idle Waypoints for Enemy
    /// </summary>
    [SerializeField]
    private Transform[] m_Waypoints;
    #endregion PrivateVariables

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move Enemy
        Movement();
    }

    // Movement 
    private void Movement()
    {
        // Find Player
        if (FindPlayer())
        {
            transform.position += transform.forward * m_Movementspeed * Time.deltaTime;
        }
        else
        {
            
        }

    }

    // Find Player in Level
    private bool FindPlayer()
    {
        if (Vector3.Distance(GameManager.Instance.Character.transform.localPosition, transform.position) <= 5)
        {
            return true;
        }

        return false;
    }
}
