using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Color spriteRendererColor;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRendererColor = spriteRenderer.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spriteRendererColor.a = 0.5f;
            spriteRenderer.color = spriteRendererColor;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spriteRendererColor.a = 1f;
            spriteRenderer.color = spriteRendererColor;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
