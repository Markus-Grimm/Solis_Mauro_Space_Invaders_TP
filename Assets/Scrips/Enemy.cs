using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int lifebot;
    public int dmgbala;

    public int spd;
    private GameObject jugador;
    public GameController a;


    Vector3 pyrposition;



    void Start()
    {
        lifebot = 10;
        jugador = GameObject.Find("Player");
        a = GameController.FindObjectOfType<GameController>();
    }

    
    void Update()
    {
        pyrposition = jugador.transform.position;
        Vector3 target = pyrposition;

        float fixedspd = spd * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedspd);

        if (transform.position == target || transform.position.x <= -7)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, fixedspd);
        }

        if (lifebot <= 0)
        {
            a.AumentoScore();
            Dead();
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.tag == "Bala")
        {
            lifebot -= 5;
        }

    }


    void Dead()
    {
        Destroy(gameObject);
    }

}
