using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float time;
    private float timerAdd;
    private bool isTop;
    private Vector3 currentTrarget;
    private Vector3 top;
    private Vector3 down;

    private NetworkObject _networkObject;
    
    void Start()
    {
        _networkObject = GetComponent < NetworkObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(_networkObject.NetworkPosition);
        transform.position = _networkObject.NetworkPosition;
        transform.rotation = Quaternion.Euler(_networkObject.EulerAngles.x, _networkObject.EulerAngles.y, _networkObject.EulerAngles.z);
        

    }
}
