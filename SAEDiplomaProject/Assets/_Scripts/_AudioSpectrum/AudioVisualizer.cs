using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Skript erstellt von Chiavini Luca
/// </summary>

[RequireComponent (typeof (AudioSource))]

public class AudioVisualizer : MonoBehaviour
{
    private AudioSource m_Audiosource;
    public static float[] m_Samples = new float[64];
    // Start is called before the first frame update
    void Start()
    {
        m_Audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
    }

    void GetSpectrumAudioSource()
    {
        m_Audiosource.GetSpectrumData(m_Samples, 0, FFTWindow.Blackman);
    }
}
