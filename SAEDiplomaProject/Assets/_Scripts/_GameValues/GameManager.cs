using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region MemberVariables
    //Singleton
    private static GameManager m_Instance;

    //Overworld Values
    private List<GameObject> m_Enemies;
    private List<GameObject> m_Items;
    private List<GameObject> m_Events;

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

        //Searches every Enemy
        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
        {
            m_Enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        }

        //Searches every Enemy
        if (GameObject.FindGameObjectsWithTag("Item").Length > 0)
        {
            m_Items.AddRange(GameObject.FindGameObjectsWithTag("Item"));
        }

        //Searches every Enemy
        if (GameObject.FindGameObjectsWithTag("Item").Length > 0)
        {
            m_Events.AddRange(GameObject.FindGameObjectsWithTag("Event"));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }
}
