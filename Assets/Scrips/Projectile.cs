using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 18f;

    public System.Action destroyed;
    public System.Action instanciate;

    void Update()
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;                
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (this.destroyed != null)
        {
            this.destroyed.Invoke();            
        }
        this.gameObject.SetActive(false);
    }

}
