using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupManager : MonoBehaviour
{
    public GameObject popupA; //���,�˸� �˾�

    public GameObject popupB; //�����˾�

    public GameObject DeadPopup; //��� UI

    public static PopupManager instance;

    private void Awake()
    {
        instance = this;
    }
    
    public void popupForThrowEquipItem()
    {
        GameObject popup = Instantiate(popupA);
        Popups script = popup.GetComponent<Popups>();
        script.MainText.text = "���� ���� ���� ���� �� �����ϴ�.";
    }

    public void PopupForPlayerDead()
    {
        GameObject deadPopup = Instantiate(DeadPopup);
        Popups script = deadPopup.GetComponent<Popups>();
        script.MainText.text = "You're Dead";
    }
   
}
