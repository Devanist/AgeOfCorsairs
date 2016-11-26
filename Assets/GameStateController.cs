using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * Skrypt odpowiadajacy za przechowywanie stanow gry
 **/
public class GameStateController : MonoBehaviour {

    public Text territoryText;

    /**
     * Enum zawierajacy stany gry
     **/
    public enum GameState {
        PAUSED,
        PLAYING
    }

    public static GameState gameState;

	// Use this for initialization
	void Start () {
        gameState = GameState.PLAYING;

    }
	
	// Update is called once per frame
	void Update () {
        territoryText.text = "Stan gry: " + gameState.ToString();
    }
}
