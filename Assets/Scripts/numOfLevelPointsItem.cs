using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class numOfLevelPointsItem : MonoBehaviour
{
    public int Tier;
    public int IDNum;
    public int points;
    public int level = 0;
    public int frstNum;
    public int scndNum;
    public int thrdNum;
    public int forthNum;
    public bool upgrade;
    public bool stuck;
    private Image image;

    

    void Reset()
    {
        level += 1;
        upgrade = false;
    }

    void Awake()
    {
        stuck = true;
        image = GetComponent<Image>();
        image.color = new Color32(0, 0, 0, 150);
    }

    void Update()
    {
        if(level == 0 && points >= frstNum)
        {
            stuck = false;
            Debug.Log("you unlocked the item");
            points -= frstNum;
            image.color = new Color32(255, 255, 255, 255);
            Reset();
        }

        else if(level == 1 && points >= scndNum && upgrade)
        {
            Debug.Log("youre level 1 now");
            points -= scndNum;
            Reset();
        }

        else if(level == 2 && points >= thrdNum && upgrade)
        {
            Debug.Log("youre level 2 now");
            points -= thrdNum;
            Reset();

        }

        else if(level == 3 && points >= forthNum && upgrade)
        {
            Debug.Log("youre level 3 now");
            Reset();
        }
    }
}
