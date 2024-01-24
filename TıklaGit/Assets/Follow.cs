using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private Rigidbody rb;
    Vector3 destination;

    private float stopDistance;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        destination= new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        //oyun baþladýðpýnda hareket etmsein diye

        print(transform.position.y+"     "+ destination.y);
    }

    // Update is called once per frame
    void Update()
    {
        print(destination);
        GoToTheDestination();
        stopDistance=destination.y-transform.position.y;

        
    }

    Vector3 FindTheMouseLocation()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                destination = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            }
        }
        return destination;
    }

    void GoToTheDestination()
    {
        
            Vector3 goDestination = FindTheMouseLocation();
        if (stopDistance < 0.3f)
        {
            transform.position = Vector3.MoveTowards(transform.position, goDestination, 0.05f);
        }
              
    }
}

