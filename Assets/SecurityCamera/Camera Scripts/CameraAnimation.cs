using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour {

    public GameObject otherObject;
    Animator otherAnimator;

    public Animation followSpeed;
    Animator anim;
    Transform trigger;
    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 centerPos;

    private float timeLeft = 6f;
    private bool countDown = false;

    private bool resetPos = false;

    private float speed = 0.375f;
    private float counter = 0f;

    private bool patrolling = true;

    private void Start()
    {
        otherObject = GameObject.Find("Player");
        otherAnimator = otherObject.GetComponent<Animator>();

        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        endPos = new Vector3(transform.position.x + 19.15f, transform.position.y, transform.position.z);

        anim = GetComponent<Animator>();
        trigger = this.gameObject.transform.GetChild(0);

        centerPos = new Vector3(transform.position.x + 9.6f, trigger.transform.position.y, transform.position.z);

        //trigger.transform.position = startPos;
    }

    private void Update()
    {
        if (countDown == true)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 3)
            {
                anim.SetBool("Follow", true);
            }

            if (timeLeft <= 0)
            {
                Caught();
            }
        }

        if (resetPos == true)
        {
            trigger.transform.position = startPos;
            Debug.Log("Reset starting point of trigger");    
            resetPos = false;
            patrolling = true;
            counter = 0;
        }

        if (patrolling == true && resetPos == false)
        {
            counter += Time.deltaTime * speed;
            trigger.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(4.44f, 8.68f);  
            trigger.transform.position = Vector3.Lerp(startPos, endPos, Mathf.PingPong(counter, 1f));
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
        countDown = true;
    }

    public void Caught()
    {
        PlayerMovement playerControl = otherObject.GetComponent<PlayerMovement>();
        otherAnimator.GetComponent<Animator>().SetBool("PlayerCaught", true);

        anim.SetBool("Caught", true);

        GameObject[] allChildren = new GameObject[transform.childCount];
        int i = 0;
        foreach (Transform child in transform)
        {
            allChildren[i] = child.gameObject;
            i += 1;
        }
        foreach (GameObject child in allChildren)
        {
            Destroy(child.gameObject);
        }
        Debug.Log(transform.childCount);

        playerControl.canControl = false;

        this.enabled = false;
    }

    public void UnSpotted()
    {
        patrolling = false;
        anim.SetBool("Spotted", false);
        resetPos = true;
        countDown = false;
        timeLeft = 6f;
        anim.SetBool("Follow", false);
    }
}
