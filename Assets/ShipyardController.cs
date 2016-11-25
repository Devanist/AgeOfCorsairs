using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Models;

public class ShipyardController : MonoBehaviour {

    GameObject  ShipsButton,
                UpgradesButton,
                RepairsButton,
                ShipsPanel,
                UpgradesPanel,
                RepairsPanel,
                RepairsCostText,
                RepairsCostTextOutline,
                Player;

    int repairCosts;

    void Awake() {
        Player = GameObject.Find("Ship");
        RepairsCostText = GameObject.Find("RepairCostText");
        RepairsCostTextOutline = GameObject.Find("RepairCostTextOutline");
    }

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

    public void calculateRepairCosts() {
        repairCosts = Player.GetComponent<ShipHealthScript>().startingHealth - Player.GetComponent<ShipHealthScript>().currentHealth;
        repairCosts *= (int)(Player.GetComponent<ShipStats>().Endurance() / 2);

        RepairsCostText.GetComponent<Text>().text = repairCosts.ToString();
        RepairsCostTextOutline.GetComponent<Text>().text = repairCosts.ToString();
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

    public void RepairHandler() {
        if(Player.GetComponent<Wallet>().CashAmount >= repairCosts) {

            Player.GetComponent<ShipHealthScript>().currentHealth = Player.GetComponent<ShipHealthScript>().startingHealth;
            Player.GetComponent<Wallet>().changeAmount(-repairCosts);
            calculateRepairCosts();

        }
    }
}
