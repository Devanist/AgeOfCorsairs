using UnityEngine;
using System.Collections;

public class CityMenuController : MonoBehaviour {

    GameObject CityMenu;
    GameObject HUD;
    GameObject ButtonPanel;

	// Use this for initialization
	void Start () {
        CityMenu = GameObject.FindGameObjectsWithTag("City Menu")[0];
        HUD = GameObject.FindGameObjectsWithTag("HUD")[0];
        ButtonPanel = GameObject.FindGameObjectsWithTag("Button Panel")[0];

        CityMenu.SetActive(false);
        HUD.SetActive(false);
        ButtonPanel.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    /**
     * Aktywacja i dezaktywacja menu miasta
     * Powinna tez zostac dodana jakas pauza na czas przebywania w menu 
     **/
    public void openCityMenu() {
        CityMenu.SetActive(true);
        HUD.SetActive(false);
        ButtonPanel.SetActive(false);
    }

    public void closeCityMenu() {
        CityMenu.SetActive(false);
        HUD.SetActive(true);
        ButtonPanel.SetActive(true);
    }

}
