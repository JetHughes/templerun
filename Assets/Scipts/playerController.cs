using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class playerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody myRigidbody;
    private int lives = 3;

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

    private void OnTriggerEnter(Collider other){
        lives -= 1;
        print("life lost");
        Destroy(other.transform.parent.gameObject);
        if (lives < 0) {
            Destroy(gameObject);
        }   
    }
}
