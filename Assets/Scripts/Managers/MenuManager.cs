using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] Menu[] Menus;

    private enum MenuItem
    {
        MainMenu,
        PlayerMenu
    }
    
    private void LoadMenu(MenuItem menu)
    {
        for(int i = 0; i < Menus.Length; i++)
            Menus[i].SetActive(false);
        Menus[(int)menu].SetActive(true);
    }

    public void StartGame()
    {
        LoadMenu(MenuItem.PlayerMenu);
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
        LoadMenu(MenuItem.MainMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}