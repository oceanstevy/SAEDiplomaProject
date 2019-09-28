using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC : MonoBehaviour
{
    #region MemberVariables
    [SerializeField] private float m_MovementSpeed = 10.0f;
    [SerializeField] private GameObject m_Camera;
    private float m_RunSpeedMultiplier;
    private Enums.Walkstate m_WalkState = 0;
    #endregion MemberVariables

    // Update is called once per frame
    void FixedUpdate()
    {
        //Changes Walkstate to Run
        if (Input.GetKey("left shift"))
        {
            m_WalkState = Enums.Walkstate.Run;
            MoveCharacter();
        }
        //Resets WalkState to Walk
        else
        {
            m_WalkState = Enums.Walkstate.Walk;
            MoveCharacter();
        }
        
    }

    void MoveCharacter()
    {
        //Checks current walkState, and decreases speed or slows down, deppending on State shift
        if (m_WalkState == Enums.Walkstate.Walk)
        {
            if (m_RunSpeedMultiplier > 1.0f)
            {
                //Decrease speed over time
                m_RunSpeedMultiplier -= Time.deltaTime * 2;
            }
            else
            {
                m_RunSpeedMultiplier = 1.0f;
            }
        }
        else if(m_WalkState == Enums.Walkstate.Run)
        {
            if (m_RunSpeedMultiplier < 1.5f)
            {
                //Increase speed over time
                m_RunSpeedMultiplier += Time.deltaTime;
            }
            else
            {
                m_RunSpeedMultiplier = 1.5f;
            }
        }

        //Checks Movement of Axis
        float positionVertical = Input.GetAxis("Vertical") * m_MovementSpeed * Time.deltaTime;
        float positionHorizontal = Input.GetAxis("Horizontal") * m_MovementSpeed * Time.deltaTime;

        if (positionVertical != 0 && positionHorizontal != 0 && positionVertical > 0.0f)
        {
            //Makes vertical Walk as fast as Horizontal walk if we re walking forward
            transform.Translate(positionHorizontal * 0.7071f*m_RunSpeedMultiplier, 0, positionVertical * 0.7071f*m_RunSpeedMultiplier);
        }
        else if (positionVertical != 0 && positionHorizontal != 0)
        {
            //Makes vertical Walk as fast as Horizontal walk if we re walking backwards
            transform.Translate(positionHorizontal * 0.4071f, 0, positionVertical * 0.4071f);
        }
        else if (positionVertical < 0.0f)
        {
            //If we're running backwards
            transform.Translate(positionHorizontal * 0.4071f, 0, positionVertical * 0.4071f);
        }
        else
        {
            //Usual run speed, no multiplier
            transform.Translate(positionHorizontal*m_RunSpeedMultiplier, 0, positionVertical*m_RunSpeedMultiplier);
        }

        //Sets Rotation in direction Camera is looking at
        float CamPosY = m_Camera.transform.eulerAngles.y;

        transform.rotation = Quaternion.Euler(0, CamPosY, 0);
    }
}
