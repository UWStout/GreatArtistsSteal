using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPatrolling : MonoBehaviour {

    Animator anim;
    Vector3 startPos;
    Vector3 endPos;

    private bool patrolling = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
        startPos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        endPos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
    }

    private void Update()
    {
        if (patrolling == true)
        {
            
        }
        else if (patrolling == false)
        {
            
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(20, 8.68f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            patrolling = false;
            anim.SetBool("Spotted", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            anim.SetBool("Spotted", false);
        }
    }
}
