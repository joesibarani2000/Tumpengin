using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingTable : MonoBehaviour
{
    [SerializeField] private float speed;
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 1f) * Time.deltaTime * speed);
    }
}
