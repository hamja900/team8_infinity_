using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    [Range(0f,1f)]public float volume;
    public Slider volumeSlider;
    public GameObject optionWindow;

    private void Start()
    {
        volumeSlider.value = volume;
    }

    public void OnMainMenuButton()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void OnQuitOption()
    {
        optionWindow.SetActive(false);
    }




}
