
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Scr_cartsDecka : MonoBehaviour
{
    [SerializeField] public Scr_LevelsRule LevelsRule;

    [SerializeField] public Transform platformPosition;

    [SerializeField] public GameObject fireBall;
    [SerializeField] public int fireBallCost;

    [SerializeField] public GameObject electricity;
    [SerializeField] public int electricityCost;

    [SerializeField] public GameObject laser;
    [SerializeField] public int laserCost;


    public void Start()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
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
            if (this.gameObject.transform.GetChild(i).name == "cart_laser")
            {
                this.gameObject.transform.GetChild(i).GameObject().transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = (laserCost).ToString();
                //Debug.Log("pausePanel");
            }
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


}
