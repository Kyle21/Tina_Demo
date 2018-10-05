using UnityEngine;

public class CharaAnimation : MonoBehaviour
{
	Animator animator;
	CharacterStatus status;
    CharacterMove move;
	Vector3 prePosition;
	bool isDown = false;
	bool attacked = false;

    public float m_fIdleTime = 2.0f;



	
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
    void ResetIdleTime()
    {
        m_fIdleTime = 0.0f;
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
        m_fIdleTime += Time.deltaTime;
        animator.SetFloat("State_Walk", m_fIdleTime);


        //Vector3 delta_position = transform.position - prePosition;
        // animator.SetFloat("Speed", delta_position.magnitude / Time.deltaTime);



        if (move.arrived && Vector3.Distance(transform.position, move.destination) < 0.6)
        {
            Debug.Log("공격 애니");
            animator.SetTrigger("State_Attacking");
        }
          
                // animator.SetBool("Attacking", true);




        //      if (attacked && !status.attacking)
        //{
        //	attacked = false;
        //}
        //animator.SetBool("Attacking", (!attacked && status.attacking));

        //if(!isDown && status.died)
        //{
        //	isDown = true;
        //	animator.SetTrigger("Down");
        //}

        //prePosition = transform.position;
    } 
} 