using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class LevelsRule : MonoBehaviour
{
    public int ballCount = 3;
    public Transform bricks;
    [SerializeField] public GameObject fireBall;
    [SerializeField] public int fireBallCost;
    [SerializeField] public Transform fireBallStartPosition;

    [SerializeField] public GameObject electricity;
    [SerializeField] public int electricityCost;
    //public GameObject thisObject;

    private TextMeshProUGUI livesInfo;
    private TextMeshProUGUI scoreInfo;
    private TextMeshProUGUI PCaption;
    private GameObject pausePanel;
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
            if (this.gameObject.transform.GetChild(i).name == "PausePanel")
            {
                pausePanel = this.gameObject.transform.GetChild(i).GameObject();
                //Debug.Log("pausePanel");
            }
            if (this.gameObject.transform.GetChild(i).name == "cart_fireBall")
            {
                this.gameObject.transform.GetChild(i).GameObject().transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = (fireBallCost).ToString();
                //Debug.Log("pausePanel");
            }
            if (this.gameObject.transform.GetChild(i).name == "cart_electicity")
            {
                this.gameObject.transform.GetChild(i).GameObject().transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = (electricityCost).ToString();
                //Debug.Log("pausePanel");
            }
        }

        for (int i = 0; i < pausePanel.transform.childCount; i++)
        {
            if (pausePanel.transform.GetChild(i).name == "PCaption (TMP)")
            {
                PCaption = pausePanel.transform.GetChild(i).GameObject().GetComponent<TextMeshProUGUI>();
                Debug.Log("PCaption");
            }
        }
        pausePanel.SetActive(false);
        livesInfo.text = (ballCount + " Lives").ToString();
    }

    public void BallFall()
    {
        Debug.Log("Ball down");
        ballCount--;
        livesInfo.text = (ballCount + " Lives").ToString();
        if (ballCount < 1)
        {
            //Debug.Log("You lose");
            PCaption.text = "You lose";
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
            

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
        if (BricksBroke >= bricksTotalCount)
        {
            Invoke("wining", 1.5f);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }

    private void wining()
    {
        Debug.Log("You Win");
        PCaption.text = "You Win";
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CatchBonuce()
    {
        Debug.Log("CatchBonuce");
        goldCount++;
        scoreInfo.text = ("Gold: " + goldCount).ToString();
    }
    public void activateFireBall()
    {
        if (goldCount >= fireBallCost)
        { 
            Debug.Log("activateFireBall");
            Instantiate(fireBall, fireBallStartPosition.position, Quaternion.identity);
            goldCount -= fireBallCost;
            scoreInfo.text = ("Gold: " + goldCount).ToString();
        }
    }
    public void activateElectrisity()
    {
        if (goldCount >= electricityCost)
        {
            Debug.Log("activateFireBall");
            Instantiate(electricity, fireBallStartPosition.position, Quaternion.identity);
            goldCount -= electricityCost;
            scoreInfo.text = ("Gold: " + goldCount).ToString();
        }
    }
}
