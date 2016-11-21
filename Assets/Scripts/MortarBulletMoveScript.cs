using UnityEngine;
using System.Collections;

public class MortarBulletMoveScript : MonoBehaviour {

    public Vector3 TargetPosition = new Vector3();
    public GameObject MortarTarget;
    public float Speed = 10f;
    public bool isCentral;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        if (gameObject.activeInHierarchy) {
            float step = Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, TargetPosition, step);

            if (transform.position == TargetPosition) {
                gameObject.SetActive(false);
                if (isCentral) {
                    MortarTarget.SetActive(false);
                }
            }
        }

    }

}
