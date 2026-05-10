using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapper : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNextScene(string sceneName)
    {
        Globals.nextScene = sceneName;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(Globals.nextScene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
