using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float dmg;
    private string owner;

    public void Setup(string _owner)
    {
        owner = _owner;
    }
   
    private void OnTriggerEnter(Collider collision)
    {
        //Owner = GetComponentInParent<Gun>().Owner;
        if (!collision.gameObject.CompareTag(owner) && !collision.gameObject.CompareTag("Gun") && !collision.gameObject.CompareTag("Bullet"))
        {
            if (collision.GetComponent<Health>() != null)
            {
                Health hp = collision.gameObject.GetComponent<Health>();
                hp.TakeDamage(dmg);
            }
            StartCoroutine(HideWeapon());
        }
    }

    private IEnumerator HideWeapon()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }
}
