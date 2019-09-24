using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntercomValue : MonoBehaviour
{
    #region MemberVariables
    private AudioClip m_Voiceclip;
    private AudioClip m_Ringtone;
    private string m_Header;
    private Sprite m_Portrait;
    private float m_Timer;
    private bool m_Isvoiceon;
    private bool m_Incoming;
    private bool m_Callended;
    private float m_Voicelength;
    private IntercomValue m_Temp;
    public GameObject m_PanelIn;
    public GameObject m_PanelOut;
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
    public Sprite Portrait { get => m_Portrait; set => m_Portrait = value; }
    /// <summary>
    /// Timer for the Calls
    /// </summary>
    public float Timer { get => m_Timer; set => m_Timer = value; }
    /// <summary>
    /// Bool to check if the Intercom in activ
    /// </summary>
    public bool Isvoiceon { get => m_Isvoiceon; set => m_Isvoiceon = value; }
    /// <summary>
    /// Gte the voiceLength
    /// </summary>
    public float Voicelength { get => m_Voicelength; set => m_Voicelength = value; }
    /// <summary>
    /// Bool that turns true if the Intercom Rings
    /// </summary>
    public bool Incoming { get => m_Incoming; set => m_Incoming = value; }
    /// <summary>
    /// Variable to quicksave the Data from the Call
    /// </summary>
    public IntercomValue Temp { get => m_Temp; set => m_Temp = value; }
    /// <summary>
    /// Bool that changes when the call has ended, so we can hide the Panel
    /// </summary>
    public bool Callended { get => m_Callended; set => m_Callended = value; }
    /// <summary>
    /// Locates the Panel Inscreen Position
    /// </summary>
    public GameObject PanelIn { get => m_PanelIn; set => m_PanelIn = value; }
    /// <summary>
    /// Locates the Panel Outscreen Position
    /// </summary>
    public GameObject PanelOut { get => m_PanelOut; set => m_PanelOut = value; }
    /// <summary>
    /// Audio Ringtone
    /// </summary>
    public AudioClip Ringtone { get => m_Ringtone; set => m_Ringtone = value; }
    #endregion Properties

    public IntercomValue(AudioClip voiceclip, string header, Sprite portrait)
    {
        m_Voiceclip = voiceclip;
        m_Header = header;
        m_Portrait = portrait;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Put the Panel out of the Screen
        UiManager.Instance.Intercom.transform.position = m_PanelOut.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //To Test the Call
        if (Input.GetKeyDown("space") && m_Incoming == false && m_Isvoiceon == false && m_Callended == false)
        {
            IncomingCall(GameManager.Instance.IntercomMassages[0]);
        }


        #region Incoming Call
        /// <summary>
        /// Incoming Call
        /// </summary>
        if (m_Incoming == true)
        {
            Debug.Log("Res");
            //Get the Panel
            GameObject Intercompanel = UiManager.Instance.Intercom;

            //Let it Slide into the Screen
            Intercompanel.transform.position = new Vector3(Intercompanel.transform.position.x - (200 * Time.deltaTime) , Intercompanel.transform.position.y, Intercompanel.transform.position.z);

            //Stop Sliding if the Panel has reached the right position
            if (Intercompanel.transform.position.x <= m_PanelIn.transform.position.x)
            {
                //Set the Variable Incoming to false
                m_Incoming = false;

                //Start the Call
                StartingCall(m_Temp);
            }
        }
        #endregion Incoming Call

        #region Call is activ
        /// <summary>
        /// Call is aktiv
        /// </summary>
        //if the Call is activ, start the Timer
        if (m_Isvoiceon == true)
        {
            //Timer running
            m_Timer += Time.deltaTime;
        }

        //When the Timer has reached the Length of the Clip, stop the Call
        if (m_Timer > m_Voicelength  && m_Isvoiceon == true)
        {
            //Voice has ended
            m_Isvoiceon = false;

            //Call has ended
            m_Callended = true;
        }
        #endregion Call is activ

        #region Call has ended
        /// <summary>
        /// Call has ended
        /// </summary>
        if (m_Callended == true)
        {

            //Get the Panel
            GameObject Intercompanel = UiManager.Instance.Intercom;

            //Let it Slide out of the Screen
            Intercompanel.transform.position = new Vector3(Intercompanel.transform.position.x + (200 * Time.deltaTime), Intercompanel.transform.position.y, Intercompanel.transform.position.z);

            //Stop Sliding if the Panel has reached the right position
            if (m_Callended == true && Intercompanel.transform.position.x >=  m_PanelOut.transform.position.x)
            {
                //Set the Variable Incoming to false
                m_Callended = false;

                //Hide the Panel
                UiManager.Instance.Intercom.SetActive(false);
                
            }
        }
        #endregion Call has ended

    }

    //Trigger Intercom
    private void IncomingCall(IntercomValue call)
    {
        //Setting the bool to true
        m_Incoming = true;

        //Enable Intercom UI
        UiManager.Instance.Intercom.SetActive(true);

        //Fill the Caller Text in the UI
        Text header = UiManager.Instance.Intercom.gameObject.transform.GetChild(0).GetComponent<Text>();
        header.text = call.m_Header;

        //Fill the Image of the Caller in the UI
        Image portrait = UiManager.Instance.Intercom.gameObject.transform.GetChild(1).GetComponent<Image>();
        portrait.sprite = call.m_Portrait;

        //Save the Data for later
        m_Temp = call;
    }

    //Starting Call
    private void StartingCall(IntercomValue call)
    {

        //Reset Timer
        m_Timer = 0;

        //Set bool to true
        m_Isvoiceon = true;

        //Get Clip Length
        m_Voicelength = call.m_Voiceclip.length;

        //Play the Voice Clip
        AudioSource voice = this.GetComponent<AudioSource>();
        voice.PlayOneShot(call.m_Voiceclip, 0.8f);

    }
}
