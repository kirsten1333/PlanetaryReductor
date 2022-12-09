using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{

    public Transform target; //������, ������ �������� �������
    public float distance = 5.0f; // ��������� ��������
    public float xSpeed = 125.0f; // ���������������� �� ��� X
    public float ySpeed = 50.0f; // ���������������� �� ��� Y
    public float zoom = 0.25f; // ���������������� ��� ����������, ��������� �����
    public float zoomMax = 10; // ����. ����������
    public float zoomMin = 3; // ���. ����������

    [SerializeField]
    private float x = 0.0f; // ���� �� x
    [SerializeField]
    private float y = 0.0f; // ���� �� y

    void Start()
    { 
        var angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    void LateUpdate()
    {
        if (target)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0) distance += zoom;
            else if (Input.GetAxis("Mouse ScrollWheel") < 0) distance -= zoom;

            distance = Mathf.Clamp(distance, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));

            if (Input.GetKey(KeyCode.Mouse0))
            {
                x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;

                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            }

            var rotation = Quaternion.Euler(y, x, 0);
            var position = rotation * new Vector3(0.0f, 0.0f, distance) + target.position;

            transform.SetPositionAndRotation(position, rotation);
        }
    }

}
