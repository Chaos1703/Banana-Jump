using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScripts : MonoBehaviour
{
    [SerializeField] private GameObject banana , bananas;
    [SerializeField] private Transform spawnPoint;

    void Start()
    {
        GameObject newBanana = null;
        if(Random.Range(0 , 10) > 3){
            newBanana = Instantiate(banana , spawnPoint.position , Quaternion.identity);
        }
        else{
            newBanana = Instantiate(bananas , spawnPoint.position , Quaternion.identity);
        }
        newBanana.transform.parent = transform;
    }
}
