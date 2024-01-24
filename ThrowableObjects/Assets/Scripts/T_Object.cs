using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
public class T_Object : MonoBehaviour
{

    Rigidbody rb;
    public bool taken = false;

    public float forcePower=10;

    [HideInInspector]
    public bool hasReseted = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (taken)
        {
            GameObject obj = GameObject.FindGameObjectWithTag("pivot");

            rb.MovePosition(obj.transform.position);
            rb.MoveRotation(Quaternion.LookRotation(Camera.main.transform.forward));
            rb.useGravity = false;
        }
        else
        {
            rb.useGravity = true;
        }
        if (!hasReseted)
        {
            resetForce();
            hasReseted=true;
        }
    }

    public void resetForce() // �al��t��� an b�t�n kuvvetlerden kurtuluyor, elimize ald��m�zd d�nememsi i�in
    {
        rb.isKinematic = true;
        rb.isKinematic = false;
    }

    public void Force()
    {
        rb.AddForce(Camera.main.transform.forward*forcePower, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        taken = false;
    }
}
