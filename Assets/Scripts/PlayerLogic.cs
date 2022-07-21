using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : EntityLogic
{
    public GameObject gun;
	private Vector3 _posMouse, _posCam;

    void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
			gun.GetComponent<GunLogic>().changeBangFlag();
			_posMouse = Input.mousePosition;
		}
		else if (Input.GetMouseButton(0))
		{
			if (Input.mousePosition.y > _posMouse.y)
				gun.GetComponent<GunLogic>().GunUp();
			if (Input.mousePosition.y < _posMouse.y)
				gun.GetComponent<GunLogic>().GunDown();
		}
		else if (Input.GetMouseButtonUp(0)) 
		{
			gun.GetComponent<GunLogic>().changeBangFlag();
		}
	}
}
