using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class CharacterRay : MonoBehaviour
{
    public static float distanceFromTarget;
    public float toTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward * 1.5f,out hit))
        {
            toTarget = hit.distance;
            distanceFromTarget = toTarget;
        }
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 1.5f, Color.red);
       // print(distanceFromTarget);
    }
}
