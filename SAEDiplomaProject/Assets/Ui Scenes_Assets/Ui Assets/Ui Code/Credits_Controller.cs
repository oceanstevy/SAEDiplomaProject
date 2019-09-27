using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits_Controller : MonoBehaviour
{
    //The image from luca to be changed
    [SerializeField]
    private Image _Luca_Headshot;

    //the actual sprite for luca which should be in the credits menu
    [SerializeField]
    private Sprite _Luca_Real_Sprite;

    // the sprite for luca used as an easter egg
    [SerializeField]
    private Sprite _Luca_Fake_Sprite;

    //the biography to be changed
    [SerializeField]
    private Text _Luca_Bio;

    //The image from steven to be changed
    [SerializeField]
    private Image _Steven_Headshot;

    //the actual sprite for steven which should be in the credits menu
    [SerializeField]
    private Sprite _Steven_Real_Sprite;

    // the sprite for steven used as an easter egg
    [SerializeField]
    private Sprite _Steven_Fake_Sprite;

    //the biography to be changed
    [SerializeField]
    private Text _Steven_Bio;

    // controls whether the easter egg sprite is currently shown
    private bool _EasterEgg;

    private void Start()
    {
        _EasterEgg = false;
    }
    private void Update()
    {
        //switches the sprites witht eh press of the L key
        if (Input.GetKeyDown(KeyCode.L))
        {
            Pic_Switch();
        }
    }
    public void Pic_Switch()
    {
        //swaps out lucas real sprite for the easter egg
        if (_EasterEgg == false)
        {
            _EasterEgg = true;

            _Luca_Headshot.sprite = _Luca_Fake_Sprite;
            _Luca_Bio.text = "Drives much too quickly\n\nPretty decent DJ though";
            _Steven_Headshot.sprite = _Steven_Fake_Sprite;
            _Steven_Bio.text = "He will shown\n\nyou DA WAE";
            return;
        }
        //changes lucas easter egg back to the proper sprite
        if (_EasterEgg == true)
        {
            _EasterEgg = false;

            _Luca_Headshot.sprite = _Luca_Real_Sprite;
            _Luca_Bio.text = "Diploma and Bachelor student at SAE Institute. Produces\n\nmusic, and loves cats.";
            _Steven_Headshot.sprite = _Steven_Real_Sprite;
            _Steven_Bio.text = "Programming student at SAE in Köln. Skilled\n\nprogrammer, " +
                "is pretty convinced catching Pokemon is a job.";
            return;
        }
    }
}
