using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{

    //int x = 0;
    //int y = 0;
    public static ManageScene Instance = null;

    public void SetInitialScreenRes()
    {
        // Set initial screen resolution
        //Screen.SetResolution(x, y, Screen.fullScreenMode);
    }
    void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
		if (Instance == null)
		{
			Instance = this;
		}
		//If an instance already exists, destroy whatever this object is to enforce the singleton.
		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad (gameObject);
        
    }

    public void PlayGame()
    {
        //GameStateManager.instance.NewGame();
        SceneManager.LoadSceneAsync("Sterling");
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