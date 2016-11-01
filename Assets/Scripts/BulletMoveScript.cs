using UnityEngine;
using System.Collections;

public class BulletMoveScript : MonoBehaviour
{
    public Vector3 TargetPosition = new Vector3();
    public float Speed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (gameObject.activeInHierarchy)
        {
            float step = Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, TargetPosition, step);

            if (transform.position == TargetPosition)
                gameObject.SetActive(false);
        }

    }
}
