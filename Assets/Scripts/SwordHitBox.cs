using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitBox : MonoBehaviour
{
    //public float swordDamage = 1f;
    Vector2 rightAttackOffset;
    public Collider2D swordCollier;
    //public Vector3 right = new Vector3(0.05f, 0.01f, 0);
    //public Vector3 left = new Vector3(-0.44f, 0.01f, 0);
    // Start is called before the first frame update
    void Start()
    {
        if(swordCollier == null)
        {
            Debug.LogWarning("sword collider not set");
        }
        rightAttackOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "enemy")
        {

        collision.collider.SendMessage("OnHit", 100f);
        }
        /*if (collision.collider.tag == "enemy")
        {
            Enemies enemy = collision.collider.GetComponent<Enemies>();
            if (enemy != null)
            {
                enemy.Health -= swordDamage;
            }
        }*/
    }

    /*void IsFacingRight(bool isFacingRight)
    {
        if (isFacingRight)
        {
            gameObject.transform.localPosition = right;
        }
        else
        {
            gameObject.transform.localPosition = left;
        }
    }*/

}
