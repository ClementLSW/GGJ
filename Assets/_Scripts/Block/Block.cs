using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour, IDamagable
{
    public int Health = 100;
    public bool Destructable = true;

    [Space(10)]
    [SerializeField] private GameObject explosionPrefab;

    protected void Update()
    {
        if(Destructable && Health <= 0)
        {
            DestroySequence();
        }
    }

    public void DestroyBlock()
    {
        if (!Destructable)
            return;

        Health = 0;
    }

    private void DestroySequence()
    {
        Instantiate(explosionPrefab, gameObject.transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void MinusHP(int dmgAmt)
    {
        Health -= dmgAmt;
    }
}
