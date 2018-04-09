using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steal : MonoBehaviour {

    private bool canSteal = false;
    public GameObject scoreCount;

    Animator anim;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (canSteal == true)
        {
            //scoreCount = GetComponent<>();
            Score newScore = scoreCount.gameObject.GetComponent<Score>();

            anim.SetBool("Active", true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("10$");
                Destroy(gameObject);
                newScore.AddScore();
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
