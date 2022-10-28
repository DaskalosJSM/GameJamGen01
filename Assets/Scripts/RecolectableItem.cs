using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolectableItem : MonoBehaviour
{

    public PlayerStats estadisticas;
    public GameObject collecionable;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && collecionable.gameObject.tag == "Coin")
        {
            estadisticas.coins += 1;
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player" && collecionable.gameObject.tag == "Star")
        {
            estadisticas.stars += 1;
            Destroy(gameObject);
        }
    }
}
