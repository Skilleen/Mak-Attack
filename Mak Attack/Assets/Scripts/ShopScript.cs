using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopScript : MonoBehaviour {

	// Use this for initialization
    public Button healthButton;
    public Button weaponButton;
    public Button potionsButton;
    public Rigidbody2D rb;
    public Text yourPoints;
    private int playerPoints;
    private float playerHealth;
    private float playerDamage;
    private int playerMaxHealth;
    private int potionCount;
    private int currentLevel;

    void Start () {
        Cursor.visible = true;
        playerPoints = PlayerPrefs.GetInt("score");
        playerHealth = PlayerPrefs.GetFloat("health");
        playerDamage = PlayerPrefs.GetFloat("damage");
        potionCount = PlayerPrefs.GetInt("potions");
        playerMaxHealth = PlayerPrefs.GetInt("maxhealth");
        currentLevel = PlayerPrefs.GetInt("level");
    }
	
	// Update is called once per frame
	void Update () {

        PlayerPrefs.SetInt("score", playerPoints);
        if (playerPoints >= 100)
        {
            if (rb.mass == 1)
            {
                playerPoints = playerPoints - 100;
                playerMaxHealth = playerMaxHealth + 10;
                rb.mass = 5;
            }
            if (rb.mass == 2)
            {
                playerPoints = playerPoints - 100;
                playerDamage = playerDamage + 5;
                rb.mass = 5;
            }
            if (rb.mass == 3)
            {
                playerPoints = playerPoints - 100;
                potionCount = potionCount + 1;
                rb.mass = 5;
            }
        }
        if (rb.mass == 4)
        {
            rb.mass = 5;
            PlayerPrefs.SetFloat("health", playerHealth);
            PlayerPrefs.SetInt("maxhealth", playerMaxHealth);
            PlayerPrefs.SetInt("score", playerPoints);
            PlayerPrefs.SetFloat("damage", playerDamage);
            PlayerPrefs.SetInt("potions", potionCount);
            if (currentLevel == 1)
            {
                SceneManager.LoadScene("LevelTwo");
            }
            else if (currentLevel == 2)
            {
                SceneManager.LoadScene("LevelThree");
            }
            if (currentLevel == 3)
            {
                SceneManager.LoadScene("LevelFour");
            }
            else if (currentLevel == 4)
            {
                SceneManager.LoadScene("LevelFive");
            }
        }
        yourPoints.text = "Health: "+playerHealth.ToString("n1")+"/" + playerMaxHealth + "         Damage: "+playerDamage+"            Potions: "+potionCount+"            Points: "+playerPoints.ToString();
	
	}
}
