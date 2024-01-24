using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectThrow : MonoBehaviour
{

    public float distance = 5f;
    public bool isTaked=false;

    public Image cross;

    public Transform pivot;

    GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isTaked)
        {
            var objComp = item.GetComponent<T_Object>();

            if (objComp.taken==false) // bu kýsým T_Object ten geliyor ve bir yere dokunursa objenin düþmesi için
            { 
                isTaked = false;
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                objComp.Force();
                isTaked = false;
                objComp.taken = false;
            }

                cross.color = Color.white;
        }

        if(!isTaked)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray,out hit ,distance) && hit.collider.tag=="takeAble")
            {
                cross.color = Color.red;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    item=hit.collider.gameObject;
                    item.GetComponent<T_Object>().hasReseted = false;
                    item.GetComponent<T_Object>().taken = true;                   
                    isTaked = true; // aldýktan sonra hala cross kýrmýzý gözüküyor
                }
            }
            

        }

    }
}
