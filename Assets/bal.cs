using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class bal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * 100;
    }

    float hitFactor(Vector2 balPositie, Vector2 racketPositie, float racketHeight)
    {
        return (balPositie.x - racketPositie.x) / racketHeight;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Racket")
        {
            float x = hitFactor(transform.position,
                col.transform.position,
                col.collider.bounds.size.x);
            Vector2 dir = new Vector2(x, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * 100;
        }
    }
}
