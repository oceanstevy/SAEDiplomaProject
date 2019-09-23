using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    #region MemberVariables
    private GameObject m_Crosshair;
    private static UiManager m_Instance;
    private GameObject m_StartGameButton;
    private GameObject m_TestText;
    private GameObject m_MenuPanel;
    private GameObject m_HelpPanel;
    private GameObject m_CreditsPanel;
    private GameObject m_OptionsPanel;
    #endregion MemberVariables
    #region Properties
    /// <summary>
    /// This is the Crosshair we're aiming with
    /// </summary>
    public GameObject Crosshair { get => m_Crosshair; set => m_Crosshair = value; }
    /// <summary>
    /// These Values are needed for our singleton, so we have access from everywhere
    /// </summary>
    public static UiManager Instance { get => m_Instance; set => m_Instance = value; }    public GameObject TestText { get => m_TestText; set => m_TestText = value; }


    #endregion Properties


    private void Awake()
    {
        //Creates Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Crosshair = GameObject.Find("UiCorsshair");
        TestText = GameObject.Find("TestText");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
