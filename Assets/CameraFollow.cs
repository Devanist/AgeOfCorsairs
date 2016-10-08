using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject targetGO;
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(targetGO.transform.position.x,
                                         targetGO.transform.position.y,
                                         transform.position.z);
    }
}
