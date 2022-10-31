using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("SideRotation")]
    public GameObject ModelRot;
    public Quaternion NewRotation;
    public float RotationSpeed;
    public Quaternion actualRotation;

    [Header("Animator")]
    public bool Climbing;
    public Animator anim;
    [Header("Stats")]
    public PlayerStats estadisticas;
    [Header("Movement")]
    public float MaxSpeed;
    private Rigidbody rb;
    public bool gravity;
    [SerializeField] float Gvalue;
    private float gravityVuale;
    public float JumpforceUp;
    public float JumpforceDown;
    public bool IsGrounded;

    public int jumCount;

    // Start is called before the first frame update
    void Start()
    {
        gravityVuale = Gvalue;
        NewRotation = Quaternion.identity;
        NewRotation.eulerAngles = new Vector3(0, 250, 0);
        actualRotation = ModelRot.transform.rotation;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector3(0, Gvalue, 0), ForceMode.Acceleration);
        float horizontalInput = Input.GetAxis("Horizontal");
        //Animations states
        if (Input.GetKeyDown(KeyCode.Space) && Climbing == true)
        {
            anim.SetTrigger("JumpfromWall");
            Climbing = false;
            jumCount = 2;
        }
        //Player rotation
        if (horizontalInput < 0)
        {
            ModelRot.transform.rotation = Quaternion.Lerp(ModelRot.transform.rotation, NewRotation, Time.deltaTime * RotationSpeed);

        }
        else if (horizontalInput > 0)
        {
            ModelRot.transform.rotation = Quaternion.Lerp(ModelRot.transform.rotation, actualRotation, Time.deltaTime * RotationSpeed);
        }

        //Gravity
        if (gravity == true)
        {
            Gvalue = -gravityVuale;
        }
        if (gravity == false)
        {
            Gvalue = gravityVuale;
        }
        // Movement
        if (horizontalInput != 0 && IsGrounded == true)
        {
            Move();
        }

        else if (IsGrounded == true)
        {
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsMoving", false);
            anim.SetBool("IsFalling", false);
            anim.SetBool("IsClimbing", false);

            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);

        }
        else if (IsGrounded == false)
        {
            //Movimineto en el aire
            float PlayerVelocity = rb.velocity.x;
            float horizontalInputAir = Input.GetAxis("Horizontal");
            rb.AddForce(new Vector3(horizontalInputAir, 0, 0), ForceMode.Impulse);
            rb.AddForce(new Vector3(0, Gvalue, 0), ForceMode.Acceleration);
            rb.velocity = new Vector3(Mathf.Clamp(PlayerVelocity, -MaxSpeed, MaxSpeed), rb.velocity.y, rb.velocity.z);


        }
        //Jump & doblejump
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded == true)
        {
            Jump();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && IsGrounded == false && jumCount != 0)
        {
            jumCount = jumCount - 1;
            Jump();
            if (gravity == true)
            {
                // Movement in mid air
                rb.AddForce(new Vector3(0, JumpforceUp / 3, 0), ForceMode.VelocityChange);
            }
            if (gravity == false)
            {
                rb.AddForce(new Vector3(0, JumpforceDown / 3, 0), ForceMode.VelocityChange);
            }
        }
    }
    void Jump()
    {
        anim.SetBool("IsJumping", true);
        anim.SetBool("IsFalling", true);
        IsGrounded = false;
        if (gravity == true)
        {
            // Movement in mid air
            rb.AddForce(new Vector3(0, JumpforceUp, 0), ForceMode.VelocityChange);
        }
        if (gravity == false)
        {
            rb.AddForce(new Vector3(0, JumpforceDown, 0), ForceMode.VelocityChange);
        }
    }
    void Move()
    {
        anim.SetBool("IsMoving", true);
        anim.SetBool("IsJumping", false);
        float PlayerVelocityM = rb.velocity.x;
        float horizontalInputGround = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector3(horizontalInputGround, 0, 0), ForceMode.Impulse);
        rb.AddForce(new Vector3(0, Gvalue, 0), ForceMode.Acceleration);
        rb.velocity = new Vector3(Mathf.Clamp(PlayerVelocityM, -MaxSpeed, MaxSpeed), rb.velocity.y, rb.velocity.z);
    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Wall")
        {
            jumCount = 1;
            anim.SetBool("IsClimbing", true);
            Climbing = true;
        }
        if (collision.gameObject.tag == "Ground")
        {
            jumCount = 1;
            IsGrounded = true;
        }
        if (collision.gameObject.tag == "platform")
        {
            this.transform.SetParent(collision.gameObject.transform);
            jumCount = 1;
            IsGrounded = true;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        Debug.Log(anim.GetBool("IsClimbing"));
        if (other.gameObject.tag == "Wall")
        {
            anim.SetBool("IsClimbing", true);
            jumCount = 1;
            Climbing = true;
        }

    }

    //consider when character is jumping .. it will exit collision.
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            anim.SetBool("IsFalling", true);
        }
        if (collision.gameObject.tag == "Wall")
        {
            anim.SetBool("IsClimbing", false);
            Climbing = false;
        }
        if (collision.gameObject.tag == "platform")
        {
            this.transform.SetParent(null);
        }
    }
}

