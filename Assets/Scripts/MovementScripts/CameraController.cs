using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   [SerializeField] GameObject Cam1;
   [SerializeField] GameObject Cam2;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Cam2.SetActive(true);
        }
         if (Input.GetKeyUp(KeyCode.Q))
        {
            Cam2.SetActive(false);
        }
           
    }
    
}
