using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(WebRequests))]
public class LoadingManager : MonoBehaviour
{
    [SerializeField] TMP_Text jokeText;

    WebRequests webRequests;

    private void Awake()
    {
        jokeText.text = "Loading Joke...";
        webRequests = GetComponent<WebRequests>();
    }

    void LoadJoke()
    {
        string url = "https://api.chucknorris.io/jokes/random";
        webRequests.Get(url, OnSuccess, OnError);
    }

    class ChuckNorrisJoke
    {
        public string value = "";
        public string url = "";
    }

    void OnSuccess(string resultText)
    {
        ChuckNorrisJoke joke = webRequests.JsonDeserialize<ChuckNorrisJoke>(resultText);
        jokeText.text = joke.value;
    }

    void OnError(string errorText)
    {
        Debug.Log(errorText);
    }

    void Start()
    {
        LoadJoke();
    }
}
