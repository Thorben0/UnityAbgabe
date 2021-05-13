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
        timeOffset = Random.Range(0f, 360f);
    }

    // Update is called once per frame
    void Update()
    {
        timeOffset += Time.deltaTime * 200;
        transform.rotation = Quaternion.Euler(0, timeOffset, 0);
    }
}
