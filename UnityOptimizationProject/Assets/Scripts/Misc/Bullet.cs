using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


    public float speed = 20f;
    public float timer = 5f;
    public Transform bulletTransform;
    public Rigidbody thisRigidbody;
    public Coroutine disableCoroutine;

    // Start is called before the first frame update
    void Start() {
    }

    private void OnEnable() {
        disableCoroutine = StartCoroutine("Disable");
    }

    private void OnDisable() {
        StopCoroutine(disableCoroutine);
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private IEnumerator Disable() {
        yield return new WaitForSeconds(timer);
        this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision) {
        StopCoroutine(disableCoroutine);
        this.gameObject.SetActive(false);
    }
}
