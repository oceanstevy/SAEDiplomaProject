using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    #region MemberVariables
    private GameObject m_Crosshair;
    private UiManager m_Instance;
    private GameObject m_StartGameButton;
    #endregion MemberVariables
    #region Properties
    /// <summary>
    /// this is the Corsshair we're aiming with
    /// </summary>
    public GameObject Crosshair { get => m_Crosshair; set => m_Crosshair = value; }
    /// <summary>
    /// This Values is need for our singleton, so we have acces from everywhere
    /// </summary>
    public UiManager Instance { get => m_Instance; set => m_Instance = value; }
    /// <summary>
    /// This button will be used 2 start the game
    /// </summary>
    public GameObject StartGameButton { get => m_StartGameButton; set => m_StartGameButton = value; }
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
        m_StartGameButton = GameObject.Find("StartGame");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
