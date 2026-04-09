using TMPro;
using UnityEngine;

public class CubaGameUI : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    public float Timer;

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        TimerText.text = "생존 시간 : " + Timer.ToString("0.00");
    }
}
