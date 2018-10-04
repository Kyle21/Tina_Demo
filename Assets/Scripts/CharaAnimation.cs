using UnityEngine;

public class CharaAnimation : MonoBehaviour
{
	Animator animator;
	CharacterStatus status;
    CharacterMove move;
	Vector3 prePosition;
	bool isDown = false;
	bool attacked = false;
    
	
	public bool IsAttacked()
	{
		return attacked;
	}
	
	void StartAttackHit()
	{
		Debug.Log ("StartAttackHit");
	}
	
	void EndAttackHit()
	{
		Debug.Log ("EndAttackHit");
	}
	
	void EndAttack()
	{
		attacked = true;
	}
	
	void Start ()
	{
		animator = GetComponent<Animator>();
		status = GetComponent<CharacterStatus>();
        move = FindObjectOfType<CharacterMove>();
        prePosition = transform.position;
        //prePosition.x = 140;

    }
	
	void Update ()
	{
        Vector3 delta_position = transform.position - prePosition;
        // Debug.Log("transform : " + transform.position.ToString());
        // Debug.Log("prePosition: " + prePosition.ToString());

         animator.SetFloat("Speed", delta_position.magnitude / Time.deltaTime);

        //if (!move.arrived) // 속도로 조절하면 굳이 else 쓸 필요없다.
        //{
        //    animator.SetFloat("Speed",   2000.0f*Time.deltaTime);
        //}
        //else
        //    animator.SetFloat("Speed", 0.0f);


        if (move.arrived && Vector3.Distance(transform.position, move.destination) < 0.6)
            animator.SetBool("Attacking", true);




        if (attacked && !status.attacking)
		{
			attacked = false;
		}
		animator.SetBool("Attacking", (!attacked && status.attacking));
		
		if(!isDown && status.died)
		{
			isDown = true;
			animator.SetTrigger("Down");
		}
		
		//prePosition = transform.position;
	} 
} 