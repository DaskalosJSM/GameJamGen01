using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoutdownTimer : MonoBehaviour
{
    float currentTime = 0;
    float startingTime = 59;
    float minutes = 0;
    public float minutesTime = 2;
    [SerializeField] bool isRewinding = false;
    [SerializeField] bool PauseTime = false;

    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] TextMeshProUGUI countdownTextMinutes;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        minutes = minutesTime;
    }

    // Update is called once per frame
    void Update()
    {
        countdownTextMinutes.text = minutesTime.ToString("0");
        countdownText.text = currentTime.ToString("0");
        if (PauseTime == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                PauseTime = false;
            }

        }
        if (isRewinding == false && PauseTime == false)
        {
            currentTime -= 1 * Time.deltaTime;
        }

        if (isRewinding == true)
        {
            currentTime = currentTime + 1 * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isRewinding = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            isRewinding = false;
            PauseTime = true;
        }

        if (currentTime <= 0 && minutesTime > 0 && isRewinding == false)
        {
            currentTime = 59;
            minutesTime--;
        }
        if (currentTime >= 59 && isRewinding == true)
        {
            currentTime = 0;
            minutesTime++;
        }
    }
}
