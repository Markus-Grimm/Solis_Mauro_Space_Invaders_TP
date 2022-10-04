using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public int lifebot, dmgbala;

    public GameController gameController;

    public Sprite[] animSprite;
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
        this.killed.Invoke();
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            if (this.gameObject.layer == LayerMask.NameToLayer("GreatEnemy"))
            {
                Dead(100);
            }
            else
            {
                Dead(1);
            }
        }

    }


}
