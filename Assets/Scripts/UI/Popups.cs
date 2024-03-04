using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Popups : MonoBehaviour
{
    public TextMeshProUGUI MainText;

    public void OnQuitButton()
    {
        Destroy(gameObject);
    }

    public void OnMainSeceneButton()
    {
        DataManager.I.RemoveSaveData();
        SceneManager.LoadScene("StartScene");
    }

    public void OnRetryButton()
    {
        DataManager.I.RemoveSaveData();
        SceneManager.LoadScene("MainScene");
    }
}
