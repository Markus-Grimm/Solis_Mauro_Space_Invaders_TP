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
    public bool lose;
    public int scr;

    void Start()
    {
        scr = 0;
    }

    
    void Update()
    {
        if (scr >= 20)
        {
            Victory();
        }
    }

    public void AumentoScore()
    {
        scr += 1;
        Score.text = "Score: " + scr;
    }

    public void Victory()
    {
        gamevictory.text = "Victory";
        StartCoroutine(Defeatcrono(6f));
    }

    public void Defeat()
    {
        gamedefeat.text = "Game Over";
        StartCoroutine(Defeatcrono(6f));       
    }

    public IEnumerator Defeatcrono(float valcrono)
    {        
        yield return new WaitForSeconds(valcrono);
        SceneManager.LoadScene("Main Menú");
    }

}
