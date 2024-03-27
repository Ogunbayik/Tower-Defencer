using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateZero : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
