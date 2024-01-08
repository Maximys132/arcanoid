
using System.Collections;
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
    [SerializeField] private GameObject laser;
    [SerializeField] private GameObject magnitArea;

    public void Start()
    {
    }

    public void activateFireBall()
    {
        //Debug.Log("activateFireBall");
        Vector3 startPos = platformPosition.position;
        startPos.y += 1;
        Instantiate(fireBall, startPos, Quaternion.identity);
    }
    public void activateElectrisity()
    {
        //Debug.Log("activateElectrisity");
        Instantiate(electricity, platformPosition.position, Quaternion.identity);
    }
    public void activateLaser()
    {
        //Debug.Log("activateLaser");
        Vector3 startPos = platformPosition.position;
        startPos.y += 2;
        Instantiate(laser, startPos, Quaternion.identity);
    }
    public void activateMagnGold()
    {
        //Debug.Log("activate gold magnite");
        magnitArea.transform.localScale = 30 * magnitArea.transform.localScale;
        StartCoroutine(CorutuneWaitTime(spelTimer, "disactivateMagnGold"));
    }
    public void disactivateMagnGold()
    {
        //Debug.Log("disactivate gold magnite");
        magnitArea.transform.localScale = magnitArea.transform.localScale / 30;
    }
    private IEnumerator CorutuneWaitTime(float timer, string nameProcedure)
    {
        yield return new WaitForSeconds(timer);
        Invoke(nameProcedure, 0f);
    }
    public void activateMagnBall()
    {
        activateFireBall();
    }


}
