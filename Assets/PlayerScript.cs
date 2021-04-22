using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 3f;
    [SerializeField]
    private float _turnSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMove();
        UpdateLook();
    }

    void UpdateMove()
    {
        float angle = Mathf.Deg2Rad * transform.rotation.eulerAngles.y;
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        Vector3 inputVec = new Vector3(inputX, 0, inputZ);
        Vector3 lookVec = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
        Vector3 targetVec = Quaternion.LookRotation(lookVec) * inputVec;
        Vector3 moveVec = targetVec * _moveSpeed * Time.deltaTime;
        transform.position += moveVec;
    }

    void UpdateLook()
    {
        float inputRotation = 0;
        if (Input.GetKey(KeyCode.E))
        {
            inputRotation += _turnSpeed;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            inputRotation -= _turnSpeed;
        }
        Quaternion rotation = Quaternion.AngleAxis(inputRotation * Time.deltaTime, Vector3.up);
        transform.rotation *= rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Collectable")){
            print("collectable");
            other.gameObject.SetActive(false);
        }
    }
}