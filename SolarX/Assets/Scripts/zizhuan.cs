using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zizhuan : MonoBehaviour
{
    public float _RotationSpeed; //������ת���ٶ�
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.down * _RotationSpeed, Space.World);
    }
}
