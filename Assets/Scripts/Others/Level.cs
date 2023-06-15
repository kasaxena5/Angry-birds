using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] TMP_Text levelText;
    
    public void InitializeLevel(int level)
    {
        levelText.text = level.ToString();
    }

    public void Select()
    {
        this.GetComponent<Button>().Select();
    }
}
