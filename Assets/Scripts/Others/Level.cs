using UnityEngine;
using TMPro;

public class Level : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] TMP_Text levelText;
    private int level;

    public void InitializeLevel(int level)
    {
        this.level = level;
        levelText.text = level.ToString();
    }
}
