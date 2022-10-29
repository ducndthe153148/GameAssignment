using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    public float fireDamage = 3f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    /*private void OnTriggerEnter2D(Collision2D collision)
    {
        collision.collider.SendMessage("OnHit", fireDamage);        
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.BroadcastMessage("OnHit1",fireDamage);
    }

}
