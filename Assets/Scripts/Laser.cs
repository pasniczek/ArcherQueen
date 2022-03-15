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
    public int stone1Price;
    public int stone2Price;
    public int stone3Price;
    public int wood1Price;
    public int wood2Price;
    public int wood3Price;
    public int gem1Price;
    public int gem2Price;
    public int gem3Price;
    private Vector3 cor;

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Wood")
        {
            cor = other.transform.position;
            StartCoroutine(SpawnSmoke());
            Destroy(other.gameObject);
            Hook.Lr.enabled = false;
            Money += wood1Price;
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

        if(other.tag == "Wood2")
        {
            cor = other.transform.position;
            StartCoroutine(SpawnSmoke());
            Destroy(other.gameObject);
            Hook.Lr.enabled = false;
            Money += wood2Price;
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

        if(other.tag == "Wood3")
        {
            cor = other.transform.position;
            StartCoroutine(SpawnSmoke());
            Destroy(other.gameObject);
            Hook.Lr.enabled = false;
            Money += wood3Price;
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
            Money += stone1Price;
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


        if(other.tag == "Rock2")
        {
            cor = other.transform.position;
            StartCoroutine(SpawnSmoke());
            Destroy(other.gameObject);
            Hook.Lr.enabled = false;
            Money += stone2Price;
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

        if(other.tag == "Rock3")
        {
            cor = other.transform.position;
            StartCoroutine(SpawnSmoke());
            Destroy(other.gameObject);
            Hook.Lr.enabled = false;
            Money += stone3Price;
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


        if(other.tag == "Gem")
        {
            cor = other.transform.position;
            StartCoroutine(SpawnSmoke());
            Destroy(other.gameObject);
            Hook.Lr.enabled = false;
            Money += gem1Price;
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


        if(other.tag == "Gem2")
        {
            cor = other.transform.position;
            StartCoroutine(SpawnSmoke());
            Destroy(other.gameObject);
            Hook.Lr.enabled = false;
            Money += gem2Price;
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

        if(other.tag == "Gem3")
        {
            cor = other.transform.position;
            StartCoroutine(SpawnSmoke());
            Destroy(other.gameObject);
            Hook.Lr.enabled = false;
            Money += gem3Price;
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
        moneyDisplay1.SetText(Money.ToString());
        moneyDisplay2.SetText(Money.ToString());
    }

    IEnumerator SpawnSmoke()
    {
        GameObject spawned = Instantiate(smoke, cor, Quaternion.identity);
        yield return new WaitForSeconds(0.34f);
        Destroy(spawned);
    }
}
