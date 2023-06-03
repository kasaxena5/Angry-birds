using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneLoader.Instance.StartScene("Level1Scene");
    }

    public void ContinueToGame()
    {
    }

    public void ReturnToMenu()
    {
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}