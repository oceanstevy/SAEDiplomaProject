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

    private int CurrentWaypoint;

    private FieldOfView FoV;
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

            // Im Standard nutzen wir den lokalen Space bei Transform.Translate
            transform.Translate(Dir, Space.World);
            transform.forward = Vector3.RotateTowards(transform.forward, Dir.normalized, Mathf.PI * Time.deltaTime, 0);
        }
        else
        {
            /*Vector3 dir = m_Waypoints[CurrentWaypoint].position - transform.position;

            // Falls die Schrittlänge größer ist als die Entfernung zum Ziel
            // normalisierte Vektoren haben die Länge 1, behalten aber ihre Richtung
            dir = dir.normalized;
            dir = dir * Time.deltaTime * m_Movementspeed;
            if (dir.magnitude > Vector3.Distance(m_Waypoints[CurrentWaypoint].position, transform.position))
            {
                //m_GoingForward = !m_GoingForward;
                // Modulo hilft hier um kein out of range zu bekommen
                CurrentWaypoint = (CurrentWaypoint + m_Waypoints.Length) % m_Waypoints.Length;
            }

            // Im Standard nutzen wir den lokalen Space bei Transform.Translate
            transform.Translate(dir, Space.World);
            transform.forward = Vector3.RotateTowards(transform.forward, dir.normalized, Mathf.PI * Time.deltaTime, 0);*/
        }
    }
}
