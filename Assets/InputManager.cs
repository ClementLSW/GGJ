using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    // Events
    [HideInInspector] public UnityEvent On_P1_DPAD_UP_Click = new UnityEvent();
    [HideInInspector] public UnityEvent On_P1_DPAD_DOWN_Click = new UnityEvent();
    [HideInInspector] public UnityEvent On_P1_DPAD_LEFT_Click = new UnityEvent();
    [HideInInspector] public UnityEvent On_P1_DPAD_RIGHT_Click = new UnityEvent();
    [HideInInspector] public UnityEvent On_P1_LB_Click = new UnityEvent();
    [HideInInspector] public UnityEvent On_P1_LT_Click = new UnityEvent();
    [HideInInspector] public UnityEvent On_P1_RB_Click = new UnityEvent();
    [HideInInspector] public UnityEvent On_P1_RT_Click = new UnityEvent();
    [HideInInspector] public UnityEvent On_P1_KEYUP_Click = new UnityEvent();
    [HideInInspector] public UnityEvent On_P1_KEYDOWN_Click = new UnityEvent();
    [HideInInspector] public UnityEvent On_P1_KEYLEFT_Click = new UnityEvent();
    [HideInInspector] public UnityEvent On_P1_KEYRIGHT_Click = new UnityEvent();

    [HideInInspector] public UnityEvent On_P2_DPAD_UP_Click = new UnityEvent();
    [HideInInspector] public UnityEvent On_P2_DPAD_DOWN_Click = new UnityEvent();
    [HideInInspector] public UnityEvent On_P2_DPAD_LEFT_Click = new UnityEvent();
    [HideInInspector] public UnityEvent On_P2_DPAD_RIGHT_Click = new UnityEvent();
    [HideInInspector] public UnityEvent On_P2_LB_Click = new UnityEvent();
    [HideInInspector] public UnityEvent On_P2_LT_Click = new UnityEvent();
    [HideInInspector] public UnityEvent On_P2_RB_Click = new UnityEvent();
    [HideInInspector] public UnityEvent On_P2_RT_Click = new UnityEvent();
    [HideInInspector] public UnityEvent On_P2_KEYUP_Click = new UnityEvent();
    [HideInInspector] public UnityEvent On_P2_KEYDOWN_Click = new UnityEvent();
    [HideInInspector] public UnityEvent On_P2_KEYLEFT_Click = new UnityEvent();
    [HideInInspector] public UnityEvent On_P2_KEYRIGHT_Click = new UnityEvent();


    public static InputManager instance;

    private void OnEnable()
    {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);

        On_P1_DPAD_UP_Click.AddListener(delegate { Debug.Log("On_P1_DPAD_UP_Click"); });
        On_P1_DPAD_DOWN_Click.AddListener(delegate { Debug.Log("On_P1_DPAD_DOWN_Click"); });
        On_P1_DPAD_LEFT_Click.AddListener(delegate { Debug.Log("On_P1_DPAD_LEFT_Click"); });
        On_P1_DPAD_RIGHT_Click.AddListener(delegate { Debug.Log("On_P1_DPAD_RIGHT_Click"); });

        On_P1_LB_Click.AddListener(delegate { Debug.Log("On_P1_LB_Click"); });
        On_P1_LT_Click.AddListener(delegate { Debug.Log("On_P1_LT_Click"); });
        On_P1_RB_Click.AddListener(delegate { Debug.Log("On_P1_RB_Click"); });
        On_P1_RT_Click.AddListener(delegate { Debug.Log("On_P1_RT_Click"); });

        On_P1_KEYUP_Click.AddListener(delegate { Debug.Log("On_P1_KEYUP_Click"); });
        On_P1_KEYDOWN_Click.AddListener(delegate { Debug.Log("On_P1_KEYDOWN_Click"); });
        On_P1_KEYLEFT_Click.AddListener(delegate { Debug.Log("On_P1_KEYLEFT_Click"); });
        On_P1_KEYRIGHT_Click.AddListener(delegate { Debug.Log("On_P1_KEYRIGHT_Click"); });


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

        Debug.Log("Controllers: " + Gamepad.all.Count);
    }

    private void Update()
    {
        ProcessControllerKeys();
    }

    private void ProcessControllerKeys()
    {
        if (Gamepad.all[0].dpad.up.wasPressedThisFrame)
            On_P1_DPAD_UP_Click.Invoke();

        if (Gamepad.all[0].dpad.down.wasPressedThisFrame)
            On_P1_DPAD_DOWN_Click.Invoke();

        if (Gamepad.all[0].dpad.left.wasPressedThisFrame)
            On_P1_DPAD_LEFT_Click.Invoke();

        if (Gamepad.all[0].dpad.right.wasPressedThisFrame)
            On_P1_DPAD_RIGHT_Click.Invoke();


        if (Gamepad.all[0].leftShoulder.wasPressedThisFrame)
            On_P1_LB_Click.Invoke();

        if (Gamepad.all[0].rightShoulder.wasPressedThisFrame)
            On_P1_RB_Click.Invoke();

        if (Gamepad.all[0].leftTrigger.wasPressedThisFrame)
            On_P1_LT_Click.Invoke();

        if (Gamepad.all[0].rightTrigger.wasPressedThisFrame)
            On_P1_RT_Click.Invoke();


        if (Gamepad.all[0].yButton.wasPressedThisFrame)
            On_P1_KEYUP_Click.Invoke();

        if (Gamepad.all[0].aButton.wasPressedThisFrame)
            On_P1_KEYDOWN_Click.Invoke();

        if (Gamepad.all[0].xButton.wasPressedThisFrame)
            On_P1_KEYLEFT_Click.Invoke();

        if (Gamepad.all[0].bButton.wasPressedThisFrame)
            On_P1_KEYRIGHT_Click.Invoke();


        if (Gamepad.all[1].dpad.up.wasPressedThisFrame)
            On_P2_DPAD_UP_Click.Invoke();

        if (Gamepad.all[1].dpad.down.wasPressedThisFrame)
            On_P2_DPAD_DOWN_Click.Invoke();

        if (Gamepad.all[1].dpad.left.wasPressedThisFrame)
            On_P2_DPAD_LEFT_Click.Invoke();

        if (Gamepad.all[1].dpad.right.wasPressedThisFrame)
            On_P2_DPAD_RIGHT_Click.Invoke();


        if (Gamepad.all[1].leftShoulder.wasPressedThisFrame)
            On_P2_LB_Click.Invoke();

        if (Gamepad.all[1].rightShoulder.wasPressedThisFrame)
            On_P2_RB_Click.Invoke();

        if (Gamepad.all[1].leftTrigger.wasPressedThisFrame)
            On_P2_LT_Click.Invoke();

        if (Gamepad.all[1].rightTrigger.wasPressedThisFrame)
            On_P2_RT_Click.Invoke();


        if (Gamepad.all[1].yButton.wasPressedThisFrame)
            On_P2_KEYUP_Click.Invoke();

        if (Gamepad.all[1].aButton.wasPressedThisFrame)
            On_P2_KEYDOWN_Click.Invoke();

        if (Gamepad.all[1].xButton.wasPressedThisFrame)
            On_P2_KEYLEFT_Click.Invoke();

        if (Gamepad.all[1].bButton.wasPressedThisFrame)
            On_P2_KEYRIGHT_Click.Invoke();
    }
}