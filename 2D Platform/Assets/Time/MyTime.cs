using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MyTime : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    float sec = 0;
    int min = 0;

    public bool isUsed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isUsed == false)
        {
            StopAllCoroutines();
            StartCoroutine(UseItem());
        }

        sec += Time.deltaTime;
        if (sec >= 60f)
        {
            min += 1;
            sec = 0;
        }

        if (isUsed)
            timeText.text = string.Format("{0:D2}:{1:D2}", min, (int)sec);
        else
            timeText.text = "";
    }

    IEnumerator UseItem()
    {
        isUsed = true;
        yield return new WaitForSeconds(5f);
        isUsed = false;
    }

}
