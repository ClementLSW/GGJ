using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class RestartScene : MonoBehaviour
{
    public void Update()
    {
        if(Gamepad.all[0].leftTrigger.wasPressedThisFrame && Gamepad.all[0].rightTrigger.wasPressedThisFrame)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
