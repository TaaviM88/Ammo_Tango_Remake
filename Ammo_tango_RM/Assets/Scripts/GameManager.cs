using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static List<GameObject> playerList;
    public static List<GameObject> spawnpoints;

    //public Transform[] spawnpoints;

    void Awake()
    {
        if(instance = null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

        SetupGame();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerList.Count);
    }

    public void SetupGame()
    {

        //lisää timeri

        playerList = new List<GameObject>();
        spawnpoints = new List<GameObject>();

        AddSpawnPoint(GameObject.Find("Spawn1"));
        AddSpawnPoint(GameObject.Find("Spawn2"));

        AddPlayer(GameObject.FindGameObjectWithTag("P1"));
        AddPlayer(GameObject.FindGameObjectWithTag("P2"));

        GetSpawnPoints();

    }

    public void AddPlayer(GameObject player)
    {
        playerList.Add(player);
    }

    public void RemovePlayer(GameObject player)
    {
        if (playerList.Contains(player)){
            playerList.Remove(player);
        }

        return;
    }

    public GameObject GetPlayer(GameObject player)
    {
        if (playerList.Contains(player))
        {
            return player;
        }

        return null;
    }

    public void AddSpawnPoint(GameObject spawner)
    {
        spawnpoints.Add(spawner);
    }

    /// <summary>
    /// Sets players on the playerList on spawnpoints on their respective list. Requires Spawn1, Spawn2 and Player1, Player2.
    /// </summary>
    public void GetSpawnPoints()
    {
        foreach(GameObject point in spawnpoints)
        {
            if (point.name.Equals("Spawn1"))
            {
                GetPlayer(playerList[0]).transform.position = point.transform.position;
            }
            if (point.name.Equals("Spawn2"))
            {
                GetPlayer(playerList[1]).transform.position = point.transform.position;
            }
        }
    }
}
