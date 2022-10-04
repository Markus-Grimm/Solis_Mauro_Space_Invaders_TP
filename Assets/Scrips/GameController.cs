using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    //Interfaz, derrota y victoria
    public Text gamedefeat, gamevictory, Score, lifestxt;
    public bool lose, reset;
    public int scr, maxscr, lifes;

    public GameObject enemycheat;

    private delegate void GameOver();
    GameOver events;

    void Start()
    {
        lose = false;
        reset = false;
        scr = 0;
        lifes = 3;
        Score.text = "Score: " + scr + " / " + maxscr;
        lifestxt.text = "Lifes: " + lifes;
    }

    
    void Update()
    {
        if (scr >= maxscr)
        {
            if (events != null)
            {
                events -= Victory;
                events -= Defeat;
                events -= LoseLife;
            }
            events += Victory;
            events();
        }

        if (reset && (Input.GetKeyDown(KeyCode.R)))
        {
            reset = false;
            SceneManager.LoadScene("Gameplay");
        }

        if (reset && (Input.GetKeyDown(KeyCode.E)))
        {
            reset = false;
            SceneManager.LoadScene("Main Menú");
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            enemycheat.SetActive(true);
        }
    }

    public void AumentoScore(int score)
    {
        scr += score;
        Score.text = "Score: " + scr + " / " + maxscr;
    }

    public void LoseLife()
    {
        lifes = lifes - 1;
        lifestxt.text = "Lifes: " + lifes;        
    }

    public void Victory()
    {
        gamevictory.text = "Victory\nPress R to restart or E to return menu";
        reset = true;
    }

    public void Defeat()
    {
        gamedefeat.text = "Game Over\nPress R to restart or E to return menu";
        reset = true;
    }

}
