using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBackLight : MonoBehaviour
{

    [SerializeField] private GameObject flame;
    [SerializeField][Range(0,5)] private float lightDT;

    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateBacklight()
    {
        Debug.Log("ping");
        flame.SetActive(true);
        Invoke("DeactivateBackLight", lightDT);
    }

    private void DeactivateBackLight()
    {
        Debug.Log("off");
        flame.SetActive(false);
    }
}