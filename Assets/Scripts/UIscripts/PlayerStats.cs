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
    public int coins = 0;
    public int stars = 0;
    public int vidas = 3;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Debug.Log(vidaActual);
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

        if (other.gameObject.tag == "DeathZone")
        {
            vidas -= 1;
            vidaui[vidaActual].gameObject.SetActive(false);
            Player.transform.position = spawn.transform.position;
            vidaActual -= 1;
        }
    }

}
