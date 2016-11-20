using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    private Vector3 spawnPoint;

    private bool isWalking = false;

	// Use this for initialization
	void Start () {
        spawnPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if(isWalking)
        {
            transform.position = transform.position + Camera.main.transform.forward * 0.5f * Time.deltaTime;
        }

        if(transform.position.y < -15f)
        {
            transform.position = spawnPoint;
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0f));

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.name.Equals("Plane"))
            {
                isWalking = false;
            }
            else
            {
                isWalking = true;
            }
        }
    }
}
