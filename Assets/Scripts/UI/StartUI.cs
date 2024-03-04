using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    public GameObject buttons;
    public GameObject popup;
    public GameObject negativePopup;
    public string path;

    private void Awake()
    {
        path = Path.Combine(Application.dataPath, "database.json");
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            buttons.SetActive(true);
        }
    }

    public void StartAtFirst()
    {
        if(File.Exists(path))
        {
            popup.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("TutorialScene");
        }
    }

    public void Load()
    {
        if (!File.Exists(path))
        {
            negativePopup.SetActive(true);  
        }
        else
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    public void YesButton()
    {
        File.Delete(path);
        SceneManager.LoadScene("TutorialScene");
    }

    public void NoAndConfirmButton()
    {
        popup.SetActive(false);
        negativePopup.SetActive(false);
    }
}
