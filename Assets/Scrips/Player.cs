using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    Vector2 movement;

    public int lifeply, dmgenemy;
    public Animator anim;
    public bool _dmged = false;
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
        if (!GameController.reset)
        {           
            Mov();            
        }
            

        if ((Input.GetMouseButtonDown(0) && !GameController.reset) || (Input.GetKeyDown(KeyCode.Space) && !GameController.reset))
        {
            Shoot();
        }
    }


    protected override void Shoot()
    {
        if (!_shootActive)
        {
            _shootActive = true; 
            this.GetComponent<AudioSource>().Play();
            //Instantiate(this.projectilePrefab, this.transform.position + new Vector3(0, 0.6f, 0), Quaternion.identity);
            ProjectileInstantiate();
        }        
    }

    private void ProjectileInstantiate()
    {
        GameObject projectil = ObjectPool.sharedInstance.GetPooledObject();
        Projectile projectile = projectil.GetComponent<Projectile>();
        projectile.instanciate += ProjectileInstantiate;
        if (projectil != null)
        {
            projectil.transform.position = this.transform.position + new Vector3(0, 0.6f, 0);
            projectil.transform.rotation = Quaternion.identity;
            projectil.SetActive(true);
        }
        //projectile.destroyed += ProjectileDestroyed;
        StartCoroutine(AttackSpeed(0.1f));

    }

    private void ProjectileDestroyed()
    {
        StartCoroutine(AttackSpeed(0.1f));
    }

    private IEnumerator AttackSpeed(float valcrono)
    {
        yield return new WaitForSeconds(valcrono);
        _shootActive = false;
    }

    protected override void Mov() 
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        if ((this.gameObject.transform.position.x >= -7) && (this.gameObject.transform.position.x <= 7))
        {
            rb.MovePosition(rb.position + movement * movspd * Time.fixedDeltaTime);
        }
        else
        {
            if (this.gameObject.transform.position.x >= -7)
            {
                this.transform.Translate(this.transform.position.x * (-1.9f), 0, 0);
                return;
            }
            else
            {
                if (this.gameObject.transform.position.x <= 7)
                {
                    this.transform.Translate(this.transform.position.x * (-1.9f), 0, 0);
                    return;
                }                
            }
        }
    }

    protected override void Dead()
    {        
        GameObject.Destroy(this.gameObject);
        GameController.Defeat();
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Missile") && !_dmged)
        {
            lifeply -= dmgenemy;
            if (lifeply <= 0) Dead(); else StartCoroutine(Damaged(1f));
        }

        if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Dead();
        }
    }


    public IEnumerator Damaged(float valcrono)
    {
        _dmged = true;
        anim.SetBool("Dmged", _dmged);

        yield return new WaitForSeconds(valcrono);

        _dmged = false;
        anim.SetBool("Dmged", _dmged);
    }

}
