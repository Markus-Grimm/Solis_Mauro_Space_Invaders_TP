using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public int lifebot, dmgbala;

    public GameController gameController;

    public Sprite[] animSprite;
    public Sprite dead;
    public float animTime = 1f;
    public System.Action killed;

    private SpriteRenderer _spriteRenderer;
    private int _animFrame;



    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        movspd = 1.0f;
        lifebot = 10;

        gameController = GameController.FindObjectOfType<GameController>();

        InvokeRepeating(nameof(AnimateSprite), this.animTime, this.animTime);
    }

    private void AnimateSprite()
    {
        _animFrame++;
        if (_animFrame >= this.animSprite.Length) _animFrame = 0;

        _spriteRenderer.sprite = this.animSprite[_animFrame];
    }


    private void Dead(int score) 
    {
        
        gameController.AumentoScore(score);
        this.gameObject.SetActive(false); 
        this.killed.Invoke();        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            if (this.gameObject.layer == LayerMask.NameToLayer("GreatEnemy"))
            {
                StartCoroutine(DeadAnim(1.0f, gameController.maxscr / 2));                
            }
            else
            {
                StartCoroutine(DeadAnim(0.1f, 1));
            }
        }
    }

    private IEnumerator DeadAnim(float valcrono, int score)
    {
        _spriteRenderer.sprite = this.dead;        
        yield return new WaitForSeconds(valcrono);
        Dead(score);
    }


}
