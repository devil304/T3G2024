using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//prosta klasa do śledzenia gracza kamerą
public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _targetToFollow;

    Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - _targetToFollow.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = _targetToFollow.position + _offset;
    }
}
