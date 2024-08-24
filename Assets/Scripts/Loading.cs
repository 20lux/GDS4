using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class Loading
{
    public enum Scene
    {
        Title,
        Load,
        Main
    }
    private static Action OnLoaderCallback;
    public static void LoadScene(Scene scene)
    {
        // Set the loader callbacl action to load the target scene
        OnLoaderCallback = () =>
        {
            Initiate.Fade(scene.ToString(), Color.black, 15f);
        };

        // Load the loading scene
        Initiate.Fade(Scene.Load.ToString(), Color.black, 15f);
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
