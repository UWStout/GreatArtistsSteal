using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steal : MonoBehaviour {

    private bool canSteal = false;

    private void Update()
    {
        if (canSteal == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("10$");
                Destroy(gameObject);

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == ("Player"))
        {
            canSteal = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == ("Player"))
        {
            canSteal = false;
        }
    }
}
