using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TerritoryController : MonoBehaviour {

    public Text territoryText;

	// Use this for initialization
	void Start () {
        territoryText.text = "xxx";

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D collider) {

        if (collider.tag == "Enemy Island") {
            territoryText.text = "Jestes na wrogim terytorium";
        }
        else if (collider.tag == "Friendly Island") {
            territoryText.text = "Jestes na przyjaznym terytorium";
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        territoryText.text = "Jestes na niczyim terytorium";
    }

}
