﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    #region MemberVariables
    private bool m_CanShrink = false;
    private bool m_CanKill = false;
    [SerializeField] private int m_Radius;
    [SerializeField] private int m_ExplosionForce;
    [SerializeField] private int m_PullForce;
    private Vector3 m_ExplosionPos;
    private Collider[] m_Colliders;
    #endregion MemberVariables
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_CanKill == false)
        {
            if (transform.localScale.x < 4.0f && m_CanShrink == false)
            {
                transform.localScale += new Vector3(Time.deltaTime * 10, Time.deltaTime * 10, Time.deltaTime * 10);
            }
            else if (transform.localScale.x <= -5.0f && m_CanShrink)
            {
                m_CanKill = true;
                m_ExplosionPos = transform.position;
                m_Colliders = Physics.OverlapSphere(m_ExplosionPos, m_Radius);
                int i = 0;
                while (i < m_Colliders.Length)
                {
                    if (m_Colliders[i].gameObject.GetComponent<Rigidbody>() != null)
                    {
                        if (m_Colliders[i].gameObject.tag != "Player")
                        {
                            float distance = m_Radius - Vector3.Magnitude(m_Colliders[i].gameObject.transform.position - gameObject.transform.position);
                            m_Colliders[i].gameObject.GetComponent<Rigidbody>().AddForce((m_Colliders[i].gameObject.transform.position - gameObject.transform.position).normalized * distance * m_ExplosionForce, ForceMode.Impulse);
                        }
                    }
                    i++;
                }
            }
            else
            {
                m_CanShrink = true;
                m_ExplosionPos = transform.position;
                m_Colliders = Physics.OverlapSphere(m_ExplosionPos, m_Radius);
                transform.localScale -= new Vector3(Time.deltaTime * 5, Time.deltaTime * 5, Time.deltaTime * 5);
                int i = 0;
                while (i < m_Colliders.Length)
                {
                    if (m_Colliders[i].gameObject.GetComponent<Rigidbody>() != null)
                    {
                        if (m_Colliders[i].gameObject.tag != "Player")
                        {
                            m_Colliders[i].gameObject.transform.position = Vector3.MoveTowards(m_Colliders[i].gameObject.transform.position, transform.position, m_PullForce * Time.deltaTime);
                        }
                    }
                    i++;
                }
            }
        }
        else
        {
            transform.localScale += new Vector3(Time.deltaTime * 11, Time.deltaTime * 11, Time.deltaTime * 11);
            if (transform.localScale.x >= 0.0f)
            {
                Destroy(this.gameObject);
            }
        }
        
    }
}