using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] GameObject[] Menus;
    private enum Menu
    {
        MainMenu,
        PlayerMenu
    }
    
    private void LoadMenu(Menu menu)
    {
        for(int i = 0; i < Menus.Length; i++)
            Menus[i].SetActive(false);
        Menus[(int)menu].SetActive(true);
    }

    public void StartGame()
    {
        LoadMenu(Menu.PlayerMenu);
    }

    public void LoadLevels()
    {
        SceneLoader.Instance.StartScene("LevelSelectScene");
    }

    public void ContinueToGame()
    {
        SceneLoader.Instance.StartScene("Level0Scene");
    }

    public void ReturnToMainMenu()
    {
        LoadMenu(Menu.MainMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}