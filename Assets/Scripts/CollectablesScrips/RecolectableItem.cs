using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolectableItem : MonoBehaviour
{

    public PlayerStats estadisticas;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && this.gameObject.tag == "Coin")
        {
            estadisticas.coins += 1;
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player" && this.gameObject.tag == "Star")
        {
            estadisticas.stars += 1;
            Destroy(gameObject);
        }
    }
}
