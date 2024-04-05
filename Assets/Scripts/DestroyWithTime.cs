using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithTime : MonoBehaviour
{
    [SerializeField] private float destroyTime;

    private void OnEnable()
    {
        Destroy(this.gameObject, destroyTime);
    }
}
