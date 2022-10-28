using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementPlatform : MonoBehaviour
{
    [SerializeField] Transform inicialPosition;
    [SerializeField] GameObject objectivePosition;
    [SerializeField] GameObject platform;
    private Vector3 direccion;
    public float platformVelocity = 2;
    // Start is called before the first frame update
    void Start()
    {
        inicialPosition = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        platform.transform.Translate(direccion*Time.deltaTime*platformVelocity);
        if(platform.transform.position == inicialPosition.position)
        {
            direccion = new Vector3(1,0,0);
        }
        if (platform.transform.position == objectivePosition.transform.position)
        {
            direccion = new Vector3(-1,0,0);
        }
        Debug.Log(direccion);
    }
}
