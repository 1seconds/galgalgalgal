using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PLAYERSTATEMENT
{
    READY = 0,              // 게임시작 전
    PAUSE,                  // 게임시작 중 일시정지
    IDLE,                   // 기본상태
    WALK,                   // 걷기
    LADDER_MOVE,              // 사다리에서 움직일때
    LADDER_STOP,            // 사다리 중간에 멈출때 
    LADDER_TOP,             // 사다리 꼭대기 도착했을때
    JUMP,                   // 점프 시
    HIT,                    // 피격받았을시
    ATTACK,                 // 공격시
    DIE,                    // 사망시
}

public class PlayerManager : MonoBehaviour
{
    public PLAYERSTATEMENT currentPlayerState;

    public float jumpPower;
    public float speed;

    static public bool isAttackAble = false;
    static public bool isJumpAble = false;
    static public bool isRadderInside = false;
    static public bool isPlayerDie = false;
    static public bool isReady = false;

    public void FixedUpdate()
    {
        if (isPlayerDie || !isReady)
            return;

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if(h > 0)
        {
            currentPlayerState = PLAYERSTATEMENT.WALK;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(h < 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            currentPlayerState = PLAYERSTATEMENT.WALK;
        }
        else if(h == 0)
        {
            if(v == 0)
            {
                if (isRadderInside)
                {
                    currentPlayerState = PLAYERSTATEMENT.LADDER_STOP;
                }
                else
                {
                    currentPlayerState = PLAYERSTATEMENT.IDLE;
                }
            }
            else
            {
                if (isRadderInside)
                {
                    currentPlayerState = PLAYERSTATEMENT.LADDER_MOVE;
                }
                else
                {
                    currentPlayerState = PLAYERSTATEMENT.IDLE;
                }
            }
            
        }

        switch (currentPlayerState)
        {
            case PLAYERSTATEMENT.READY:
                break;
            case PLAYERSTATEMENT.PAUSE:
                break;
            case PLAYERSTATEMENT.IDLE:
                gameObject.transform.GetChild(0).GetComponent<PlayerBody>().PlayerAnim_Idle();
                break;
            case PLAYERSTATEMENT.WALK:
                gameObject.transform.GetChild(0).GetComponent<PlayerBody>().PlayerAnim_Run();
                break;
            case PLAYERSTATEMENT.LADDER_MOVE:
                break;
            case PLAYERSTATEMENT.LADDER_STOP:
                break;
            case PLAYERSTATEMENT.LADDER_TOP:
                break;
            case PLAYERSTATEMENT.JUMP:
                break;
            case PLAYERSTATEMENT.HIT:
                break;
            case PLAYERSTATEMENT.ATTACK:
                break;
            case PLAYERSTATEMENT.DIE:
                break;
        }
    }
}
