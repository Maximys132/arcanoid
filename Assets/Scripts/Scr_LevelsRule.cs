using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;

public class Scr_LevelsRule : MonoBehaviour
{
    public int ballCount = 3;
    public Transform bricks;
    //public GameObject thisObject;

    private TextMeshProUGUI livesInfo;
    private TextMeshProUGUI scoreInfo;
    private TextMeshProUGUI timeInfo;
    private TextMeshProUGUI GoldInfo;
    //private TextMeshProUGUI PCaption;
    [SerializeField] private Scr_SceneSetting pausePanel;
    private int BricksBroke, bricksTotalCount, bricksHPCount, goldCount, score, totalStars;
    private float timer = 0, dtime = 0;

    public void Start()
    {
        goldCount = 0;
        BricksBroke = 0;
        score = 0;
        totalStars = 0;
        bricksTotalCount = bricks.childCount;
        Debug.Log("bricksTotalCount = " + bricksTotalCount);
        for (int i = 0; i < bricks.childCount; i++)
        {
            bricksHPCount = bricksHPCount + bricks.GetChild(i).GetComponent<Animator>().GetInteger("health");
        }
        bricksHPCount = bricksHPCount * 500;
        Debug.Log("bricksHPCount = " + bricksHPCount);

        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            if (this.gameObject.transform.GetChild(i).name == "Lives (TMP)")
            {
                livesInfo = this.gameObject.transform.GetChild(i).GameObject().GetComponent<TextMeshProUGUI>();
            }
            if (this.gameObject.transform.GetChild(i).name == "Gold (TMP)")
            {
                GoldInfo = this.gameObject.transform.GetChild(i).GameObject().GetComponent<TextMeshProUGUI>();
            }
            if (this.gameObject.transform.GetChild(i).name == "Score (TMP)")
            {
                scoreInfo = this.gameObject.transform.GetChild(i).GameObject().GetComponent<TextMeshProUGUI>();
            }
            if (this.gameObject.transform.GetChild(i).name == "Time (TMP)")
            {
                timeInfo = this.gameObject.transform.GetChild(i).GameObject().GetComponent<TextMeshProUGUI>();
            }
        }
        livesInfo.text = (ballCount + " Lives").ToString();
    }
    
    private void FixedUpdate()
    {
        timer = timer + Time.deltaTime;
        dtime = dtime + Time.deltaTime;
        timeInfo.text = ("Time   : " + timer.ToString("F2")).ToString();
    }

    public void BallFall()
    {
        Debug.Log("Ball down");
        ballCount--;
        livesInfo.text = (ballCount + " Lives").ToString();
        score = score - 2000;
        scoreInfo.text = ("Score : " + score.ToString());
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
        //Debug.Log("Bricks crashed" + BricksBroke);
        if (BricksBroke >= bricksTotalCount)
        {
            Invoke("wining", 1.5f);

        }
    }

    public void BrickDamaged()
    {
        score = (int)(score + 500 - dtime * 10);
        dtime = 0;
        scoreInfo.text = ("Score : " + score.ToString());
    }

    private void wining()
    {
        Debug.Log("You Win");
        if (score >= bricksHPCount * 0.5f) totalStars = 1;
        if (score >= bricksHPCount * 0.7f) totalStars = 2;
        if (score >= bricksHPCount * 0.9f) totalStars = 3;
        pausePanel.PauseButtonPress("You Win " + totalStars);
    }

    public void CatchBonuce()
    {
        Debug.Log("CatchBonuce");
        goldCount++;
        GoldInfo.text = ("Gold: " + goldCount).ToString();
    }
    public void addGold(int increm)
    {
        goldCount += increm;
        GoldInfo.text = ("Gold: " + goldCount).ToString();
    }
    public int getGold()
    {
        return goldCount;
    }
}
