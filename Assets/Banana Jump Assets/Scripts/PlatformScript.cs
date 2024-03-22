using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public static PlatformScript instance;
    [SerializeField] private GameObject leftPlatform , rightPlatform;
    private float leftXMin = -4.4f , leftXMax = -2.8f , rightXMin = 4.4f , rightXMax = 2.8f;
    private float heightThreshold = 2.6f , lastY;
    public int spawnCount = 8;
    private int platformSpawned;
    [SerializeField] Transform platformParent;
    [SerializeField] private GameObject bird;
    public float birdY = 5f;
    public float birdXMin = -2.3f , birdXMax = 2.3f;    


    void Awake()
    {
        if(instance == null)
            instance = this;
    }

    void Start()
    {
        lastY = transform.position.y;
        SpawnPlatform();
    }

    public void SpawnPlatform(){
        Vector2 temp = transform.position;
        GameObject newPlatform = null;
        for(int i = 0; i< spawnCount; i++){
            temp.y = lastY;
            if(platformSpawned % 2 == 0){
                temp.x = Random.Range(leftXMin , leftXMax);
                newPlatform = Instantiate(rightPlatform , temp , Quaternion.identity);
            }
            else{
                temp.x = Random.Range(rightXMin , rightXMax);
                newPlatform = Instantiate(leftPlatform , temp , Quaternion.identity);
            }
            newPlatform.transform.parent = platformParent;
            lastY += heightThreshold;
            platformSpawned++;
        }
        if(Random.Range(0 , 2) > 0){
            SpawnBird();
        }
    }

    public void SpawnBird(){
        Vector2 temp = transform.position;
        temp.y = birdY;
        temp.x = Random.Range(birdXMin , birdXMax);
        GameObject newBird = Instantiate(bird , temp , Quaternion.identity);
        newBird.transform.parent = platformParent;
    }
}
