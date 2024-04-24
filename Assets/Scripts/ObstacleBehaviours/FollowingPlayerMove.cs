
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingPlayerMove : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 5f; //Vitesse de l'objet, modifiable
	[SerializeField] private Rigidbody2D rb; //Le rigidbody pour bouger l'obstacle
	private Vector2 direction;
	private GameObject player;
	
	private float delay = 0.5f;
	private float timerDelay = 0;
	private Vector2 initPosition; //position initiale

	//Au démarrage, défini la variable de mouvement
	void Start(){
		player = PlayerManager.GetPlayer();
		initPosition = new Vector2(transform.position.x, transform.position.y);
		animator = GetComponent<Animator>(); //On charge l'animator de l'objet dans notre script
	}

	//A chaque frame, on bouge l'objet via son rigidbody dans le mouvement défini * la vitesse de l'objet moveSpeed * Time.fixedDeltaTime le laps de temps écoulé en 1 frame
	void FixedUpdate() {
		//Si le timer de delay est supérieur à 0, on attend que le temps soit écoulé jusqu'à zéro
		if(timerDelay > 0){
			timerDelay = Mathf.Max(0, timerDelay - Time.fixedDeltaTime);
		}
		direction = (player.transform.position - transform.position).normalized;
		rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
	}

	private Vector2 movement;
	private Animator animator;
		
    // Fonction qui se lance à chaque frame.
    void Update() {
		
		//On récupère si les touches de directions horizontales et verticales sont pressées, cela donne un nombre entre 0 (pas pressé) et 1 (pressé).
        movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
		
		if(movement != Vector2.zero){ //Si le joueur bouge, on partage les variables à l'animator pour qu'il bouge le sprite en conséquence
			animator.SetFloat("moveX", movement.x);
			animator.SetFloat("moveY", movement.y);
			animator.SetBool("moving", true);
		} else {
			animator.SetBool("moving", false);
		}

		//Si la valeur récupérée est supérieure à 0, ça veut dire que la touche est pressée.
		bool isMovingHorizontal = Mathf.Abs(movement.x) > 0;
		bool isMovingVertical = Mathf.Abs(movement.y) > 0;

		//On évite que le joueur bouge horizontalement ET verticalement.
		if (Mathf.Abs(movement.x) > 0)
        {
            isMovingHorizontal = true;
            isMovingVertical = false;
        }

		//S'il se déplace verticalement, la priorité est au déplacement vertical
        if (Mathf.Abs(movement.y) > 0)
        {
            isMovingHorizontal = false;
            isMovingVertical = true;
        }

		//On définit le vecteur de mouvement en fonction des données précédentes.
        if (isMovingHorizontal)
        {
            movement = Vector2.right * movement.normalized.x;
        }
        else if (isMovingVertical)
        {
            movement = Vector2.up * movement.normalized.y;
        }
		
    }
	
	//Fonction qui remet l'objet à sa position initiale
	public void reinitPosition(){
		transform.position = initPosition;
		timerDelay += delay;
	}
}