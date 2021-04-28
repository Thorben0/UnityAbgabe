using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScipt : MonoBehaviour
{
    public Transform target;
    public float horizontalDist = 5;
    public float verticallDist = 1;
    public float slerp = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* Update the cameras position */
        float angle = Mathf.Deg2Rad * target.rotation.eulerAngles.y;
        Vector3 lookVec = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
        Vector3 offset = lookVec * -horizontalDist;
        offset.y += verticallDist;
        transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, slerp * Time.deltaTime);

        /* Now update the cameras rotation */
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookVec), slerp * Time.deltaTime);
    }
}
