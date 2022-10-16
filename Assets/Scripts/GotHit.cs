using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GotHit : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hitted_screen;
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("Hitted");
            hitted();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
        
            hitted();
        }
    }
    void hitted()
    {
        var color = hitted_screen.GetComponent<Image>().color;
        color.a = 0.8f;
        hitted_screen.GetComponent<Image>().color = color;
    }
    // Update is called once per frame
    void Update()
    {
        if (hitted_screen != null)
        {
            if (hitted_screen.GetComponent<Image>().color.a > 0)
            {
                var color = hitted_screen.GetComponent<Image>().color;
                color.a -= 0.01f;
                hitted_screen.GetComponent<Image>().color = color;
            }
        }
    }
}
