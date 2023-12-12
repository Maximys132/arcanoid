
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scr_cart_state : MonoBehaviour
{
    [SerializeField] private float cd_time = 100f;
    [SerializeField] public Scr_LevelsRule LevelsRule;
    private Image stab;
    private bool isCD;
    void Start()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            if (this.gameObject.transform.GetChild(i).name == "Stab")
            {
                stab = this.gameObject.transform.GetChild(i).gameObject.GetComponent<Image>();
            }
        }
        isCD = true;
        activate();
        enable();
    }

    void activate ()
    {
        Debug.Log("cart activate");
        stab.CrossFadeAlpha(0f, 100f, true); 
    }

    void enable()
    {
        Debug.Log("cart enable");
        stab.CrossFadeAlpha(0.7f, 100f, true);
    }

}
