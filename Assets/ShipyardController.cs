using UnityEngine;
using System.Collections;

public class ShipyardController : MonoBehaviour {

    GameObject  ShipsButton, 
                UpgradesButton,
                ShipsPanel,
                UpgradesPanel;

	// Use this for initialization
	void Start () {
        ShipsButton = GameObject.Find("ShipsButton");
        UpgradesButton = GameObject.Find("UpgradesButton");
        ShipsPanel = GameObject.Find("ShipsPanel");
        UpgradesPanel = GameObject.Find("UpgradesPanel");

        ShipsPanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onShipsClick() {
        UpgradesPanel.SetActive(false);
        ShipsPanel.SetActive(true);
    }

    public void onUpgradesClick() {
        UpgradesPanel.SetActive(true);
        ShipsPanel.SetActive(false);
    }
}
