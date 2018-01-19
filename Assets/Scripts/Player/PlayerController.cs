using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private Vector3 gravity;

    [SerializeField]
    private float maxMoveSpeed, maxRotSpeed;

    [SerializeField]
    private float minJumpSpeed, maxJumpSpeed, jumpChargeAmount;

    [SerializeField]
    private Transform lookTarget, playerGraphics;

    private float moveSpeed, rotSpeed, jumpAmount;

    private Vector3 playerVel, playerDir;

    private bool isGrounded = false;

    private float deltaTime;

	// Use this for initialization
	void Start () {
        playerVel = new Vector3();
        rotSpeed = maxRotSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        deltaTime = Time.deltaTime;
        if (deltaTime > 0.15f) {
            deltaTime = 0.15f;
        }

        transform.rotation = Quaternion.Euler(playerDir);

        playerVel.x = playerVel.z = transform.forward.x * moveSpeed;

        if (isGrounded) {
            playerVel.y = 0;
        } else {
            playerVel += gravity * deltaTime;
        }

        transform.position += playerVel * deltaTime;

        if (transform.position.y <= 0) {
            isGrounded = true;
            transform.position = new Vector3(transform.position.x, 0, transform.position.y);
        }
    }

    public void DirectionInput (float horiz, float vert) {
        if (!isGrounded) {
            transform.Translate(0, 0.5f, 0);
            playerDir += new Vector3(vert * rotSpeed, horiz * rotSpeed, 0);
            transform.Translate(0, -0.5f, 0);
        }
    }

    public void ChargeJump () {
        if (isGrounded) {
            if (jumpAmount < 1)
                jumpAmount += jumpChargeAmount * deltaTime;

            float squishAmount = jumpAmount * 0.3f;
            playerGraphics.localScale = new Vector3(playerGraphics.localScale.x, 1 - squishAmount, playerGraphics.localScale.z);
        }
    }

    public void Jump () {
        if (isGrounded) {
            playerVel.y += jumpAmount.Remap(0, 1, minJumpSpeed, maxJumpSpeed);
            jumpAmount = 0;

            playerGraphics.localScale = Vector3.one;
            isGrounded = false;
        }
    }

    public Transform GetLookTarget () {
        return lookTarget;
    }
}
