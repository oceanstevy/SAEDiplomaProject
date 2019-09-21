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
    #endregion MemberVariables
    #region Properties
    /// <summary>
    /// this is the Corsshair we're aiming with
    /// </summary>
    public GameObject Crosshair { get => m_Crosshair; set => m_Crosshair = value; }
    /// <summary>
    /// This Values is need for our singleton, so we have acces from everywhere
    /// </summary>
    public static UiManager Instance { get => m_Instance; set => m_Instance = value; }
    /// <summary>
    /// This is a TextExemple for will
    /// </summary>
    public GameObject TestText { get => m_TestText; set => m_TestText = value; }
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

        Crosshair = GameObject.Find("UiCorsshair");
        TestText = GameObject.Find("TestText");
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
