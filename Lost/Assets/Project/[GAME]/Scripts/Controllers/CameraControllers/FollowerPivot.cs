using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerPivot : MonoBehaviour
{
    [SerializeField] private Transform _target;
    /*[SerializeField]*/ private Vector3 _offset;
    private float _rotationSpeed = 5.0f;

    void Start()
    {
        //_offset = _target.position - transform.position;
        //_offset = new Vector3(-1.16f, -2.3f, 1.16f);

        //_offset = new Vector3(-0.2199993f, -1.73f, 0.2200003f);

        _offset = _target.position - transform.position;
        _offset = new Vector3(-17.545f, -16.94f, -18.634f);
    }

    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            Quaternion camTurnAngle =
                Quaternion.AngleAxis(Input.GetAxis("Mouse X") * _rotationSpeed, Vector3.up);

            _offset = camTurnAngle * _offset;
        }

        transform.position = _target.position - _offset;
        transform.LookAt(_target.position + Vector3.up * 2f);
    }
}
