using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGun : Gun
{
    [SerializeField]
    private Pooling bulletPooler;
    public override void Shoot()
    {
        if (Time.time > fireCount)
        {
            fireCount = Time.time + fireRate;
            Debug.DrawLine(transform.position, GameManager.Instance.Player.position, Color.green);
            Debug.Log("Shooting to player");
            bulletPooler.CreateBullet();
        }
    }
    
}
