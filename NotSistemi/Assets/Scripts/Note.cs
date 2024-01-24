using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private float distanceFromPlayer;
    public Transform playerNotePosition;
    public Transform tableNotePosition;

    private bool isReading = false;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region alýnca hareket etmesin diye
        if (isReading)
        {
            GameObject.FindWithTag("Player").GetComponent<FirstPersonController>().enabled=false;
        }
        else if (!isReading)
        {
            GameObject.FindWithTag("Player").GetComponent<FirstPersonController>().enabled = true;
        }
        #endregion


        distanceFromPlayer = CharacterRay.distanceFromTarget;


        if (distanceFromPlayer < 2 && !isReading && Input.GetKey(KeyCode.E))
        {
            TakeNote();
        }
        else if (isReading && Input.GetKey(KeyCode.G))
        {
            DropNote();
        }


    }


    private void TakeNote()
    {    
            gameObject.transform.position = playerNotePosition.position;
            gameObject.transform.parent = playerNotePosition;
            gameObject.transform.rotation = playerNotePosition.rotation;
            isReading = true;
            print("aldýn");       
    }

    private void DropNote()
    {
        gameObject.transform.position = tableNotePosition.position;
        gameObject.transform.parent = tableNotePosition;
        gameObject.transform.rotation = Quaternion.Euler(90, 90, 0);
        isReading = false;
        print("býraktýn");
    }
}
