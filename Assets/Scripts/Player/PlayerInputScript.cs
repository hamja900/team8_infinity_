using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum Dir
{
    q, w, e,
    a, d,
    z, x, c
}

public class PlayerInputScript : MonoBehaviour
{
    PlayerAttack attack;
    PlayerMove move;
    private void Awake()
    {
        move = GetComponent<PlayerMove>();
        attack = GetComponent<PlayerAttack>();
    }
    #region Inputs
    //-------------move-----------
    public void OnQ()
    {
        if (TuenManager.I.isPlayerTurn)
        {
            move.CanMove(Dir.q);
        }
    }
    public void OnW()
    {
        if (TuenManager.I.isPlayerTurn)
        {
            move.CanMove(Dir.w);
        }
    }
    public void OnE()
    {
        if (TuenManager.I.isPlayerTurn)
        {
            move.CanMove(Dir.e);
        }
    }
    public void OnA()
    {
        if (TuenManager.I.isPlayerTurn)
        {
            move.CanMove(Dir.a);
        }
    }
    public void OnD()
    {
        if (TuenManager.I.isPlayerTurn)
        {
            move.CanMove(Dir.d);
        }
    }
    public void OnZ()
    {
        if (TuenManager.I.isPlayerTurn)
        {
            move.CanMove(Dir.z);
        }
    }
    public void OnX()
    {
        if (TuenManager.I.isPlayerTurn)
        {
            move.CanMove(Dir.x);
        }
    }
    public void OnC()
    {
        if (TuenManager.I.isPlayerTurn)
        {
            move.CanMove(Dir.c);
        }
    }
    //---------------Move----------
    //--------------Stop-----------
    public void OnS()
    {
        if (TuenManager.I.isPlayerTurn)
        {
            TuenManager.I.PlayerTurns(10);
        }
    }
    //-------------Stop-----------
    //------------Attack---------
    public void OnR()
    {
        if (TuenManager.I.isPlayerTurn)
        {
            attack.CanAttack();
        }
    }
    public void OnF() //targetChange
    {
        attack.ChangeTarget();
    }
    //---------Attack-----------
    //-----------Toolbar---------
    public void On_1()
    {
        if (HUD.instance.hotKey[0] == null || HUD.instance.hotKey[0].items == null)
        {
            return;
        }
        Inventory.instance.OnUsebutton(0);
    }
    public void On_2()
    {
        if (HUD.instance.hotKey[1] == null || HUD.instance.hotKey[1].items == null)
        {
            return;
        }
        Inventory.instance.OnUsebutton(1);
    }
    public void On_3()
    {
        if (HUD.instance.hotKey[2] == null || HUD.instance.hotKey[2].items == null)
        {
            return;
        }
        Inventory.instance.OnUsebutton(2);
    }
    public void On_4()
    {
        if (HUD.instance.hotKey[3] == null || HUD.instance.hotKey[3].items == null)
        {
            return;
        }
        Inventory.instance.OnUsebutton(3);
    }
    public void On_5()
    {
        if (HUD.instance.hotKey[4] == null || HUD.instance.hotKey[4].items == null)
        {
            return;
        }
        Inventory.instance.OnUsebutton(4);
    }
    public void On_6()
    {
        if (HUD.instance.hotKey[5] == null || HUD.instance.hotKey[5].items == null)
        {
            return;
        }
        Inventory.instance.OnUsebutton(5);
    }
    public void On_7()
    {
        if (HUD.instance.hotKey[6] == null || HUD.instance.hotKey[6].items == null)
        {
            return;
        }
        Inventory.instance.OnUsebutton(6);
    }
    public void On_8()
    {
        if (HUD.instance.hotKey[7] == null || HUD.instance.hotKey[7].items == null)
        {
            return;
        }
        Inventory.instance.OnUsebutton(7);
    }
    //---------Toolbar---------
    //---------PickUp---------
    public void OnV()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 0.1f, LayerMask.GetMask("Item"));
        if (hit.transform != null)
        {
            hit.transform.gameObject.GetComponent<ItemScript>().GetItem();
        }
    }
    #endregion
}
