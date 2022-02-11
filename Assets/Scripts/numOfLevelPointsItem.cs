using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numOfLevelPointsItem : MonoBehaviour
{
    public int points;
    public int level = 0;
    public int frstNum;
    public int scndNum;
    public int thrdNum;
    public int forthNum;
    public bool upgrade;
    

    void Reset()
    {
        level += 1;
        upgrade = false;
    }

    void Update()
    {
        if(level == 0 && points >= frstNum && upgrade)
        {
            Debug.Log("you unlocked the item");
            points -= frstNum;
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
