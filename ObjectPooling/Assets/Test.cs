using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 1;

    [SerializeField] private ObjectPool objectPool = null;

    private void Start()
    {
        StartCoroutine(spawnRoutine());
    }

    private IEnumerator spawnRoutine()
    {
        int counter = 0;
        while (true)
        {

            GameObject obj= objectPool.GetPoolObject(counter++ % 2); // counter deðerinin 2 modunu al ve 1 ekle, yani ya 0 gelecek ya 1
            obj.transform.position = Vector3.zero;

            yield return new WaitForSeconds(spawnInterval);

        }
    }
}
