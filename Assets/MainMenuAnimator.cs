using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUPERLASER;

public class MainMenuAnimator : MonoBehaviour
{
    private UIAnimator a;

    private void Start()
    {
        a = GetComponent<UIAnimator>();
        StartCoroutine(S());

    }

    private IEnumerator S()
    {
        yield return new WaitForSeconds(3);
        a.Animate_Pos_ToOpposite();
    }
}
