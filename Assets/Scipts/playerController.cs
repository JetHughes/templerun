using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof (Rigidbody))]
public class playerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody myRigidbody;
    private int lives = 4;
    private float health = 1.0f; // Start with full health (1.0)

    public Slider healthSlider; // Reference to your Health Bar Slider

    // Start is called before the first frame update
    void Start()
    {
        healthSlider = GameObject.Find("Canvas/Health_Bar").GetComponent<Slider>();
        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
        Vector3 velocity = input.normalized * moveSpeed;
        myRigidbody.MovePosition (myRigidbody.position + velocity * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        // Reduce health when taking damage
        health -= 0.25f; // Adjust this value based on your game's health system
        lives -= 1;
        print("Damage taken");
        // Destroy(other.transform.parent.gameObject);

        // Check for death
        if (health <= 0) {
            // Destroy(gameObject);
        }

        UpdateHealthBar(); // Call the function to update the Health Bar
    }


    void UpdateHealthBar() {
        // Update the Health Bar Slider with the current health value
        if (healthSlider != null) {
            healthSlider.value = health;
        }
    }
}
