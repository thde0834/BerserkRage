using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Boot : MonoBehaviour
{
    private void Start() => OnGameStart();

    // TODO: Create Loading scene
    // TODO: Create and Load start menu scene
    private async void OnGameStart()
    {
        List<UniTask> loadingTasks = new List<UniTask>()
        {
            AdditiveSceneManager.LoadSceneAsync("Static"),
            AdditiveSceneManager.LoadSceneAsync("Game")
        };

        await UniTask.WhenAll(loadingTasks);
    }

}
