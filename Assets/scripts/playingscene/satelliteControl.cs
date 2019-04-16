using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class satelliteControl : MonoBehaviour {

	void OnBecomeInvisible()
    {
        Destroy(gameObject);
    }
}
