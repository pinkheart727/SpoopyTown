using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpened = false;
    public GameObject pumpkin;
    public float shootDelay;
    public GameObject spawnPoint;
    private bool canShoot = true;
    public Material defaultMaterial;
    public Material usedMaterial;
    public MeshRenderer myMR;

    private void Start()
    {
        myMR = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isOpened)
        {
            isOpened = true;
            Debug.Log("BOO!");
            StartCoroutine(DoorReset());
            myMR.material = usedMaterial;
            canShoot = false;
            Instantiate(pumpkin, spawnPoint.transform.position, spawnPoint.transform.rotation);
            StartCoroutine(ShootDelay());
        }
    }

    IEnumerator DoorReset()
    {
        yield return new WaitForSeconds(5);
        myMR.material = defaultMaterial;
        isOpened = false;
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }
}
