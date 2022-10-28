using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public float knockBackTime = 10f;
    [SerializeField]
    private TowerHealth towerHealth;
    [SerializeField]
    private PlayerHealth playerHealth;
    private GameObject[] enemiesSpawn;
    private int health;
    private int damage;
    private float speed;
    private float cooldownAttack;
    private float score;
    private EnemyController enemyController;
    void Start()
    {
        towerHealth = GameObject.FindGameObjectWithTag("Tower").GetComponent<TowerHealth>();
        playerHealth = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<PlayerHealth>();
        enemiesSpawn = GameObject.FindGameObjectsWithTag("enemy");
        enemyController = GetComponent<EnemyController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        damage = (int)enemyController.damage;
        if (collision.gameObject.tag == "Tower")
        {
            Rigidbody2D rb = transform.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                //rb.isKinematic = false;
                Vector2 dir = -(collision.transform.position - transform.position);
                dir = dir.normalized * 10;
                rb.AddForce(dir, ForceMode2D.Impulse);
                StartCoroutine(knockBack(rb));
            }
            towerHealth.TakeDamage(damage);
        }
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody2D rb = transform.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                //rb.isKinematic = false;
                Vector2 dir = -(collision.transform.position - transform.position);
                dir = dir.normalized * 5;
                rb.AddForce(dir, ForceMode2D.Impulse);
                StartCoroutine(knockBack(rb));
            }
            playerHealth.TakeDamage(damage);
        }



    }
    // Update is called once per frame

    private IEnumerator knockBack(Rigidbody2D rb)
    {
        if (rb != null)
        {
            yield return new WaitForSeconds(knockBackTime);
            rb.velocity = Vector2.zero;
            //rb.isKinematic = true;
        }
    }
    void Update()
    {

    }
}
