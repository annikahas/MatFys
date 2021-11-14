using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /*public GameObject Main;
    public GameObject Settings;
    public GameObject Credits;

    private void Update()
    {
        if(Main.activeSelf == false)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(Settings.activeSelf == true)
                {
                    Settings.SetActive(false);
                    Main.SetActive(true);
                } else if (Credits.activeSelf == true)              
                {
                    Credits.SetActive(false);
                    Main.SetActive(true);
                }
            }
        }

    }*/

    public void PlayGame()
    {
        //Debug.Log("Starting game");
        //SceneManager.LoadScene("MiscTest");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
