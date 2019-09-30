using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region MemberVariables

    #endregion MemberVariables
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            UiManager.Instance.Inventory.SetActive(true);
            Time.timeScale = 0.1f;
            Screen.lockCursor = false;
        }
        else
        {
            UiManager.Instance.Inventory.SetActive(false);
            Time.timeScale = 1;
            Screen.lockCursor = true;
        }
    }

    //Sets the Active WeaponType
    public void SetWeaponType(int weaponType)
    {
        switch (weaponType)
        {
            case 0:
                if (GameManager.Instance.ActiveWeaponType != Enums.WeaponAttachment.Default)
                {
                    GameManager.Instance.ActiveWeaponType = Enums.WeaponAttachment.Default;
                    TriggerAnimation();
                }
                break;
            case 1:
                if (GameManager.Instance.ActiveWeaponType != Enums.WeaponAttachment.Grenade)
                {
                    GameManager.Instance.ActiveWeaponType = Enums.WeaponAttachment.Grenade;
                    TriggerAnimation();
                }
                break;
            case 2:
                if (GameManager.Instance.ActiveWeaponType != Enums.WeaponAttachment.Stasis)
                {
                    GameManager.Instance.ActiveWeaponType = Enums.WeaponAttachment.Stasis;
                    TriggerAnimation();
                }
                break;
            case 3:
                if (GameManager.Instance.ActiveWeaponType != Enums.WeaponAttachment.Welding)
                {
                    GameManager.Instance.ActiveWeaponType = Enums.WeaponAttachment.Welding;
                    TriggerAnimation();
                }
                break;
            default:
                break;
        }
    }

    private void TriggerAnimation()
    {
        Debug.Log("Trigger Animation");
    }
}
