using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraScript : MonoBehaviour
{
        public Transform John;

    void Update()
    {
        if (John != null)
        {
            Vector3 position = transform.position;
            position.x = John.position.x;
            transform.position = position;
        }
    }
}
