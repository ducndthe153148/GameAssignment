using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed = 0.4f;
    private GameObject player;
    private Vector2 direction;
    internal bool foundPlayer = false;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 0.5f), Time.deltaTime * speed);
        if (Vector2.Distance(transform.position, player.transform.position) < 3)
        {
            foundPlayer = true;
        }
    }
    private void FixedUpdate()
    {
        if (foundPlayer)
        {
            direction = (player.transform.position - transform.position).normalized;
        }
        transform.Translate(direction * speed * Time.smoothDeltaTime);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        transform.position = Vector2.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, Time.deltaTime * speed);
    //    }
    //}
}
