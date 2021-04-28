using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private float timeOffset;
    private Vector3 basePos;

    // Start is called before the first frame update
    void Start()
    {
        // Damit nicht alle Coins sich synchron bewegen
        timeOffset = Random.Range(0f, 10f);
        // Speichern der Ursprungsposition
        basePos = transform.position;

        print("Start");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0), Time.deltaTime * 200);
        float yOff = Mathf.Sin((Time.time + timeOffset) * 3f) * 0.1f;
        transform.position = new Vector3(0, yOff, 0) + basePos;
    }
}
