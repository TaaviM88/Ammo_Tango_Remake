using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static List<GameObject> playerList;

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

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerList.Count);
    }

    public void addPlayer(GameObject player)
    {
        playerList.Add(player);
    }

    public void removePlayer(GameObject player)
    {
        if (playerList.Contains(player)){
            playerList.Remove(player);
        }

        return;
    }

    public GameObject getPlayer(GameObject player)
    {
        if (playerList.Contains(player))
        {
            return player;
        }

        return null;
    }
}
