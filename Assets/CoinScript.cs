using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private float timeOffset;

    // Start is called before the first frame update
    void Start()
    {
        // Damit nicht alle Coins sich synchron bewegen
        timeOffset = Random.Range(0f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0), Time.deltaTime * 200);
    }
}
