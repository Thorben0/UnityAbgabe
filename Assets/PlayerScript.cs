using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 3f;
    [SerializeField]
    private float _turnSpeed = 100f;

    private GameObject _playground;

    private int _score;

    public float inputRotate;
    public float inputMove;

    // Start is called before the first frame update
    void Start()
    {
        _playground = GameObject.FindGameObjectWithTag("Playground");
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

        // Override by UI Buttons
        if (inputZ == 0)
        {
            inputZ = inputMove;
        }

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
        // Override by UI Buttons
        if (inputRotation == 0)
        {
            inputRotation = inputRotate * _turnSpeed;
        }
        Quaternion rotation = Quaternion.AngleAxis(inputRotation * Time.deltaTime, Vector3.up);
        transform.rotation *= rotation;
    }

    private void FixedUpdate()
    {
        if (_playground == null)
        {
            return;
        }
        if (transform.position.y < _playground.transform.position.y - 10)
        {
            Debug.Log("Player position reset");
            transform.position = _playground.transform.position + new Vector3(0, 1, 0);
            transform.rotation = Quaternion.identity;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
            _score++;
            Debug.Log("Score: " + _score);
        }
    }
}