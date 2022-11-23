using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float h = 0.0f;
    private float v = 0.0f;

    private Transform tr;
    public float moveSpeed = 10.0f;
    public float rotSpeed = 100.0f;
    public float jumpPower = 20.0f;

    Rigidbody myRigidbody;
    void Start()
    {
        tr = GetComponent<Transform>(); //transform 할당
        myRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        tr.Translate(moveDir.normalized * Time.deltaTime * moveSpeed, Space.Self);
        tr.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X")); // 화면 회전
    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }
}
