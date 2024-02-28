using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Popups : MonoBehaviour
{
    public TextMeshProUGUI MainText;

    public void OnQuitButton()
    {
        Destroy(gameObject);
    }

}
