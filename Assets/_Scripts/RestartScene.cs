using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class RestartScene : MonoBehaviour
{
    public void Update()
    {
        if(Gamepad.all[0].leftTrigger.isPressed && Gamepad.all[0].rightTrigger.isPressed)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);


        if (Gamepad.all[1].leftTrigger.isPressed && Gamepad.all[1].rightTrigger.isPressed)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
