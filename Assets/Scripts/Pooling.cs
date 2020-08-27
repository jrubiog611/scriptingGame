using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Pooling : MonoBehaviour
{
    [SerializeField]
    private GameObject objToPool;
    private int sizeLimit;
    public int sizePool;
    private Rigidbody rb;

    private Queue<GameObject> pool = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //CreateInstances(objToPool,sizePool);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetFalse(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void CreateInstances()
    {
        if (sizeLimit < sizePool)
        {
            GameObject inst = Instantiate(objToPool,transform.position,transform.rotation);
            pool.Enqueue(inst);
            sizeLimit++;
        }
        
    }

}
