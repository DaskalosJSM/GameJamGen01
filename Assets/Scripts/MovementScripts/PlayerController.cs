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
    public float Playervelocity;
    public bool gravity;
    [SerializeField] float Gvalue;
    private float gravityVuale;
    public float JumpforceUp;
    public float JumpforceDown;
    public bool IsGrounded;
    public float jumpvelocity;
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

        float horizontalInput = Input.GetAxis("Horizontal") * Playervelocity;

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
            rb.velocity = Vector3.zero;
        }
        else if (IsGrounded == false)
        {

            //Movimineto en el aire
            rb.AddForce(new Vector3(0, Gvalue, 0), ForceMode.Acceleration);
            float horizontalInputJump = Input.GetAxis("Horizontal") * jumpvelocity;
            rb.AddForce(new Vector3(horizontalInputJump, 0, 0), ForceMode.Impulse);
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, MaxSpeed*2f);
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
            anim.SetBool("IsJumping", true);
        if (gravity == true)
        {
            // Movement in mid air
            rb.AddForce(new Vector3(0, JumpforceUp*1.3f, 0), ForceMode.VelocityChange);
        }
        if (gravity == false)
        {
            rb.AddForce(new Vector3(0, JumpforceDown*1.3f, 0), ForceMode.VelocityChange);
        }
        }
    }
    void Jump()
    {
        anim.SetBool("IsJumping", true);
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
        rb.AddForce(new Vector3(0, Gvalue, 0), ForceMode.Acceleration);
        float horizontalInput = Input.GetAxis("Horizontal") * Playervelocity;
        rb.AddForce(new Vector3(horizontalInput, 0, 0), ForceMode.Impulse);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, MaxSpeed);
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

    //consider when character is jumping .. it will exit collision.
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            IsGrounded = false;
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
            IsGrounded = false;
        }
    }
}

