using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : EntityLogic
{
    public float rechargeTime, shootingTime, changeRotationTime, shildOnTime;
    private float _shootindCoolDown, _changeRotationCoolDown, _changeRotationDirection, _shildOnCoolDown;
    private bool _areShoot;
    public GameObject gun, shild;


    // Update is called once per frame
    void Update()
    {
        if (_shootindCoolDown < 0)
        {
            _shootindCoolDown = Random.Range(0, _areShoot ? rechargeTime : shootingTime);
            gun.GetComponent<GunLogic>().changeBangFlag();
            _areShoot = !_areShoot;
        }
        if (_areShoot)
        {
            if(_changeRotationCoolDown < 0)
            {
                _changeRotationCoolDown = changeRotationTime;
                _changeRotationDirection = Random.Range(0f, 1f);
            }
            else
            {
                _changeRotationCoolDown -= Time.deltaTime;
                if (_changeRotationDirection < 0.4)
                    gun.GetComponent<GunLogic>().GunDown();
                if (_changeRotationDirection > 0.6)
                    gun.GetComponent<GunLogic>().GunUp();
            }
        }
        if(_shildOnCoolDown < 0)
        {
            shild.GetComponent<ShildLogic>().ShildOn();
            _shildOnCoolDown = shildOnTime;
        }
        _shildOnCoolDown -= Time.deltaTime;
        _shootindCoolDown -= Time.deltaTime;
    }
}
