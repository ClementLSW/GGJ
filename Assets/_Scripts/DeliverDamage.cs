using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverDamage : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private int dmgVal;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if(collision.gameObject.GetComponent<IDamagable>() != null)
            collision.gameObject.GetComponent<IDamagable>().MinusHP(dmgVal);

        Instantiate(explosionPrefab, gameObject.transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
