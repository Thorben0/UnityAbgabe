using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobScript : MonoBehaviour
{
    public Transform mob;
    public Transform target;
    public float moveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 from = mob.position;
        Vector3 to = target.position;
        Vector3 targetDirection = (to - from).normalized;

        mob.transform.rotation = Quaternion.Slerp(mob.transform.rotation, Quaternion.LookRotation(-targetDirection), Time.deltaTime);
        mob.transform.position += targetDirection * moveSpeed * Time.deltaTime;
    }
}
