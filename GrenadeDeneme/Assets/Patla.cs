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
               // Bu kýsým hit(yolldaýðýmýz ýþýn) in deðdiði yerde görünmez küre çýkarýyor ve küreye deðenleri bi array içinde bilgilerini tutuyor

                foreach (var bulunanlar in carpilanlar)
                {
                    Rigidbody govde=bulunanlar.GetComponent<Rigidbody>();
                    // Burda kürenin içinde kalan her elemanýn içindeki rigidbody deðerini tanýmlýyoruz, iþlem yapabilmek için.

                    if ( govde != null)// bunun nedeni ise deðen þeylerin içinde rigidbody yoksa null hatasý verecek
                    {
                        govde.AddExplosionForce(explosionPower, hit.point, 4f, 2f);
                        // patlama gücü, patlayacaðý yer, patladýpjnda etkþineleceði alan, gerçekçilil(?) ve etkilendðinde yukarý savrulmasý(?)
                        
                    }
                    
                }


            }


            // Debug.DrawRay(isin.origin,isin.direction*hit.distance, Color.red);
        }

    }
}
