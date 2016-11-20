using UnityEngine;
using System.Collections;

public class CityMenuController : MonoBehaviour {

    GameObject cityMenu;
    GameObject shopMenu;
    GameObject tavernMenu;
    GameObject shipyardMenu;
    GameObject cityFrame;
    GameObject pauseMenuButton;

    GameObject hud;
    GameObject buttonPanel;

    public GameObject EnterCityButton;
    // Aktywuje sie po wejsciu w submenu, zeby przyslonic inne buttony i nie pozwolic
    // na otworzenie kilku submenu jedno za drugim
    public GameObject ButtonBlocker;

    /**
     * Pobieranie GameObjectow, chowanie menu miasta na poczatku gry
     **/
    void Start () {
        cityMenu     = GameObject.FindGameObjectsWithTag("City Menu")[0];
        shopMenu     = GameObject.FindGameObjectsWithTag("Shop Menu")[0];
        tavernMenu   = GameObject.FindGameObjectsWithTag("Tavern Menu")[0];
        shipyardMenu = GameObject.FindGameObjectsWithTag("Shipyard Menu")[0];
        cityFrame    = GameObject.FindGameObjectsWithTag("CityViewFrame")[0];

        hud             = GameObject.FindGameObjectsWithTag("HUD")[0];
        buttonPanel     = GameObject.FindGameObjectsWithTag("Button Panel")[0];
        pauseMenuButton = GameObject.FindGameObjectsWithTag("Pause Menu Button")[0];

        cityMenu.SetActive(false);
        shopMenu.SetActive(false);
        tavernMenu.SetActive(false);
        shipyardMenu.SetActive(false);
        cityFrame.SetActive(false);


    }
	
	// Update is called once per frame
	void Update () {
	
	}

    /**
     * Aktywacja i dezaktywacja menu miasta
     * Powinna tez zostac dodana jakas pauza na czas przebywania w menu 
     **/
    public void openCityMenu() {
        GameStateController.gameState = GameStateController.GameState.PAUSED;

        cityMenu.SetActive(true);
        cityFrame.SetActive(true);

        hud.SetActive(false);
        buttonPanel.SetActive(false);
        pauseMenuButton.SetActive(false);
        EnterCityButton.SetActive(false);

        ButtonBlocker.SetActive(false);
    }

    public void closeCityMenu() {
        cityMenu.SetActive(false);
        shopMenu.SetActive(false);
        tavernMenu.SetActive(false);
        shipyardMenu.SetActive(false);
        cityFrame.SetActive(false);

        hud.SetActive(true);
        buttonPanel.SetActive(true);
        pauseMenuButton.SetActive(true);
        EnterCityButton.SetActive(true);

        GameStateController.gameState = GameStateController.GameState.PLAYING;
    }

    /**
     * Otwieranie i zamykanie menu sklepu
     **/
    public void openShopMenu() {
        shopMenu.SetActive(true);
        ButtonBlocker.SetActive(true);
    }

    public void closeShopMenu() {
        shopMenu.SetActive(false);
        ButtonBlocker.SetActive(false);
    }

    /**
     * Otwieranie i zamykanie menu tawerny
     **/
    public void openTavernMenu() {
        tavernMenu.SetActive(true);
        ButtonBlocker.SetActive(true);
    }

    public void closeTavernMenu() {
        tavernMenu.SetActive(false);
        ButtonBlocker.SetActive(false);
    }

    /**
     * Otwieranie i zamykanie menu stoczni
     **/
    public void openShipyardMenu() {
        shipyardMenu.SetActive(true);
        ButtonBlocker.SetActive(true);
    }

    public void closeShipyardMenu() {
        shipyardMenu.SetActive(false);
        ButtonBlocker.SetActive(false);
    }
}
