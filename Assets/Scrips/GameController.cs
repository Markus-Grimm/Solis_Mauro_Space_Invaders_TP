using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject enemy;
    public float x,y,tspawn;

    //Interfaz, derrota y victoria
    public Text gamedefeat, gamevictory, Score;
    public bool lose, reset;
    public int scr, maxscr;

    public GameObject enemycheat;

    void Start()
    {
        lose = false;
        reset = false;
        scr = 0;
        Score.text = "Score: " + scr + " / " + maxscr;
    }

    
    void Update()
    {
        if (scr >= maxscr)
        {
            Victory();
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
