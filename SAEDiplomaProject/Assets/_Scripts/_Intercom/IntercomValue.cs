using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntercomValue : MonoBehaviour
{
    #region MemberVariables
    private AudioClip m_Voiceclip;
    private string m_Header;
    private Image m_Portrait;
    #endregion  MemberVariables

    #region Properties
    /// <summary>
    /// Voice Memo from Incoming Call
    /// </summary>
    public AudioClip Voiceclip { get => m_Voiceclip; set => m_Voiceclip = value; }
    /// <summary>
    /// Message Name
    /// </summary>
    public string Header { get => m_Header; set => m_Header = value; }
    /// <summary>
    /// Image from Caller
    /// </summary>
    public Image Portrait { get => m_Portrait; set => m_Portrait = value; }
    #endregion Properties

    public IntercomValue(AudioClip voiceclip, string header, Image portrait)
    {
        m_Voiceclip = voiceclip;
        m_Header = header;
        m_Portrait = portrait;
    }

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
