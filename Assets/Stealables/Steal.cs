using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steal : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.transform.tag == ("Player"))
        {

        }
    }
}
