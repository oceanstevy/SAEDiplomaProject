using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFeatures : MonoBehaviour
{
    #region MemberVariables
    [SerializeField] private Transform m_BulletSpawnPos;
    #endregion MemberVariables
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GunShot();
    }

    //Shoot and Aim
    void GunShot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DefaultGun();
        }
    }

    //Default gun shot
    void DefaultGun()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject tmpBullet = Resources.Load<GameObject>("_Bullets/DefaultBullet");
            tmpBullet.gameObject.GetComponent<Bullet>().EndPosition = hit.point;
            tmpBullet.gameObject.GetComponent<Bullet>().WeaponType = 1;
            Instantiate(tmpBullet, m_BulletSpawnPos.position, Quaternion.identity);
        }
        else
        {
            GameObject tmpBullet = Resources.Load<GameObject>("_Bullets/DefaultBullet");
            tmpBullet.gameObject.GetComponent<Bullet>().EndPosition = ray.GetPoint(50);
            tmpBullet.gameObject.GetComponent<Bullet>().WeaponType = 1;
            Instantiate(tmpBullet, m_BulletSpawnPos.position, Quaternion.identity);
        }
    }
}
