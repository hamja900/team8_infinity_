using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public ItemSO itemSO;
    public Transform player;


    private void Start()
    {
        player = HUD.instance.player.transform;
        GameManager.I.ItemList.Add(this.gameObject);
    }
    public void GetItem()
    {
        float distance = Vector2.Distance(player.position,transform.position); 
        if (distance <= 1)
        {
            if (Inventory.instance == null)
            {
                HUD.instance.OnInventoryButton();
                StartCoroutine(WaitForInven());
                return;
            }
            SoundManager.I.Play(SfxIndex.PickUpSound);
            Inventory.instance.AddItem(itemSO);
            GameManager.I.ItemList.Remove(this.gameObject);
            Destroy(gameObject);
        }
    }
    IEnumerator WaitForInven()
    {
        yield return null;
        SoundManager.I.Play(SfxIndex.PickUpSound);
        Inventory.instance.AddItem(itemSO);
        HUD.instance.inventoryParent.transform.GetChild(0).gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
