using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShipCrewScript : MonoBehaviour
{
    public Image crewMember1, crewMember2, crewMember3, crewMember4, crewMember5;
    public Image crewMember6, crewMember7, crewMember8, crewMember9, crewMember10;
    public int startCrewNumber = 10;
    public int currentCrewNumber;

    private int oldCrewNumber;

    void Start ()
    {
        currentCrewNumber = startCrewNumber;
    }
	
	void Update ()
    {
        if(currentCrewNumber != oldCrewNumber)
        {
            disableCrew();
            switch(currentCrewNumber)
            {
                case 0: disableCrew(); break;
                case 1: enableOneCrew(); break;
                case 2: enableTwoCrew(); break;
                case 3: enableThreeCrew(); break;
                case 4: enableFourCrew(); break;
                case 5: enableFiveCrew(); break;
                case 6: enableSixCrew(); break;
                case 7: enableSevenCrew(); break;
                case 8: enableEightCrew(); break;
                case 9: enableNineCrew(); break;
                case 10: enableTenCrew(); break;
            }
        }
        oldCrewNumber = currentCrewNumber;
    }

    private void disableCrew()
    {
        crewMember1.enabled = false;
        crewMember2.enabled = false;
        crewMember3.enabled = false;
        crewMember4.enabled = false;
        crewMember5.enabled = false;
        crewMember6.enabled = false;
        crewMember7.enabled = false;
        crewMember8.enabled = false;
        crewMember9.enabled = false;
        crewMember10.enabled = false;
    }

    private void enableOneCrew()
    {
        crewMember1.enabled = true;
    }

    private void enableTwoCrew()
    {
        enableOneCrew();
        crewMember2.enabled = true;
    }

    private void enableThreeCrew()
    {
        enableTwoCrew();
        crewMember3.enabled = true;
    }

    private void enableFourCrew()
    {
        enableThreeCrew();
        crewMember4.enabled = true;
    }

    private void enableFiveCrew()
    {
        enableFourCrew();
        crewMember5.enabled = true;
    }

    private void enableSixCrew()
    {
        enableFiveCrew();
        crewMember6.enabled = true;
    }

    private void enableSevenCrew()
    {
        enableSixCrew();
        crewMember7.enabled = true;
    }

    private void enableEightCrew()
    {
        enableSevenCrew();
        crewMember8.enabled = true;
    }

    private void enableNineCrew()
    {
        enableEightCrew();
        crewMember9.enabled = true;
    }

    private void enableTenCrew()
    {
        enableNineCrew();
        crewMember10.enabled = true;
    }
}
