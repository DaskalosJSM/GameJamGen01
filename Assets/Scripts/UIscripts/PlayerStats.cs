using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    public GameObject[] vidaui;
    public int vidaActual = 0;
    public GameManager Manager;
    public GameObject Player;
    public Transform spawn;
    public Transform spawn2;
    public int coins = 0;
    public int stars = 0;
    public int vidas = 3;
    private Rigidbody rb;
    public bool Checkpoint = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        muerte();
    }
    void muerte()
    {
        if (vidas == 0)
        {
            Manager.GameOver();
        }
    }
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "DeathZone"&& Checkpoint== false)
        {
            vidas -= 1;
            vidaui[vidaActual].gameObject.SetActive(false);
            Player.transform.position = spawn.transform.position;
            vidaActual -= 1;
            rb.velocity= new Vector3(0,0,0);
        }
        if (other.gameObject.tag == "DeathZone"&& Checkpoint== true)
        {
            vidas -= 1;
            vidaui[vidaActual].gameObject.SetActive(false);
            Player.transform.position = spawn2.transform.position;
            vidaActual -= 1;
            rb.velocity= new Vector3(0,0,0);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Respawn"){
            Checkpoint= true;
        }
    }
}
