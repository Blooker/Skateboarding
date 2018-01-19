using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    private float horizAxis, vertAxis;

    PlayerController playerController;

    private void Awake() {
        playerController = GetComponent<PlayerController>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        horizAxis = Input.GetAxisRaw("Horizontal");
        vertAxis = Input.GetAxisRaw("Vertical");

        playerController.DirectionInput(horizAxis, vertAxis);

        if (Input.GetKey(KeyCode.Space)) {
            playerController.ChargeJump();
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            playerController.Jump();
        }
    }
}
