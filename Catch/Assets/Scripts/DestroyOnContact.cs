using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject, 0.5f);
    }
}
