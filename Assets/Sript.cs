using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sript : MonoBehaviour
{
    public Transform myPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; i++) {
            float x = UnityEngine.Random.Range(-10, 10);
            float z = UnityEngine.Random.Range(-10, 10);
            Instantiate(myPrefab, new Vector3(x, 0.38f, z), Quaternion.Euler(0f, 0f, 0f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
