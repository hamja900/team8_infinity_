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
    }
    public void GetItem()
    {
        float distance = Vector2.Distance(player.position,transform.position); 
        if (distance <= 1)
        {
            Inventory.instance.AddItem(itemSO);
            Destroy(gameObject);
        }
    }
}
