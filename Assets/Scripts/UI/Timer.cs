using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI timerText1;
    float elasedTime;

    private void Update()
    {
        elasedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elasedTime / 60);
        int seconds = Mathf.FloorToInt(elasedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        timerText1.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
