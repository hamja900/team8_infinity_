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

    //몬스터의 동작이 끝난후 동작하도록 추가해야함.
    #region Inputs
    //-------------move-----------
    public void OnQInput(InputAction.CallbackContext con)
    {
        if (con.phase == InputActionPhase.Started)
        {
            if (move.CanMove())
            {
                move.Move(Dir.q);
            }
        }
    }
    public void OnWInput(InputAction.CallbackContext con)
    {
        if (con.phase == InputActionPhase.Started)
        {
            if (move.CanMove())
            {
                move.Move(Dir.w);
            }
        }
    }
    public void OnEInput(InputAction.CallbackContext con)
    {
        if (con.phase == InputActionPhase.Started)
        {
            if (move.CanMove())
            {
                move.Move(Dir.e);
            }
        }
    }
    public void OnAInput(InputAction.CallbackContext con)
    {
        if (con.phase == InputActionPhase.Started)
        {
            if (move.CanMove())
            {
                move.Move(Dir.a);
            }
        }
    }
    public void OnDInput(InputAction.CallbackContext con)
    {
        if (con.phase == InputActionPhase.Started)
        {
            if (move.CanMove())
            {
                move.Move(Dir.d);
            }
        }
    }
    public void OnZInput(InputAction.CallbackContext con)
    {
        if (con.phase == InputActionPhase.Started)
        {
            if (move.CanMove())
            {
                move.Move(Dir.z);
            }
        }
    }
    public void OnXInput(InputAction.CallbackContext con)
    {
        if (con.phase == InputActionPhase.Started)
        {
            if (move.CanMove())
            {
                move.Move(Dir.x);
            }
        }
    }
    public void OnCInput(InputAction.CallbackContext con)
    {
        if (con.phase == InputActionPhase.Started)
        {
            if (move.CanMove())
            {
                move.Move(Dir.c);
            }
        }
    }
    //---------------Move----------
    //--------------Stop-----------
    public void OnSInput()
    {
    }
    //-------------Stop-----------
    //------------Attack---------
    public void OnRInput(InputAction.CallbackContext con)
    {
        if (con.phase == InputActionPhase.Started)
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
    #endregion
}
