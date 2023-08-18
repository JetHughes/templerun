using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class playerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Rigidbody myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
        Vector3 velocity = input.normalized * moveSpeed;
        myRigidbody.MovePosition (myRigidbody.position + velocity * Time.fixedDeltaTime);
    }
}
