using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC : MonoBehaviour
{
    #region MemberVariables
    [SerializeField] private float m_MovementSpeed = 10.0f;
    [SerializeField] private GameObject m_Camera;
    #endregion MemberVariables

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveCharacter();
    }

    void MoveCharacter()
    {
        //Checks Movement of Axis
        float positionVertical = Input.GetAxis("Vertical") * m_MovementSpeed * Time.deltaTime;
        float positionHorizontal = Input.GetAxis("Horizontal") * m_MovementSpeed * Time.deltaTime;

        transform.Translate(positionHorizontal, 0, positionVertical);

        //Sets Rotation in direction Camera is looking at
        float CamPosY = m_Camera.transform.eulerAngles.y;

        transform.rotation = Quaternion.Euler(0, CamPosY, 0);
    }
}
