using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollMap : MonoBehaviour
{
    Renderer quad;

    public float v = 0.1f;

    void Start()
    {
        quad = GetComponent<Renderer>();
    }
    void Update()
    {
        Vector2 offset = new Vector2(v * Time.deltaTime, 0);
        quad.material.mainTextureOffset += offset;
    }
}
