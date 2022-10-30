using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managerz : MonoBehaviour
{
    private const int Max= 4;
    private const string SpawnFacPrefabName = "Factory";
    private readonly Transform[] _factoryBuildings = new Transform[Max];

    //private GameObject FacBuilding;
    public GameObject FacA;
    //private GameObject FacB;
    //private GameObject FacC;
    //private GameObject FacD;

    // Start is called before the first frame update
    void Start()
    {
        Assign();
        InvokeRepeating(nameof(spawn), 5, 4);
    }

    public void spawn()
    {
        for (var i = 0; i < Max; i++)
        {
            if (_factoryBuildings[i] == null || _factoryBuildings[i].GetComponent<EnemyFactory>() == null) continue;

            if (Random.Range(0, 2) == 0)
            {
                _factoryBuildings[i].GetComponent<EnemyFactory>().createMelee();
            }
            else
            {
                _factoryBuildings[i].GetComponent<EnemyFactory>().createRange();
            }
        
        }

    }

    public void Assign()
    {
        Transform SpawnFacTransform = null;
        CreateAll(0, FacA, out SpawnFacTransform);
        if(SpawnFacTransform==null)
        {
            Debug.Log("not init");
        }
        SpawnFacTransform.gameObject.SetActive(false);
        EnemyFactory enemyFactory = SpawnFacTransform.transform.gameObject.GetComponent<EnemyFactory>();
        Destroy(enemyFactory);
        if (Random.Range(0, 1) == 0)
        {
            FireFactory fireFactory = SpawnFacTransform.gameObject.AddComponent<FireFactory>();
            fireFactory.Fac = FacA;
            fireFactory.SpawnTransform = SpawnFacTransform;
        }
        else
        {
            FireFactory fireFactory = SpawnFacTransform.gameObject.AddComponent<FireFactory>();
            fireFactory.Fac = FacA;
            fireFactory.SpawnTransform = SpawnFacTransform;
        }
        SpawnFacTransform.gameObject.SetActive(true);
        //CreateAll(1, FacB, out SpawnFacTransform);
        //CreateAll(2, FacC, out SpawnFacTransform);
        //CreateAll(3, FacD, out SpawnFacTransform);

        
    }

    private Transform CreateFac(GameObject fac)
    {
        var factory = Resources.Load(SpawnFacPrefabName) as GameObject;
        if (factory == null) throw new System.ArgumentException(SpawnFacPrefabName + " could not find");
        Transform newFactory = Instantiate(factory.transform, new Vector2(fac.transform.position.x, fac.transform.position.y), Quaternion.identity);
        return newFactory;
    }

    private void CreateAll(int arrayPosition, GameObject Fac, out Transform spawnFacTransform)
    {
        if (_factoryBuildings[arrayPosition] == null)
        {
            _factoryBuildings[arrayPosition] = CreateFac(Fac);
            spawnFacTransform = _factoryBuildings[arrayPosition];
        }
        else
        {
            spawnFacTransform = _factoryBuildings[arrayPosition];
        }
    }

}
