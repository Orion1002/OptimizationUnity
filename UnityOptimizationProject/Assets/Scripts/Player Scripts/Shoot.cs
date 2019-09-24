using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public Transform bulletPoint;
    public Transform playerBodyTransform;
    public GameObject[] bulletPool;
    public float coolDown = 0.2f;
    [SerializeField]private int currentIndex = 0;
    public string shoot = "";
    public Coroutine shootCoroutine;
    public bool canShoot = true;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown(shoot) && canShoot) {
            shootCoroutine = StartCoroutine("ShootBullet");

            if (currentIndex >= bulletPool.Length) {
                currentIndex = 0;
            }
        }
    }

    private IEnumerator ShootBullet() {
        canShoot = false;
        bulletPool[currentIndex].SetActive(true);
        bulletPool[currentIndex].transform.position = bulletPoint.position;
        bulletPool[currentIndex].transform.rotation = playerBodyTransform.rotation;
        currentIndex++;

        yield return new WaitForSeconds(coolDown);
        canShoot = true;
    }
}
