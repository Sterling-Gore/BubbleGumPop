using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{

    //int x = 0;
    //int y = 0;
    
    public void SetInitialScreenRes()
    {
        // Set initial screen resolution
        //Screen.SetResolution(x, y, Screen.fullScreenMode);
    }
    /*void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("SceneManager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        
    }*/
    public void PlayGame()
    {
        //GameStateManager.instance.NewGame();
        SceneManager.LoadSceneAsync("Stage One");
    }


    public void Options()
    {
        SceneManager.LoadSceneAsync("Options Menu");
    }
    /*public void LoadGame()
    {
        GameStateManager.instance.LoadGame(GameStateManager.saveFilePath);
        if (GameStateManager.startedNewGame)
            GameStateManager.instance.LoadGame(GameStateManager.checkPointFilePath);
        SceneManager.LoadSceneAsync("Ship");
    }*/

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReturnToStart()
    {
        SceneManager.LoadSceneAsync("Start Menu");
    }
}