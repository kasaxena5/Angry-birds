using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] Level levelPrefab;
    [SerializeField] Transform levelSelectCanvas;

    [Header("Configs")]
    [SerializeField] int rows;
    [SerializeField] int columns;
    [SerializeField] float gridGap;

    Level[,] levelGrid;

    private void InitializeLevelGrid()
    {
        levelGrid = new Level[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                levelGrid[i, j] = Instantiate(levelPrefab);
                levelGrid[i, j].transform.SetParent(levelSelectCanvas, false);
                levelGrid[i, j].GetComponent<RectTransform>().localPosition = new Vector3(gridGap * j - (columns / 2) * gridGap, -gridGap * i + (rows / 2) * gridGap, 0);

                int x = i;
                int y = j;
                levelGrid[i, j].GetComponent<Button>().onClick.AddListener(() => { OnClick(x, y); });
                levelGrid[i, j].InitializeLevel(i * rows + j);
            }
        }
    }

    void OnClick(int i, int j)
    {
        int level = i * rows + j;
        SceneLoader.Instance.StartScene("Level" + level + "Scene");
    }

    void Awake()
    {
        InitializeLevelGrid();    
    }
}
