using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretaScript : MonoBehaviour
{
    [SerializeField] float Temporizador;
    public GameObject prefaBala;
    private float Timer;
    void Start()
    {
        Timer = Temporizador;
    }

    // Update is called once per frame
    void Update()
    {
        Temporizador-= 1 * Time.deltaTime;
        if (Temporizador <= 0)
        {
            Instantiate(prefaBala,this.transform.position, this.transform.rotation);
            Temporizador = Timer;
        }
    }
}
