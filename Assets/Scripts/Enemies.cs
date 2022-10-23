using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    Animator animator;
    public float _health = 3;
    // Start is called before the first frame update
    public void Start()
    {
        animator = GetComponent<Animator>();        
    }
    public float Health
    {
        set
        {
            _health = value;
            if(_health <= 0)
            {
                animator.SetTrigger("death");
            }
        }
        get
        {
            return _health;
        }
    }
    void OnHit(float damage)
    {
        Debug.Log("hit for " + damage);
        Health -= damage;
    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }
}
