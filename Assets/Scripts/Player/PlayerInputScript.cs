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
    public void On1()
    {

    }
    public void On2()
    {

    }
    public void On3()
    {

    }
    public void On4()
    {

    }
    public void On5()
    {

    }
    public void On6()
    {

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
