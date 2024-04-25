using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManagerAnimated1 : MonoBehaviour
{

	//Singleton, permet de n'avoir qu'une seule et unique instance de l'objet

	public Weapon weapon;

	Vector2 mousePosition;
	
    // Fonction qui se lance à chaque frame.
    void Update() {
        if(Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        Vector2 aimDirection = mousePosition - new Vector2(transform.position.x, transform.position.y) ;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        transform.eulerAngles = new Vector3(0,0,aimAngle);
        //_rb.rotation = aimAngle;
    }

}
