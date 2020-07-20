using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class PlayerAction
{

    //Læg her mærke til at du har lavet alting i Pascal Case!
    //Dette er vigtigt idet du ikke kan få andet fra en ASP.Net applikation
    //Når du poster må du ikke medsende et id i objected. Det skal ligge ved siden af!!
    public PlayerAction(string playername, string actionName, float actionValue)
    {
        playerName = playername;
        this.actionName = actionName;
        this.actionValue = actionValue;
    }
    public PlayerAction() { }
    public string playerName;
    public string actionName;
    public float actionValue;
    public override string ToString()
    {
        return "" +  actionName + actionValue;
    }
  

}
