using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            Instantiate(obj1, transform.position, Quaternion.identity);
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            Instantiate(obj2, transform.position, Quaternion.identity);
        }
    }
}
