using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIStats : MonoBehaviour
{
    [SerializeField] PlayerStats estadisticas;
    [SerializeField] TextMeshProUGUI coinsTexts;
    [SerializeField] TextMeshProUGUI starsText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinsTexts.text = estadisticas.coins.ToString("0");
        starsText.text = estadisticas.stars.ToString("0");
    }
}
