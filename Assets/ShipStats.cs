using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipStats : MonoBehaviour {

    private List<Upgrade> Upgrades;
    private string[] _UpgradeNames = {
        "Hardened body",
        "Swivel guns",
        "Bow cannons",
        "Stern cannons",
        "Cotton sails"
    };

    private float _BaseMaxSpeed;
    private float _BaseEndurance;
    private float _BaseManeuverability;

    private float _MaxSpeed;
    private float _Endurance;
    private float _Maneuverability;

    public string ShipType;

    // Use this for initialization
    void Start () {

        Upgrades = new List<Upgrade>();
        foreach (var item in _UpgradeNames) {
            Upgrades.Add(new Upgrade(item));
        }

        switch (ShipType) {
            case "Sloop":
                _BaseMaxSpeed = 7.0f;
                _BaseEndurance = 10.0f;
                _BaseManeuverability = 5.0f;
                break;
            case "Brig":
                _BaseMaxSpeed = 8.0f;
                _BaseEndurance = 15.0f;
                _BaseManeuverability = 4.5f;
                break;
            case "Sloop-of-war":
                _BaseMaxSpeed = 9.0f;
                _BaseEndurance = 18.0f;
                _BaseManeuverability = 4.2f;
                break;
        };

        UpdateStats();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public string[] UpgradesNames() {
        return _UpgradeNames;
    }

    public float Endurance() {
        return _Endurance;
    }

    public bool isApplied(string s) {
        foreach(Upgrade item in Upgrades) {
            if(item.name() == s) {
                return item.isApplied();
            }
        }
        throw new System.Exception("NO_UPDATE_LIKE: " + s);
    }

    public void apply(string s) {
        foreach(Upgrade item in Upgrades) {
            if(item.name() == s) {
                item.apply();
            }
        }
    }

    void UpdateStats() {

        _MaxSpeed = _BaseMaxSpeed;
        _Endurance = _BaseEndurance;
        _Maneuverability = _BaseManeuverability;

        foreach (Upgrade item in Upgrades) {
            switch (item.name()) {
                case "Hardened body":
                    if (item.isApplied()) {
                        _Endurance += _BaseEndurance * 0.15f;
                    }
                    break;
                case "Swivel guns":
                    if (item.isApplied()) {

                    }
                    break;
                case "Bow cannons":
                    if (item.isApplied()) {

                    }
                    break;
                case "Stern cannons":
                    if (item.isApplied()) {

                    }
                    break;
                case "Cotton sails":
                    if (item.isApplied()) {
                        _MaxSpeed += _BaseMaxSpeed * 0.2f;
                    }
                    break;
                default:
                    break;
            }
        }
    }

    private class Upgrade {
        private string _name;
        private bool _applied;

        public Upgrade(string name) {
            _name = name;
            _applied = false;
        }

        public void apply() {
            _applied = true;
        }

        public bool isApplied() {
            return _applied;
        }

        public string name() {
            return _name;
        }
    };
}
