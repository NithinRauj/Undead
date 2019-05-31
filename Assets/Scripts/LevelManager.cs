using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour {

private int game_Scene_Index=1;
private int start_Scene_Index=0;

public void LoadStartScene()
{
    SceneManager.LoadScene(start_Scene_Index); 
}
public void LoadGameScene()
{
    SceneManager.LoadScene(game_Scene_Index);
}

public void QuitGame()
{
    Application.Quit();
}
	
}
