using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEnclose : MonoBehaviour {

    Vector3 FinalScale = new Vector3(.6f, .6f, 1f);
    Vector3 InitialScale = new Vector3(8f, 8f, 8f);

    private float TimeScale = 0.25f;

    private void Update()
    {
            StartCoroutine(LerpDown());
        
    }

    IEnumerator LerpDown()
    {
        float progress = 0;

        while (progress <= 1)
        {
            transform.localScale = Vector3.Lerp(InitialScale, FinalScale, progress);
            progress += Time.deltaTime * TimeScale;
            yield return null;
        }
        transform.localScale = FinalScale;
    }
}
