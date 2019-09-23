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
        GameObject tmpBullet = Resources.Load<GameObject>("_Bullets/DefaultBullet");
        Instantiate(tmpBullet, m_BulletSpawnPos.position, Quaternion.identity);
        tmpBullet.gameObject.GetComponent<Bullet>().WeaponType = 1;
    }
}
