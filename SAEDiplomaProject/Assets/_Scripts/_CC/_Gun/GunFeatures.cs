using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFeatures : MonoBehaviour
{
    #region MemberVariables
    [SerializeField] private Transform m_BulletSpawnPos;
    [SerializeField] private int m_MaxStaseDistace;
    [SerializeField] private int m_StasePushForce;
    [SerializeField] private GameObject m_LightBeam;
    [SerializeField] private float m_GrenadeShotTimer;
    [SerializeField] private float m_DefaultShotTimer;
    private float m_TimeBetweenShot = 0.0f;
    private bool m_IsStaseActive = false;
    private GameObject m_StaseObject;
    private GameObject m_InstantiatedLightBeam;
    #endregion MemberVariables

    // Update is called once per frame
    void Update()
    {
        ShootTimer();
        GunShot();
        if (m_IsStaseActive)
        {
            Stase();
        }
    }

    //Shoot and Aim
    void GunShot()
    {
        if (Input.GetMouseButtonDown(0) && !UiManager.Instance.Inventory.active)
        {
            switch (GameManager.Instance.ActiveWeaponType)
            {
                case Enums.WeaponAttachment.Default:
                    FireBullet(1, "DefaultBullet");
                    break;
                case Enums.WeaponAttachment.Grenade:
                    FireBullet(2, "GrenadeBullet");
                    break;
                case Enums.WeaponAttachment.Stasis:
                    FireStase();
                    break;
                case Enums.WeaponAttachment.Welding:
                    break;
            }
        }
    }

    //Default gun shot
    void FireBullet(short type, string name)
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (m_TimeBetweenShot == 0.0f)
        {
            //Time between grenade Shots
            if (name == "GrenadeBullet") { m_TimeBetweenShot = m_GrenadeShotTimer; }            

            //Time between DefaultShot
            if (name == "DefaultBullet") { m_TimeBetweenShot = m_DefaultShotTimer; }

            //If we hit something with ray cast
            if (Physics.Raycast(ray, out hit) && type == 1)
            {
                GameObject tmpBullet = Resources.Load<GameObject>("_Bullets/" + name);
                tmpBullet.gameObject.GetComponent<Bullet>().EndPosition = hit.point;
                tmpBullet.gameObject.GetComponent<Bullet>().WeaponType = type;
                Instantiate(tmpBullet, m_BulletSpawnPos.position, Quaternion.Euler(Camera.main.gameObject.transform.rotation.x, Camera.main.gameObject.transform.rotation.y,0));
            }
            //If we hit nothing with raycast, we need a max distance in that case
            else
            {
                GameObject tmpBullet = Resources.Load<GameObject>("_Bullets/" + name);
                tmpBullet.gameObject.GetComponent<Bullet>().EndPosition = ray.GetPoint(50);
                tmpBullet.gameObject.GetComponent<Bullet>().WeaponType = type;
                Instantiate(tmpBullet, m_BulletSpawnPos.position, Quaternion.Euler(Camera.main.gameObject.transform.rotation.x, Camera.main.gameObject.transform.rotation.y, 0));
            }
        }
    }

    //Fire Stase
    private void FireStase()
    {
        //Checks if item is pulled
        if (!m_IsStaseActive)
        {
            m_IsStaseActive = true;
        }
        //If item is pulled we can push the item
        else
        {
            ShootStaseObject();
        }
    }

    //Drags Items
    private void Stase()
    {
        //Gets the mid of the screen as raycast point
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        //If no item is pulled, we will search for one
        if (m_StaseObject == null)
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.distance < m_MaxStaseDistace)
                {
                    //Checks if item contains a rigidbody
                    if (hit.rigidbody != null)
                    {
                        m_StaseObject = hit.rigidbody.gameObject;
                        if (m_StaseObject != null)
                        {
                            //Turns gravity off so the object won't be affected by it, while we're holding it
                            m_StaseObject.GetComponent<Rigidbody>().useGravity = false;
                            m_StaseObject.AddComponent<DropStaseObject>();
                            m_StaseObject.GetComponent<DropStaseObject>().PulledByScript = GetComponent<GunFeatures>();
                        }
                    }
                }
            }
        }
        //if we found an item to pull, we will pull it now
        else
        {
            m_StaseObject.transform.position =  Vector3.MoveTowards(m_StaseObject.transform.position, m_BulletSpawnPos.position, (m_StasePushForce/2)*Time.deltaTime);
        }
        
    }

    //Shoot StaseObject
    private void ShootStaseObject()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        Vector3 EndPos;
        EndPos = new Vector3(ray.GetPoint(50).x, ray.GetPoint(50).y, ray.GetPoint(50).z);
        if (m_StaseObject != null)
        {
            m_StaseObject.GetComponent<Rigidbody>().AddForce((EndPos - m_StaseObject.transform.position) * m_StasePushForce);
            m_StaseObject.GetComponent<Rigidbody>().useGravity = true;
            ResetStase();
        }
    }

    private void ShootTimer()
    {
        if (m_TimeBetweenShot > 0.0f)
        {
            m_TimeBetweenShot -= Time.deltaTime;
        }
        else
        {
            m_TimeBetweenShot = 0.0f;
        }
    }

    //Resets Values so we can pull a new Object
    public void ResetStase()
    {
        m_StaseObject = null;
        m_IsStaseActive = false;
    }
}
