using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour, IDamagable
{
    public int Health = 100;
    private int maxHeath;
    public bool Destructable = true;

    [Space(10)]
    [SerializeField] private GameObject explosionPrefab;

    [Header("Sprites")]
    [SerializeField] private Sprite fullHP;
    [SerializeField] private Sprite halfHP;
    private SpriteRenderer sr;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip build;
    [SerializeField] private AudioClip explode;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        maxHeath = Health;
    }

    protected void Update()
    {
        if(Destructable && Health <= 0)
        {
            DestroySequence();
        }

        if (fullHP != null && halfHP != null)
        {
            if (Health > maxHeath / 2)
                SetSprite(true);
            else
                SetSprite(false);
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
        SoundManager.Instance.PlaySound(explode);
        Destroy(gameObject);
    }

    public void MinusHP(int dmgAmt)
    {
        Health -= dmgAmt;
    }

    public void SetSprite(bool isFullHP)
    {
        if (isFullHP)
            sr.sprite = fullHP;
        else
            sr.sprite = halfHP;
    }
}
