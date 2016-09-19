using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float rotationSpeed = 1f;
    public float basic_acceleration = 1200f;
    private float acceleration;

    public GameObject[] pathPoint;
    public GameObject player;

    private GameObject nextPoint;
    public int pointCounter;
    private Rigidbody rb;
    private Vector3 innerVector;
    private int resetCounter;

    private bool chaseMode = false;
    
    // Use this for initialization
	void Start () {
        //pointCounter = 0;
        rb = this.GetComponent<Rigidbody>();
        nextPoint = pathPoint[pointCounter];
        innerVector = Vector3.forward;
        resetCounter = 100;
        acceleration = basic_acceleration;

        innerVector = this.transform.position - nextPoint.transform.position;
        innerVector.Normalize();



    }
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.y < -2)
            Destroy(this.gameObject);

        //chasing player
        if (chaseMode)
        {
            innerVector = this.transform.position - player.transform.position;
            innerVector.Normalize();
            this.GetComponent<Renderer>().material.color = Color.blue;

            if (Mathf.Abs((this.transform.position.x - player.transform.position.x)) < 4f
               && Mathf.Abs((this.transform.position.z - player.transform.position.z)) < 4f)
            {
                acceleration = basic_acceleration * 2;
                this.GetComponent<Renderer>().material.color = Color.red;
               

            }
            else {
                acceleration = basic_acceleration;
                this.GetComponent<Renderer>().material.color = Color.blue;
            }
        }
        //patroling
        else
        {

            //switching to the chase mode
            if (Mathf.Abs((this.transform.position.x - player.transform.position.x)) < 8f
               && Mathf.Abs((this.transform.position.z - player.transform.position.z)) < 8f)
            {
                chaseMode = true;
            }
            //change target during patroling
            if (Mathf.Abs((this.transform.position.x - nextPoint.transform.position.x)) < 0.5f
                && Mathf.Abs((this.transform.position.z - nextPoint.transform.position.z)) < 0.5f)
            {
                changeTarget();
            }
                        resetCounter--;
            if (resetCounter < 0)
            {
                resetCounter = 100;
                innerVector = this.transform.position - nextPoint.transform.position;
                innerVector.Normalize();
            }
        }

        rb.AddForce(-innerVector * acceleration);
	
	}

    void changeTarget() {
        pointCounter++;
        if (pointCounter == 4)
            pointCounter = 0;
        nextPoint = pathPoint[pointCounter];

        innerVector = this.transform.position - nextPoint.transform.position;
        innerVector.Normalize();
        //Debug.Log("moving to" + pathPoint[pointCounter]);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;


    }
}
