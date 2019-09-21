using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    #region MemberVariables
    private GameObject m_Crosshair;
    private static UiManager m_Instance;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
