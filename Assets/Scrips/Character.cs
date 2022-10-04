using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected float movspd;
    protected GameObject proyectile;
    protected Rigidbody2D rb;

    protected virtual void Dead() { }

    protected virtual void Mov() { }

    protected virtual void Shoot() { }

    void Start()
    {
        
    }

}
