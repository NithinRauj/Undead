using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour {

private int game_Scene_Index=1;
private int start_Scene_Index=0;
[SerializeField]
private GameObject loading_Screen;
[SerializeField]
private UnityEngine.UI.Slider slider;

public void LoadStartScene()
{
    SceneManager.LoadScene(start_Scene_Index); 
}
public void LoadGameScene()
{
    StartCoroutine(LoadSceneAsynchronously(game_Scene_Index));
}

public void QuitGame()
{
    Application.Quit();
}

IEnumerator LoadSceneAsynchronously(int scene_Index)
{
    AsyncOperation load_Operation=SceneManager.LoadSceneAsync(scene_Index);
    Cursor.visible=false;
    loading_Screen.SetActive(true);
    while(!load_Operation.isDone)
    {
        float progress=Mathf.Clamp01(load_Operation.progress/0.9f);
        Debug.Log(progress);
        slider.value=progress;
        yield return null;
    }
}	
}
