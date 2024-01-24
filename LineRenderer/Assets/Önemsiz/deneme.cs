using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class deneme : MonoBehaviour
{
    public GameObject obj;
    [Range(0f,100f)]
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Sol t�kland� m�?
        {
            // Fare pozisyonunu ekran koordinatlar�nda al
            Vector3 mousePositionScreen = Input.mousePosition;

            // Ekran koordinatlar�n� d�nya koordinatlar�na d�n��t�r
            Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));

            

            // D�n��t�r�lm�� koordinatlar� kullanarak bir �eyler yapabilirsin
            Debug.Log("EKRAN  " + mousePositionScreen);
            Debug.Log("D�NYA  " + mousePositionWorld);
            Debug.Log("-------------------------------------" );

            Instantiate(obj,mousePositionScreen,obj.transform.rotation);
            Instantiate(obj, mousePositionWorld, obj.transform.rotation);
            
        }
    }
}
