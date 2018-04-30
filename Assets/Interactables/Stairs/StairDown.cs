using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairDown : MonoBehaviour {

    //public Transform player;
    //public GameObject player;
    private float locationDown = -9f;
    public GameObject Player;
    public GameObject UpStairs;
    private Animator anim;
    
    public Animator anim2;
    private bool triggerEntered = false;
    float changeHeight = -9f;

    void Start() {
        Player = GameObject.FindGameObjectWithTag("Player");
        //player.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        anim = GetComponent<Animator>();
        anim2 = UpStairs.GetComponent<Animator> ();

        anim.SetBool("DownGoingDown", false);
        anim.SetBool("DownComingUp", false);
     }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && triggerEntered == true)
        {
            CameraFollow moveCam = GameObject.FindGameObjectWithTag("Camera").gameObject.GetComponent<CameraFollow>();
            moveCam.LerpDown();
            //Debug.Log("Lerp down called from stairs down");
            /* 
            if(anim.GetBool("DefaultDown") == true){
                anim.enabled = true;
            }
            */

            Player.SetActive(false);
            StartCoroutine(Delay());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            triggerEntered = true;
            Debug.Log("can interact");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            triggerEntered = false;
            Debug.Log("cant interact");
        }
    }

    IEnumerator Delay() {
        
        //anim.Play("DownGoingDown");
        yield return new WaitForSeconds(1f);
        Vector2 before = Player.transform.position;
        Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y + locationDown);
        Vector2 after = Player.transform.position;
        //player.transform.position = player.transform.position +9;
        Debug.Log(string.Format("PlayerMoveDown: {0} vs {1}", before, after));
        //CameraFollow.cameraHeight = CameraFollow.cameraHeight + locationDown;
        yield return new WaitForSeconds(1f);
        Player.SetActive(true); 
       /*anim.enabled = false;
    anim.SetBool("DefaultDown", true);
    */
    }
}
