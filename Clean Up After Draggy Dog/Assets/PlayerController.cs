using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float capacity = 1000f;
    [SerializeField] float stored = 0f;
    [SerializeField] TMP_Text storedText;

    // Start is called before the first frame update
    void Start()
    {
        if (storedText != null) storedText.text = StoredOverCapacity(stored,capacity);
    }

    // Update is called once per frame
    void Update()
    {
        CheckWin();
    }

    public void CollectDebris(float amt) {
        stored += amt;
        if (stored >= capacity) stored = capacity;
        if (storedText != null) storedText.text = StoredOverCapacity(stored,capacity);
    }

    private string StoredOverCapacity(float stored, float capacity) {
        return $"{stored.ToString("0")}/{capacity.ToString("0")}";
    }

    private void CheckWin() {
        if (stored >= capacity) {
            print("you wonnered");
        }
    }
}
