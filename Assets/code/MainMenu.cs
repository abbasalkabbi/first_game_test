using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame(int levelIndex)
    {
        SceneManager.LoadSceneAsync("Level" + levelIndex);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
