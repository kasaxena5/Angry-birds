using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }

    [Header("Prefabs")]
    [SerializeField] private GameObject loadingCanvasPrefab;

    [Header("Configs")]
    [SerializeField] SceneState sceneState = SceneState.Loaded;
    [SerializeField] string animationEntryTrigger;
    [SerializeField] string animationExitTrigger;
    [SerializeField] float animationTime;

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
        
        yield return StartCoroutine(PlayAndWaitForLoadingAnimation(animationExitTrigger));

        TearDownLoadingCanvas();
    }

    IEnumerator PlayAndWaitForLoadingAnimation(string clipName)
    {
        Animator animator = loadingCanvas.GetComponent<Animator>();
        animator.SetTrigger(clipName);

        yield return new WaitForSeconds(animationTime);
    }

}