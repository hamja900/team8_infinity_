using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScene : MonoBehaviour
{
    [SerializeField] GameObject anyKeyInput;

    IEnumerator ShowText()
    {
        yield return new WaitForSeconds(5f);
        anyKeyInput.SetActive(true);
        if (Input.anyKey)
        {
            SceneManager.LoadScene("MainScene");
        }
    }
    private void Update()
    {
        StartCoroutine(ShowText());
    }
}
