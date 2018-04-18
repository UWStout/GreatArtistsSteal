using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEnclose : MonoBehaviour {

    Vector3 scale = new Vector3(.1f, .1f, 1f);

    private void Start()
    {
        transform.localScale = new Vector3(.1f, .1f, 1f);
     //   transform.localScale = Vector3.Lerp(transform.localScale, scale, Time.deltaTime);
    }
}
