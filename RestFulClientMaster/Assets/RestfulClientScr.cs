using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RestfulClientScr : MonoBehaviour
{
    private static RestfulClientScr _inst;
    private const string defaultContentType = "application/json";
    public string url = "";

    public static RestfulClientScr Inst
    {
        get
        {
            if (_inst == null)
            {
                _inst = FindObjectOfType<RestfulClientScr>();
                if (_inst == null)
                {
                    GameObject go = new GameObject();
                    go.name = typeof(RestfulClientScr).Name;
                    _inst = go.AddComponent<RestfulClientScr>();
                    DontDestroyOnLoad(go);
                }
            }
            return _inst;
        }
    }

    public IEnumerator Delete(string url, string name)
    {
        string urlWithParams = string.Format("{0}{1}", url, name);

        using (UnityWebRequest www = UnityWebRequest.Delete(urlWithParams))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    Debug.Log("Deleted " + name);
                }
            }
        }
    }
    //Unity's JsonUtility kan ikke deserialisere lister af objekter. derfor skal man smide skidtet ind i et objekt der har listen.
    public IEnumerator Get(string url)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    Debug.ClearDeveloperConsole();
                    //Debug.Log(www.downloadHandler.text);
                    string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);

                    string res = "{\"playeraction\":" + www.downloadHandler.text + "}";


                    PlayerActionsDTO dto = new PlayerActionsDTO();
                    JsonUtility.FromJsonOverwrite(jsonResult, dto);

                    //var questionRoot = JsonUtility.FromJson<QuestionRoot>(dataAsJSON);
                    Debug.Log(jsonResult);

                    //if (playerList.playerlist.Count > 0)
                    //{
                    //    Debug.Log(playerList.playerlist.Count);
                    //    foreach (PlayerInfo item in playerList.playerlist)
                    //    {
                    //        Debug.Log(item.ToString());
                    //    }
                    //    FlightManager.inst.playerList = playerList.playerlist;
                    //}

                    if (true)
                    {
                    }
                }
            }
        }

    }
    public IEnumerator Get(string url, string id)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url+"\\"+id))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    Debug.ClearDeveloperConsole();
                    //Debug.Log(www.downloadHandler.text);
                    string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);

                    //PlayerList playerList = new PlayerList();
                    string res = "{\"playerAction\": " + www.downloadHandler.text + "}";
                    string res2 = "{" + www.downloadHandler.text + "}";
                    PlayerAction play = new PlayerAction();

                    List<PlayerAction> playerlist1 = new List<PlayerAction>();
                    List<PlayerAction> playerlist2 = new List<PlayerAction>();
                    //   playerlist2 = JsonUtility.FromJson<List<PlayerAction>>(res);
                    JsonUtility.FromJsonOverwrite(jsonResult, play);

                    //var questionRoot = JsonUtility.FromJson<QuestionRoot>(dataAsJSON);
                    Debug.Log(jsonResult);

                    //if (playerList.playerlist.Count > 0)
                    //{
                    //    Debug.Log(playerList.playerlist.Count);
                    //    foreach (PlayerInfo item in playerList.playerlist)
                    //    {
                    //        Debug.Log(item.ToString());
                    //    }
                    //    FlightManager.inst.playerList = playerList.playerlist;
                    //}

                    if (true)
                    {
                    }
                }
            }
        }

    }


    
    public void SetStringURL(string rl)
    {
        url = rl;

    }
    // Lærepenge til næste gang du vil poste noget!
    // Der må ikke være en ID i klassen man poster med for some fekkin reason! Det virker sindssygt men sådan er det.
    // Det var naturligvis også derfor at jeg ikke kunne skyde en enkelt klasse afsted, men i stedet skulle pakke det ind i en liste, da dette på en eller anden måde omgår kravet om no ID på en post!
    public IEnumerator Post(PlayerAction pos)
    {
        string jsonData = JsonUtility.ToJson(pos);
        Debug.Log("IPost");
        Debug.Log(jsonData);

        PlayerAction play = new PlayerAction();
        JsonUtility.FromJsonOverwrite(jsonData,play);
        Debug.Log("Woko");
        using (UnityWebRequest www = UnityWebRequest.Post(url, jsonData))
        {
            www.SetRequestHeader("content-type", "Application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            yield return www.SendWebRequest();
            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    if (www.isHttpError)
                    {
                        Debug.Log(www.error);
                    }
                    Debug.Log("Uploaded");
                }
            }
        }
    }
    public IEnumerator Put(string url, PlayerAction pos)
    {
        string jsonData = JsonUtility.ToJson(pos);
        using (UnityWebRequest www = UnityWebRequest.Put(url+"\\"+pos.playerName, jsonData))
        {
            www.SetRequestHeader("content-type", "Application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            yield return www.SendWebRequest();
            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    Debug.Log("Putting up shit");
                    Debug.Log(www.responseCode);
                    string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    Debug.Log(jsonResult);
                }
            }
        }
    }


    //public IEnumerator GetMoves(string url, System.Action<MoveList> callBack)
    //{
    //    using (UnityWebRequest www = UnityWebRequest.Get(url))
    //    {
    //        yield return www.SendWebRequest();
    //        if (www.isNetworkError)
    //        {
    //            Debug.Log(www.error);
    //        }
    //        else
    //        {
    //            if (www.isDone)
    //            {
    //                Debug.Log(www.downloadHandler.text);
    //                string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
    //                MoveList movelist = new MoveList();
    //                string res = "{ \"moves\": " + www.downloadHandler.text + "}";
    //                JsonUtility.FromJsonOverwrite(res, movelist);
    //                callBack(movelist);
    //                // Debug.Log(jsonResult);
    //            }
    //        }
    //    }
    //}



}


public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}

