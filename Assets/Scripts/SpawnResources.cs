using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnResources : MonoBehaviour
{
    private GameObject[] WoodSpawns;
    private GameObject[] RockSpawns;
    private GameObject[] GemSpawns;
    public int[] Woodtable ={ 60, 30, 10};
    public List<GameObject> WoodPrefabs;
    public int[] Rocktable ={ 60, 30, 10};
    public List<GameObject> RockPrefabs;
    public int[] Gemtable ={ 60, 30, 10};
    public List<GameObject> GemPrefabs;
    private int randomNum;
    private int RandomNumI;
    private int total;
    private int type;
    private GameObject[] Deletable1;
    private GameObject[] Deletable2;
    private GameObject[] Deletable3;
    private GameObject[] Deletable4;
    private GameObject[] Deletable5;
    private GameObject[] Deletable6;
    private GameObject[] Deletable7;
    private GameObject[] Deletable8;
    private GameObject[] Deletable9;


    void Awake()
    {
        WoodSpawns = GameObject.FindGameObjectsWithTag("WoodSpawn");
        RockSpawns = GameObject.FindGameObjectsWithTag("RockSpawn");
        GemSpawns = GameObject.FindGameObjectsWithTag("GemSpawn");
    }

    public void SpawnRecources()
    {
        //Wood spawn
        RandomNumI = 0;
        for(int u = 0; u < WoodSpawns.Length; u++)
        {
            RandomNumI = Random.Range(1, 4);
            for(int i = 0; i < RandomNumI; i++)
                {
                randomNum = 0;
                total = 0;
                foreach(var item in Woodtable)
                {
                    total += item;
                }
                randomNum = Random.Range(1, total);
                for(int j = 0; j < Woodtable.Length; j++)
                {
                    if(randomNum <= Woodtable[j])
                    {
                        Instantiate(WoodPrefabs[j], WoodSpawns[u].transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
                        break;
                    }
                    else
                    {
                        randomNum -= Woodtable[j];
                    }
                }
            }
        }


        //Rock spawn
        RandomNumI = 0;
        for(int u = 0; u < RockSpawns.Length; u++)
        {
            RandomNumI = Random.Range(1, 4);
            for(int i = 0; i < RandomNumI; i++)
                {
                randomNum = 0;
                total = 0;
                foreach(var item in Rocktable)
                {
                    total += item;
                }
                randomNum = Random.Range(1, total);
                for(int j = 0; j < Rocktable.Length; j++)
                {
                    if(randomNum <= Rocktable[j])
                    {
                        Instantiate(RockPrefabs[j], RockSpawns[u].transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
                        break;
                    }
                    else
                    {
                        randomNum -= Rocktable[j];
                    }
                }
            }
        }


        //Gem spawn
        RandomNumI = 0;
        for(int u = 0; u < GemSpawns.Length; u++)
        {
            RandomNumI = Random.Range(1, 4);
            for(int i = 0; i < RandomNumI; i++)
                {
                randomNum = 0;
                total = 0;
                foreach(var item in Gemtable)
                {
                    total += item;
                }
                randomNum = Random.Range(1, total);
                for(int j = 0; j < Gemtable.Length; j++)
                {
                    if(randomNum <= Gemtable[j])
                    {
                        Instantiate(GemPrefabs[j], GemSpawns[u].transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
                        break;
                    }
                    else
                    {
                        randomNum -= Gemtable[j];
                    }
                }
            }
        }
    }

    public void DeleteRecources()
    {
        Deletable1 = GameObject.FindGameObjectsWithTag("Rock");
        Deletable2 = GameObject.FindGameObjectsWithTag("Rock2");
        Deletable3 = GameObject.FindGameObjectsWithTag("Rock3");
        Deletable4 = GameObject.FindGameObjectsWithTag("Wood");
        Deletable5 = GameObject.FindGameObjectsWithTag("Wood2");
        Deletable6 = GameObject.FindGameObjectsWithTag("Wood3");
        Deletable7 = GameObject.FindGameObjectsWithTag("Gem");
        Deletable8 = GameObject.FindGameObjectsWithTag("Gem2");
        Deletable9 = GameObject.FindGameObjectsWithTag("Gem3");
        foreach(GameObject delete in Deletable1)
        {
            GameObject.Destroy(delete);
        }
        foreach(GameObject delete in Deletable2)
        {
            GameObject.Destroy(delete);
        }
        foreach(GameObject delete in Deletable3)
        {
            GameObject.Destroy(delete);
        }
        foreach(GameObject delete in Deletable4)
        {
            GameObject.Destroy(delete);
        }
        foreach(GameObject delete in Deletable5)
        {
            GameObject.Destroy(delete);
        }
        foreach(GameObject delete in Deletable6)
        {
            GameObject.Destroy(delete);
        }
        foreach(GameObject delete in Deletable7)
        {
            GameObject.Destroy(delete);
        }
        foreach(GameObject delete in Deletable8)
        {
            GameObject.Destroy(delete);
        }
        foreach(GameObject delete in Deletable9)
        {
            GameObject.Destroy(delete);
        }
    }

}
