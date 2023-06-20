using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] Button primaryButton;

    public void SetActive(bool value)
    {
        primaryButton.Select();
        this.gameObject.SetActive(value);
    }
}
