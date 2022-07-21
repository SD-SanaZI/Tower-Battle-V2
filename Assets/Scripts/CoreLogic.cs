using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreLogic : MonoBehaviour
{
    private string _enemyTag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Transform>().position.x > 11 || GetComponent<Transform>().position.x < -11 
            || GetComponent<Transform>().position.y > 5 || GetComponent<Transform>().position.y < -5)
            Destroy(gameObject);
    }

    public void SetEnemyTag(string enemyTag)
    {
        _enemyTag = enemyTag;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == _enemyTag)
        {
            if (collision.gameObject.name == "Shild")
                collision.GetComponent<ShildLogic>().TakeDamage(5f);
            else
                collision.GetComponentInParent<EntityLogic>().TakeDamage(5f);
            Destroy(gameObject);
        }
    }
}
