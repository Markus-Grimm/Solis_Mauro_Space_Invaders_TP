using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    Vector2 movement;

    public int lifeply, dmgenemy;
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
        movspd = 5f;
        rb = GetComponent<Rigidbody2D>();
    }

  
    void Update()
    {
        Mov();

        Shoot();               
    }


    private void FixedUpdate()
    {
    }


    protected override void Shoot()
    {
        elapsedTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && elapsedTime > firerate)
        {
            this.GetComponent<AudioSource>().Play();

            Instantiate(proyectil, launchposition.transform.position + new Vector3(0.6f, 0, 0), launchposition.transform.rotation);

            elapsedTime = 0f;
        }
    }

    protected override void Mov() 
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        rb.MovePosition(rb.position + movement * movspd * Time.fixedDeltaTime);
    }

    protected override void Dead()
    {
        if (lifeply <= 0)
        {
            GameObject.Destroy(this.gameObject);
            GameController.Defeat();
        }
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
