using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropStaseObject : MonoBehaviour
{
    #region MemberVariables
    private GunFeatures m_PulledByScript;
    #endregion MemberVariables

    #region Properties
    /// <summary>
    /// Defines the, Script by which the Object is pulled, so we can change values
    /// </summary>
    public GunFeatures PulledByScript { get => m_PulledByScript; set => m_PulledByScript = value; }
    #endregion Properties

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>() == null)
        {
            GetComponent<Rigidbody>().useGravity = true;
            PulledByScript.ResetStase();
            Destroy(GetComponent<DropStaseObject>());
        }
    }
}
