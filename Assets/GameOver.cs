using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverMenu;
    public Healthbar healthBar;
    public Healthbar healthBar2;
    public TMP_Text winnerText;
    public Slider slider;
    public Slider slider2;
    public Shooting shooting;
    public Shooting shooting2;
    public static bool isActive;
    //public GameObject player1;
    //public GameObject player2;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.Find("Player1").GetComponent<Healthbar>();
        healthBar2 = GameObject.Find("Player2").GetComponent<Healthbar>();
        shooting = GameObject.Find("Player1").GetComponent<Shooting>();
        shooting2 = GameObject.Find("Player2").GetComponent<Shooting>();
        gameOverMenu.SetActive(false);
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if(healthBar.currentHealth == 0)
            if(slider.value == 0)
        {
            isActive = true;
            gameOverMenu.SetActive(true);
            //Time.timeScale = 0f;
            winnerText.text = "Player 2 wins";
        }
        if (slider2.value == 0)
        {
            isActive = true;
            gameOverMenu.SetActive(true);
            //Time.timeScale = 0f;
            winnerText.text = "Player 1 wins";
        }
        /*if (healthBar2.currentHealth == 0)
        {
            gameOverMenu.SetActive(true);
            Time.timeScale = 0f;
            winnerText.text = "Player 1 wins";
        }*/

    }

    public void PlayAgain()
    {
        isActive = false;
        //Time.timeScale = 1f;
        Shooting.Ammo++;
        //Shooting.Ammo++;
        //SceneManager.LoadScene("MainMenu");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        Shooting.Ammo++;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
