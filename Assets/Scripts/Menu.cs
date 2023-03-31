using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CallAfterDelay : MonoBehaviour
{
    float delay;
    System.Action action;

    // Will never call this frame, always the next frame at the earliest
    public static CallAfterDelay Create(float delay, System.Action action)
    {
        CallAfterDelay cad = new GameObject("CallAfterDelay").AddComponent<CallAfterDelay>();
        cad.delay = delay;
        cad.action = action;
        return cad;
    }

    float age;

    void Update()
    {
        if (age > delay)
        {
            action();
            Destroy(gameObject);
        }
    }
    void LateUpdate()
    {
        age += Time.deltaTime;
    }
}

public class Menu : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("Main game");
    }

    public void startSokoban()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);
        SceneManager.LoadScene("LevelScene", LoadSceneMode.Additive);

        CallAfterDelay.Create(1, () => {
            UnityEngine.SceneManagement.SceneManager.SetActiveScene(
                UnityEngine.SceneManagement.SceneManager.GetSceneByName("LevelScene"));
        });

    }

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("QUIT!");
    }
}
