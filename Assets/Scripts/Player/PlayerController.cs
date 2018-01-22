using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private GameObject playerModel;

    [Header("Wheels")]
    [SerializeField]
    private GameObject frontWheel;
    [SerializeField]
    private GameObject backWheel;

    [SerializeField]
    private float floorCheckUpAmount;

    private Vector3 boardDir;

    private bool grounded = true;

    private Rigidbody rigid;

    private void Awake() {
        //rigid = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * Time.deltaTime * 5;

        if (grounded) {
            boardDir = CalcBoardDir();

            if (boardDir != Vector3.zero) {
                transform.LookAt(transform.position + boardDir);
            }
        }

    }

    Vector3 CalcBoardDir () {
        Vector3 _boardDir = Vector3.zero;
        Vector3 frontPoint = GetFloorPoint(frontWheel), backPoint = GetFloorPoint(backWheel);

        //Debug.Log("frontNorm: " + frontNorm.ToString() + ", backNorm: " + backNorm.ToString());

        if (frontPoint == Vector3.zero || backPoint == Vector3.zero)
            return Vector3.zero;

        if (playerModel.transform.rotation.y > 90 && playerModel.transform.rotation.y < 270) {
            _boardDir = backPoint - frontPoint;
        } else {
            _boardDir = frontPoint - backPoint;
        }

        Debug.DrawLine(transform.position, transform.position + _boardDir);

        return _boardDir;
    }

    Vector3 GetFloorPoint (GameObject wheel) {
        Vector3 point = Vector3.zero;

        transform.Translate(transform.up * floorCheckUpAmount);

        RaycastHit hit;
        Ray ray = new Ray(wheel.transform.position, -wheel.transform.right);

        if (Physics.Raycast(ray, out hit, 1)) {
            point = hit.point;
            Debug.DrawLine(ray.origin, point, Color.red);

        }

        transform.Translate(transform.up * -floorCheckUpAmount);

        return point;
    }
}
