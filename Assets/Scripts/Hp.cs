using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{
  public Image[] hearts;
  public CapsuleCollider2D playerCollider;
  public GameObject player;
  public int numOfHearts;
  public Sprite blanket;

  private bool respawnRunning;

  private bool touchedSpikes;

  public float lastXSafeSpot;
  public float lastYSafeSpot;

  public Animator anim;
  public float transitionTime;



  private void Update(){

      for (int i = 0; i < hearts.Length; i++)
      {
          if(i < numOfHearts){
              hearts[i].sprite = blanket;
          }

          if(i < numOfHearts){
              hearts[i].enabled = true;
          }

          else {
            hearts[i].enabled = false;
          }
      }
      if(touchedSpikes == true && respawnRunning == false) {
        StartCoroutine(LoadLevel());
      }
    }
    private void OnCollisionEnter2D(Collision2D collison){
        if (collison.gameObject.CompareTag("Spikes") && numOfHearts != 0){
            touchedSpikes = true;
        }
        else {
            touchedSpikes = false;
        }
    }

    IEnumerator LoadLevel(){

        respawnRunning = true;

        numOfHearts--;

        anim.SetBool("Black", true);

        yield return new WaitForSeconds(transitionTime);

        transform.position = new Vector2(lastXSafeSpot, lastYSafeSpot);

        yield return new WaitForSeconds(transitionTime);
        
        anim.SetBool("Black", false);

        yield return new WaitForSeconds(transitionTime);

        respawnRunning = false;
    }
    
}

