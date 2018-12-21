using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public PLAYER playerState;
    private float time_;
    public float speed;
    static public bool isTrigger = false;

    public void Select()
    {
        if(!isTrigger)
         StartCoroutine(Twinkle(playerState));
    }

    IEnumerator Twinkle(PLAYER playerState)
    {
        isTrigger = true;
        SoundManager.instance_.SFXPlay(SoundManager.instance_.clips[0]);
        time_ = 0;
        while (true)
        {
            time_ += Time.deltaTime;
            gameObject.transform.eulerAngles += new Vector3(0, 0, time_ * time_ * speed);
            yield return new WaitForEndOfFrame();
            if (time_ > 3.0f)
                break;
        }

        isTrigger = false;
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().currentState = GAMESTATE.PLAYING;
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().ChangePlayer(playerState);
    }
}
