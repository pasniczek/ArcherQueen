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
            // Debug.Log(numOfWood);

            if(numOfWood == 1)
            {
                Instantiate(WoodPrefab, WoodSpawn.transform.position, Quaternion.identity);
            }
            if(numOfWood == 2)
            {
                Instantiate(WoodPrefab, WoodSpawn.transform.position, Quaternion.identity);
                Instantiate(WoodPrefab, WoodSpawn.transform.position, Quaternion.identity);
            }
            if(numOfWood == 3)
            {
                Instantiate(WoodPrefab, WoodSpawn.transform.position, Quaternion.identity);
                Instantiate(WoodPrefab, WoodSpawn.transform.position, Quaternion.identity);
                Instantiate(WoodPrefab, WoodSpawn.transform.position, Quaternion.identity);
            }
        }
        foreach (GameObject RockSpawn in RockSpawns)
        {
            numOfRock = Random.Range(1, 4); 
            // Debug.Log(numOfRock);

            if(numOfRock == 1)
            {
                Instantiate(RockPrefab, RockSpawn.transform.position, Quaternion.identity);
            }
            if(numOfRock == 2)
            {
                Instantiate(RockPrefab, RockSpawn.transform.position, Quaternion.identity);
                Instantiate(RockPrefab, RockSpawn.transform.position, Quaternion.identity);
            }
            if(numOfRock == 3)
            {
                Instantiate(RockPrefab, RockSpawn.transform.position, Quaternion.identity);
                Instantiate(RockPrefab, RockSpawn.transform.position, Quaternion.identity);
                Instantiate(RockPrefab, RockSpawn.transform.position, Quaternion.identity);
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
