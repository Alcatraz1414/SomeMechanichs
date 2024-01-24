using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addforce : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        kuvvetUygula();
    }

    void kuvvetUygula()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector3(0, 5, 0));
        }
    }
}
