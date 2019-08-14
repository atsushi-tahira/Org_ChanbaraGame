using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordSC : MonoBehaviour {

    public bool isRight;
    TextMesh debugText;

	void Start () {
        debugText = GameObject.Find("debugText").GetComponent<TextMesh>();
	}


    void OnTriggerEnter(Collider other)
    {
        //GetComponent<AudioSource>().Play();
        Debug.Log("!isRight in");
        if (other.gameObject.tag == "LeftSword")
        {
            //キィンっていう音
            StartCoroutine(Neutralization(other.gameObject.GetComponent<SwordSC>()));
        }
    }

    IEnumerator Neutralization(SwordSC leftSword)
    {
        GetComponent<AudioSource>().Play();
        leftSword.isRight = true;
        yield return new WaitForSeconds(1.5f);
        leftSword.isRight = false;
    }
}
