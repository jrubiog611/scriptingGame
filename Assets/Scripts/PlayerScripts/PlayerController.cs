using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float height = 1;
    public float moveSpeed = 1;

    private Health hp;

    [SerializeField]
    private Gun gun;


    // Start is called before the first frame update
    void Start()
    {
        hp = GetComponent<Health>();

        if (hp != null)
            hp.DestroyInstance += OnDestroy;
    //    if (GameObject.FindGameObjectWithTag("Gun") != null)
    //    {
    //        gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>();
    //    }
    }

    // Update is called once per frame
    void Update()
    {

        if (!GameManager.Instance.isWin)
        {
            if (Input.GetMouseButton(0))
            {
                Attack();
            }

            if (Input.GetMouseButtonUp(0))
                gameObject.GetComponent<Renderer>().material.color = Color.blue; 
        }
    }
    private void Attack()
    {
        gun.Shoot();
        gameObject.GetComponent<Renderer>().material.color = Color.cyan;
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }

}
