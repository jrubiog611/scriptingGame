using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAtk : Gun
{
    [SerializeField]
    private Weapon weapon;
    private void Start()
    {
        weapon.Setup(owner);
    }
    public override void Shoot()
    {
        // play atk animation
        if (Time.time > fireCount)
        {
            fireCount = Time.time + fireRate;
            weapon.gameObject.SetActive(true);
            Debug.Log("Im atacking");
        }
    }

    // this should be on weapon
    //private void OnTriggerEnter(Collider collision)
    //{
    //    if (!collision.gameObject.CompareTag(owner) && !collision.gameObject.CompareTag("Gun") && !collision.gameObject.CompareTag("Bullet"))
    //    {
    //        if (collision.GetComponent<Health>() != null)
    //        {
    //            Health hp = collision.gameObject.GetComponent<Health>();
    //            //hp.TakeDamage(dmg);
    //        }
    //    }
    //}




}
