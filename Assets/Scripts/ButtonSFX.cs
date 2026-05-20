using UnityEngine;
using TMPro;

public class ButtonSFX : MonoBehaviour
{
    AudioManager audioManager;


    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    
    public void ClickButtonSFX()
    {
        audioManager.Play2DSFX(audioManager.buttonClick);
    }

    public void ReturnButtonSFX()
    {
        audioManager.Play2DSFX(audioManager.buttonClickReturn);
    }

}
