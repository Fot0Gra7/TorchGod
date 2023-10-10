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
        StartCoroutine(FollowObject()); //запускаем корутину которая на старте задает точку полета пули
        if (shot) //после того как выстрелили и запомнили точку уже сбрасываем вечное следование за прицелом
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
            yield return new WaitForSeconds(playerRememberTime); //время сколько пуля должна запоминать точку прицела (если выремя будет слишком долгое пуля будет прилипать к прицелу)
                                                                 //если слишком быстрое пуля будет лететь прямее как при обычной стрельбе и влияние шатающегося прицела будет не видно
            shot = true;
            StopAllCoroutines(); //мы обязательно должны остановить корутину иначе пуля будет пытаться вернуться в прицел если она пролетела мимо
        }
    }   
}