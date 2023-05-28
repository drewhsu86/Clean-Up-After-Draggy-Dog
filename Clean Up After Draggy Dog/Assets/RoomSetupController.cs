using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSetupController : MonoBehaviour
{
    [SerializeField] List<GameObject> smallDebris;
    [SerializeField] List<GameObject> bigDebris;
    [SerializeField] int smallDebrisNum = 4;
    [SerializeField] int bigDebrisNum = 3;

    void Start()
    {
        Initialize();
    }

    private static void Shuffle(List<GameObject> list)  
    {  
        int n = list.Count;  
        while (n > 1) {  
            n--;  
            int k = Random.Range(0, n-1);  
            GameObject value = list[k];  
            list[k] = list[n];  
            list[n] = value;  
        }  
    }

    private static void ReduceDebris(List<GameObject> list, int keepNum) {
        int deleteNum = list.Count - keepNum;
        for (int i = 0; i < deleteNum; i++) {
            Destroy(list[i]);
        }
    }

    private void Initialize() {
        Shuffle(smallDebris);
        Shuffle(bigDebris);
        ReduceDebris(smallDebris, smallDebrisNum);
        ReduceDebris(bigDebris, bigDebrisNum);
    }
}
