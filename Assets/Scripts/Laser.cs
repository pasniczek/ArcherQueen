using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Laser : MonoBehaviour
{
    public Hook Hook;
    public GameObject smoke;
    public TextMeshProUGUI moneyDisplay1;
    public TextMeshProUGUI moneyDisplay2;
    public int Money;
    public int stonePrice;
    public int woodPrice;
    private Vector3 cor;

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Wood")
        {
            cor = other.transform.position;
            StartCoroutine(SpawnSmoke());
            Destroy(other.gameObject);
            Hook.Lr.enabled = false;
            Money += woodPrice;
            int RN = Random.Range(1,3);
            if(RN == 1 )
            {
                FindObjectOfType<AudioManager>().Play("sellSound1");
            }
            else 
            {
                FindObjectOfType<AudioManager>().Play("sellSound2");
            }
        }

        if(other.tag == "Rock")
        {
            cor = other.transform.position;
            StartCoroutine(SpawnSmoke());
            Destroy(other.gameObject);
            Hook.Lr.enabled = false;
            Money += stonePrice;
            int RN = Random.Range(1,3);
            if(RN == 1)
            {
                FindObjectOfType<AudioManager>().Play("sellSound1");
            }
            else 
            {
                FindObjectOfType<AudioManager>().Play("sellSound2");
            }
        }
    }

    void Update()
    {
        moneyDisplay1.SetText(Money.ToString() + "$");
        moneyDisplay2.SetText(Money.ToString() + "$");
    }

    IEnumerator SpawnSmoke()
    {
        GameObject spawned = Instantiate(smoke, cor, Quaternion.identity);
        yield return new WaitForSeconds(0.34f);
        Destroy(spawned);
    }
}
