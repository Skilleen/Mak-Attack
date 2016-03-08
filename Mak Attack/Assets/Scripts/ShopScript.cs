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
    private float playerMaxHealth;
    private int potionCount;

    void Start () {
        Cursor.visible = true;
        playerPoints = PlayerPrefs.GetInt("score");
        playerHealth = PlayerPrefs.GetFloat("health");
        playerDamage = PlayerPrefs.GetFloat("damage");
        potionCount = PlayerPrefs.GetInt("potions");
        playerMaxHealth = PlayerPrefs.GetFloat("maxhealth");
    }
	
	// Update is called once per frame
	void Update () {

        PlayerPrefs.SetInt("score", playerPoints);
        if (playerPoints >= 50)
        {
            if (rb.mass == 1)
            {
                playerPoints = playerPoints - 50;
                playerMaxHealth = playerMaxHealth + 10;
                rb.mass = 5;
            }
            if (rb.mass == 2)
            {
                playerPoints = playerPoints - 50;
                playerDamage = playerDamage + 5;
                rb.mass = 5;
            }
            if (rb.mass == 3)
            {
                playerPoints = playerPoints - 50;
                potionCount = potionCount + 1;
                rb.mass = 5;
            }
        }
        if (rb.mass == 4)
        {
            rb.mass = 5;
            SceneManager.LoadScene("menu");
        }
        yourPoints.text = "Health: "+playerHealth.ToString("n1")+"/" + playerMaxHealth + "         Damage: "+playerDamage+"            Potions: "+potionCount+"            Points: "+playerPoints.ToString();
	
	}
}
