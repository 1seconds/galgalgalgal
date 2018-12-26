using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PLAYERSTATEMENT
{
    IDLE,                   // 기본상태
    WALK,                   // 걷기
    LADDER_MOVE,              // 사다리에서 움직일때
    LADDER_STOP,            // 사다리 중간에 멈출때 
    JUMP,                   // 점프 시
    HIT,                    // 피격받았을시
    ATTACK,                 // 공격시
    DIE,                    // 사망시
}

public class PlayerManager : MonoBehaviour
{
    public PLAYERSTATEMENT currentPlayerState;

    public float maxSpeed;
    public float moveSpeed;
    private Vector3 playerVelocity;

    static public bool isAttackAble = false;
    static public bool isJumpAble = true;
    static public bool isJumping = false;
    static public bool isGrounded = false;
    private bool isRadderInside = false;
    private bool isRadderTop = false;

    private GameManager gameManager;

    float h = 0;
    float v = 0;

    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    public void FixedUpdate()
    {
        if (!gameManager.currentState.Equals(GAMESTATE.PLAYING))
            return;

        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        //이동
        if (h > 0)
        {
            if (v == 0)
            {
                if (isRadderInside && !isRadderTop)
                {
                    currentPlayerState = PLAYERSTATEMENT.LADDER_MOVE;
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
                else if(isRadderInside && isRadderTop)
                {
                    currentPlayerState = PLAYERSTATEMENT.LADDER_MOVE;
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    currentPlayerState = PLAYERSTATEMENT.WALK;
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
            }
            else
            {
                if (isRadderInside && !isRadderTop)
                {
                    currentPlayerState = PLAYERSTATEMENT.LADDER_MOVE;
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
                else if(isRadderInside && isRadderTop)
                {
                    currentPlayerState = PLAYERSTATEMENT.LADDER_MOVE;
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    currentPlayerState = PLAYERSTATEMENT.WALK;
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
            }
        }
        else if(h < 0)
        {
            if (v == 0)
            {
                if (isRadderInside && !isRadderTop)
                {
                    currentPlayerState = PLAYERSTATEMENT.LADDER_MOVE;
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
                else if(isRadderInside && isRadderTop)
                {
                    currentPlayerState = PLAYERSTATEMENT.LADDER_MOVE;
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    currentPlayerState = PLAYERSTATEMENT.WALK;
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
            }
            else
            {
                if (isRadderInside && !isRadderTop)
                {
                    currentPlayerState = PLAYERSTATEMENT.LADDER_MOVE;
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
                else if(isRadderInside && isRadderTop)
                {
                    currentPlayerState = PLAYERSTATEMENT.LADDER_MOVE;
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    currentPlayerState = PLAYERSTATEMENT.WALK;
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
            }
        }
        else if(h == 0)
        {
            if(v == 0)
            {
                if (isRadderInside && !isRadderTop)
                {
                    currentPlayerState = PLAYERSTATEMENT.LADDER_STOP;
                }
                else if(isRadderInside && isRadderTop)
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
                if (isRadderInside && !isRadderTop)
                {
                    currentPlayerState = PLAYERSTATEMENT.LADDER_MOVE;
                }
                else if(isRadderInside && isRadderTop)
                {
                    currentPlayerState = PLAYERSTATEMENT.LADDER_MOVE;
                }
                else
                {
                    currentPlayerState = PLAYERSTATEMENT.IDLE;
                }
            }
        }

        //점프
        if (Input.GetKey(KeyCode.Space))
        {
            if (!isJumpAble)
                return;

            currentPlayerState = PLAYERSTATEMENT.JUMP;
            if (gameObject.GetComponent<Rigidbody2D>().velocity.y == 0)
            {
                isJumping = true;
            }
            else
            {
                isJumping = false;
            }
        }

        //공격
        if (isAttackAble)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlayerAnim_Attack();
                currentPlayerState = PLAYERSTATEMENT.ATTACK;
            }
        }

        //Debug.Log("RADDERTOP = " + isRadderTop + "/ RADDERINSIDE = " + isRadderInside + "/ ISJUMPINGABLE = " + isJumpAble + "/ ISJUMPING = " + isJumping);

        switch (currentPlayerState)
        {
            case PLAYERSTATEMENT.IDLE:
                PlayerAnim_Idle();
                playerVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
                playerVelocity.x = 0;
                gameObject.GetComponent<Rigidbody2D>().velocity = playerVelocity;
                break;
            case PLAYERSTATEMENT.WALK:
                PlayerAnim_Run();

                if(ConvBelt.isInsideLeft)
                {
                    if(h < 0)
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(-5, 0, 0));
                    else
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(45, 0, 0));
                }
                else if(ConvBelt.isInsideRight)
                {
                    if (h < 0)
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(-45, 0, 0));
                    else
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(5, 0, 0));
                }
                else
                {
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(moveSpeed * h, 0, 0));

                    if (Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
                    {
                        if (gameObject.GetComponent<Rigidbody2D>().velocity.x < 0)
                        {
                            playerVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
                            playerVelocity.x = -maxSpeed;
                            gameObject.GetComponent<Rigidbody2D>().velocity = playerVelocity;
                        }
                        else
                        {
                            playerVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
                            playerVelocity.x = maxSpeed;
                            gameObject.GetComponent<Rigidbody2D>().velocity = playerVelocity;
                        }
                    }
                }
                break;
            case PLAYERSTATEMENT.LADDER_MOVE:
                if (!isGrounded)
                    PlayerAnim_LadderMove();
                else
                    PlayerAnim_Run();
                gameObject.transform.Translate(0, v * moveSpeed * 0.5f * Time.deltaTime, 0);
                gameObject.transform.Translate(h * moveSpeed * 0.2f * Time.deltaTime, 0, 0);

                break;
            case PLAYERSTATEMENT.LADDER_STOP:
                PlayerAnim_LadderStop();
                playerVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
                playerVelocity.x = 0;
                playerVelocity.y = 0;
                gameObject.GetComponent<Rigidbody2D>().velocity = playerVelocity;
                break;
            case PLAYERSTATEMENT.JUMP:
                if (isJumping)
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, moveSpeed * 30, 0));

                PlayerAnim_Run();
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(moveSpeed * h, 0, 0));

                if (Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
                {
                    if (gameObject.GetComponent<Rigidbody2D>().velocity.x < 0)
                    {
                        playerVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
                        playerVelocity.x = -maxSpeed;
                        gameObject.GetComponent<Rigidbody2D>().velocity = playerVelocity;
                    }
                    else
                    {
                        playerVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
                        playerVelocity.x = maxSpeed;
                        gameObject.GetComponent<Rigidbody2D>().velocity = playerVelocity;
                    }
                }
                break;
            case PLAYERSTATEMENT.ATTACK:
                Debug.Log("공격했다");
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Monster"))
        {
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().currentState = GAMESTATE.DONE;
            PlayerAnim_Die();
            StartCoroutine(DEADCor());
        }
    }

    IEnumerator DEADCor()
    {
        currentPlayerState = PLAYERSTATEMENT.DIE;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("InGame");
    }

    void OnTriggerStay2D(Collider2D obj)
    {
        //Debug.Log(obj.gameObject.name);
        if (obj.CompareTag("DeadZone") || obj.CompareTag("Fire"))
        {
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().currentState = GAMESTATE.DONE;
            PlayerAnim_Die();
            StartCoroutine(DEADCor());
        }

        if (obj.CompareTag("Ladder"))
        {
            if (isRadderTop)
            {
                if (v < 0)
                {
                    currentPlayerState = PLAYERSTATEMENT.LADDER_MOVE;
                    isJumpAble = false;
                    gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                    isRadderInside = true;
                    obj.GetComponent<RadderTopObject>().obj.transform.GetChild(0).GetComponent<BoxCollider2D>().isTrigger = true;
                }
                else
                {
                    isJumpAble = true;
                    gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                    obj.GetComponent<RadderTopObject>().obj.transform.GetChild(0).GetComponent<BoxCollider2D>().isTrigger = false;

                    playerVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
                    playerVelocity.y = 0;
                    gameObject.GetComponent<Rigidbody2D>().velocity = playerVelocity;
                }

            }
            else
            {
                currentPlayerState = PLAYERSTATEMENT.LADDER_STOP;
                isJumpAble = false;
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                isRadderInside = true;
            }                
        }
        if(obj.CompareTag("LadderTop"))
        {
            isRadderTop = true;
            if (v < 0)
            {
                currentPlayerState = PLAYERSTATEMENT.LADDER_MOVE;
                isJumpAble = false;
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                isRadderInside = true;
                obj.GetComponent<RadderTopObject>().obj.GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.CompareTag("Ladder"))
        {
            playerVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
            playerVelocity.y = 0;
            gameObject.GetComponent<Rigidbody2D>().velocity = playerVelocity;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Ladder"))
        {
            isJumpAble = true;
            isRadderInside = false;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        if (col.CompareTag("LadderTop"))
        {
            isRadderTop = false;
            col.transform.GetChild(0).GetComponent<BoxCollider2D>().isTrigger = true;
        }


    }

    public void PlayerAnim_Idle()
    {
        gameObject.GetComponent<Animator>().SetInteger("state", 0);
    }
    public void PlayerAnim_Run()
    {
        gameObject.GetComponent<Animator>().SetInteger("state", 1);
    }
    public void PlayerAnim_Attack()
    {
        gameObject.GetComponent<Animator>().SetInteger("state", 2);
    }
    public void PlayerAnim_LadderMove()
    {
        gameObject.GetComponent<Animator>().SetInteger("state", 3);
    }
    public void PlayerAnim_Die()
    {
        gameObject.GetComponent<Animator>().SetInteger("state", 4);
    }
    public void PlayerAnim_AtkEnd()
    {
        gameObject.transform.parent.GetComponent<PlayerMove>().isAtkActivated = false;
    }
    public void PlayerAnim_LadderStop()
    {
        gameObject.GetComponent<Animator>().SetInteger("state", 5);
    }
}
