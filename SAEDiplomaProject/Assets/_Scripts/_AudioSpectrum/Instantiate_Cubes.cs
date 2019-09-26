using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Skript erstellt von Chiavini Luca
/// </summary>

public class Instantiate_Cubes : MonoBehaviour
{
    #region Membervariabeln
    [SerializeField]
    private GameObject m_SampleCubePrefab;
    private GameObject[] m_SampleCube = new GameObject[64];
    private float m_MaxScale;
    #endregion Membervariabeln

    // Start is called before the first frame update
    void Start()
    {
        //Setting the MaxScale auf the Audio Spectrum
        m_MaxScale = 100;
        
        for (int i = 0; i < 64; i++)
        {
            GameObject _instanceSampleCube = (GameObject)Instantiate(m_SampleCubePrefab);
            _instanceSampleCube.transform.parent = this.transform;

            _instanceSampleCube.transform.position = new Vector3(this.transform.position.x+(i*2),transform.position.y,transform.position.z);
            _instanceSampleCube.name = "SampleCube" + i;
            m_SampleCube[i] = _instanceSampleCube;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 64; i++)
        {
            if (m_SampleCube != null)
            {
                m_SampleCube[i].transform.localScale = new Vector3(1, (AudioVisualizer.m_Samples[i] * m_MaxScale) + 2, 1);

            }
        }
    }
}
