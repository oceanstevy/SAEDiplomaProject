using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCCamera : MonoBehaviour
{
    #region MemberVariables
    [SerializeField] private float m_CameraDistance, m_MaxDistance, m_MinDistance;
    [SerializeField] private float m_MaxDistanceAim;
    [SerializeField] private float m_Sensitivity;
    [SerializeField] private float m_ViewClampUp, m_ViewClampDown;
    [SerializeField] Transform m_DefaultCamPos, m_AimCamPos;
    [SerializeField] private LayerMask m_IgnoreLayer;
    private float m_MouseX = 0, m_MouseY = 0;
    private Vector3 m_CameraPosition;
    private Transform m_Player;
    private float DefaultCameraDistance, DefaultMaxDistance, DefaultMinDistance;
    private string m_CurrentFollowingName,m_DefaultFollowingName = "";
    #endregion MemberVariables

    private void Start()
    {
        SetupCam();
    }

    private void Update()
    {
        Aim();
    }

    private void FixedUpdate()
    {
        SetCameraPositionAndRotation();
    }

    private void SetCameraPositionAndRotation()
    {
        //Lock Camera in center
        Screen.lockCursor = true;

        //Sets MousePos, so we can turn around the Object (Left, Right)
        m_MouseX += Input.GetAxis("Mouse X") * m_Sensitivity;

        //Sets MousePos, so we can turn around the Object (Up, Down)
        m_MouseY -= Input.GetAxis("Mouse Y") * m_Sensitivity;

        //Checks if the turn radius is in Range
        m_MouseY = Mathf.Clamp(m_MouseY, m_ViewClampDown, m_ViewClampUp);

        //Gets Position
        Vector3 direction = new Vector3(0, 0, -m_CameraDistance);

        //Checks if we re colliding with a GameObject, means if camera should go throught wall, it will be pushed closer to the player instead + Sets New Rotation
        RaycastHit hit;
        if (m_Player != null)
        {
            if (Physics.Raycast(m_Player.transform.position, transform.position - m_Player.transform.position, out hit, m_CameraDistance, m_IgnoreLayer))
            {
                direction.z = -Vector3.Distance(m_Player.transform.position, hit.point + new Vector3(0, 1f, 0));
            }

            Quaternion rotation = Quaternion.Euler(m_MouseY, m_MouseX, 0);

            //Checks if we're aiming or not
            if (m_DefaultFollowingName != m_CurrentFollowingName)
            {
                transform.position = Vector3.MoveTowards(transform.position, m_Player.position + rotation * direction, 15 * Time.deltaTime);

                Vector3 targetDir = m_Player.position - transform.position;

                // The step size is equal to speed times frame time.
                float step = 12 * Time.deltaTime;

                Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
                //Debug.DrawRay(transform.position, newDir, Color.red);

                // Move our position a step closer to the target.
                transform.rotation = Quaternion.LookRotation(newDir);

                if (transform.position == m_Player.position + rotation * direction)
                {
                    m_DefaultFollowingName = m_CurrentFollowingName;
                }
            }
            else
            {
                //Simple sets the position
                transform.position = m_Player.position + rotation * direction;
                transform.LookAt(m_Player);
            }
        }
    }

    private void SetupCam()
    {
        //Sets up camera Values, needed for calculations etc
        DefaultCameraDistance = m_CameraDistance;
        DefaultMaxDistance = m_MaxDistance;
        DefaultMinDistance = m_MinDistance;

        transform.parent = null;
        m_Player = m_DefaultCamPos;
        m_DefaultFollowingName = m_DefaultCamPos.name;
        m_CurrentFollowingName = m_DefaultFollowingName;
    }

    void Aim()
    {
        //If right Mouse Button is clicked
        if (Input.GetMouseButtonDown(1))
        { 
            m_MaxDistance = m_MaxDistanceAim;
            m_CameraDistance = m_MaxDistanceAim;

            m_Player = m_AimCamPos;
            m_CurrentFollowingName = m_AimCamPos.name;
        }
        //If Right Mouse button is released
        else if(Input.GetMouseButtonUp(1))
        {
            m_MaxDistance = DefaultMaxDistance;
            m_CameraDistance = DefaultCameraDistance;

            m_Player = m_DefaultCamPos;
            m_CurrentFollowingName = m_DefaultCamPos.name;
        }
    }
}
