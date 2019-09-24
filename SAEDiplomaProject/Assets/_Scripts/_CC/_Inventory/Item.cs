using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    #region MemberVirables
    private string m_Name;
    private Image m_Icon;
    private int m_Value;
    private Material m_Material;
    #endregion MemberVirables
    #region Virables
    /// <summary>
    /// Item Name
    /// </summary>
    public string Name { get => m_Name; set => m_Name = value; }
    /// <summary>
    /// Item Icon
    /// </summary>
    public Image Icon { get => m_Icon; set => m_Icon = value; }
    /// <summary>
    /// 
    /// </summary>
    public int Value { get => m_Value; set => m_Value = value; }

    public Material Material { get => m_Material; set => m_Material = value; }
    #endregion Virables

    /// <summary>
    /// If player "enters" item to pick up
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        
    }

    /// <summary>
    /// If player "leaves" item to pick up
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        
    }
}
