using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] List<string> scenes = new List<string>();
    [SerializeField] private float delayInSeconds = 0.0f;

    public void LoadNextScene(int index)
    {
        SceneManager.LoadScene(scenes[index]);
    }

    public void LoadRandomNextScene()
    {
        int index = Random.Range(0,scenes.Count);
        StartCoroutine(LoadingSceneWithDelay(scenes[index], delayInSeconds));
    }

    public void LoadNextSceneWithDelay(int index)
    {
        StartCoroutine(LoadingSceneWithDelay(scenes[index], delayInSeconds));
    }

    private IEnumerator LoadingSceneWithDelay(string sceneName, float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        SceneManager.LoadScene(sceneName);
    }
}
