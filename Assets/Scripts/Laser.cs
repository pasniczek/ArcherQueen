using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Laser : MonoBehaviour
{
    public Hook Hook;
    public TextMeshProUGUI moneyDisplay1;
    public TextMeshProUGUI moneyDisplay2;
    public int Money;
    public int stonePrice;
    public int woodPrice;

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Wood")
        {
            Destroy(other.gameObject);
            Hook.Lr.enabled = false;
            Money += woodPrice;
        }

        if(other.tag == "Rock")
        {
            Destroy(other.gameObject);
            Hook.Lr.enabled = false;
            Money += stonePrice;
        }
    }

    void Update()
    {
        moneyDisplay1.SetText(Money.ToString() + "$");
        moneyDisplay2.SetText(Money.ToString() + "$");
    }
}
