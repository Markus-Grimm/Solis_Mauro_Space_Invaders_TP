using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityScroll : MonoBehaviour
{

    Material mt;
    public float paralax = 2f;
    Vector2 offset;

    void Start()
    {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        mt = sp.material;

        offset = mt.mainTextureOffset;
    }

 
    void Update()
    {

        offset.x += Time.deltaTime / paralax;

        mt.mainTextureOffset = offset;

    }
}
