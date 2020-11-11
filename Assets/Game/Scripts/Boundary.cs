using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -26f, 26f),
            Mathf.Clamp(transform.position.y, -14.5f, 14.5f), transform.position.z);
    }
}
