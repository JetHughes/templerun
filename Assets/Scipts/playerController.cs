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
    public GameObject ObstacleSpawner;
    public GameObject CoinSpawner;
    private int lives = 4;
    private float health = 1.0f; // Start with full health (1.0)
    float startTime; 
    float currentTime;


    Slider Wrist_healthSlider; // Reference to your Health Bar Slider
    TMP_Text Wrist_timerText;
    Slider healthSlider; // Reference to your Health Bar Slider
    TMP_Text timerText;
    public TMP_Text coinsLabel;
    private int coins = 0;

    public AudioSource audioData;
    public AudioSource audioData2;

    public SpriteRenderer damageScreen;
    float fadeSpeed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        Wrist_healthSlider = GameObject.Find("Wrist_Canvas/Health_Bar").GetComponent<Slider>();
        Wrist_timerText = GameObject.Find("Wrist_Canvas/Timer_Count").GetComponent<TMP_Text>();
        healthSlider = GameObject.Find("Canvas/Health_Bar").GetComponent<Slider>();
        timerText = GameObject.Find("Canvas/Timer_Count").GetComponent<TMP_Text>();
        coinsLabel = GameObject.Find("Canvas/Coins_Label").GetComponent<TMP_Text>();
        UpdateHealthBar();
        UpdateCoins();
        GameOver.SetActive(false);
        startTime = Time.time;
        Color tmp = damageScreen.color;
        tmp.a = 0;
        damageScreen.color = tmp;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
        Vector3 velocity = input.normalized * moveSpeed;
        myRigidbody.MovePosition (myRigidbody.position + velocity * Time.fixedDeltaTime);
        currentTime = Time.time - startTime;
        Wrist_timerText.SetText("Time: " + currentTime);
        timerText.SetText("Time: " + currentTime);
        if(damageScreen.color.a > 0){
            Color tmp = damageScreen.color;
            tmp.a = tmp.a - fadeSpeed;
            damageScreen.color = tmp;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "obstacle"){
            audioData2.Play(0);
            Color tmp = damageScreen.color;
            tmp.a = 1;
            damageScreen.color = tmp;
            // Reduce health when taking damage
            health -= 0.25f; // Adjust this value based on your game's health system
            lives -= 1;
            print("Damage taken");
            Destroy(other.transform.parent.gameObject);

            // Check for death
            if (health <= 0) {
                Destroy(gameObject);
                GameOver.GetComponent<TMP_Text>().SetText("Game Over\ntime: " + (Time.time - startTime) + "\ncoins: " + coins);
                GameOver.SetActive(true);
                Destroy(ObstacleSpawner);
                Destroy(CoinSpawner);
            }
        } else if (other.tag == "coin"){
            coins += 1;
            audioData.Play(0);

        }
        UpdateCoins();
        UpdateHealthBar(); // Call the function to update the Health Bar
    }

    void UpdateCoins(){
        if (coinsLabel != null){
            coinsLabel.SetText("Coins: " + coins);
        }
    }


    void UpdateHealthBar() {
        // Update the Health Bar Slider with the current health value
        if (Wrist_healthSlider != null) {
            Wrist_healthSlider.value = health;
            healthSlider.value = health;
        }
    }
}
