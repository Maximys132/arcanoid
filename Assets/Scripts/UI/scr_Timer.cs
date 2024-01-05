using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class scr_Timer : MonoBehaviour
{
    private TextMeshProUGUI timeInfo;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        timeInfo = GetComponent<TextMeshProUGUI>();
    }

    private void FixedUpdate()
    {
        timer = timer + Time.deltaTime;
        timeInfo.text = ("Time   : " + timer.ToString("F2")).ToString();
    }

}
