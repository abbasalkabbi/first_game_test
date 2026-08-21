using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eagel : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    int height =2;
    Vector3 startPos;
    SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr =GetComponentInChildren<SpriteRenderer>();
        startPos = transform.position;
        StartCoroutine(Eagel_move());
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.x > transform.position.x)
        {
           sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
    IEnumerator Eagel_move()
    {
        Vector3 endPos = new Vector3(startPos.x, startPos.y + height, startPos.z);
        bool isflight = true;
        float value = 0;
        while (true)
        {
            yield return null;
            if(isflight)
            transform.position= Vector3.Lerp(startPos, endPos, value);
            else
                transform.position = Vector3.Lerp(endPos, startPos,value);
            value= value+Time.deltaTime * height;
            if (value > 1) { 
                value = 0;
                isflight = !isflight;
            }
           
        }
    }
}
