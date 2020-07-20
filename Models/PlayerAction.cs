using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Threading.Tasks;

namespace SteamPunkAPI.Models
{
    [JsonObject, Serializable]
    public class PlayerAction
    {
        //public PlayerAction(int playerID, string actionName, float actionValue)
        //{
        //    PlayerID = playerID;
        //    ActionName = actionName;
        //    ActionValue = actionValue;
        //}
        //public PlayerAction()
        //{

        //}
        public string playerName { get; set; }
        public string actionName { get; set; }
        public float actionValue { get; set; }
        

    }
}
