using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float height = 1;
    public float moveSpeed = 1;
    private float health = 100;
    Vector3 movement;
    private Vector3 direction, mousePos;

    private Pooling bulletPooling;

    // Start is called before the first frame update
    void Start()
    {
        bulletPooling = transform.GetComponent<Pooling>();
    }

    // Update is called once per frame
    void Update()
    {
        #region movement
        Movement();
        #endregion

        #region attack check
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
            bulletPooling.CreateInstances();
        }

        if (Input.GetMouseButtonUp(0))
            gameObject.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
        #endregion
    }
    private void Movement()
    {
        float h = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        float v = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

        movement = new Vector3(gameObject.transform.position.x + h, height, gameObject.transform.position.z + v);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = new Vector3(mousePos.x - transform.position.x, transform.position.y, mousePos.z - transform.position.z);
        transform.position = movement;
        transform.LookAt(direction);
    }
    private void Attack()
    {
        Color32 colorAtk = new Color32(255, 0, 255, 255);
        Color32 colorBase = new Color32(255, 255, 255, 255);

        gameObject.GetComponent<Renderer>().material.color = colorAtk;


    }
}
