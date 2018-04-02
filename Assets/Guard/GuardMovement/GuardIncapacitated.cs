using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardIncapacitated : MonoBehaviour {

    public Rigidbody2D rb;
    public GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
        rb = player.gameObject.GetComponent<Rigidbody2D>();
        //rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //GuardMovement incapacitated = gameObject.GetComponent<GuardMovement>();
        GuardMovement incapacitated = gameObject.GetComponentInParent<GuardMovement>();

        if (collision.gameObject.tag == ("Player"))
        {
            rb.AddForce(transform.up * 1500);
            Debug.Log("Guard Incapacitated");
            incapacitated.GuardIncapacitated();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
