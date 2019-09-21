using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    #region MemberVariables
    private int m_Health;
    private int m_Oxigen;
    private int m_Ammo;
    #endregion MemberVariables
    #region Properties
    /// <summary>
    /// Health of Player
    /// </summary>
    public int Health { get => m_Health; set => m_Health = value; }
    /// <summary>
    /// Amount of Oxigen the Player has
    /// </summary>
    public int Oxigen { get => m_Oxigen; set => m_Oxigen = value; }
    /// <summary>
    /// Amount of Ammo the Player has
    /// </summary>
    public int Ammo { get => m_Ammo; set => m_Ammo = value; }
    #endregion Properties

    public Player(int health,int oxigen, int ammo) {
        m_Health = health;
        m_Oxigen = oxigen;
        m_Ammo = ammo;
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
