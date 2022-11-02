using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firepoint : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    Quaternion rotate;
    public bool right;
    Vector3 localScale;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rotate = transform.rotation;
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
