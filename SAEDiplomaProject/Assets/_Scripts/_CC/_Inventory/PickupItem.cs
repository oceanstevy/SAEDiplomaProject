using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    #region MemberVirables
    private Enums.Item m_Item;
    private Enums.ItemType m_Type;
    private short m_Quantity;
    private Material m_Material;
    #endregion MemberVirables
    #region Properties
    /// <summary>
    /// What Kind of Item
    /// </summary>
    public Enums.Item Item { get => m_Item; set => m_Item = value; }
    /// <summary>
    /// What Item Type
    /// </summary>
    public Enums.ItemType Type { get => m_Type; set => m_Type = value; }
    /// <summary>
    /// The Amount from said Item
    /// </summary>
    public short Quantity { get => m_Quantity; set => m_Quantity = value; }
    /// <summary>
    /// 
    /// </summary>
    public Material Material { get => m_Material; set => m_Material = value; }
    #endregion Properties

    private Renderer ObjectRenderer;
    private Material OriginalMaterial;

    private void Awake()
    {
        ObjectRenderer = GetComponent<Renderer>();
        OriginalMaterial = GetComponent<Material>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ObjectRenderer.material = OriginalMaterial;
    }

    private void OnTriggerExit(Collider other)
    {
        ObjectRenderer.material = m_Material;
    }
}
