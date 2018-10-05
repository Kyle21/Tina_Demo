using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem_Ai : MonoBehaviour {

	
    CharacterStatus status;
    CharaAnimation charaAnimation;
    CharacterMove characterMove;
    Transform attackTarget;

    // 대기 시간은 2초로 설정한다.
    public float waitBaseTime = 2.0f;
    // 남은 대기 시간.
    float waitTime;
    // 이동 범위 5미터.
    public float walkRange = 5.0f;
    // 초기 위치를 저장해 둘 변수.
    public Vector3 basePosition;
    // 복수의 아이템을 저장할 수 있는 배열로 한다.
    public GameObject[] dropItemPrefab;

    // 스테이트 종류.
    enum State
    {
        Walking,	// 탐색.
        Chasing,	// 추적.
        Attacking,	// 공격.
        Died,       // 사망.
    };

    State state = State.Walking;        // 현재 스테이트.
    State nextState = State.Walking;    // 다음 스테이트.


    // Use this for initialization
    void Start()
    {
        status = GetComponent<CharacterStatus>();
        charaAnimation = GetComponent<CharaAnimation>();
        characterMove = GetComponent<CharacterMove>();
        // 초기 위치를 저장한다.
        basePosition = transform.position;
        // 대기 시간.
        waitTime = waitBaseTime;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    switch (state)
    //    {
    //        case State.Walking:
    //            Walking();
    //            break;
    //        case State.Chasing:
    //            Chasing();
    //            break;
    //        case State.Attacking:
    //            Attacking();
    //            break;
    //    }

    //    if (state != nextState)
    //    {
    //        state = nextState;
    //        switch (state)
    //        {
    //            case State.Walking:
    //                WalkStart();
    //                break;
    //            case State.Chasing:
    //                ChaseStart();
    //                break;
    //            case State.Attacking:
    //                AttackStart();
    //                break;
    //            case State.Died:
    //                Died();
    //                break;
    //        }
    //    }
    //}
    //void ChaseStart()
    //{
    //    StateStartCommon();
    //}
    //// 추적 중.
    //void Chasing()
    //{
    //    // 이동할 곳을 플레이어에 설정한다.
    //    SendMessage("SetDestination", attackTarget.position);
    //    // 2미터 이내로 접근하면 공격한다.
    //    if (Vector3.Distance(attackTarget.position, transform.position) <= 2.0f)
    //    {
    //        ChangeState(State.Attacking);
    //        Debug.Log("접근");
    //    }
    //    else
    //        Debug.Log("미접근");

    //}

    //// 공격 스테이트가 시작되기 전에 호출된다.
    //void AttackStart()
    //{
    //    StateStartCommon();
    //    status.attacking = true;

    //    // 적이 있는 방향으로 돌아본다.
    //    Vector3 targetDirection = (attackTarget.position - transform.position).normalized;
    //    SendMessage("SetDirection", targetDirection);

    //    // 이동을 멈춘다.
    //    SendMessage("StopMove");
    //}

    //// 공격 중 처리.
    //void Attacking()
    //{
    //    if (charaAnimation.IsAttacked())
    //        ChangeState(State.Walking);
    //    // 대기 시간을 다시 설정한다.
    //    waitTime = Random.Range(waitBaseTime, waitBaseTime * 2.0f);
    //    // 타겟을 리셋한다.
    //    attackTarget = null;
    //}

}
