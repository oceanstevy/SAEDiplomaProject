using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFeatures : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GunShot();
    }

    //Default Gunshot
    void GunShot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForceAtPosition(ray.direction * 500, hit.point);
                    Debug.Log(hit.rigidbody.gameObject.name);
                }
            }
        }
    }
}
