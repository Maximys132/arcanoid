using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class Scr_LevelsRule : MonoBehaviour
{
    public int ballCount = 3;
    public Transform bricks;
    //public GameObject thisObject;

    private TextMeshProUGUI livesInfo;
    private TextMeshProUGUI scoreInfo;
    //private TextMeshProUGUI PCaption;
    [SerializeField] private Scr_SceneSetting pausePanel;
    private int BricksBroke, bricksTotalCount, goldCount;

    public void Start()
    {
        goldCount = 0;
        BricksBroke = 0;
        bricksTotalCount = bricks.childCount;
        Debug.Log("bricksTotalCount = " + bricksTotalCount);


        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            if (this.gameObject.transform.GetChild(i).name == "Lives (TMP)")
            {
                livesInfo = this.gameObject.transform.GetChild(i).GameObject().GetComponent<TextMeshProUGUI>();
                //Debug.Log("livesInfo");
            }
            if (this.gameObject.transform.GetChild(i).name == "Score (TMP)")
            {
                scoreInfo = this.gameObject.transform.GetChild(i).GameObject().GetComponent<TextMeshProUGUI>();
                //Debug.Log("livesInfo");
            }
        }
        livesInfo.text = (ballCount + " Lives").ToString();
    }

    public void BallFall()
    {
        Debug.Log("Ball down");
        ballCount--;
        livesInfo.text = (ballCount + " Lives").ToString();
        if (ballCount < 1)
        {
            pausePanel.PauseButtonPress("You lose");
        }
    }

    public void LevelClear()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void BrickDown()
    {
        BricksBroke++;
        Debug.Log("Bricks crashed" + BricksBroke);
        if (BricksBroke >= bricksTotalCount)
        {
            Invoke("wining", 1.5f);

        }
    }

    private void wining()
    {
        Debug.Log("You Win");
        pausePanel.PauseButtonPress("You Win");
    }

    public void CatchBonuce()
    {
        Debug.Log("CatchBonuce");
        goldCount++;
        scoreInfo.text = ("Gold: " + goldCount).ToString();
    }
    public void addGold(int increm)
    {
        goldCount += increm;
        scoreInfo.text = ("Gold: " + goldCount).ToString();
    }
    public int getGold()
    {
        return goldCount;
    }
}
