using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/**
 * Pokazywanie / chowanie menu pauzy, pauzowanie gry
 **/
public class PauseMenuController : MonoBehaviour {

    GameObject pauseMenu;
    public GameObject enterCityButton;

    //Do chowania buttona od miasta
    private bool wasEnterCityButtonActive;


    void Start () {
        pauseMenu = GameObject.FindGameObjectsWithTag("Pause Menu")[0];

        wasEnterCityButtonActive = false;
        pauseMenu.SetActive(false);
    }
	

	void Update () {
	
	}

    public void showPauseMenu() {
        pauseMenu.SetActive(true);

        if(enterCityButton.activeSelf) {
            wasEnterCityButtonActive = true;
            enterCityButton.SetActive(false);
        }

        GameStateController.gameState = GameStateController.GameState.PAUSED;
    }

    public void hidePauseMenu() {
        pauseMenu.SetActive(false);

        if(wasEnterCityButtonActive) {
            wasEnterCityButtonActive = false;
            enterCityButton.SetActive(true);
        }

        GameStateController.gameState = GameStateController.GameState.PLAYING;
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("mainMenu");
    }
}
