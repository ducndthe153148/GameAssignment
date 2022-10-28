using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float health;
    public float damage;
    public float speed;
    public float cooldownAttack;
    public float score;
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
        Vector2 turretPosition = GameObject.Find("Tower").transform.position;
        transform.position = Vector2.MoveTowards(transform.position, turretPosition, Time.deltaTime * speed);
    }
}
