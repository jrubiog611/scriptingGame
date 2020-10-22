using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1;
    private Vector3 movement, mousePos, direction;
    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        float v = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

        movement = new Vector3(gameObject.transform.position.x + h, transform.position.y, gameObject.transform.position.z + v);
        mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y, Camera.main.ScreenToWorldPoint(Input.mousePosition).z);
        //print(mousePos);
        Debug.DrawLine(transform.position, mousePos, Color.red);
        transform.position = movement;
        transform.LookAt(mousePos);
    }
}
