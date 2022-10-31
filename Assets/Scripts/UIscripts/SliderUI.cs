using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUI : MonoBehaviour
{
    public float CurrentTime;
    public float MaxTimer = 10;
    public Slider MainSlider;
    [SerializeField] bool IsRewinding = false;
    [SerializeField] bool IsPaused = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MainSlider.value = CurrentTime;
        if (IsRewinding == true && IsPaused == false)
        {
            CurrentTime -= 1 * Time.deltaTime;
        }
        else
        {
            CurrentTime = CurrentTime + 0;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            IsRewinding = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            IsPaused = true;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            IsRewinding = false;
            IsPaused = false;
        }
        if (CurrentTime <= MaxTimer && IsRewinding == false && IsPaused == false)
        {
            CurrentTime += 1 * Time.deltaTime;
        }
        if (CurrentTime >= MaxTimer && IsRewinding == false && IsPaused == false)
        {
            CurrentTime = 0;
        }

    }
}
