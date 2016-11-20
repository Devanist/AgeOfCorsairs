using UnityEngine;
using System.Collections;

/**
 * Skrypt odpowiadajacy za przechowywanie stanow gry
 **/
public class GameStateController : MonoBehaviour {

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
	
	}
}
