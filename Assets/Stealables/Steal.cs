using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steal : MonoBehaviour {

    private bool canSteal = false;
    //public GameObject scoreCount;
    GameObject scoreCount1;

    Animator anim;

    private void Start()
    {
        scoreCount1 = GameObject.FindGameObjectWithTag("GUI");
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        
        if (canSteal == true)
        {
            //scoreCount = GetComponent<>();
            //Score newScore = scoreCount.gameObject.GetComponent<Score>();
            Score newScore1 = scoreCount1.gameObject.GetComponentInChildren<Score>();

            anim.SetBool("Active", true);

            if (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Interact"))
            {
                FindObjectOfType<AudioManager>().Play("Steal");
                Debug.Log("10$");
                Destroy(gameObject);
				newScore1.AddScore(Random.Range(1,4));
            }
       }else if (canSteal == false)
        {
            anim.SetBool("Active", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == ("Player"))
        {
            canSteal = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == ("Player"))
        {
            canSteal = false;
        }
    }
}
