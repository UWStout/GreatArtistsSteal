using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMovement : MonoBehaviour {

    public LayerMask guardMask;//layermask of guard so the guard cannot colide with itself
    Rigidbody guardBody;//rigidbody of the guard
    Transform guardTrans;

    public void Start()
    {
        guardTrans = this.transform;
        

    }
}
