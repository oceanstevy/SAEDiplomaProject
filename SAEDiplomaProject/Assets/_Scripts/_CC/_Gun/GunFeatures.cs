using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFeatures : MonoBehaviour
{
    #region MemberVariables
    [SerializeField] private Transform m_BulletSpawnPos;
    [SerializeField] private int m_MaxStaseDistace;
    [SerializeField] private int m_StasePushForce;
    private float m_TimeBetweenShot = 0.0f;
    private bool m_IsStaseActive = false;
    private GameObject m_StaseObject;
    #endregion MemberVariables
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        if (Input.GetMouseButtonDown(0))
        {
            //FireBullet(1, "DefaultBullet");
            FireBullet(2, "GrenadeBullet");
            //FireStase();
        }
    }

    //Default gun shot
    void FireBullet(short type, string name)
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (m_TimeBetweenShot == 0.5f)
        {
            m_TimeBetweenShot = 0.0f;
            if (Physics.Raycast(ray, out hit) && type == 1)
            {
                GameObject tmpBullet = Resources.Load<GameObject>("_Bullets/" + name);
                tmpBullet.gameObject.GetComponent<Bullet>().EndPosition = hit.point;
                tmpBullet.gameObject.GetComponent<Bullet>().WeaponType = type;
                Instantiate(tmpBullet, m_BulletSpawnPos.position, this.transform.rotation);
            }
            else
            {
                GameObject tmpBullet = Resources.Load<GameObject>("_Bullets/" + name);
                tmpBullet.gameObject.GetComponent<Bullet>().EndPosition = ray.GetPoint(50);
                tmpBullet.gameObject.GetComponent<Bullet>().WeaponType = type;
                Instantiate(tmpBullet, m_BulletSpawnPos.position, Quaternion.identity);
            }
        }
    }

    //Fire Stase
    private void FireStase()
    {
        Debug.Log(m_StasePushForce);
        if (!m_IsStaseActive)
        {
            m_IsStaseActive = true;
        }
        else
        {
            ShootStaseObject();
        }
    }

    //Drags Items
    private void Stase()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (m_StaseObject == null)
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.distance < m_MaxStaseDistace)
                {
                    m_StaseObject = hit.rigidbody.gameObject;
                    if (m_StaseObject != null)
                    {
                        m_StaseObject.GetComponent<Rigidbody>().useGravity = false;
                    }
                }
            }
        }
        else
        {
            m_StaseObject.transform.position =  Vector3.MoveTowards(m_StaseObject.transform.position, m_BulletSpawnPos.position, 80);
        }
        
    }

    //Shoot StaseObject
    private void ShootStaseObject()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        Vector3 EndPos;
        EndPos = new Vector3(ray.GetPoint(50).x, ray.GetPoint(50).y, ray.GetPoint(50).z);
        m_StaseObject.GetComponent<Rigidbody>().AddForce((EndPos - m_StaseObject.transform.position) * m_StasePushForce);
        m_StaseObject.GetComponent<Rigidbody>().useGravity = true;
        m_StaseObject = null;
        m_IsStaseActive = false;
    }

    private void ShootTimer()
    {
        if (m_TimeBetweenShot < 0.5f)
        {
            m_TimeBetweenShot += Time.deltaTime;
        }
        else
        {
            m_TimeBetweenShot = 0.5f;
        }
        
    }
}
