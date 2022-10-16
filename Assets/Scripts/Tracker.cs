using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Target;
    public float hide;
    

    // Update is called once per frame
    void Update()
    {
        var dir = Target.position - transform.position;
        Vector3 targetPos = Camera.main.WorldToScreenPoint(Target.position);
        bool IsInvisible = targetPos.x <= 0 || targetPos.x >= Screen.width
            || targetPos.y <= 0 || targetPos.y >= Screen.height;
        
        if (!IsInvisible)
        {
            setchild(false);
            
        }
        else
        {
            setchild(true);
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);  
        }
    }
    void setchild( bool value)
    {
        foreach (Transform c in transform)
        {
            c.gameObject.SetActive(value);
        }
    }

}
