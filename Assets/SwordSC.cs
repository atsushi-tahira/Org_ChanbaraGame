using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordSC : MonoBehaviour {

    public bool isRight;
    TextMesh debugText;
	// Use this for initialization
	void Start () {
        debugText = GameObject.Find("debugText").GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        GetComponent<AudioSource>().Play();
        if (!this.isRight)
        {
            Debug.Log("!isRight in");
            if (collision.gameObject.tag == "RightSword")
            {
                debugText.text = "Collision In";
                //キィンっていう音
                GetComponent<AudioSource>().Play();
                StartCoroutine("Neutralization");
            }
        }
    }

    void OnTriggerEnter(Collision collision)
    {
        GetComponent<AudioSource>().Play();
        if (!this.isRight)
        {
            Debug.Log("!isRight in");
            if (collision.gameObject.tag == "RightSword")
            {
                debugText.text = "Collision In";
                //キィンっていう音
                GetComponent<AudioSource>().Play();
                StartCoroutine("Neutralization");
            }
        }
    }

    IEnumerator Neutralization()
    {
        isRight = true;
        Debug.Log("isRight = " + isRight);
        yield return new WaitForSeconds(1.5f);
        isRight = false;
        Debug.Log("isRight = " + isRight);
    }

    void OnCollisionExit(Collision collision)
    {
        if (!this.isRight)
        {
            if (collision.gameObject.GetComponent<SwordSC>().isRight == true)
            {
                debugText.text = "Collision Out";
            }
        }
    }
}
