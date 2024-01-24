using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(LineRenderer))]
public class DrawingPath : MonoBehaviour
{
    
    Rigidbody rb;
    LineRenderer lr;
    public float timeForNextRay;
    public List<GameObject> wayPoints;
    float timer = 0;
    int currentWayPoint = 0;
    int wayIndex;
    bool move;
    bool touchStartedOnPlayer;

    [Range(0f, 100f)] public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;  // baþlangýçta çizgi olamsýn diye
        wayIndex = 1;
        move = false;
        touchStartedOnPlayer = false;

    }

    // Update is called once per frame
    void Update()
    {
        timer+= Time.deltaTime;
        if(Input.GetMouseButton(0) && timer>timeForNextRay && touchStartedOnPlayer)
        {
            Vector3 worldFromMousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f));
            Vector3 direction = worldFromMousePos - Camera.main.transform.position;

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, direction,out hit, 100f))
            {
                Debug.DrawLine(Camera.main.transform.position, direction, Color.red, 2f);

                GameObject newWayPoint = new GameObject("WayPoint");  // buradabi boþ gameobject oluþturuyor.
                newWayPoint.transform.position = new Vector3(hit.point.x,transform.position.y,hit.point.z);  // burda ise ýþýnýn çarptýðý yerin konumunda (y hariç çünkü playerin konumunda y si) o waypointi koyuyor
                wayPoints.Add(newWayPoint); //yeni waypoint i listemize ekliyoruz(gidilecekler listesi)
                lr.positionCount = wayIndex+1; //gidilecek poscount u da 1 arttýrýyoruz çünkü ekledik
                lr.SetPosition(wayIndex, newWayPoint.transform.position); // burda da pozisyonlardan wayIndex indexindekinin pozisyonunu newWayPoint in pozisyonu yapýyor.
                timer = 0;
                wayIndex++;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            touchStartedOnPlayer = false;
            move = true;          
        }
        if (move)// bu kýsým gidilecek yere götürüyor ve oraya baktýrýyor
        {          
                transform.LookAt(wayPoints[currentWayPoint].transform);
                transform.position = Vector3.MoveTowards(transform.position, wayPoints[currentWayPoint].transform.position, speed * Time.deltaTime);
                // rb.MovePosition(wayPoints[currentWayPoint].transform.position);
            
            if (transform.position==wayPoints[currentWayPoint].transform.position) // burasý gidilcek yere gittiysek yeni gidilecek yeri belirliyor
            {
                currentWayPoint++;
            }

            if (currentWayPoint == wayPoints.Count)  // bu if içi, artýk gidicek yer kalmayýnca gidilcek yer vs her þeyi resetliyor
            {
                move = false;
                foreach (var item in wayPoints)
                {
                    Destroy(item);                                   
                }
                wayPoints.Clear();
                wayIndex = 1;
                currentWayPoint = 0;
                lr.enabled = false;
            }
        }
    }

    public void OnMouseDown()
    {
        lr.enabled = true;
        touchStartedOnPlayer=true;
        lr.positionCount = 1; //pozisyon sayýsýný 1 yaptý
        lr.SetPosition(0,transform.position); // burdan da bi üst satýrda yaptýðý pozisyonun(0.index çünkü 1 tane var) yerini ayarladý.
    }
}
