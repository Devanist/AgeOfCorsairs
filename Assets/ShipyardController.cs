using UnityEngine;
using System.Collections;

public class ShipyardController : MonoBehaviour {

    GameObject ShipsButton,
                UpgradesButton,
                RepairsButton,
                ShipsPanel,
                UpgradesPanel,
                RepairsPanel;

	// Use this for initialization
	void Start () {
        ShipsButton = GameObject.Find("ShipsButton");
        UpgradesButton = GameObject.Find("UpgradesButton");
        ShipsPanel = GameObject.Find("ShipsPanel");
        RepairsButton = GameObject.Find("RepairsButton");
        RepairsPanel = GameObject.Find("RepairsPanel");
        UpgradesPanel = GameObject.Find("UpgradesPanel");

        ShipsPanel.SetActive(false);
        UpgradesPanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onShipsClick() {
        UpgradesPanel.SetActive(false);
        RepairsPanel.SetActive(false);
        ShipsPanel.SetActive(true);
    }

    public void onUpgradesClick() {
        UpgradesPanel.SetActive(true);
        ShipsPanel.SetActive(false);
        RepairsPanel.SetActive(false);
    }

    public void onRepairsClick() {
        UpgradesPanel.SetActive(false);
        ShipsPanel.SetActive(false);
        RepairsPanel.SetActive(true);
    }
}
