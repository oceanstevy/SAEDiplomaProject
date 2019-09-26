using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Controller : MonoBehaviour
{
    public GameObject _Menu_Panel;
    public GameObject _Help_Panel;
    public GameObject _Options_Panel;
    public GameObject _Credits_Panel;

    private void Start()
    {
        _Menu_Panel = GameObject.Find("MenuPanel");
        _Help_Panel = GameObject.Find("HelpPanel");
        _Options_Panel = GameObject.Find("OptionsPanel");
        _Credits_Panel = GameObject.Find("CreditsPanel");

        _Menu_Panel.SetActive(true);
        _Help_Panel.SetActive(false);
        _Options_Panel.SetActive(false);
        _Credits_Panel.SetActive(false);
    }

    public void Open_Menu()
    {
        _Menu_Panel.SetActive(true);
        _Help_Panel.SetActive(false);
        _Options_Panel.SetActive(false);
        _Credits_Panel.SetActive(false);
    }

    public void Open_Help()
    {
        _Menu_Panel.SetActive(false);
        _Help_Panel.SetActive(true);
        _Options_Panel.SetActive(false);
        _Credits_Panel.SetActive(false);
    }

    public void Open_Options()
    {
        _Menu_Panel.SetActive(false);
        _Help_Panel.SetActive(false);
        _Options_Panel.SetActive(true);
        _Credits_Panel.SetActive(false);
    }

    public void Open_Credits()
    {
        _Menu_Panel.SetActive(false);
        _Help_Panel.SetActive(false);
        _Options_Panel.SetActive(false);
        _Credits_Panel.SetActive(true);
    }
}
