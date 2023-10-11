using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // rb.AddForce(direction*moveSpeed, ForceMode.VelocityChange);
        Destroy(gameObject, 6.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = new Vector3(0.0f, 0.0f, -1.0f);
        Vector3 velocity = direction.normalized * moveSpeed;
        rb.MovePosition (rb.position + velocity * Time.fixedDeltaTime);
    }

}
