using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_SceneSetting : MonoBehaviour
{
    [SerializeField] public GameObject PausePanel;
    [SerializeField] public GameObject joystick;

    private TextMeshProUGUI PCaption;
    private void Start()
    {
        for (int j = 0; j < PausePanel.transform.childCount; j++)
        {
            if (PausePanel.transform.GetChild(j).name == "PCaption (TMP)")
            {
                PCaption = PausePanel.transform.GetChild(j).GameObject().GetComponent<TextMeshProUGUI>();
                //Debug.Log("PCaption");
                PausePanel.SetActive(false);
            }
        }
    }

    [System.Obsolete]
    public void PauseButtonPress()
    {
        joystick.active = false;
        PCaption.text = "";
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    [System.Obsolete]
    public void PauseButtonPress(string caption)
    {
        joystick.active = false;
        PCaption.text = caption;
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    [System.Obsolete]
    public void ContinueButtonPress()
    {
        joystick.active = true;
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    [System.Obsolete]
    public void RestartButtonPress()
    {
        joystick.active = true;
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
