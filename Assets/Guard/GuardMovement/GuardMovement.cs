using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMovement : MonoBehaviour {

    private float guardScale = 1f;

    //determine sprite direction
    bool faceRight = true;

    //left and right wall check
    bool wallCheckL = false;
    bool wallCheckR = false;
    public LayerMask whatIsGuardWall;//determines what is considered a wall for the guard
    float wallRadius = .2f;
    public Transform wallNearL;
    public Transform wallNearR;
    bool movingRight = true;

    bool Patrolling = true;
    bool playerCaught = false;
    bool Incapacitated = false;
    public bool chasing = false;
    bool caught = false;
    bool alert = false;

    //timer
    private float time = 1000f;
    private int count = 0;

    public Transform incapacitatedTrigger;
    public Transform chasingTrigger;
    public Transform caughtTrigger;

    //player componenets to be called from script
    public Transform player;
    Animator otherAnimator;
    public Transform playerObject;
    public GameObject otherObject;

    public bool stopChasingSwapLeft = false;
    public bool stopChasingSwapRight = false;
    public bool swap = false;

    //animator
    Animator anim;

    //guard move speed
    public float walkSpeed = 4f;

    private void Awake()
    {
        incapacitatedTrigger = this.gameObject.transform.GetChild(4);
        caughtTrigger = this.gameObject.transform.GetChild(2);
        chasingTrigger = this.gameObject.transform.GetChild(3);
        player = GameObject.Find("Player").transform;
        
        otherAnimator = otherObject.GetComponent<Animator>();
    }

    public void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool( "Patrolling",Patrolling);
    }


    private void FixedUpdate()
    {

        wallCheckL = Physics2D.OverlapCircle(wallNearR.position, wallRadius, whatIsGuardWall);
        wallCheckR = Physics2D.OverlapCircle(wallNearL.position, wallRadius, whatIsGuardWall);

        if (Patrolling == true && Incapacitated == false && chasing == false && playerCaught == false && alert == false)//patrolling state
        {
            switch (movingRight)
            {
                case true:
                    moveRight();
                    if (wallCheckR)
                    {
                        //Switch();
                        Flip();
                        chasingTrigger.transform.localScale = new Vector3(chasingTrigger.transform.localScale.x * -1, chasingTrigger.transform.localScale.y, chasingTrigger.transform.localScale.z);
                        caughtTrigger.transform.localScale = new Vector3(caughtTrigger.transform.localScale.x * -1, caughtTrigger.transform.localScale.y, caughtTrigger.transform.localScale.z);
                        incapacitatedTrigger.transform.localScale = new Vector3(incapacitatedTrigger.transform.localScale.x * -1, incapacitatedTrigger.transform.localScale.y, incapacitatedTrigger.transform.localScale.z);
                        
                        movingRight = false;
                        faceRight = false;    

                    }
                    break;

                case false:
                    moveLeft();
                    if (wallCheckL)
                    {
                        //Switch();
                        Flip();
                        chasingTrigger.transform.localScale = new Vector3(chasingTrigger.transform.localScale.x * -1, chasingTrigger.transform.localScale.y, chasingTrigger.transform.localScale.z);
                        caughtTrigger.transform.localScale = new Vector3(caughtTrigger.transform.localScale.x * -1, caughtTrigger.transform.localScale.y, caughtTrigger.transform.localScale.z);
                        incapacitatedTrigger.transform.localScale = new Vector3(incapacitatedTrigger.transform.localScale.x * -1, incapacitatedTrigger.transform.localScale.y, incapacitatedTrigger.transform.localScale.z);
                        movingRight = true;
                        faceRight = true;

                    }
                    break;              
            }

            
        }
        else if (Incapacitated == true && Patrolling == false)//incapacitated state
        {
            Patrolling = false;
        }
        else if (Incapacitated == false && chasing == true)//chasing state
        {
            if (player.transform.localPosition.x > transform.localPosition.x)
            {
                transform.position += transform.right * (walkSpeed * 2) * Time.deltaTime;
            }
            else if (player.transform.localPosition.x < transform.localPosition.x)
            {
                transform.position += -transform.right * (walkSpeed * 2) * Time.deltaTime;
            }
        }
        else if (Incapacitated == false && playerCaught == true)//player caught state
        {
            otherAnimator.SetBool("PlayerCaught", playerCaught);
        }

        anim.SetBool("Incapacitated", Incapacitated);
        anim.SetBool("Chasing", chasing);
        
    }

    private void Update()
    {

        if (Patrolling == true && swap == true)
        {
            Flip();
            chasingTrigger.transform.localScale = new Vector3(chasingTrigger.transform.localScale.x * -1, chasingTrigger.transform.localScale.y, chasingTrigger.transform.localScale.z);
            caughtTrigger.transform.localScale = new Vector3(caughtTrigger.transform.localScale.x * -1, caughtTrigger.transform.localScale.y, caughtTrigger.transform.localScale.z);
            incapacitatedTrigger.transform.localScale = new Vector3(incapacitatedTrigger.transform.localScale.x * -1, incapacitatedTrigger.transform.localScale.y, incapacitatedTrigger.transform.localScale.z);
            transform.localScale = new Vector3(guardScale, guardScale, guardScale);
            swap = false;
        }

    }

    //movement of the guard position
    public void moveLeft()
    {
        transform.position += transform.right * walkSpeed * Time.deltaTime;
        
        Patrolling = true;
    }
    public void moveRight()
    {
        transform.position += -transform.right * walkSpeed * Time.deltaTime;
        Patrolling = true;
    }

    //flips the direction of the sprite depending on which way the player is facing/moving
    void Flip()
    {
        SpriteRenderer guardSprite = gameObject.GetComponent<SpriteRenderer>();
        
        if (guardSprite.flipX == true)
        {
            guardSprite.flipX = false;
            
        }
        else
        {
            guardSprite.flipX = true;
        }

    }

    public void GuardChasing()
    {
        if (transform.position.x < player.transform.position.x && movingRight == true)
        {
            transform.localScale = new Vector3(-guardScale, guardScale, guardScale);
        }else if (transform.position.x > player.transform.position.x && movingRight == true)
        {
            transform.localScale = new Vector3(guardScale, guardScale, guardScale);
        }
        else if (transform.position.x < player.transform.position.x && movingRight == false)
        {
            transform.localScale = new Vector3(guardScale, guardScale, guardScale);
        }
        else if (transform.position.x > player.transform.position.x && movingRight == false)
        {
            transform.localScale = new Vector3(-guardScale, guardScale, guardScale);
        }
        Debug.Log("GuardChasing");
        chasing = true;
    }

    public void StopGuardChasing()
    {
        Debug.Log("GuardStopChasing");

        chasing = false;
        //StartCoroutine(delay());
        
        //alert = true;

        if (transform.position.x < player.transform.position.x && movingRight == false)
        {
            Debug.Log("Guard moving right with player on right");
        }
        else if (transform.position.x > player.transform.position.x && movingRight == false)
        {
            Debug.Log("Guard moving right with player on left");
            transform.localScale = new Vector3(-guardScale, guardScale, guardScale);
            movingRight = true;
            stopChasingSwapLeft = true;
            swap = true;
        }
        else if (transform.position.x < player.transform.position.x && movingRight == true)
        {
            Debug.Log("Guard moving left with player on right");
            transform.localScale = new Vector3(guardScale, guardScale, guardScale);
            movingRight = false;
            stopChasingSwapRight = true;
            swap = true;
        }
        else if (transform.position.x > player.transform.position.x && movingRight == true)
        {
            Debug.Log("Guard moving left with player on left");
        }

        Patrolling = true;
    }

    public void GuardAlert()
    {
        
        Patrolling = false;
        anim.SetBool("Alert", true);

        Debug.Log("GUARDALERT");
        StartCoroutine(AlertFlip());

    }

    public void GuardCuaght()
    {
        PlayerMovement playerControl = otherObject.GetComponent<PlayerMovement>();

        chasing = false;
        caught = true;

        if (transform.position.x < player.transform.position.x && movingRight == true)
        {
            transform.localScale = new Vector3(-guardScale, guardScale, guardScale);
        }
        else if (transform.position.x > player.transform.position.x && movingRight == true)
        {
            transform.localScale = new Vector3(guardScale, guardScale, guardScale);
        }
        else if (transform.position.x < player.transform.position.x && movingRight == false)
        {
            transform.localScale = new Vector3(guardScale, guardScale, guardScale);
        }
        else if (transform.position.x > player.transform.position.x && movingRight == false)
        {
            transform.localScale = new Vector3(-guardScale, guardScale, guardScale);
        }

        Debug.Log("GuardCaught");
        playerCaught = true;
        otherAnimator.GetComponent<Animator>().SetBool("PlayerCaught", true);
        anim.SetBool("playerCaught", true);

        Debug.Log(transform.childCount);
        int i = 0;
        GameObject[] allChildren = new GameObject[transform.childCount];
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

    public Sprite incapacitatedSprite;
    public void GuardIncapacitated()
    {
        Debug.Log("Guard incapacitated");
        Incapacitated = true;
        Patrolling = false;
        chasing = false;
        alert = false;

        //anim.SetBool("Incapacitated", true);
        anim.SetTrigger("Incap");

        //array to hold all child objects
        Debug.Log(transform.childCount);
        int i = 0;
        GameObject[] allChildren = new GameObject[transform.childCount];
        foreach (Transform child in transform)
        {
            allChildren[i] = child.gameObject;
            i += 1;
        }
        foreach(GameObject child in allChildren)
        {
            child.gameObject.SetActive(false);
        }
        Debug.Log(transform.childCount);


        //gameObject.GetComponent<Animator>().enabled = false;
        StartCoroutine(DelayAnimationDisable());
        this.enabled = false;

        //moves the guard back in space to allow the player sprite to not clip
        gameObject.transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y - .22f, transform.localPosition.z);

        StartCoroutine(RespawnGuard());
    }

    IEnumerator AlertFlip()
    {
        yield return new WaitForSeconds(3f);
        anim.SetBool("Alert", false);
        Patrolling = true;
    }

    IEnumerator DelayAnimationDisable()
    {
        yield return new WaitForSeconds(.5f);
        gameObject.GetComponent<Animator>().enabled = false;
    }

    IEnumerator RespawnGuard()
    {
        yield return new WaitForSeconds(10f);
        this.enabled = true;
        gameObject.transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y + .22f, transform.localPosition.z);
        

        Debug.Log(transform.childCount);
        int i = 0;
        GameObject[] allChildren = new GameObject[transform.childCount];
        foreach (Transform child in transform)
        {
            allChildren[i] = child.gameObject;
            i += 1;
        }
        foreach (GameObject child in allChildren)
        {
            child.gameObject.SetActive(true);
        }
        Debug.Log(transform.childCount);

        anim.ResetTrigger("Incap");
        //anim.SetBool("Incapacitated", false);
        //anim.SetTrigger("Incap");
        anim.SetBool("Patrolling", true);

        Debug.Log("YOUVE MADE IT THIS FAR");

        Patrolling = true;
        Incapacitated = false;
        chasing = false;
        alert = false;
    }
}
