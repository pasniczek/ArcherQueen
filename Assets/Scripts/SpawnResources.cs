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
                Instantiate(WoodPrefab, WoodSpawn.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
            }
            if(numOfWood == 2)
            {
                Instantiate(WoodPrefab, WoodSpawn.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
                Instantiate(WoodPrefab, WoodSpawn.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
            }
            if(numOfWood == 3)
            {
                Instantiate(WoodPrefab, WoodSpawn.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
                Instantiate(WoodPrefab, WoodSpawn.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
                Instantiate(WoodPrefab, WoodSpawn.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
            }
        }
        foreach (GameObject RockSpawn in RockSpawns)
        {
            numOfRock = Random.Range(1, 4);
            // Debug.Log(numOfRock);

            if(numOfRock == 1)
            {
                Instantiate(RockPrefab, RockSpawn.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
            }
            if(numOfRock == 2)
            {
                Instantiate(RockPrefab, RockSpawn.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
                Instantiate(RockPrefab, RockSpawn.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
            }
            if(numOfRock == 3)
            {
                Instantiate(RockPrefab, RockSpawn.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
                Instantiate(RockPrefab, RockSpawn.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
                Instantiate(RockPrefab, RockSpawn.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
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
