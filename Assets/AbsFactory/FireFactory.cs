using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFactory : EnemyFactory
    
{
    public GameObject Fac;
    private const string FireRangeName = "Fire_Boss";
    private const string FireMeleeName = "Fire_Mob";

    public override void createBoss()
    {
        var FireRangeObj = Resources.Load(FireRangeName) as GameObject;
        if(FireRangeObj != null)
        {
                Instantiate(FireRangeObj.transform, new Vector2(Fac.transform.position.x, Fac.transform.position.y),Quaternion.identity);
        }
        else
        {
            throw new System.ArgumentException(FireRangeObj + " not found");
        }
    }

    public override void createMob()
    {
        var FireMeleeObj = Resources.Load(FireMeleeName) as GameObject;
        if (FireMeleeObj != null)
        {
            Instantiate(FireMeleeObj.transform, new Vector2(Fac.transform.position.x, Fac.transform.position.y), Quaternion.identity);
        }
        else
        {
            throw new System.ArgumentException(FireMeleeObj + " not found");
        }
    }

   
}
