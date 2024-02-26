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
    public void OnQInput(InputAction.CallbackContext con)
    {
        if (con.phase == InputActionPhase.Started)
        {
            if (move.CanMove())
            {
                move.Move(Dir.q, this);
            }
        }
    }
    public void OnWInput(InputAction.CallbackContext con)
    {
        if (con.phase == InputActionPhase.Started)
        {
            if (move.CanMove())
            {
                move.Move(Dir.w,this);
            }
        }
    }
    public void OnEInput(InputAction.CallbackContext con)
    {
        if (con.phase == InputActionPhase.Started)
        {
            if (move.CanMove())
            {
                move.Move(Dir.e, this);
            }
        }
    }
    public void OnAInput(InputAction.CallbackContext con)
    {
        if (con.phase == InputActionPhase.Started)
        {
            if (move.CanMove())
            {
                move.Move(Dir.a, this);
            }
        }
    }
    public void OnDInput(InputAction.CallbackContext con)
    {
        if (con.phase == InputActionPhase.Started)
        {
            if (move.CanMove())
            {
                move.Move(Dir.d, this);
            }
        }
    }
    public void OnZInput(InputAction.CallbackContext con)
    {
        if (con.phase == InputActionPhase.Started)
        {
            if (move.CanMove())
            {
                move.Move(Dir.z, this);
            }
        }
    }
    public void OnXInput(InputAction.CallbackContext con)
    {
        if (con.phase == InputActionPhase.Started)
        {
            if (move.CanMove())
            {
                move.Move(Dir.x, this);
            }
        }
    }
    public void OnCInput(InputAction.CallbackContext con)
    {
        if (con.phase == InputActionPhase.Started)
        {
            if (move.CanMove())
            {
                move.Move(Dir.c, this);
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
    public void OnRInput()
    {
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
    #endregion
}
