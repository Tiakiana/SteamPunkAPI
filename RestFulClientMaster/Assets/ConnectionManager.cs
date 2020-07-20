using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ConnectionManager : MonoBehaviour
{
    public string WEB_URL;
    public GameObject SpawnedPlayers;

 
    public static ConnectionManager inst;
    
    // Use this for initialization
    private void Awake()
    {
        inst = this;
    }
    void Start()
    {

        //  StartCoroutine(RestfulClientScr.Inst.Post(WEB_URL, new PostObject { currentturn = 34 }));
        //  StartCoroutine("CheckForMoves");

        RestfulClientScr.Inst.SetStringURL(WEB_URL);
        StartCoroutine(RestfulClientScr.Inst.Post(new PlayerAction("Jakob","Tag en ged",142f)));
       StartCoroutine(RestfulClientScr.Inst.Get(WEB_URL));
        StartCoroutine(RestfulClientScr.Inst.Get(WEB_URL,"Hubert"));
        StartCoroutine(RestfulClientScr.Inst.Put(WEB_URL,new PlayerAction("Hubert","Fremelsk en franskmand",42)));

    }


    IEnumerator CheckForMoves()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(1);
        }
    }

    //public void CheckAndSpawnPlayer()
    //{
    //    foreach (PlayerInfo player in FlightManager.inst.playerList)
    //    {
    //        if (SpawnedPlayers.transform.Find(player.name) == null)
    //        {
    //            GameObject play = Instantiate(PlanePrefab, SpawnedPlayers.transform) as GameObject;
    //            play.name = player.name;
    //            if (player.team == 1)
    //            {
    //                play.transform.position = SpawnPointsTeam1.transform.GetChild(spawnnumberteam1).transform.position;
    //                play.transform.rotation = SpawnPointsTeam1.transform.GetChild(spawnnumberteam1).transform.rotation;
    //                spawnnumberteam1++;
    //                play.GetComponent<XWingMovement>().Team = 1;
    //            }
    //            else if (player.team == 2)
    //            {
    //                play.transform.position = SpawnPointsTeam2.transform.GetChild(spawnnumberteam2).transform.position;
    //                play.transform.rotation = SpawnPointsTeam2.transform.GetChild(spawnnumberteam2).transform.rotation;
    //                spawnnumberteam2++;
    //                play.GetComponent<XWingMovement>().Team = 2;

    //            }
    //            else if (player.team == 3)
    //            {
    //                play.transform.position = SpawnPointsTeam3.transform.GetChild(spawnnumberteam2).transform.position;
    //                play.transform.rotation = SpawnPointsTeam3.transform.GetChild(spawnnumberteam2).transform.rotation;
    //                spawnnumberteam3++;
    //                play.GetComponent<XWingMovement>().Team = 3;


    //            }
    //            else
    //            {
    //                play.transform.position = SpawnPointsTeam4.transform.GetChild(spawnnumberteam2).transform.position;
    //                play.transform.rotation = SpawnPointsTeam4.transform.GetChild(spawnnumberteam2).transform.rotation;
    //                spawnnumberteam4++;
    //                play.GetComponent<XWingMovement>().Team = 4;

    //            }
    //        }
    //    }
    //}



    public void DeletePlayer(string name) {
       // RestfulClientScr.Inst.Delete(WEB_URL,name);
    }

    public void PostNewTurn(int turnnumber)
    {
       // StartCoroutine(RestfulClientScr.Inst.Post(WEB_URL, new PostObject() { currentturn = turnnumber }));
    }

    public void GetPlayerActions()
    {
   //     StartCoroutine(RestfulClientScr.Inst.Get(WEB_URL));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
