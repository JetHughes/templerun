using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent (typeof (Rigidbody))]
public class playerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody myRigidbody;
    public GameObject GameOver;
    private int lives = 4;
    private float health = 1.0f; // Start with full health (1.0)

    Slider healthSlider; // Reference to your Health Bar Slider
    public TMP_Text coinsLabel;
    private int coins = 0;

    // Start is called before the first frame update
    void Start()
    {
        healthSlider = GameObject.Find("Canvas/Health_Bar").GetComponent<Slider>();
        coinsLabel = GameObject.Find("Canvas/Coins_Label").GetComponent<TMP_Text>();
        UpdateHealthBar();
        UpdateCoins();
        GameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
        Vector3 velocity = input.normalized * moveSpeed;
        myRigidbody.MovePosition (myRigidbody.position + velocity * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "obstacle"){
            // Reduce health when taking damage
            health -= 0.25f; // Adjust this value based on your game's health system
            lives -= 1;
            print("Damage taken");
            Destroy(other.transform.parent.gameObject);

            // Check for death
            if (health <= 0) {
                Destroy(gameObject);
                GameOver.SetActive(true);
            }
        } else if (other.tag == "coin"){
            coins += 1;
        }
        UpdateCoins();
        UpdateHealthBar(); // Call the function to update the Health Bar
    }

    void UpdateCoins(){
        if (coinsLabel != null){
            coinsLabel.SetText(coins.ToString());
        }
    }


    void UpdateHealthBar() {
        // Update the Health Bar Slider with the current health value
        if (healthSlider != null) {
            healthSlider.value = health;
        }
    }
}
