using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShildLogic : MonoBehaviour
{
    private float _hp, _coolDown, _coolDownTime;
    public float maxHp;
    // Start is called before the first frame update
    void Start()
    {
        _hp = 15;
        _coolDownTime = 15;
    }

    // Update is called once per frame
    void Update()
    {
        _coolDown -= Time.deltaTime;
    }

    public bool deathCheck()
    {
        if (_hp <= 0)
            return true;
        return false;
    }

    private void death()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Debug.Log("Entity " + gameObject.name + " is killed.");
    }

    public void TakeDamage(float damage)
    {
        _hp -= damage;
        Debug.Log(gameObject.name + " hp is " + _hp.ToString());
        ChangeColor();
        if (deathCheck())
        {
            death();
        }
    }

    private void ChangeColor()
    {
        Color color = GetComponent<SpriteRenderer>().color;
        color.a = _hp / maxHp;
        GetComponent<SpriteRenderer>().color = color;
    }

    public bool ShildOn()
    {
        Debug.Log("Shild cd = " + _coolDown.ToString());
        if (deathCheck() && _coolDown < 0)
        {
            _coolDown = _coolDownTime;
            _hp = maxHp;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            ChangeColor();
            return true;
        }
        return false;
    }

    public float GetCoolDown()
    {
        return _coolDown;
    }
}
