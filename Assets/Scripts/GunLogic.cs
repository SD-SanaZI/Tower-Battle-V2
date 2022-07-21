using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLogic : MonoBehaviour
{
    private float _degree, _x, _coolDown;
    private bool _bangFlag;
    public float maxDegree, minDegree, delta, timeBtwBang, power;
    public GameObject core;
    void Start()
    {
        _degree = GetComponent<Transform>().rotation.z;
        _x = GetComponent<Transform>().rotation.x;
        _coolDown = 0;
        _bangFlag = false;
    }

    void Update()
    {
        if (_degree > maxDegree)
            GunDown();
        if (_degree < minDegree)
            GunUp();
        if (_coolDown > 0)
        {
            _coolDown -= Time.deltaTime;
        }
        Bang();
    }

    public void GunUp()
    {
        _degree += delta * Time.deltaTime;
        GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(_x, 0, _degree));
    }

    public void GunDown()
    {
        _degree -= delta * Time.deltaTime;
        GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(_x, 0, _degree));
    }

    public void changeBangFlag()
    {
        _bangFlag = !_bangFlag;
    }

    public void Bang()
    {
        if (_coolDown <= 0 && _bangFlag)
        {
            _coolDown = timeBtwBang;
            GameObject coreInstance = Instantiate(core, GetComponent<Transform>().position, Quaternion.identity);
            coreInstance.GetComponent<CoreLogic>().SetEnemyTag(GetComponentInParent<EntityLogic>().enemyTag);
            coreInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(
                            (float)(Math.Cos(GetComponent<Transform>().rotation.eulerAngles.z / 180 * Math.PI)) * power * GetComponent<Transform>().localScale.x,
                            (float)(Math.Sin(GetComponent<Transform>().rotation.eulerAngles.z / 180 * Math.PI)) * power * GetComponent<Transform>().localScale.x));
        }
    }
}
