using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC : MonoBehaviour
{
    #region MemberVariables
    [SerializeField] private float m_MovementSpeed = 10.0f;
    [SerializeField] private GameObject m_Camera;
    private float m_RunSpeedMultiplier;
    #endregion MemberVariables

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("left shift"))
        {
            if (m_RunSpeedMultiplier < 1.5f)
            {
                m_RunSpeedMultiplier += Time.deltaTime;
            }
            else
            {
                m_RunSpeedMultiplier = 1.5f;
            }
            MoveCharacter();
        }
        else
        {
            if (m_RunSpeedMultiplier > 1.0f)
            {
                m_RunSpeedMultiplier -= Time.deltaTime*2;
            }
            else
            {
                m_RunSpeedMultiplier = 1.0f;
            }
            
            MoveCharacter();
        }
        
    }

    void MoveCharacter()
    {

        //Checks Movement of Axis
        float positionVertical = Input.GetAxis("Vertical") * m_MovementSpeed * Time.deltaTime;
        float positionHorizontal = Input.GetAxis("Horizontal") * m_MovementSpeed * Time.deltaTime;

        if (positionVertical != 0 && positionHorizontal != 0 && positionVertical > 0.0f)
        {
            transform.Translate(positionHorizontal * 0.7071f*m_RunSpeedMultiplier, 0, positionVertical * 0.7071f*m_RunSpeedMultiplier);
        }
        else if (positionVertical != 0 && positionHorizontal != 0)
        {
            transform.Translate(positionHorizontal * 0.4071f, 0, positionVertical * 0.4071f);
        }
        else if (positionVertical < 0.0f)
        {
            transform.Translate(positionHorizontal * 0.4071f, 0, positionVertical * 0.4071f);
        }
        else
        {
            transform.Translate(positionHorizontal*m_RunSpeedMultiplier, 0, positionVertical*m_RunSpeedMultiplier);
        }

        //Sets Rotation in direction Camera is looking at
        float CamPosY = m_Camera.transform.eulerAngles.y;

        transform.rotation = Quaternion.Euler(0, CamPosY, 0);
    }
}
