using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public GameObject target;
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 newPosition = new Vector3(this.transform.position.x, this.transform.position.y, target.transform.position.z-11);
        this.transform.position = newPosition;

    }
}
