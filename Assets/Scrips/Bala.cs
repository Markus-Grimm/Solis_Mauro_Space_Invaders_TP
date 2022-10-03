using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{

    public float Speed = 18f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(0, Speed * Time.deltaTime, 0);

        if (this.transform.position.x > 8)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy1")
        {
            Destroy(gameObject);
        }
        if (collision.transform.tag == "Muro")
        {
            Destroy(gameObject);
        }
    }

}
