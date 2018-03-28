using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMovement : MonoBehaviour {

    //look distance of guard to determine if chasing or not
    /*public float lookDistance = 30f;
    public LayerMask hitting;//determines what to hit with the raycast
    public Transform originPoint;
    private Vector2 direction = new Vector2(-1, 0);*/

    private float guardScale = 0.8f;

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
    bool chasing = false;
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

        /*Animation animation = GetComponent<Animation>();            
        animation["Incapacitated"].wrapMode = WrapMode.Once;*/
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
        else if (Incapacitated == false && chasing == false && Patrolling == false && alert == true)//guard alert state
        {
            /*while (count <= 5 && alert == true)
            {
                while (time > 0)
                {
                    time--;
                    if (time == 1)
                    {
                        count++;
                        time = 1000f;
                    }
                }

                if (count % 2 == 0)
                {
                    Flip();
                }
                else
                {
                    Flip();
                }
            }
            if (count == 6)
            {
                alert = false;
                Patrolling = true;
            }*/
            anim.SetBool("Alert", alert);
        }
        anim.SetBool("Incapacitated", Incapacitated);
        anim.SetBool("Chasing", chasing);

    }

    private void Update()
    {
        /*Debug.DrawRay(originPoint.position, direction, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(originPoint.position, direction, lookDistance);

        if(hit == true)
        {
            if (hit.collider.tag == ("Player"))
            {
                Debug.Log("Player Hit");
            }
            if (hit.collider.tag == ("Wall"))
            {
                direction *= -1;
            }
        }

        anim.SetBool("Caught", playerCaught);*/

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

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            Debug.Log("Guard incapacitated");
            Incapacitated = true;
            //anim.SetTrigger("IncapacitatedOnce");
            gameObject.GetComponent<Collider2D>().enabled = false;

            //moves the guard back in space to allow the player sprite to not clip
            //gameObject.transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y - 1, 1);
        }
    }*/

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
        alert = true;
    }
    public void GuardCuaght()
    {
        chasing = false;
        caught = true;

        /*if (player.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-guardScale, guardScale, guardScale);
        }
        else if (player.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-guardScale, guardScale, guardScale);
        }*/

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
        otherAnimator.GetComponent<Animator>().SetTrigger("Caught");
        anim.SetBool("playerCaught", caught);
    }

    public Sprite incapacitatedSprite;
    public void GuardIncapacitated()
    {
        Debug.Log("Guard incapacitated");
        Incapacitated = true;
        anim.SetBool("Incapacitated", true);
        //gameObject.GetComponent<Animation>().Play("Incapacitated");
        //gameObject.GetComponent<Collider2D>().enabled = false;

        //moves the guard back in space to allow the player sprite to not clip
        gameObject.transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y - .33f, transform.localPosition.z);

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
            Destroy(child.gameObject);
        }
        Debug.Log(transform.childCount);

        this.enabled = false;
    }
}
