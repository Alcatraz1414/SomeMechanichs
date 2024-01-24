using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   /* void Explosion()
    {
        if (Input.GetKey(KeyCode.X))
        {
            rb.AddExplosionForce(100f, transform.position, 100f, 3f ,ForceMode.Force);
        }
    }*/
}
