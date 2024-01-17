using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdditiveSceneManager : MonoBehaviour
{
    // Singleton
    public static AdditiveSceneManager Instance { get; private set; }
    private void Awake() => Instance = this;

    // Scenes that are active in real-time
    private static List<string> activeScenes = new List<string>();

    // Scenes that are loading in real-time
    private static Dictionary<string, AsyncOperation> loadingOperations = new Dictionary<string, AsyncOperation>();


    // Loads a scene asynchronously - We're assuming that we don't want to load duplicate scenes
    public static async UniTask LoadSceneAsync(string sceneName)
    {
        if (activeScenes.Contains(sceneName) || loadingOperations.ContainsKey(sceneName))
        {
            throw new System.Exception("Scene is already loading / loaded!");
        }

        var operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        // Add to list of currently active loading scene operations
        loadingOperations.Add(sceneName, operation);

        // Wait for scene to finish loading
        await operation;

        // Remove from list of currently active loading scene operations
        loadingOperations.Remove(sceneName);

        // Add to list of currently active scenes
        activeScenes.Add(sceneName);
    }

    // Unloads a scene asynchronously, even if the scene is still loading in real-time
    public static async UniTask UnloadSceneAsync(string sceneName)
    {
       // Check if scene is currently loading
        if (loadingOperations.ContainsKey(sceneName))
        {
            // Wait for scene to finish loading
            await loadingOperations[sceneName];
        }
        else if (activeScenes.Contains(sceneName) == false)
        {
            // Scene is not loading / active 
            throw new System.Exception("Scene is not loading nor is active!");
        }

        var operation = SceneManager.UnloadSceneAsync(sceneName);

        // SceneManager.UnloadSceneAsync() returns null if scene is already unloading
        if (operation == null)
        {
            throw new System.Exception("Scene is already unloading!");
        }

        await operation;

        // Remove from list of currently active scenes
        activeScenes.Remove(sceneName);
    }

    public static async UniTask UnloadAllScenesAsync()
    {
        List<UniTask> uniTasks = new List<UniTask>();

        foreach (var sceneName in activeScenes)
        {
            uniTasks.Add(UnloadSceneAsync(sceneName));
        }

        foreach (var sceneName in loadingOperations.Keys)
        {
            uniTasks.Add(UnloadSceneAsync(sceneName));
        }

        await UniTask.WhenAll(uniTasks);
    }

}