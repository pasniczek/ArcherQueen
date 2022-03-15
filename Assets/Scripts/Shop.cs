using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<GameObject> ShopItems; 
    public int[] shopNum;
    private int total;
    private int randomNumber;


    void Start()
    {
       spawnShop(); 
    }

    public void spawnShop()
    {
        for(int i = 0; i < 3; i++)
        {
            foreach(var item in shopNum)
            {
                total += item;
            }
            randomNumber = Random.Range(1, total);
            for(int j = 0; j < shopNum.Length; j++)
            {
                if(randomNumber <= shopNum[j])
                {
                    Debug.Log(ShopItems[j].GetComponent<numOfLevelPointsItem>().Name);
                    break;
                }
                else
                {
                    randomNumber -= shopNum[j];
                }
            }
        }
    }
}
