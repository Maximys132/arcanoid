using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_SceneSetting : MonoBehaviour
{
    public GameObject PausePanel;
    public int level;

    public void PauseButtonPress()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ContinueButtonPress()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void RestartButtonPress()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1f;
    }
}
