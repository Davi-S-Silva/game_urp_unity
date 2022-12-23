using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoController : MonoBehaviour
{
    [SerializeField]
    protected float _forca, _vida, _velocidade, _timeDestroy, _dano, _minDistance, _minDistanceAtack;
    [SerializeField]
    protected bool _andar, _correr, _parado, _ataque;
    // Start is called before the first frame update
    void Start()
    {
        _dano = 1;
        _minDistance = 2;
        _minDistanceAtack = 2;
        _vida = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
