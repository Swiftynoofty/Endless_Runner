using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] objectsToSpawn;
    

    float timeToNextSpawn;
    float timeSinceLastSpawn = 0.0f;

    public float minSpawnTime = 2.0f, createSpawnTimer;
    public float maxSpawnTime = 5.0f;
    public float spawnTimeRate = 0.5f;
    float rateIncrease = 0.1f, initialCreateDelay = 3.0f;
    int callCounter = 0;
    public int callsBeforeRateIncrease = 5;

  
    




    // Start is called before the first frame update
    void Start()
    {
        timeToNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn = timeSinceLastSpawn + Time.deltaTime;
           
       if (timeSinceLastSpawn > timeToNextSpawn)
        {
            int selection = Random.Range(0, objectsToSpawn.Length);

            Instantiate(objectsToSpawn[selection], transform.position, Quaternion.identity);

            timeToNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
            timeSinceLastSpawn = 0.0f;
        }
         
            createSpawnTimer -= Time.deltaTime;
        if(createSpawnTimer < 0)
        {
            CustomInvoke();
        }


        void CustomInvoke()
        {
            
            callCounter++;
            if(callCounter >= callsBeforeRateIncrease)
            {
                maxSpawnTime -= rateIncrease;
                callCounter = 0;
            }
            createSpawnTimer = maxSpawnTime;
        }


    }  
}
