using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBodySC : MonoBehaviour {

    public static int playerLife = 3;
    bool isStay = false;
    [SerializeField] Renderer dameged;
    float speed = 1;
    float time;
    float alfa;
    float endTime;
    public GameObject gameoverText;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {

        playerLife = Mathf.Clamp(playerLife, 0, 3);
        speed = playerLife == 1 ? 10f : (playerLife == 2 ? 5f : 0f);

        //ゲームオーバー画面にフェードイン
        if (playerLife == 0)
        {
            endTime += Time.deltaTime * 0.4f;
            dameged.material.color = new Color(0f, 0f, 0f, Mathf.Clamp(endTime,0f,100f));
            gameoverText.SetActive(true);
        }
        else
        {
            time += Time.deltaTime * speed;
            alfa = Mathf.Sin(time) * 0.2f;
            dameged.material.color = new Color(255f, 0f, 0f, alfa);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<SwordSC>().isRight == false && !isStay)
        {
            isStay = true;
            playerLife--;
            Debug.Log("PlayerLife is " + playerLife);
            StartCoroutine("DuplicateProtection");
            //ジュバっていう音
            GetComponent<AudioSource>().Play();
        }
    }

    IEnumerator DuplicateProtection()
    {
        yield return new WaitForSeconds(1.5f);
        isStay = false;
    }
}