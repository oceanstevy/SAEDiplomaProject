using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region MemberVariables
    private short m_WeaponType = 1;
    [SerializeField] private Vector3 m_EndPosition;
    [SerializeField] private Transform m_SpawnPoint;
    #endregion MemberVariables
    #region Properties
    /// <summary>
    /// Defines the Weapon type, used for the gun type and the type of bullet we spawn
    /// </summary>
    public short WeaponType { get => m_WeaponType; set => m_WeaponType = value; }
    /// <summary>
    /// Position where the Bullet will land
    /// </summary>
    public Vector3 EndPosition { get => m_EndPosition; set => m_EndPosition = value; }
    #endregion Properties

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (WeaponType)
        {
            case 1:
                DefaultBulletMovement();
                break;
            case 2:
                Debug.Log("test");
                break;
        }
    }

    public void DefaultBulletMovement()
    {
        GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 2000);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
