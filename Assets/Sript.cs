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
        SpawnObjects();
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
            var obj = Instantiate(collectablePrefab);
            obj.transform.parent = _parent;
            obj.transform.localPosition = new Vector3(x, 0.5f, z);
        }

        // Spawn Monsters
        for (int i = 0; i < 3; i++)
        {
            float x = UnityEngine.Random.Range(-10, 10);
            float z = UnityEngine.Random.Range(-10, 10);
            var obj = Instantiate(mobPrefab);
            obj.transform.parent = _parent;
            obj.transform.localPosition = new Vector3(x, 0.3f, z);
        }
    }
}
