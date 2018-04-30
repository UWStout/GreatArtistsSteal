using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairUp : MonoBehaviour {

    //public Transform player;
    //public GameObject player;
    private float locationUp = 9f;
    private bool triggerEntered = false;
    public GameObject Player;
    public GameObject DownStairs;

    //private Animator anim;
    //public Animator anim2;
    private bool enter;
    float changeHeight = 9f;
//    private bool play = true;


 void Start() {
        DownStairs = GameObject.Find("DownStairs");
        Player = GameObject.FindGameObjectWithTag("Player");
        //player.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
       // anim = GetComponent<Animator>();
        //anim2 = DownStairs.GetComponent<Animator> ();
/* 
        anim.SetBool("UpGoingUp", false);
        anim.SetBool("UpComingDown", false);
        */
     }
    private void Update()
    {
        //Debug.Log(anim.GetBool("UpGoingUp"));
        if (Input.GetKeyDown(KeyCode.E) && triggerEntered == true)
        {
            CameraFollow moveCam = GameObject.FindGameObjectWithTag("Camera").gameObject.GetComponent<CameraFollow>();
            moveCam.LerpUp();
    
            Player.SetActive(false);
            StartCoroutine(Delay());
                      
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            triggerEntered = true;
//            Debug.Log("can interact"); 
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            triggerEntered = false;
//            Debug.Log("can't interact");
        }
    }

IEnumerator Delay() {
       // play = true;
        //anim.Play("UpGoingUp");
        //anim.SetBool("UpGoingUp", true);
       //anim.Play("UpGoingUp");
       yield return new WaitForSeconds(1f);
       Vector2 before = Player.transform.position;
       Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y + locationUp);
       Vector2 after = Player.transform.position;
       //player.transform.position = player.transform.position +9;
       //Debug.Log(string.Format("PlayerMoveUp: {0} vs {1}", before, after));
       //CameraFollow.cameraHeight = CameraFollow.cameraHeight + locationUp; 
       yield return new WaitForSeconds(1f);
       Player.SetActive(true);
       

    }
    
}
