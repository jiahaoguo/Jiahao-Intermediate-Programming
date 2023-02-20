
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class turretLookAt : LookingAtCamera
{
    public float detectionRadius;
    public GameObject turret2;
    private GameObject nearestObject;

    // Start is called before the first frame update
    protected override void Start()
    {
        targetToLook = Camera.main.transform;
    }

    // Update is called once per frame
    protected override void Update()
    {

        

        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Enemy");

        float nearestDistance = Mathf.Infinity;

        foreach (GameObject objectWithTag in objectsWithTag)
        {
            float distance = Vector3.Distance(transform.position, objectWithTag.transform.position);

            if (distance <= detectionRadius && distance < nearestDistance)
            {
                nearestObject = objectWithTag;
                nearestDistance = distance;
                turret2.GetComponent<turret2>().targetEnemy = nearestObject;
            }
        }

        // If there is a nearest object, rotate towards it
        if (nearestObject != null)
        {
            transform.LookAt(nearestObject.transform);
        }
    }

}


