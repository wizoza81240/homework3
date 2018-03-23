using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class move : MonoBehaviour {
    Rigidbody rb;
    public Text countText;
    public Text winText;
    public Text myTime;
    int count;
    DateTime curr;
    public float speed;
    // Use this for initialization
	
    void Start () {
        rb = GetComponent<Rigidbody>();
        count = 0;
        countText.text = "分數";
        winText.text = "";
        curr = DateTime.Now;
        myTime.text = "10";
    }
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //transform.Translate(x, 0, z);

        rb.AddForce(new Vector3(x, 0, z)*speed);
        TimeSpan ts = DateTime.Now - curr;
        if (ts.Seconds < 10 && count < 3)
        {
            myTime.text = (10 - ts.Seconds).ToString() + ":" + (1000 - ts.Milliseconds).ToString();
        }else if(count < 3)
        {
            myTime.text = "0";
            winText.text = "You lose!";
        }
        else if (count >= 3)
        {
            myTime.text = myTime.text;
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("pick"))
        {
            other.gameObject.SetActive(false);
            count++;
            countText.text = "分數:" + count.ToString();

            if (count >= 3)
            {
                winText.text = "You win";
            }
        }
    }
}