using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot1 : MonoBehaviour {

    public GameObject[] bulletPool = new GameObject[0];
    public float coolDownTimer = 0.2f;
    public string shootButton = "Space";
    public Transform bulletPoint;
    public Transform playerBody;
    [SerializeField]private int currentIndex = 0;
    [SerializeField]private bool canShoot = true;


    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButton(shootButton) && canShoot) {
            StartCoroutine("PressToShoot");

            if (currentIndex >= bulletPool.Length) {
                currentIndex = 0;
            }
        }

    }

    private IEnumerator PressToShoot(int whatever) {
        canShoot = false;
        currentIndex++;
        bulletPool[currentIndex].transform.position = bulletPoint.transform.position;
        bulletPool[currentIndex].SetActive(true);
        bulletPool[currentIndex].transform.rotation = playerBody.transform.rotation;

        yield return new WaitForSeconds(coolDownTimer);
        canShoot = true;
    }
}
