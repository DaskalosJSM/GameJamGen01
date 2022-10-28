using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public GameManager Manager;
    private GameObject Player;

    public int coins = 0;
    public int stars = 0;
    public int vidas = 3;

    void Update()
    {
        muerte();
    }
    void muerte()
    {
        if (vidas == 0)
        {
            Manager.PrincipalMenu();
        }
    }

}
