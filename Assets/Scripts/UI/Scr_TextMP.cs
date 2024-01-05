
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Scr_TextMP : MonoBehaviour
{
    public string caption;


    private TextMeshProUGUI Info;
    // Start is called before the first frame update
    void Start()
    {
        Info = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void UpdateText(int value)
    {
        Info.text = (caption + value);
    }
}
