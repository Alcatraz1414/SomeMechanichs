using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patla : MonoBehaviour
{
    RaycastHit hit;

    [Range(0, 5000)]
    public float explosionPower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
       // print(hit.distance);
    }

    void FixedUpdate()
    {

        if (Input.GetMouseButton(0))
        {
            Ray isin = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(isin, out hit))
            {

               Collider[] carpilanlar = Physics.OverlapSphere(hit.point,3f);  
               // Bu k�s�m hit(yollda���m�z ���n) in de�di�i yerde g�r�nmez k�re ��kar�yor ve k�reye de�enleri bi array i�inde bilgilerini tutuyor

                foreach (var bulunanlar in carpilanlar)
                {
                    Rigidbody govde=bulunanlar.GetComponent<Rigidbody>();
                    // Burda k�renin i�inde kalan her eleman�n i�indeki rigidbody de�erini tan�ml�yoruz, i�lem yapabilmek i�in.

                    if ( govde != null)// bunun nedeni ise de�en �eylerin i�inde rigidbody yoksa null hatas� verecek
                    {
                        govde.AddExplosionForce(explosionPower, hit.point, 4f, 2f);
                        // patlama g�c�, patlayaca�� yer, patlad�pjnda etk�inelece�i alan, ger�ek�ilil(?) ve etkilend�inde yukar� savrulmas�(?)
                        
                    }
                    
                }


            }


            // Debug.DrawRay(isin.origin,isin.direction*hit.distance, Color.red);
        }

    }
}
