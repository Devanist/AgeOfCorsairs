using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TerritoryController : MonoBehaviour {

    public Text territoryText;
    public GameObject enterCityButton;

	// Use this for initialization
	void Start () {
        territoryText.text = "xxx";

        // Deaktywacja buttona od miasta
        enterCityButton.SetActive(false);


    }
	
	// Update is called once per frame
	void Update () {
	
	}

    /**
     * Obsluga wplyniecia do miasta
     **/
    void OnTriggerEnter2D(Collider2D collider) {

        if (collider.tag == "Friendly City") {
            enterCityButton.SetActive(true);
        }
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

        if (collider.tag == "Friendly City") {
            enterCityButton.SetActive(false);
            //territoryText.text = "Wyplynales z miasta";
        }

        territoryText.text = "Jestes na niczyim terytorium";
    }

}
