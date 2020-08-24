using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float height = 1;
    public float moveSpeed = 1;
    private float health = 100;
    Vector3 movement;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region movement
        float h = Input.GetAxisRaw("Horizontal")*moveSpeed*Time.deltaTime;
        float v = Input.GetAxisRaw("Vertical")*moveSpeed*Time.deltaTime;

        movement = new Vector3(gameObject.transform.position.x + h, height, gameObject.transform.position.z + v);

        gameObject.transform.position = movement;
        #endregion

        #region attack check
        if (Input.GetMouseButton(0))
            Attack(true);
        else
            Attack(false);
        #endregion
    }

    private void Attack(bool atk)
    {
        Color32 colorAtk = new Color32(255, 0, 255, 255);
        Color32 colorBase = new Color32(255, 255, 255, 255);

        #region attack
        if (atk)
        {
            gameObject.GetComponent<Renderer>().material.color = colorAtk;
        }
        else if (!atk)
        { 
            gameObject.GetComponent<Renderer>().material.color = colorBase;
        }
        #endregion
    }
}
