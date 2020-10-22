using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float height = 1;
    public float moveSpeed = 1;

    [SerializeField]
    private GameObject gun;


    // Start is called before the first frame update
    void Start()
    {
        //bulletPooling = transform.GetComponent<Pooling>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
            //bulletPooling.CreateInstances();
        }

        if (Input.GetMouseButtonUp(0))
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }
    private void Attack()
    {
        // si tiene arma ejecuta la accion de atk del arma
        // el arma deberia ser quien instancie sus propias balas
        if (GameObject.FindGameObjectWithTag("Gun") != null)
        {
            GameObject gun = GameObject.FindGameObjectWithTag("Gun");
            gun.GetComponentInChildren<Pooling>().OnShoot();
        }
        gameObject.GetComponent<Renderer>().material.color = Color.cyan;
    }

}
