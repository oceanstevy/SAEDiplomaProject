using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    #region MemberVirables
    [Header("Item Type")]
    [SerializeField]
    private Enums.ItemType m_Type;
    [SerializeField]
    private Enums.Item m_Item;
    [SerializeField]
    private short m_Quantity;
    private Material m_Material;
    #endregion MemberVirables
    #region Properties
    /// <summary>
    /// What Item Type
    /// </summary>
    public Enums.ItemType Type { get => m_Type; set => m_Type = value; }
    /// <summary>
    /// What Kind of Item
    /// </summary>
    public Enums.Item Item { get => m_Item; set => m_Item = value; }
    /// <summary>
    /// The Amount from said Item
    /// </summary>
    public short Quantity { get => m_Quantity; set => m_Quantity = value; }
    /// <summary>
    /// 
    /// </summary>
    public Material Material { get => m_Material; set => m_Material = value; }
    #endregion Properties

    private Light SpotLight;

    private void Awake()
    {
        SpotLight = GetComponentInChildren<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            return;

        SpotLight.gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player")
            return;

        SpotLight.gameObject.SetActive(true);

    }
}
