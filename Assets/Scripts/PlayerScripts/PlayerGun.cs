using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : Gun
{
    [SerializeField]
    private Pooling bulletPooler;
    public override void Shoot()
    {
        if(Time.time > fireCount)
        {
            fireCount = Time.time + fireRate;
            bulletPooler.CreateBullet();
        }
    }
}
