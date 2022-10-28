using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlatform : MonoBehaviour
{
    public float TimeToRespawn = 4;
    public float CurrentToRespawn;
    [SerializeField] bool IsGrounded = false;
    public Vector3 spawn;
    void Start() {
         spawn = this.transform.position ;
         CurrentToRespawn = TimeToRespawn;
        
    }
    void Update()
    {
        if (IsGrounded)
        {
            CurrentToRespawn -= 1 * Time.deltaTime;
        }
        if (CurrentToRespawn <= 0)
        {
            GotoOringin();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            IsGrounded = true;
        }
    }
    void GotoOringin()
    {
        this.transform.position = spawn;
        IsGrounded = false;
        CurrentToRespawn = TimeToRespawn;
    }
}
