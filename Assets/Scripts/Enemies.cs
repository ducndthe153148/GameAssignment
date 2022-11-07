using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    Animator animator;
    //public float _health = 3;
    private EnemyController _enemyController;
    Fireball fireball;
    // Start is called before the first frame update
    public void Start()
    {
        animator = GetComponent<Animator>();
        _enemyController = GetComponent<EnemyController>();
        fireball = new Fireball();
    }
    public float Health
    {
        set
        {
            _enemyController.health = value;
            if (_enemyController.health <= 0)
            {
                animator.SetTrigger("death");
                if (_enemyController != null)
                {
                    Debug.Log(_enemyController.score);
                }
                if (_enemyController != null)
                {
                    CountScore.scoreValue += (int)_enemyController.score;
                }
                //CountScore.scoreValue += 1;
                //Debug.Log(_enemyController.score);
            }
        }
        get
        {
            return _enemyController.health;
        }
    }
    void OnHit(float damage)
    {
        //Debug.Log("hit for " + damage);
        Health -= damage;
        Debug.Log("Quai con " + Health + " mau");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fireball")
        {
            Health -= 200f;
        }
        fireball.FireBallExplode();
    }

    public void RemoveEnemy()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
        if (_enemyController != null)
        {
            Debug.Log(_enemyController.score);
        }
    }
}
