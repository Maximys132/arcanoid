
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Scr_cartsDecka : MonoBehaviour
{
    [SerializeField] public Scr_LevelsRule LevelsRule;

    [SerializeField] public Transform platformPosition;

    [SerializeField] private GameObject fireBall;
    [SerializeField] private int fireBallCost = 5;

    [SerializeField] private GameObject electricity;
    [SerializeField] private int electricityCost = 5;

    [SerializeField] private GameObject laser;
    [SerializeField] private int laserCost = 1;

    [SerializeField] private GameObject magnitArea;
    [SerializeField] private int magniteGoldCost = 5;
    [SerializeField] private float magniteGoldTimer = 10;

    [SerializeField] private int magniteBallCost = 1;

    private float timerMG = 0;
    private bool activMG = false;
    public void Start()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            setLabel(i, "cart_fireBall", (fireBallCost).ToString());
            setLabel(i, "cart_electicity", (electricityCost).ToString());
            setLabel(i, "cart_laser", (laserCost).ToString());
            setLabel(i, "cart_GMagn", (magniteGoldCost).ToString());
            setLabel(i, "cart_BMagn", (magniteBallCost).ToString());
        }
    }

    private void FixedUpdate()
    {
        if (activMG)
        {
            timerMG = timerMG + UnityEngine.Time.deltaTime;
            if (timerMG >= magniteGoldTimer)
            {
                disactivateMagnGold();
            }
            //Debug.Log("timerMG  " + timerMG);
        }
    }
    private void setLabel(int i, string name, string label)
    {
        if (this.gameObject.transform.GetChild(i).name == name)
        {
            this.gameObject.transform.GetChild(i).GameObject().transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = label;
        }
    }

    public void activateFireBall()
    {
        if (LevelsRule.getGold() >= fireBallCost)
        {
            Debug.Log("activateFireBall");
            Vector3 startPos = platformPosition.position;
            startPos.y += 1;
            Instantiate(fireBall, startPos, Quaternion.identity);
            LevelsRule.addGold(-fireBallCost);
        }
    }
    public void activateElectrisity()
    {
        if (LevelsRule.getGold() >= electricityCost)
        {
            Debug.Log("activateFireBall");
            Instantiate(electricity, platformPosition.position, Quaternion.identity);
            LevelsRule.addGold(-electricityCost);
        }
    }
    public void activateLaser()
    {
        if (LevelsRule.getGold() >= laserCost)
        {
            Debug.Log("activateLaser");
            Vector3 startPos = platformPosition.position;
            startPos.y += 2;
            Instantiate(laser, startPos, Quaternion.identity);
            LevelsRule.addGold(-laserCost);
        }
    }
    public void activateMagnGold()
    {
        Debug.Log("activate gold magnite");
        magnitArea.transform.localScale = 30 * magnitArea.transform.localScale;
        timerMG = 0;
        activMG = true;
    }
    public void disactivateMagnGold()
    {
        Debug.Log("disactivate gold magnite");
        magnitArea.transform.localScale = magnitArea.transform.localScale / 30;
        timerMG = 0;
        activMG = false;
    }
    public void activateMagnBall()
    {
        activateFireBall();
    }


}
