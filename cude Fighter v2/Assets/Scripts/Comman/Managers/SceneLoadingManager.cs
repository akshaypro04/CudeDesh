using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoadingManager : MonoBehaviour
{
    public Slider SceneLoad;
    float LoadingSceneTime;
    float maxTime = 1f;

    void Start()
    {   
        SceneLoad.minValue = 0;
        SceneLoad.maxValue = maxTime;
    }

    void Update()
    {
        LoadingSceneTime += Time.deltaTime;
        SceneLoad.value = LoadingSceneTime;

        if(LoadingSceneTime > maxTime)
        {
            SceneManager.LoadScene(2);
            LoadingSceneTime = 0f;
        }
    }

}
