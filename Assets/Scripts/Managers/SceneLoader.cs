using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }

    [Header("Prefabs")]
    [SerializeField] private GameObject loadingCanvasPrefab;
    [SerializeField] private Event levelLoadedEvent;

    [Header("Configs")]
    [SerializeField] SceneState sceneState = SceneState.Loaded;
    [SerializeField] string animationEntryTrigger;
    [SerializeField] string animationExitTrigger;
    [SerializeField] float animationTime;
    [SerializeField] float waitingTime;

    public enum SceneState
    {
        Loading,
        Loaded
    }

    public SceneState GetState()
    {
        return sceneState;
    }
    

    private GameObject loadingCanvas;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    public void StartScene(string scene)
    {
        StartCoroutine(LoadScene(scene));
    }

    private void SetupLoadingCanvas()
    {
        sceneState = SceneState.Loading;
        loadingCanvas = Instantiate(loadingCanvasPrefab);
        loadingCanvas.SetActive(true);
    }

    private void TearDownLoadingCanvas()
    {
        loadingCanvas.SetActive(false);
        sceneState = SceneState.Loaded;
        Destroy(loadingCanvas);

    }
    IEnumerator LoadScene(string scene)
    {
        SetupLoadingCanvas();

        yield return StartCoroutine(PlayAndWaitForLoadingAnimation(animationEntryTrigger));
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
        yield return StartCoroutine(WaitForLoadingContent());
        yield return StartCoroutine(PlayAndWaitForLoadingAnimation(animationExitTrigger));

        TearDownLoadingCanvas();

        levelLoadedEvent.RaiseEvent();
    }

    IEnumerator WaitForLoadingContent()
    {
        WebRequests loadingWebRequests = loadingCanvas.GetComponent<WebRequests>();
        while (loadingWebRequests.GetState() == WebRequests.WebRequestState.Loading)
            yield return null;
        yield return new WaitForSeconds(waitingTime);
    }

    IEnumerator PlayAndWaitForLoadingAnimation(string clipName)
    {
        Animator animator = loadingCanvas.GetComponent<Animator>();
        animator.SetTrigger(clipName);

        yield return new WaitForSeconds(animationTime);
    }

}