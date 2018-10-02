using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneKing_Sample : MonoBehaviour {

    public MonoBehaviour Handler = null;
    Rigidbody m_Rigidbody;
    Animator m_Animator;
    Vector3 m_vMovement;
    float m_fHoriMove;
    float m_fVertMove;
    float m_fSpeed = 3.0f;

    [System.NonSerialized] public float hpMax = 10.0f;



	// Use this for initialization
	void Start () {
		
	}
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        

        Run();
    }

    // Update is called once per frame
    void Update () {


        m_fHoriMove = Input.GetAxisRaw("Horizontal");
        m_fVertMove = Input.GetAxisRaw("Vertical");

        AnimationUpdate();

    }

    void AnimationUpdate()
    {
        if (m_fHoriMove == 0 && m_fVertMove == 0)
        {
            m_Animator.SetBool("isRunning", false);
            Debug.Log(m_fHoriMove);

        }

        else
        {
            m_Animator.SetBool("isRunning", true);
            Object.FindObjectsOfType<Collider>();
           
        }
    }
           

    void Run()
    {
        m_vMovement.Set(m_fHoriMove, 0, m_fVertMove);
        m_vMovement = m_vMovement.normalized * m_fSpeed * Time.deltaTime;
        m_Rigidbody.MovePosition(transform.position + m_vMovement);
    }
}
