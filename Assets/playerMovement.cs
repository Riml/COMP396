using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour {

    public float speed = 1f;
    public float acceleration = 100f;
    public float turningSpeed = 1f;
    private Rigidbody rb;
    private GameObject particle;
   


	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody>();
        particle = GameObject.Find("particals");
        

    }
	

	// Update is called once per frame
	void Update () {

        if (this.transform.position.y < -4)
            SceneManager.LoadScene("test1");
        if (Input.GetKey("w")) {
            rb.AddRelativeForce(Vector3.forward*speed* acceleration);
        }
        if (Input.GetKey("s"))
        {
            rb.AddRelativeForce(-Vector3.forward * speed * acceleration);
        }
        if (Input.GetKey("a")) {
            rb.AddTorque(Vector3.down * turningSpeed * acceleration);
                    }
        if (Input.GetKey("d"))
        {
            rb.AddTorque(Vector3.up * turningSpeed * acceleration);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.forward * speed * acceleration*0.5f);
            particle.GetComponent<ParticleSystem>().Emit(50);


        }


    }

    void moveCar() {

    }
}
