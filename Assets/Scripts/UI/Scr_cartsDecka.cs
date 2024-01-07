
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Scr_cartsDecka : MonoBehaviour
{
    [SerializeField] public Scr_LevelsRule LevelsRule;

    [SerializeField] public Transform platformPosition;
    
    public int spelCost = 5;
    public float spelTimer = 10;

    [SerializeField] private GameObject fireBall;

    [SerializeField] private GameObject electricity;
    [SerializeField] private int electricityCost = 5;

    [SerializeField] private GameObject laser;
    [SerializeField] private int laserCost = 1;

    [SerializeField] private GameObject magnitArea;
    [SerializeField] private int magniteGoldCost = 5;

    [SerializeField] private int magniteBallCost = 1;

    private float timerMG = 0;
    private bool activMG = false;
    public void Start()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            //setLabel(i, "cart_fireBall", (spelCost).ToString());
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
            if (timerMG >= spelTimer)
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
        Debug.Log("activateFireBall");
        Vector3 startPos = platformPosition.position;
        startPos.y += 1;
        Instantiate(fireBall, startPos, Quaternion.identity);
    }
    public void activateElectrisity()
    {
        Debug.Log("activateFireBall");
        Instantiate(electricity, platformPosition.position, Quaternion.identity);
    }
    public void activateLaser()
    {
        Debug.Log("activateLaser");
        Vector3 startPos = platformPosition.position;
        startPos.y += 2;
        Instantiate(laser, startPos, Quaternion.identity);
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
