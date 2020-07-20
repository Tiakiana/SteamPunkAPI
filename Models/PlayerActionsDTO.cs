using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteamPunkAPI.Models
{
    [JsonObject, Serializable]

    public class PlayerActionsDTO
    {
        public List<PlayerAction> actions{ get; set; }

    }
}
