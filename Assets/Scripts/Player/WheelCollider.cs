using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelCollider : MonoBehaviour {

    public bool colliding = false;
    public Vector3 lastPos, lastCollNormal;


    private BoxCollider thisColl;

    private void Awake() {
        thisColl = GetComponent<BoxCollider>();
    }

    private void CalculateAvgPosAndNormal(Collision collision) {
        if (collision.contacts.Length > 0) {
            Vector3 posAvg = new Vector3(), normAvg = new Vector3();

            for (int i = 0; i < collision.contacts.Length; i++) {
                posAvg += collision.contacts[i].point;
                normAvg += collision.contacts[i].normal;
            }

            posAvg /= collision.contacts.Length;
            normAvg /= collision.contacts.Length;

            lastPos = posAvg;
            lastCollNormal = normAvg;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        CalculateAvgPosAndNormal(collision);
        colliding = true;
    }

    private void OnCollisionStay(Collision collision) {
        CalculateAvgPosAndNormal(collision);
        colliding = true;
    }

    private void OnCollisionExit(Collision collision) {
        colliding = false;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
