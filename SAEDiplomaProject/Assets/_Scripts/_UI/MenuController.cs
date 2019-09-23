using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    private GameObject m_MenuPanel;
    private GameObject m_CreditsPanel;
    private GameObject m_OptionsPanel;
    private GameObject m_HelpPanel;

    /// <summary>
    /// This is the main menu panel
    /// </summary>
    public GameObject MenuPanel { get => m_MenuPanel; set => m_MenuPanel = value; }
    /// <summary>
    /// This is the Credits panel containing development credits
    /// </summary>
    public GameObject CreditsPanel { get => m_CreditsPanel; set => m_CreditsPanel = value; }
    /// <summary>
    /// This is the options panel, used to change game settings
    /// </summary>
    public GameObject OptionsPanel { get => m_OptionsPanel; set => m_OptionsPanel = value; }
    /// <summary>
    /// This is the help panel, containing usefull game information
    /// </summary>
    public GameObject HelpPanel { get => m_HelpPanel; set => m_HelpPanel = value; }

    // Start is called before the first frame update
    void Start()
    {
        MenuPanel = GameObject.Find("MenuPanel");
        CreditsPanel = GameObject.Find("CreditsPanel");
        OptionsPanel = GameObject.Find("OptionsPanel");
        HelpPanel = GameObject.Find("HelpPanel");
        CreditsPanel.SetActive(false);
        OptionsPanel.SetActive(false);
        HelpPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //UiManager.Instance.TestText.GetComponent<Text>().text = "This is the new Text"; //<- das ist der button den wir vorhin definiert haben
    }

    //Open Menu Panel
    public void OpenMenuPanel()
    {
        MenuPanel.SetActive(true);
        CreditsPanel.SetActive(false);
        OptionsPanel.SetActive(false);
        HelpPanel.SetActive(false);
    }

    //Open Options Panel
    public void OpenOptionsPanel()
    {
        MenuPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        OptionsPanel.SetActive(true);
        HelpPanel.SetActive(false);
    }

    //Open Credits Panel
    public void OpenCreditsPanel()
    {
        MenuPanel.SetActive(false);
        CreditsPanel.SetActive(true);
        OptionsPanel.SetActive(false);
        HelpPanel.SetActive(false);
    }

    //Open Help Panel
    public void OpenHelpPanel()
    {
        MenuPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        OptionsPanel.SetActive(false);
        HelpPanel.SetActive(true);
    }

    // Leaves the game
    public void ExitGame()
    {
        Application.Quit();
    }
}
