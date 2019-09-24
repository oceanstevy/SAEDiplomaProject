using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region MemberVariables
    //Singleton
    private static GameManager m_Instance;

    //Overworld Values
    private List<GameObject> m_Enemies = new List<GameObject>();
    private List<GameObject> m_Items;
    private List<GameObject> m_Events;
    [SerializeField]private List<IntercomValue> m_IntercomMassages;
    private List<GameObject> m_Doors;

    //Player Values
    private Player m_Player;
    private GameObject m_Character;
    #endregion MemberVariables
    #region Properties
    /// <summary>
    /// List of Enemies in our Game
    /// </summary>
    public List<GameObject> Enemies { get => m_Enemies; set => m_Enemies = value; }
    /// <summary>
    /// List of Items in our Game, will be needed to see if we looted an item or not
    /// </summary>
    public List<GameObject> Items { get => m_Items; set => m_Items = value; }
    /// <summary>
    /// List of Events in our Game, well be needed to see if an Event was triggered allready
    /// </summary>
    public List<GameObject> Events { get => m_Events; set => m_Events = value; }
    /// <summary>
    /// This Values is need for our singleton, so we have acces from everywhere
    /// </summary>
    public static GameManager Instance { get => m_Instance; set => m_Instance = value; }
    /// <summary>
    /// Player Values like, health, ammo, etc
    /// </summary>
    public Player Player { get => m_Player; set => m_Player = value; }
    /// <summary>
    /// Collection of Intercom Messages
    /// </summary>
    public List<IntercomValue> IntercomMassages{ get => m_IntercomMassages; set => m_IntercomMassages = value; }
    /// <summary>
    /// Loads all doors of scene
    /// </summary>
    public List<GameObject> Doors { get => m_Doors; set => m_Doors = value; }
    /// <summary>
    /// Position of Player
    /// </summary>
    public GameObject Character { get => m_Character; set => m_Character = value; }

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

        //Initializes GameManagerValues
        Initialize();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Find Events
    private void Initialize()
    {
        //Searches every Enemy
        m_Enemies = new List<GameObject>();
        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
        {
            m_Enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        }

        //Searches every Item
        m_Items = new List<GameObject>();
        if (GameObject.FindGameObjectsWithTag("Item").Length > 0)
        {
            m_Items.AddRange(GameObject.FindGameObjectsWithTag("Item"));
        }

        //Searches every Event
        m_Events = new List<GameObject>();
        if (GameObject.FindGameObjectsWithTag("Event").Length > 0)
        {
            m_Events.AddRange(GameObject.FindGameObjectsWithTag("Event"));
        }

        //Searches every Door
        m_Doors = new List<GameObject>();
        if (GameObject.FindGameObjectsWithTag("Door").Length > 0)
        {
            m_Doors.AddRange(GameObject.FindGameObjectsWithTag("Door"));
        }

        m_Character = GameObject.FindGameObjectWithTag("Player");

        //Creates new Player
        Player = new Player(100, 100, 0);

        // Fill Intercom Messages
        GetIntercomMessages();
    }

    private void GetIntercomMessages()
    {
        IntercomMassages = new List<IntercomValue>();
        // First Audio Clip
        IntercomMassages.Add(new IntercomValue((AudioClip)Resources.Load("_Audioclip/Audio02"), "Anruf von Korrekte Typ", Resources.Load<Sprite>("_Icons/Audio01")));
        Debug.Log(IntercomMassages[0]);
    }
}
