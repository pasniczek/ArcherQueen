using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnResources : MonoBehaviour
{
    private GameObject[] WoodSpawns;
    public GameObject WoodPrefab;
    private GameObject[] Woods;
    private GameObject[] RockSpawns;
    public GameObject RockPrefab;
    private GameObject[] Rocks;
    private int numOfWood;
    private int numOfRock;
    private Quaternion randomRot;
    private int randomNum;


    void Start()
    {
        WoodSpawns = GameObject.FindGameObjectsWithTag("WoodSpawn");
        RockSpawns = GameObject.FindGameObjectsWithTag("RockSpawn");
    }

    public void SpawnRecources()
    {
        foreach (GameObject WoodSpawn in WoodSpawns)
        {
            numOfWood = Random.Range(1, 4);
            randomNum = Random.Range(1, 361);
            randomRot = new Quaternion(0f, 0f, randomNum, 1f);
            // Debug.Log(numOfWood);

            if(numOfWood == 1)
            {
                Instantiate(WoodPrefab, WoodSpawn.transform.position, randomRot);
            }
            if(numOfWood == 2)
            {
                Instantiate(WoodPrefab, WoodSpawn.transform.position, randomRot);
                Instantiate(WoodPrefab, WoodSpawn.transform.position, randomRot);
            }
            if(numOfWood == 3)
            {
                Instantiate(WoodPrefab, WoodSpawn.transform.position, randomRot);
                Instantiate(WoodPrefab, WoodSpawn.transform.position, randomRot);
                Instantiate(WoodPrefab, WoodSpawn.transform.position, randomRot);
            }
        }
        foreach (GameObject RockSpawn in RockSpawns)
        {
            numOfRock = Random.Range(1, 4);
            randomNum = Random.Range(1, 361);
            randomRot = new Quaternion(0f, 0f, randomNum, 1f); 
            // Debug.Log(numOfRock);

            if(numOfRock == 1)
            {
                Instantiate(RockPrefab, RockSpawn.transform.position, randomRot);
            }
            if(numOfRock == 2)
            {
                Instantiate(RockPrefab, RockSpawn.transform.position, randomRot);
                Instantiate(RockPrefab, RockSpawn.transform.position, randomRot);
            }
            if(numOfRock == 3)
            {
                Instantiate(RockPrefab, RockSpawn.transform.position, randomRot);
                Instantiate(RockPrefab, RockSpawn.transform.position, randomRot);
                Instantiate(RockPrefab, RockSpawn.transform.position, randomRot);
            }
        }
    }

    public void DeleteRecources()
    {
        Rocks = GameObject.FindGameObjectsWithTag("Rock");
        Woods = GameObject.FindGameObjectsWithTag("Woods");
        foreach(GameObject Rocky in Rocks)
        {
            GameObject.Destroy(Rocky);
        }

        foreach(GameObject Woody in Woods)
        {
            GameObject.Destroy(Woody);
        }
    }

}
