using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void AddScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
    }

    public static void ResetScene()
    {
        SceneManager.UnloadSceneAsync(1);
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("BaseScene"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene("Level1Scene", LoadSceneMode.Additive);

        
    }
}
