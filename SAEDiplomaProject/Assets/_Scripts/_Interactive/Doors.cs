using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    #region MemberVariables

    [SerializeField]
    private GameObject m_Doors;
    private string m_DoorName;

    private bool m_Open = false;
    private bool m_Keycard = true;

    #endregion MemberVariables


    #region Properties
    /// <summary>
    /// Keycard Value of the Door
    /// </summary>
    public bool Keycard { get => m_Keycard; set => m_Keycard = value; }

    #endregion Properties

    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in GameManager.Instance.Doors)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Keycard)
        {
            if (m_Open == true)
            {
                if (m_Doors.transform.position.y > m_Doors.transform.position.y - 6 && m_Doors.transform.position.y > -5)
                {
                    m_Doors.transform.position -= new Vector3(0, 2 * Time.deltaTime, 0);
                }

            }
            else
            {
                if (m_Doors.transform.position.y < m_Doors.transform.position.y + 6 && m_Doors.transform.position.y <0)
                {
                    m_Doors.transform.position += new Vector3(0, 2 * Time.deltaTime, 0);
                }
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Character")
        {
            Debug.Log("1");
            m_Open = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.name == "Character")
        {
            Debug.Log("2");
            m_Open = false;
        }
    }

}
