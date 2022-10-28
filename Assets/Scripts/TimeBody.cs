using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{

    bool isRewinding = false;

    public Vector3 Oriposition;

    public float recordTime = 5f;


    public List<PointInTime> pointsInTime;

    Rigidbody rb;
    public bool gravity;
    private float Gvalue;
    public bool Fall = true;

    // Use this for initialization
    void Start()
    {
        Oriposition = this.transform.position;
        pointsInTime = new List<PointInTime>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gravity == true)
        {
            Gvalue = 9.6F;
        }
        else
        {
            Gvalue = -9.6F;
        }
        if (Fall == true)
        {
            rb.AddForce(new Vector3(0, Gvalue, 0), ForceMode.Acceleration);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
            StartRewind();
        if (Input.GetKeyUp(KeyCode.Mouse0))
            StopRewind();
        if (Input.GetKeyDown(KeyCode.Mouse1))
            rb.isKinematic = false;
        rb.constraints = RigidbodyConstraints.None;
    }

    void FixedUpdate()
    {
        if (isRewinding)
            Rewind();
        else
            Record();
    }

    void Rewind()
    {
        if (pointsInTime.Count > 0)
        {
            PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointsInTime.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }

    }

    void Record()
    {
        if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
        {
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
        }

        pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
    }

    public void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = true;
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            this.transform.position = Oriposition;
        }
    }
}