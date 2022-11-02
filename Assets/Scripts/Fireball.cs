using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    float speed = 5;
    public float fireDamage = 3f;
    private Rigidbody2D rb;
    private Vector2 dir;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        dir = GameObject.Find("Dir").transform.position;
        transform.position = GameObject.Find("Firepoint").transform.position;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
       transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime);
    }

    public void FireBallExplode()
    {
        //animator.SetTrigger("explode");
        foreach(GameObject o in GameObject.FindGameObjectsWithTag("Fireball"))
        {
            Destroy(o);
        }
    }

    /*private void OnTriggerEnter2D(Collision2D collision)
    {
        collision.collider.SendMessage("OnHit", fireDamage);        
    }*/



}
