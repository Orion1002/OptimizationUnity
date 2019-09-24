using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTransform : MonoBehaviour {

    [Header("Follow Settings")]
    //Headers help format the inspector, making both the script and the inspector more readable
    [SerializeField] private Transform _targetTransfrom;
    //[SerializeField] allows private variables to be viewed in the inspector
    public Vector3 offset = new Vector3();

    // Start is called before the first frame update
    void Start() {
        
    }

    //Fixed update is best for player and camera movement
    private void FixedUpdate() {
        _FollowTransform();
    }

	private void _FollowTransform() {
        Vector3 newPosition = _targetTransfrom.position + offset;
        this.transform.position = newPosition;
	}

    /// <summary>
    /// Allows the camera to change what object the camera follows.
    /// </summary>
    /// <param name="newTarget"></param>
    public void ChangeTarget(Transform newTarget) {
        _targetTransfrom = newTarget;
    }
}
