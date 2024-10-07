using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    private class LoadingMonoBehaviour : MonoBehaviour {  }
    private static AsyncOperation loadAsyncOperation;

    public enum Scene
    {
        Title,
        Load,
        Main
    }
    
    private static Action OnLoaderCallback;
    public static void Load(Scene scene)
    {
        // Set the loader callback action to load the target scene
        OnLoaderCallback = () =>
        {
            GameObject loadingGameObject = new GameObject("Loading Game Object");   
            loadingGameObject.AddComponent<LoadingMonoBehaviour>().StartCoroutine(LoadSceneAsync(scene));
        };

        // Load the loading scene
        SceneManager.LoadScene(Scene.Load.ToString());
    }

    private static IEnumerator LoadSceneAsync(Scene scene)
    {
        yield return null;

        loadAsyncOperation = SceneManager.LoadSceneAsync(scene.ToString());

        while (!loadAsyncOperation.isDone)
        {
            yield return null;
        }
    }

    public static float GetLoadingProgress()
    {
        if (loadAsyncOperation != null)
        {
            return loadAsyncOperation.progress;
        }
        else
        {
            return 1f;
        }
    }

    public static void LoaderCallback()
    {
        // Triggered after the first update which lets the screen refresh
        // Execute the loader callback action which will load the target scene
        if (OnLoaderCallback != null)
        {
            OnLoaderCallback();
            OnLoaderCallback = null;
        }
    }
}
