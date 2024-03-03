using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupManager : MonoBehaviour
{
    public GameObject popupA; //경고,알림 팝업

    public GameObject popupB; //선택팝업

    public GameObject DeadPopup; //사망 UI

    public static PopupManager instance;

    private void Awake()
    {
        instance = this;
    }
    
    public void popupForThrowEquipItem()
    {
        GameObject popup = Instantiate(popupA);
        Popups script = popup.GetComponent<Popups>();
        script.MainText.text = "장착 중인 장비는 버릴 수 없습니다.";
    }

    public void PopupForPlayerDead()
    {
        GameObject deadPopup = Instantiate(DeadPopup);
        Popups script = deadPopup.GetComponent<Popups>();
        script.MainText.text = "You're Dead";
    }
   
}
