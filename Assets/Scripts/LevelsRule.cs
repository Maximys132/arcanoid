using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelsRule : MonoBehaviour
{
    public int ballCount = 3, bricksTotalCount;
    public GameObject Info;

    private int BricksBroke = 0;
    private TextMeshPro tm;

    public void Start()
    {
        tm = Info.GetComponent<TextMeshPro>();
    }

    public void BallFall()
    {
        Debug.Log("Ball down");
        ballCount--;
        //tm.text = " Lives";
        if (ballCount < 1)
        {
            Debug.Log("You lose");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //PausePanel.SetActive(false);
            //Time.timeScale = 1f;
            

        }
    }

    public void LevelClear()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BrickDown()
    {
        BricksBroke++;
        Debug.Log("Bricks crashed" + BricksBroke);
        if (BricksBroke == bricksTotalCount)
        {
            Debug.Log("You Win");
            //InfoBalls.GetComponent<TextMeshPro>().
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //PausePanel.SetActive(false);
            //Time.timeScale = 1f;

        }
    }
}
