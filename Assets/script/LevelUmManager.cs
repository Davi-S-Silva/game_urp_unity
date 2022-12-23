using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUmManager : MonoBehaviour
{
    [SerializeField]
    private int m_Level = 1, qtdMutantSpanw, distanceTarget, countSpawn;

    [SerializeField]
    private Transform[] locaisSpawn;

    [SerializeField]
    private Transform MutantSpawn;
    // Start is called before the first frame update
    void Start()
    {
        distanceTarget = 10;
        qtdMutantSpanw = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (qtdMutantSpanw > countSpawn)
        {
            Debug.Log("spawn mutant");
            Transform mutant = Instantiate(MutantSpawn, locaisSpawn[Random.Range(0,locaisSpawn.Length)].position, locaisSpawn[Random.Range(0, locaisSpawn.Length)].rotation) as Transform;
            countSpawn++;
        }
    }
}
