using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    // Start is called before the first frame update
    //Rigidbody2D rb;
    public float knockBackTime = 10f;
    void Start()
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tower")
        {
            Rigidbody2D rb = transform.GetComponent<Rigidbody2D>(); 
            if(rb != null)
            {
                //rb.isKinematic = false;
                Vector2 dir = - (collision.transform.position - transform.position);
                dir = dir.normalized * 10;
                rb.AddForce(dir, ForceMode2D.Impulse);
                StartCoroutine(knockBack(rb));
            }

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

        }



    }
    // Update is called once per frame

    private IEnumerator knockBack(Rigidbody2D rb)
    {
        if(rb != null)
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
