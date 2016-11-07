using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShipCrewScript : MonoBehaviour
{
    public Text crewAmountText;
    public int startCrewAmount = 10;
    public int maxCrewAmount = 10;
    public int currentCrewAmount;

    void Start ()
    {
        currentCrewAmount = startCrewAmount;
    }
	
	void Update ()
    {
        if (currentCrewAmount > maxCrewAmount) currentCrewAmount = maxCrewAmount; //zabezpieczenie przed zbyt dużą ilością załogi
        crewAmountText.text = currentCrewAmount.ToString();
    }


}
