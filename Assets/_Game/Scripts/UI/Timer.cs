using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    private TextMeshProUGUI _timeDisplay;

    // Start is called before the first frame update
    void Start()
    {
        _timeDisplay = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        float TimeLeft = GameManager.Instance.AskTime();
        int seconds = Mathf.FloorToInt(TimeLeft % 60);
        int minutes = Mathf.FloorToInt(TimeLeft / 60);

        if  (seconds <= 0 && minutes <= 0)
        {
            _timeDisplay.text = string.Format("Time Left: \n00:00");
        } else if (seconds < 10) {
            _timeDisplay.text = string.Format("Time Left: \n0{1}:0{0}", seconds, minutes);
        } else {
            _timeDisplay.text = string.Format("Time Left: \n0{1}:{0}", seconds, minutes);
        }


    }
}
