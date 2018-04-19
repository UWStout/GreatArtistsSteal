using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour {

    Animator anim;
    Transform trigger;
    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 centerPos;

    private bool resetPos = false;

    private float speed = 0.375f;

    private bool patrolling = true;

    private void Start()
    {
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        endPos = new Vector3(transform.position.x + 19.15f, transform.position.y, transform.position.z);

        anim = GetComponent<Animator>();
        trigger = this.gameObject.transform.GetChild(0);

        centerPos = new Vector3(transform.position.x + 9.6f, trigger.transform.position.y, transform.position.z);

        //trigger.transform.position = startPos;
    }

    private void Update()
    {
        if (resetPos == true)
        {
            trigger.transform.position = startPos;
            Debug.Log("Reset starting point of trigger");    
            resetPos = false;
            patrolling = true;
        }

        if (patrolling == true && resetPos == false)
        {
            
            trigger.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(4.44f, 8.68f);  
            trigger.transform.position = Vector3.Lerp(startPos, endPos, Mathf.PingPong(Time.time * speed, 1f));
        }
        else if (patrolling == false)
        {
            trigger.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(23.5f, 8.68f);
            trigger.position = centerPos;
        }
    }

    public void Spotted()
    {
        anim.SetBool("Spotted", true);
        patrolling = false;
    }

    public void Caught()
    {

    }

    public void UnSpotted()
    {
        patrolling = false;
        anim.SetBool("Spotted", false);
        resetPos = true;
    }
}
