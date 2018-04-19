using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPatrolling : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CameraAnimation spotted = gameObject.GetComponentInParent<CameraAnimation>();

        if (collision.gameObject.tag == ("Player"))
        {
            spotted.Spotted();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CameraAnimation spotted = gameObject.GetComponentInParent<CameraAnimation>();

        if (collision.gameObject.tag == ("Player"))
        {
            spotted.UnSpotted();
        }
    }

}
