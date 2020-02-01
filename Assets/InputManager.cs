using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    // Events
    public UnityEvent On_P3_LS_UP_Click = new UnityEvent();
    public UnityEvent On_P3_LS_DOWN_Click = new UnityEvent();
    public UnityEvent On_P3_LS_LEFT_Click = new UnityEvent();
    public UnityEvent On_P3_LS_RIGHT_Click = new UnityEvent();
    public UnityEvent On_P3_DPAD_UP_Click = new UnityEvent();
    public UnityEvent On_P3_DPAD_DOWN_Click = new UnityEvent();
    public UnityEvent On_P3_DPAD_LEFT_Click = new UnityEvent();
    public UnityEvent On_P3_DPAD_RIGHT_Click = new UnityEvent();
    public UnityEvent On_P3_LB_Click = new UnityEvent();
    public UnityEvent On_P3_LT_Click = new UnityEvent();
    public UnityEvent On_P3_RB_Click = new UnityEvent();
    public UnityEvent On_P3_RT_Click = new UnityEvent();
    public UnityEvent On_P3_KEYUP_Click = new UnityEvent();
    public UnityEvent On_P3_KEYDOWN_Click = new UnityEvent();
    public UnityEvent On_P3_KEYLEFT_Click = new UnityEvent();
    public UnityEvent On_P3_KEYRIGHT_Click = new UnityEvent();
    //==================================
    public UnityEvent On_P2_LS_UP_Click = new UnityEvent();
    public UnityEvent On_P2_LS_DOWN_Click = new UnityEvent();
    public UnityEvent On_P2_LS_LEFT_Click = new UnityEvent();
    public UnityEvent On_P2_LS_RIGHT_Click = new UnityEvent();
    public UnityEvent On_P2_DPAD_UP_Click = new UnityEvent();
    public UnityEvent On_P2_DPAD_DOWN_Click = new UnityEvent();
    public UnityEvent On_P2_DPAD_LEFT_Click = new UnityEvent();
    public UnityEvent On_P2_DPAD_RIGHT_Click = new UnityEvent();
    public UnityEvent On_P2_LB_Click = new UnityEvent();
    public UnityEvent On_P2_LT_Click = new UnityEvent();
    public UnityEvent On_P2_RB_Click = new UnityEvent();
    public UnityEvent On_P2_RT_Click = new UnityEvent();
    public UnityEvent On_P2_KEYUP_Click = new UnityEvent();
    public UnityEvent On_P2_KEYDOWN_Click = new UnityEvent();
    public UnityEvent On_P2_KEYLEFT_Click = new UnityEvent();
    public UnityEvent On_P2_KEYRIGHT_Click = new UnityEvent();

    // ButtonDownReady
    private bool P3_LS_V_BtnDownRdy = true;
    private bool P3_LS_H_BtnDownRdy = true;
    private bool P3_DPAD_V_BtnDownRdy = true;
    private bool P3_DPAD_H_BtnDownRdy = true;
    //==================================
    private bool P2_LS_V_BtnDownRdy = true;
    private bool P2_LS_H_BtnDownRdy = true;
    private bool P2_DPAD_V_BtnDownRdy = true;
    private bool P2_DPAD_H_BtnDownRdy = true; 
    private bool P2_LT_BtnDownRdy = true;
    private bool P2_RT_BtnDownRdy = true;


    public static InputManager instance;

    private void OnEnable()
    {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        On_P3_LS_UP_Click.AddListener(delegate { Debug.Log("On_P3_LS_UP_Click"); });
        On_P3_LS_DOWN_Click.AddListener(delegate { Debug.Log("On_P3_LS_DOWN_Click"); });
        On_P3_LS_LEFT_Click.AddListener(delegate { Debug.Log("On_P3_LS_LEFT_Click"); });
        On_P3_LS_RIGHT_Click.AddListener(delegate { Debug.Log("On_P3_LS_RIGHT_Click"); });

        On_P3_DPAD_UP_Click.AddListener(delegate { Debug.Log("On_P3_DPAD_UP_Click"); });
        On_P3_DPAD_DOWN_Click.AddListener(delegate { Debug.Log("On_P3_DPAD_DOWN_Click"); });
        On_P3_DPAD_LEFT_Click.AddListener(delegate { Debug.Log("On_P3_DPAD_LEFT_Click"); });
        On_P3_DPAD_RIGHT_Click.AddListener(delegate { Debug.Log("On_P3_DPAD_RIGHT_Click"); });

        On_P3_LB_Click.AddListener(delegate { Debug.Log("On_P3_LB_Click"); });
        On_P3_LT_Click.AddListener(delegate { Debug.Log("On_P3_LT_Click"); });
        On_P3_RB_Click.AddListener(delegate { Debug.Log("On_P3_RB_Click"); });
        On_P3_RT_Click.AddListener(delegate { Debug.Log("On_P3_RT_Click"); });

        On_P3_KEYUP_Click.AddListener(delegate { Debug.Log("On_P3_KEYUP_Click"); });
        On_P3_KEYDOWN_Click.AddListener(delegate { Debug.Log("On_P3_KEYDOWN_Click"); });
        On_P3_KEYLEFT_Click.AddListener(delegate { Debug.Log("On_P3_KEYLEFT_Click"); });
        On_P3_KEYRIGHT_Click.AddListener(delegate { Debug.Log("On_P3_KEYRIGHT_Click"); });

        //==================================

        On_P2_LS_UP_Click.AddListener(delegate { Debug.Log("On_P2_LS_UP_Click"); });
        On_P2_LS_DOWN_Click.AddListener(delegate { Debug.Log("On_P2_LS_DOWN_Click"); });
        On_P2_LS_LEFT_Click.AddListener(delegate { Debug.Log("On_P2_LS_LEFT_Click"); });
        On_P2_LS_RIGHT_Click.AddListener(delegate { Debug.Log("On_P2_LS_RIGHT_Click"); });

        On_P2_DPAD_UP_Click.AddListener(delegate { Debug.Log("On_P2_DPAD_UP_Click"); });
        On_P2_DPAD_DOWN_Click.AddListener(delegate { Debug.Log("On_P2_DPAD_DOWN_Click"); });
        On_P2_DPAD_LEFT_Click.AddListener(delegate { Debug.Log("On_P2_DPAD_LEFT_Click"); });
        On_P2_DPAD_RIGHT_Click.AddListener(delegate { Debug.Log("On_P2_DPAD_RIGHT_Click"); });

        On_P2_LB_Click.AddListener(delegate { Debug.Log("On_P2_LB_Click"); });
        On_P2_LT_Click.AddListener(delegate { Debug.Log("On_P2_LT_Click"); });
        On_P2_RB_Click.AddListener(delegate { Debug.Log("On_P2_RB_Click"); });
        On_P2_RT_Click.AddListener(delegate { Debug.Log("On_P2_RT_Click"); });

        On_P2_KEYUP_Click.AddListener(delegate { Debug.Log("On_P2_KEYUP_Click"); });
        On_P2_KEYDOWN_Click.AddListener(delegate { Debug.Log("On_P2_KEYDOWN_Click"); });
        On_P2_KEYLEFT_Click.AddListener(delegate { Debug.Log("On_P2_KEYLEFT_Click"); });
        On_P2_KEYRIGHT_Click.AddListener(delegate { Debug.Log("On_P2_KEYRIGHT_Click"); });
    }

    private void Update()
    {
        ProcessP3ControllerKeys();
        ProcessP2ControllerKeys();
    }

    private void ProcessP2ControllerKeys()
    {
        if (Input.GetAxis("P2_LS_V") != 0)
        {
            if (!P2_LS_V_BtnDownRdy)
            {
                if (Input.GetAxis("P2_LS_V") > 0)
                    On_P2_LS_UP_Click.Invoke();
                else
                    On_P2_LS_DOWN_Click.Invoke();

                P2_LS_V_BtnDownRdy = false;
            }
        }
        else
            P2_LS_V_BtnDownRdy = true;


        if (Input.GetAxis("P2_LS_H") != 0)
        {
            if (P2_LS_H_BtnDownRdy)
            {
                if (Input.GetAxis("P2_LS_H") > 0)
                    On_P2_LS_RIGHT_Click.Invoke();
                else
                    On_P2_LS_LEFT_Click.Invoke();

                P2_LS_H_BtnDownRdy = false;
            }
        }
        else
            P2_LS_H_BtnDownRdy = true;

        if (Input.GetAxis("P2_LS_V") != 0)
        {
            if (P2_LS_V_BtnDownRdy)
            {
                if (Input.GetAxis("P2_LS_V") > 0)
                    On_P2_LS_UP_Click.Invoke();
                else
                    On_P2_LS_DOWN_Click.Invoke();

                P2_LS_V_BtnDownRdy = false;
            }
        }
        else
            P2_LS_V_BtnDownRdy = true;


        if (Input.GetAxis("P2_LS_H") != 0)
        {
            if (P2_LS_H_BtnDownRdy)
            {
                if (Input.GetAxis("P2_LS_H") > 0)
                    On_P2_LS_RIGHT_Click.Invoke();
                else
                    On_P2_LS_LEFT_Click.Invoke();

                P2_LS_H_BtnDownRdy = false;
            }
        }
        else
            P2_LS_H_BtnDownRdy = true;


        if (Input.GetAxis("P2_DPAD_V") != 0)
        {
            if (P2_DPAD_V_BtnDownRdy)
            {
                if (Input.GetAxis("P2_DPAD_V") > 0)
                    On_P2_DPAD_UP_Click.Invoke();
                else
                    On_P2_DPAD_DOWN_Click.Invoke();

                P2_DPAD_V_BtnDownRdy = false;
            }
        }
        else
            P2_DPAD_V_BtnDownRdy = true;


        if (Input.GetAxis("P2_DPAD_H") != 0)
        {
            if (P2_DPAD_H_BtnDownRdy)
            {
                if (Input.GetAxis("P2_DPAD_H") > 0)
                    On_P2_DPAD_RIGHT_Click.Invoke();
                else
                    On_P2_DPAD_LEFT_Click.Invoke();

                P2_DPAD_H_BtnDownRdy = false;
            }
        }
        else
            P2_DPAD_H_BtnDownRdy = true;

        if (Input.GetButtonDown("P2_LB")) On_P2_LB_Click.Invoke();

        if (Input.GetAxis("P2_LT") != 0)
        {
            if (P2_LT_BtnDownRdy)
            {
                On_P2_LT_Click.Invoke();
                P2_LT_BtnDownRdy = false;
            }
        }
        else
            P2_LT_BtnDownRdy = true;

        if (Input.GetButtonDown("P2_RB")) On_P2_RB_Click.Invoke();

        if (Input.GetAxis("P2_RT") != 0)
        {
            if (P2_RT_BtnDownRdy)
            {
                On_P2_RT_Click.Invoke();
                P2_RT_BtnDownRdy = false;
            }
        }
        else
            P2_RT_BtnDownRdy = true;

        if (Input.GetButtonDown("P2_KEYUP")) On_P2_KEYUP_Click.Invoke();
        if (Input.GetButtonDown("P2_KEYDOWN")) On_P2_KEYDOWN_Click.Invoke();
        if (Input.GetButtonDown("P2_KEYLEFT")) On_P2_KEYLEFT_Click.Invoke();
        if (Input.GetButtonDown("P2_KEYRIGHT")) On_P2_KEYRIGHT_Click.Invoke();
    }

    private void ProcessP3ControllerKeys()
    {
        if (Input.GetAxis("P3_LS_V") != 0)
        {
            if (P3_LS_V_BtnDownRdy)
            {
                if (Input.GetAxis("P3_LS_V") > 0)
                    On_P3_LS_UP_Click.Invoke();
                else
                    On_P3_LS_DOWN_Click.Invoke();

                P3_LS_V_BtnDownRdy = false;
            }
        }
        else
            P3_LS_V_BtnDownRdy = true;


        if (Input.GetAxis("P3_LS_H") != 0)
        {
            if (P3_LS_H_BtnDownRdy)
            {
                if (Input.GetAxis("P3_LS_H") > 0)
                    On_P3_LS_RIGHT_Click.Invoke();
                else
                    On_P3_LS_LEFT_Click.Invoke();

                P3_LS_H_BtnDownRdy = false;
            }
        }
        else
            P3_LS_H_BtnDownRdy = true;

        if (Input.GetAxis("P3_LS_V") != 0)
        {
            if (P3_LS_V_BtnDownRdy)
            {
                if (Input.GetAxis("P3_LS_V") > 0)
                    On_P3_LS_UP_Click.Invoke();
                else
                    On_P3_LS_DOWN_Click.Invoke();

                P3_LS_V_BtnDownRdy = false;
            }
        }
        else
            P3_LS_V_BtnDownRdy = true;


        if (Input.GetAxis("P3_LS_H") != 0)
        {
            if (P3_LS_H_BtnDownRdy)
            {
                if (Input.GetAxis("P3_LS_H") > 0)
                    On_P3_LS_RIGHT_Click.Invoke();
                else
                    On_P3_LS_LEFT_Click.Invoke();

                P3_LS_H_BtnDownRdy = false;
            }
        }
        else
            P3_LS_H_BtnDownRdy = true;


        if (Input.GetAxis("P3_DPAD_V") != 0)
        {
            if (P3_DPAD_V_BtnDownRdy)
            {
                if (Input.GetAxis("P3_DPAD_V") > 0)
                    On_P3_DPAD_UP_Click.Invoke();
                else
                    On_P3_DPAD_DOWN_Click.Invoke();

                P3_DPAD_V_BtnDownRdy = false;
            }
        }
        else
            P3_DPAD_V_BtnDownRdy = true;


        if (Input.GetAxis("P3_DPAD_H") != 0)
        {
            if (P3_DPAD_H_BtnDownRdy)
            {
                if (Input.GetAxis("P3_DPAD_H") > 0)
                    On_P3_DPAD_RIGHT_Click.Invoke();
                else
                    On_P3_DPAD_LEFT_Click.Invoke();

                P3_DPAD_H_BtnDownRdy = false;
            }
        }
        else
            P3_DPAD_H_BtnDownRdy = true;

        if (Input.GetButtonDown("P3_LB")) On_P3_LB_Click.Invoke();
        if (Input.GetButtonDown("P3_LT")) On_P3_LT_Click.Invoke();
        if (Input.GetButtonDown("P3_RB")) On_P3_RB_Click.Invoke();
        if (Input.GetButtonDown("P3_RT")) On_P3_RT_Click.Invoke();

        if (Input.GetButtonDown("P3_KEYUP")) On_P3_KEYUP_Click.Invoke();
        if (Input.GetButtonDown("P3_KEYDOWN")) On_P3_KEYDOWN_Click.Invoke();
        if (Input.GetButtonDown("P3_KEYLEFT")) On_P3_KEYLEFT_Click.Invoke();
        if (Input.GetButtonDown("P3_KEYRIGHT")) On_P3_KEYRIGHT_Click.Invoke();
    }
}