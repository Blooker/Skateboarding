using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    [SerializeField]
    private WheelCollider frontWheelColl, backWheelColl;

    private WheelCollider currentFrontColl, currentBackColl;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetCollOrientation();

        if (currentFrontColl.colliding) {
            Debug.Log(currentFrontColl.lastPos);
        }
	}

    private void GetCollOrientation () {
        if (transform.eulerAngles.y > 90 && transform.eulerAngles.y < 270) {
            currentFrontColl = backWheelColl;
            currentBackColl = frontWheelColl;
        } else {
            currentFrontColl = frontWheelColl;
            currentBackColl = backWheelColl;
        }

    }
}
