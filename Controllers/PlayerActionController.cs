using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SteamPunkAPI.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using Newtonsoft.Json.Serialization;

namespace SteamPunkAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class PlayerActionController : ControllerBase
    {

        public static List<PlayerAction> playerActions = new List<PlayerAction>() {
        new PlayerAction(){playerName="Hubert", actionName ="gnu en gnu",actionValue = 13},
        new PlayerAction(){playerName="Franz",actionName ="hug brand",actionValue = 16}
         };

        // GET: api/PlayerAction
        [HttpGet]
        public JsonResult Get()
        {
            
            JsonResult js = new JsonResult(new PlayerActionsDTO {actions = playerActions });
            Debug.WriteLine( js.Value.ToString());  
            Debug.WriteLine(js.ToString());
            return js;
        }

        // GET: api/PlayerAction/5
        [HttpGet("{id}", Name = "Get")]
        public JsonResult Get(string id)
        {
            JsonResult res = new JsonResult(playerActions.Single(x => x.playerName == id));
            return res;
        }

        // POST: api/PlayerAction
        [HttpPost]
        public JsonResult Post([FromBody] PlayerAction value)
        {
            playerActions.Add(value);
            return new JsonResult(playerActions);
        }

        // PUT: api/PlayerAction/5
        [HttpPut("{id}")]
        public JsonResult Put(string id, [FromBody] PlayerAction value)
        {
            if (value!=null)
            {
                playerActions.First(x => x.playerName == id).actionName = value.actionName;
                playerActions.First(x => x.playerName == id).actionValue = value.actionValue;
            }
            return new JsonResult(playerActions);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
