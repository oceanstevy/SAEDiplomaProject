using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UiManager.Instance.TestText.GetComponent<Text>().text = "This is the new Text"; //<- das ist der button den wir vorhin definiert haben
    }
}
