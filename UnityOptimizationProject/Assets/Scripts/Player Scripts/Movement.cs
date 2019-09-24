using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    [Header("Movement Speeds")]
    public float currentSpeed = 5f;
    public float sprintSpeed = 8f;
    public float normalSpeed = 5f;
    public float turnSpeed = 100f;

    [Header("Movement Bools")]
    public bool canWalk = true;
    public bool canSprint = true;
    public bool canTurn = true;

    [Header("Transforms")]
    public Transform playerRigTransform;
    public Transform playerBodyTransform;

    [Header("Input Strings")]
    public string horizontal = "";
    public string vertical = "";
    public string sprint = "";

    //Calculation Variables
    private float _moveHorizontal = 0f;
    private float _moveVertical = 0f;
    private Vector3 _totalMovement = new Vector3();
    private Quaternion bodyRotation = new Quaternion();


    // Start is called before the first frame update
    void Start() {
        if (playerRigTransform == null) {
            playerRigTransform = this.transform;
        }
    }

    private void FixedUpdate() {
        Walk();
        Turn();
        Sprint();
    }

    private void Walk() {
        if (canWalk) {
            if (Input.GetAxisRaw(horizontal) != 0 || Input.GetAxisRaw(vertical) != 0) {

                _moveHorizontal = Input.GetAxisRaw(horizontal);
                _moveVertical = Input.GetAxisRaw(vertical);
                _totalMovement = new Vector3(_moveHorizontal, 0 , _moveVertical);

                _totalMovement.Normalize();
                _totalMovement = _totalMovement * Time.deltaTime * currentSpeed;
                this.transform.Translate(_totalMovement);
            }
        }
    }

    private void Turn() {
        if (canTurn) {
            //Check if walking (if not don't change rotation cause otherwise it rotates player back to 0)
            if (_moveVertical != 0f || _moveHorizontal != 0f) {
                //Rotate towards movement direction
                Quaternion newRotation = Quaternion.LookRotation(_totalMovement);
                playerBodyTransform.localRotation = Quaternion.RotateTowards(playerBodyTransform.localRotation, newRotation, turnSpeed * Time.deltaTime);
            }
            //else if (Input.GetAxis(horizontalMouse) != 0)
            //{
            //    //Only if the mouse is moving:
            //    //Reset player body rotation so that player rotation doesn't affect body.
            //    playerRigTransform.rotation = bodyRotation;
            //}
        }
    }

    private void Sprint() {
        if (canSprint) {
            if (Input.GetButtonDown(sprint)) {
                currentSpeed = sprintSpeed;
            }

            if (Input.GetButtonUp(sprint)) {
                currentSpeed = normalSpeed;
            }
        }
    }
}
