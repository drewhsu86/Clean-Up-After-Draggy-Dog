using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanDebris : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] float shrinkAmt = 5f;
    [SerializeField] float growAmt = -5f;
    [SerializeField] float hp = 100f;
    [SerializeField] float finishThreshold = 25f;
    [SerializeField] bool isShrinking = false;
    float maxHp;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        maxHp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= finishThreshold) FinishDebris();
        if (!isShrinking) { 
            DecrementHp(Time.deltaTime, growAmt);
        } else {
            DecrementHp(Time.deltaTime, shrinkAmt);
            player.CollectDebris(shrinkAmt * Time.deltaTime);
        }
    }

    private void DecrementHp(float deltaTime, float amt = 1f) {
        hp -= amt * deltaTime;
        if (hp < 0) hp = 0;
        transform.localScale = (Vector3.one) * (hp/maxHp);
    }

    private void FinishDebris() {
        player.CollectDebris(hp, true);
        Destroy(gameObject);
    }
    
    private void ToggleShrinkingFalse() {
        isShrinking = false;
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player") {
            //print("shrink");
            isShrinking = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            //print("stop shrink");
            Invoke("ToggleShrinkingFalse", 1);
        }
    }
}
