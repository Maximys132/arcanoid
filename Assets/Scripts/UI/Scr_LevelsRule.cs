using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Events;

public class Scr_LevelsRule : MonoBehaviour
{
    public int ballCount = 3;
    public Transform bricks;

    public UnityEvent<int> OnScoreChangedEvent = new UnityEvent<int>();
    public UnityEvent<int> OnGoldChangedEvent = new UnityEvent<int>();



    private TextMeshProUGUI livesInfo;
    //private TextMeshProUGUI PCaption;
    [SerializeField] private Scr_SceneSetting pausePanel;
    private int BricksBroke, bricksTotalCount, bricksHPCount, goldCount, score, totalStars;
    private float dtime = 0;

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
        }
        livesInfo.text = (ballCount + " Lives").ToString();
    }
    
    private void FixedUpdate()
    {
        dtime = dtime + Time.deltaTime;
    }

    public void BallFall()
    {
        Debug.Log("Ball down");
        ballCount--;
        livesInfo.text = (ballCount + " Lives").ToString();
        ChangeScore(-2000);
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
        ChangeScore((int)(500 - dtime * 10));
        dtime = 0;
    }
    public void ChangeScore(int incr = 0)
    {
        score = score + incr;
        OnScoreChangedEvent.Invoke(score);
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
        //Debug.Log("CatchBonuce");
        addGold(1);
    }
    public void addGold(int increm)
    {
        goldCount += increm;
        OnGoldChangedEvent.Invoke(goldCount);
    }
    public int getGold()
    {
        return goldCount;
    }
}
