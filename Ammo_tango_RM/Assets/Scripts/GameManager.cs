using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static List<GameObject> playerList;
    public static List<GameObject> spawnpoints;

    //public int playerID;

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
        playerList = new List<GameObject>();
        spawnpoints = new List<GameObject>();

        playerList.Add(GameObject.Find("P1"));
        playerList.Add(GameObject.Find("P2"));
        playerList.Add(GameObject.Find("P3"));
        playerList.Add(GameObject.Find("P4"));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupGame()
    {

        //lisää timeri

        AddSpawnPoint(GameObject.Find("Spawn1"));
        AddSpawnPoint(GameObject.Find("Spawn2"));

        /*
        AddPlayer(GameObject.FindGameObjectWithTag("P1"));
        AddPlayer(GameObject.FindGameObjectWithTag("P2"));
        */
        GetSpawnPoints();

    }

    /*
    public void AddPlayer(GameObject character)
    {
        switch (PlayerMovement.PlayerId){

            case 1:
                playerList[0] = character;
                PlayerMovement.PlayerId = 1;
                Debug.Log(playerList[0].name);
                break;
            case 2:
                playerList[1] = character;
                PlayerMovement.PlayerId = 2;
                break;

        }

        Debug.Log("lol ei toimi");
    }
    */

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
        Debug.Log(null);
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
                Instantiate(playerList[0]);
                playerList[0].GetComponent<PlayerMovement>().UpdatePlayerID(1);
                playerList[0].transform.position = point.transform.position;
            }
            if (point.name.Equals("Spawn2"))
            {
                Instantiate(playerList[1]);
                playerList[1].GetComponent<PlayerMovement>().UpdatePlayerID(2);
                playerList[1].transform.position = point.transform.position;
            }
        }
    }
}
