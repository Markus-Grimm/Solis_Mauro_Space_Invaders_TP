using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    Vector2 movement;

    public int lifeply, dmgenemy;
    public Animator anim;
    public bool _dmged;
    public GameController GameController;

    //Disparo
    public Projectile projectilePrefab;
    private bool _shootActive;
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

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }


    protected override void Shoot()
    {
        if (!_shootActive)
        {
            this.GetComponent<AudioSource>().Play();
            Projectile projectile = Instantiate(this.projectilePrefab, this.transform.position + new Vector3(0, 0.6f, 0), Quaternion.identity);
            projectile.destroyed += ProjectileDestroyed;
            _shootActive = true;
        }        
    }

    private void ProjectileDestroyed()
    {
        _shootActive = false;
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
        if (collision.transform.tag == "Enemy1" && !_dmged)
        {
            StartCoroutine(Damaged(1f));
            Debug.Log("daño");
            lifeply -= dmgenemy;            
        }
    }


    public IEnumerator Damaged(float valcrono)
    {
        _dmged = true;
        anim.SetFloat("DMG", 2);

        yield return new WaitForSeconds(valcrono);

        _dmged = false;
        anim.SetFloat("DMG", 0);
    }

}
