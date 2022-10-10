using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    //Interfaz, derrota y victoria
    public Text gamedefeat, gamevictory, score, lifestxt, pause;
    public bool lose, reset;
    public int scr, percentToSurrender, amountAlive, lifes;

    public GameObject enemycheat;

    private delegate void GameOver();
    GameOver events;

    private static GameController instance = null;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        lose = false;
        reset = false;
        scr = 0;
        lifes = 3;
        score.text = "Score: " + scr;
        lifestxt.text = "Lifes: " + lifes;
    }
    
    void Update()
    {
        if (amountAlive <= percentToSurrender)
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            reset = !reset;
            pause.gameObject.SetActive(!pause.gameObject.activeSelf);
        }
    }

    public void AumentoScore(int score)
    {
        scr += score;
        this.score.text = "Score: " + scr;
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
