using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FollowingProjectile : MonoBehaviour
{
    public float projectileSpeed = 100f;
    [Range(0f, 100f)]
    public float playerRememberTime = 0.2f;
    //public GameObject crosshair;

    public GameObject objectToFly;

    bool shot;

    void Start()
    {
        shot = false;
        //objectToFly = GameObject.Find("crosshair");
    }
    void FixedUpdate()
    {
        StartCoroutine(FollowObject()); //��������� �������� ������� �� ������ ������ ����� ������ ����
        if (shot) //����� ���� ��� ���������� � ��������� ����� ��� ���������� ������ ���������� �� ��������
        {
            transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime, Space.Self);
        }
    }

    IEnumerator FollowObject()
    {
        if (!shot)
        {
            transform.position = Vector3.MoveTowards(transform.position, objectToFly.transform.position, projectileSpeed * Time.deltaTime);
            //Debug.Log("follow");
            yield return new WaitForSeconds(playerRememberTime); //����� ������� ���� ������ ���������� ����� ������� (���� ������ ����� ������� ������ ���� ����� ��������� � �������)
                                                                 //���� ������� ������� ���� ����� ������ ������ ��� ��� ������� �������� � ������� ����������� ������� ����� �� �����
            shot = true;
            StopAllCoroutines(); //�� ����������� ������ ���������� �������� ����� ���� ����� �������� ��������� � ������ ���� ��� ��������� ����
        }
    }   
}