using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    public Slider volumeSlider;
    public GameObject optionWindow;

 
    public void Update()
    {
         SoundManager.I.volume = volumeSlider.value;
    }

    public void OnMainMenuButton()
    {
        DataManager.I.JsonSave();
        SceneManager.LoadScene("StartScene");
    }
    public void OnQuitOption()
    {
        optionWindow.SetActive(false);
    }




}
