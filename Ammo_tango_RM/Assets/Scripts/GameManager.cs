using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static List<GameObject> playerList;
    public static List<GameObject> spawnpoints;
    UIManager uIManager;
    public static float timer = 0f;
    public TextMeshProUGUI timertext;

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

        AddSpawnPoint(GameObject.Find("Spawn1"));
        AddSpawnPoint(GameObject.Find("Spawn2"));
        AddSpawnPoint(GameObject.Find("Spawn3"));
        AddSpawnPoint(GameObject.Find("Spawn4"));

        uIManager = gameObject.GetComponent<UIManager>();
        //timertext.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void SetupGame()
    {
        StartCoroutine(Timer(3));
        GetSpawnPoints();

    }

    IEnumerator Timer(int time)
    {
        

        Time.timeScale = 0;

        timertext.text = time.ToString();

        while (time > 0)
        {
            yield return new WaitForSecondsRealtime(1);
            timertext.text = time.ToString();
            time--;
        }


        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 1;
        timertext.text = "GO!";

        yield return new WaitForSecondsRealtime(1);

        timertext.text = "";
        
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
        Debug.Log(null);
        return null;
    }

    public void AddSpawnPoint(GameObject spawner)
    {
        spawnpoints.Add(spawner);
    }

    public void UpdateShield(float amount, int pID)
    {
        uIManager.UpdateShieldBar(amount, pID);
    }
    public void UpdateHealth(float amount, int pID)
    {
        uIManager.UpdateHealthBar(amount, pID);
    }

    public void HideUI(GameObject setupUI)
    {
        if(setupUI.activeSelf == true)
        {
            setupUI.SetActive(false);
        }
        else
        {
            setupUI.SetActive(true);
        }
    }

    /// <summary>
    /// Sets players on the playerList on spawnpoints on their respective list.
    /// Instantiates prefabs chosen by the player and updates playerID for the instantiated gameobject (if player has PlayerMovement -component).
    /// </summary>
    public void GetSpawnPoints()
    {
        if (playerList[0].GetComponent<PlayerMovement>() != null)
        {
            Instantiate(playerList[0]).GetComponent<PlayerMovement>().UpdatePlayerID(1);
            playerList[0].transform.position = spawnpoints[0].transform.position;
        }

        if (playerList[1].GetComponent<PlayerMovement>() != null)
        {
            Instantiate(playerList[1]).GetComponent<PlayerMovement>().UpdatePlayerID(2);
            playerList[1].transform.position = spawnpoints[1].transform.position;
        }

        if (playerList[2].GetComponent<PlayerMovement>() != null)
        {
            Instantiate(playerList[2]).GetComponent<PlayerMovement>().UpdatePlayerID(3);
            playerList[2].transform.position = spawnpoints[2].transform.position;
        }

        if (playerList[3].GetComponent<PlayerMovement>() != null)
        {
            Instantiate(playerList[3]).GetComponent<PlayerMovement>().UpdatePlayerID(4);
            playerList[3].transform.position = spawnpoints[3].transform.position;
        }

    }
}
