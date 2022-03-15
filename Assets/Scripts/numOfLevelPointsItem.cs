using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class numOfLevelPointsItem : MonoBehaviour
{
    public string Name;
    public string Description;
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
    public bool overworked = false;

    


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
            Debug.Log("you unlocked the" + Name);
            points -= frstNum;
            image.color = new Color32(255, 255, 255, 255);
            level += 1;
        }

        if(level == 1 && points >= scndNum)
        {
            if(upgrade)
            {
                upgrade = false;
                Debug.Log("level 1" + Name);
                points -= scndNum;
                level += 1;
            }
        }

        if(level == 2 && points >= thrdNum)
        {
            if(upgrade)
            {
                upgrade = false;
                Debug.Log("level 2" + Name);
                points -= thrdNum;
                level += 1;
            }

        }

        if(level == 3 && points >= forthNum)
        {
            if(upgrade)
            {
                upgrade = false;
                Debug.Log("level 3" + Name);
                level += 1;
            }
        }
    }
}
