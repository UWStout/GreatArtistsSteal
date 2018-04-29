using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoryOnLoad : MonoBehaviour
{
    public static GameObject instance;

    private void Awake()
    {
        /*if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }*/

        DontDestroyOnLoad(gameObject);
    }
	
}
