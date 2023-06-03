using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequests : MonoBehaviour
{
    public enum WebRequestState
    {
        Loading,
        Success,
        Error
    }

    private WebRequestState state = WebRequestState.Loading;

    public void SetState(WebRequestState newState)
    {
        this.state = newState;
    }

    public WebRequestState GetState()
    {
        return state;
    }

    public void Get(string url, Action<string> onSuccess, Action<string> onError)
    {
        StartCoroutine(GetCoroutine(url, onSuccess, onError));
    }

    private IEnumerator GetCoroutine(string url, Action<string> onSuccess, Action<string> onError)
    {
        SetState(WebRequestState.Loading);
        using (UnityWebRequest unityWebRequest = UnityWebRequest.Get(url))
        {
            unityWebRequest.SetRequestHeader("Content-Type", "appliction/json");
            yield return unityWebRequest.SendWebRequest();
            if(unityWebRequest.result != UnityWebRequest.Result.Success)
            {
                SetState(WebRequestState.Error);
                onError(unityWebRequest.error);
            }
            else
            {
                SetState(WebRequestState.Success);
                onSuccess(unityWebRequest.downloadHandler.text);
            }
        }
    }

    public T JsonDeserialize<T>(string resultText)
    {
        return JsonUtility.FromJson<T>(resultText);
    }

}
