using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float movspd = 5f;

    public Rigidbody2D rb;

    Vector2 movement;

    public int lifeply;
    public int dmgenemy;
    public Animator anim;
    public bool dmged;
    public GameController GameController;

    //Disparo
    public GameObject launchposition;
    public GameObject proyectil;
    public float firerate = 0.5f;
    public float elapsedTime = 0f;
    

    void Start()
    {
        
    }

  
    void Update()
    {

        // Movimiento del jugador
        movement.x = Input.GetAxisRaw("Horizontal");
        

        // Ataque del jugador
        elapsedTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && elapsedTime > firerate)
        {
            this.GetComponent<AudioSource>().Play();

            Instantiate(proyectil, launchposition.transform.position + new Vector3(0.6f, 0, 0), launchposition.transform.rotation);

            elapsedTime = 0f;
        }

        if (lifeply <= 0)
        {
            GameObject.Destroy(this.gameObject);
            GameController.Defeat();
        }

    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movspd * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy1" && !dmged)
        {
            StartCoroutine(Damaged(1f));
            Debug.Log("daño");
            lifeply -= dmgenemy;            
        }
    }

    public IEnumerator Damaged(float valcrono)
    {
        dmged = true;
        anim.SetFloat("DMG", 2);

        yield return new WaitForSeconds(valcrono);

        dmged = false;
        anim.SetFloat("DMG", 0);
    }

}
