using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Turns : MonoBehaviour
{
    private Transform player1;
    private Transform player2;
    public int number;

    public static bool pl1Turn = true;
    public static bool pl2Turn = false;

    //GameObject player_1 = GameObject.Find("Player1");
    //GameObject player_2 = GameObject.Find("Player2");

    private GameObject player_1;
    private GameObject player_2;
    private GameObject cannon1;
    private GameObject cannon2;

    public Wind wind;
    public TMP_Text turnText;

    public Shooting shooting;

    private void Start()
    {
        //player1 = GameObject.FindGameObjectWithTag("Player1").transform;
        //player2 = GameObject.FindGameObjectWithTag("Player2").transform;
        player_1 = GameObject.FindGameObjectWithTag("Player1");
        player_2 = GameObject.FindGameObjectWithTag("Player2");
        cannon1 = GameObject.FindGameObjectWithTag("Cannon1");
        cannon2 = GameObject.FindGameObjectWithTag("Cannon2");
        //player_1.GetComponent<Shooting>().enabled = true; 
        //player_2.GetComponent<Shooting>().enabled = false; 
        wind.RandomNumber();
    }

    private void Update()
    {
        if(pl1Turn == true)
        {
            player_1.GetComponent<Shooting>().enabled = true;
            cannon1.GetComponent<Rotate>().enabled = true;
            player_2.GetComponent<Shooting>().enabled = false;
            cannon2.GetComponent<Rotate>().enabled = false;
            //player_1.GetComponent<CalcTrajectory>().enabled = true;
            //player_2.GetComponent<CalcTrajectory>().enabled = false;
            turnText.text = "Player 1";
        } else if (pl2Turn == true)
        {
            player_1.GetComponent<Shooting>().enabled = false;
            cannon1.GetComponent<Rotate>().enabled = false;
            player_2.GetComponent<Shooting>().enabled = true;
            cannon2.GetComponent<Rotate>().enabled = true;
            //player_1.GetComponent<CalcTrajectory>().enabled = false;
            //player_2.GetComponent<CalcTrajectory>().enabled = true;
            turnText.text = "Player 2";
        } 
    }

    public void ChangeTurns()
    {
        if (pl1Turn == true)
        {
            pl1Turn = false;
            pl2Turn = true;
            wind.RandomNumber();
            Shooting.Ammo += 1;
        }
        else if (pl2Turn == true)
        {
            pl2Turn = false;
            pl1Turn = true;
            wind.RandomNumber();
            Shooting.Ammo += 1;
        }
    }
}
