using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorting : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        spriteRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * -10);
    }
}
