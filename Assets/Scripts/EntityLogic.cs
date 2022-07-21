using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityLogic : MonoBehaviour
{
    private float _hp;
    public float maxHp;
    public string enemyTag, gameOverMessage;
    public GameObject gameOverUI;

    void Start()
    {
        _hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool DeathCheck()
    {
        if (_hp <= 0)
            return true;
        return false;
    }

    private void Death()
    {
        Debug.Log("Entity " + gameObject.name + " is killed.");
        gameOverUI.GetComponent<GameOver>().Activate(gameOverMessage);
    }

    public void TakeDamage(float damage)
    {
        _hp -= damage;
        GetComponent<HpBarMeneger>().ChangeHp(_hp/maxHp);
        Debug.Log(gameObject.name + " hp is " + _hp.ToString());
        if (DeathCheck())
        {
            Death();
        }
    }
}
