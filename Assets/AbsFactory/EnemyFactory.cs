using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyFactory : MonoBehaviour
{
    public Transform SpawnTransform;
    public abstract void createRange();
    public abstract void createMelee();
}
