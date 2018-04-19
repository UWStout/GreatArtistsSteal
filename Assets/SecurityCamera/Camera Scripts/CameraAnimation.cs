using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour {

    Animator anim;
    Transform trigger;
    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 centerPos;

    private float fraction = 0f;

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

        trigger.transform.position = startPos;
    }

    private void Update()
    {
       
        if (patrolling == true)
        {
            if (resetPos == true)
            {
                trigger.transform.position = startPos;
                resetPos = false;
            }
            
            trigger.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(4.44f, 8.68f);

            /*if (fraction < 1)
            {
                fraction += Time.deltaTime * speed;
                trigger.transform.position = Vector3.Lerp(startPos, endPos, fraction);
            }*/
           
            trigger.transform.position = Vector3.Lerp(startPos, endPos, Mathf.PingPong(Time.time * speed, 1));
        }
        else if (patrolling == false)
        {
            trigger.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(23.5f, 8.68f);
            trigger.position = centerPos;
        }
    }

    public void Patrolling()
    {

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
        patrolling = true;
        anim.SetBool("Spotted", false);
        resetPos = true;
    }
}
