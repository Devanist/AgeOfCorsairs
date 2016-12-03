using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Models;
using System;

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
            Player.GetComponent<Wallet>().ChangeAmount(-repairCosts);
            calculateRepairCosts();

        }
    }

    public void BuyUpgrade(string updateName) {

        int cost = 0;

        switch (updateName) {
            case "Hardened body":
                cost = 500;
                break;
            case "Swivel guns":
                cost = 450;
                break;
            case "Bow cannons":
                cost = 350;
                break;
            case "Stern cannons":
                cost = 350;
                break;
            case "Cotton sails":
                cost = 400;
                break;
            default:
                throw new System.Exception("NO UPDATE LIKE: " + updateName);
        }

        if (Player.GetComponent<Wallet>().CashAmount >= cost && !Player.GetComponent<ShipStats>().isApplied(updateName)) {
            Player.GetComponent<Wallet>().ChangeAmount(-cost);
            Player.GetComponent<ShipStats>().apply(updateName);

            prepareButtons();
        }

    }

    public void prepareButtons() {

        foreach (string s in Player.GetComponent<ShipStats>().UpgradesNames()) {
            if (Player.GetComponent<ShipStats>().isApplied(s)) {
                GameObject.Find(s+" Button").GetComponent<Button>().interactable = false;
            }
        }

    }
}
