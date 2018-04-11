using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairUp : MonoBehaviour {

    public Transform player;
    //public GameObject player;
    private float locationUp = 9f;
    private bool triggerEntered = false;
    public GameObject Player;
    private Animator anim;
    private bool enter;
    float changeHeight = 9f;


 void Start() {
         anim = GetComponent<Animator>();
     }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && triggerEntered == true)
        {
           
            Player.SetActive(false);
            anim.Play("UpGoingUp");
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
        yield return new WaitForSeconds(1f);
        Vector2 before = player.transform.position;
        player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + locationUp);
        Vector2 after = player.transform.position;
        //player.transform.position = player.transform.position +9;
        Debug.Log(string.Format("PlayerMoveUp: {0} vs {1}", before, after));
        CameraFollow.cameraHeight = CameraFollow.cameraHeight + locationUp; 
        yield return new WaitForSeconds(1f);
        Player.SetActive(true); 
    }
    
}
