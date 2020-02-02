using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Turret : Block, IDamagable
{
    [SerializeField] private Transform turretGun;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private GameObject ammo;
    [SerializeField] private float velocity;
    [SerializeField] private float firingRate;
    [SerializeField] private AudioClip clip;

    private SUPERLASER.Timer firingTimer = new SUPERLASER.Timer();

    private void Start()
    {
        Base[] potentalTargets = FindObjectsOfType<Base>();

        float diff = Vector2.Distance(transform.position, potentalTargets[0].gameObject.transform.position) -
            Vector2.Distance(transform.position, potentalTargets[1].gameObject.transform.position);

        Transform target;

        if (diff < 0)
            target = potentalTargets[1].transform;
        else
            target = potentalTargets[0].transform;

        if (transform.position.x < target.position.x)
            turretGun.rotation = Quaternion.Euler(0, 0, -90);
        else
            turretGun.rotation = Quaternion.Euler(0, 0, 90);

        firingTimer.SetTimer(firingRate);
    }

    private new void Update()
    {
        base.Update();
        if(firingTimer.TimeIsUp)
        {
            firingTimer.SetTimer(firingRate);

            Rigidbody2D projectile = Instantiate(ammo, firingPoint.position, firingPoint.rotation).GetComponent<Rigidbody2D>();
            projectile.gameObject.transform.parent = null;
            projectile.velocity = projectile.transform.up * new Vector2(velocity, 0);
            SoundManager.Instance.PlaySound(clip);
        }
    }
}
