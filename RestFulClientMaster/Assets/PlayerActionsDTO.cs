using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerActionsDTO
{

    public List<PlayerAction> actions;
    public PlayerActionsDTO()
    {

    }
    public PlayerActionsDTO(List<PlayerAction> act)
    {
        actions = act;
    }


}
