using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sript : MonoBehaviour
{
    public Transform collectablePrefab;
    public Transform mobPrefab;
    public Transform _parent;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnObjects()
    {
        Debug.Log("target found");
        // Spawn coinsn
        for (int i = 0; i < 10; i++)
        {
            float x = UnityEngine.Random.Range(-10, 10);
            float z = UnityEngine.Random.Range(-10, 10);
            Vector3 position = new Vector3(x, 0.0f, z);
            Quaternion rotation = Quaternion.Euler(0f, 0f, 0f);
            var obj = Instantiate(collectablePrefab, position, rotation);
            //obj.transform.parent = _parent;
            //obj.transform.position = position;
        }

        // Spawn Monsters
        /* for (int i = 0; i < 10; i++)
         {
             float x = UnityEngine.Random.Range(-20, 20);
             float z = UnityEngine.Random.Range(-20, 20);
             Instantiate(mobPrefab, new Vector3(x, 1f, z), Quaternion.Euler(0f, 0f, 0f));
         }*/
    }
}
