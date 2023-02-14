using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eddy.Utilities
{
    public class LookingAtCamera : MonoBehaviour
    {
        Transform targetToLook;
        // Start is called before the first frame update
        void Start()
        {
            targetToLook = Camera.main.transform;
        }

        // Update is called once per frame
        void Update()
        {
            transform.LookAt(targetToLook);
        }
    }
}
