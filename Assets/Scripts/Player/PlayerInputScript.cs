using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum Dir
{
    q,w,e,
    a,d,
    z,x,c
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
    public void OnQInput(InputAction.CallbackContext con)
    {
        if (con.phase == InputActionPhase.Started && TuenManager.I.isPlayerTurn)
        {
            move.CanMove(Dir.q);
        }
    }
    public void OnWInput(InputAction.CallbackContext con)
    {
        if (con.phase == InputActionPhase.Started && TuenManager.I.isPlayerTurn)
        {
            move.CanMove(Dir.w);
        }
    }
    public void OnEInput(InputAction.CallbackContext con)
    {
        if (con.phase == InputActionPhase.Started && TuenManager.I.isPlayerTurn)
        {
            move.CanMove(Dir.e);
        }
    }
    public void OnAInput(InputAction.CallbackContext con)
    {
        if (con.phase == InputActionPhase.Started && TuenManager.I.isPlayerTurn)
        {
            move.CanMove(Dir.a);
        }
    }
    public void OnDInput(InputAction.CallbackContext con)
    {
        if (con.phase == InputActionPhase.Started && TuenManager.I.isPlayerTurn)
        {
            move.CanMove(Dir.d);
        }
    }
    public void OnZInput(InputAction.CallbackContext con)
    {
        if (con.phase == InputActionPhase.Started && TuenManager.I.isPlayerTurn)
        {
            move.CanMove(Dir.z);
        }
    }
    public void OnXInput(InputAction.CallbackContext con)
    {
        if (con.phase == InputActionPhase.Started && TuenManager.I.isPlayerTurn)
        {
            move.CanMove(Dir.x);
        }
    }
    public void OnCInput(InputAction.CallbackContext con)
    {
        if (con.phase == InputActionPhase.Started && TuenManager.I.isPlayerTurn)
        {
            move.CanMove(Dir.c);
        }
    }
    //---------------Move----------
    //--------------Stop-----------
    public void OnSInput(InputAction.CallbackContext con)
    {
        if (con.phase == InputActionPhase.Started && TuenManager.I.isPlayerTurn)
        {
            TuenManager.I.PlayerTurns(10);
        }
    }
    //-------------Stop-----------
    //------------Attack---------
    public void OnRInput(InputAction.CallbackContext con)
    {
        if (con.phase == InputActionPhase.Started && TuenManager.I.isPlayerTurn)
        {
            attack.CanAttack();
        }
    }
    public void OnFInput(InputAction.CallbackContext con) //targetChange
    {
        if (con.phase == InputActionPhase.Started)
        {
            attack.ChangeTarget();
        }
    }
    //---------Attack-----------
    //-----------Toolbar---------
    public void On1Input()
    {

    }
    public void On2Input()
    {

    }
    public void On3Input()
    {

    }
    public void On4Input()
    {

    }
    public void On5Input()
    {

    }
    public void On6Input()
    {

    }
    //---------Toolbar---------
    //---------PickUp---------
    public void OnVInput(InputAction.CallbackContext con)
    {
        if (con.phase == InputActionPhase.Started)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.zero,0.1f,LayerMask.GetMask("Item"));
            if (hit.transform != null)
            {
                hit.transform.gameObject.GetComponent<ItemScript>().GetItem();
            }
        }
    }
    #endregion
}
