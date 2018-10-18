using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointAnimation : MonoBehaviour {

    private bool increasingSize = true;
	
	// Update is called once per frame
	void Update () {
        Vector3 angles = transform.eulerAngles;
        angles.z += Time.deltaTime * 50f;
        transform.eulerAngles = angles;

        Vector3 localScale = transform.localScale;

        transform.localScale = localScale;
    }
}
