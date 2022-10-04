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

    
    void Update()
    {
        Mov();
    }

    protected override void Dead() 
    {
        this.killed.Invoke();
        this.gameObject.SetActive(false);
    }

    protected override void Mov() { }

    protected override void Shoot() { }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            Dead();
        }

    }


}
