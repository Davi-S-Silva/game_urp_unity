using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;

public class MutantController : InimigoController
{
    [SerializeField]
    protected Animator _mutantAnimator;
    [SerializeField]
    protected float _dano;
    [SerializeField]
    protected Rigidbody _rigid; 
    [SerializeField]
    protected NavMeshAgent _agentNavimesh;
    [SerializeField]
    protected Transform _target;
    [SerializeField]
    protected AudioSource _passosAudioSource;
    [SerializeField]
    protected AudioClip[] _passosAudioClip;
   


    // Start is called before the first frame update
    void Start()
    {
        _target=    FindObjectOfType<PlayerController>().transform;
        _mutantAnimator = GetComponent<Animator>();
        _velocidade = 1.5f;
        _rigid= GetComponent<Rigidbody>();
        _vida = 100f;
        _mutantAnimator.SetFloat("vida", _vida);
        _timeDestroy = 10f;
        _minDistance= 1.2f;
        _minDistanceAtack = 1.5f;
        _dano = 1;
        _agentNavimesh = GetComponent<NavMeshAgent>();
        _agentNavimesh.speed = 0f;

      
    }
  
    // Update is called once per frame
    void FixedUpdate()
    {

        _agentNavimesh.destination = _target.position;
        _agentNavimesh.speed = _velocidade;
        //Debug.Log(_agentNavimesh.remainingDistance);
        if (_agentNavimesh.remainingDistance <= _minDistance)
        {
            _andar = false;
            _correr = false;
            _agentNavimesh.Stop();
            Debug.Log("parado Proximo " + _agentNavimesh.remainingDistance + " min distance "+ _minDistance);
        }else 
        if (_agentNavimesh.remainingDistance >= _minDistance && _agentNavimesh.remainingDistance <= 10)
        {
            _andar = true;
            _correr = false;
            _agentNavimesh.Resume();
            Debug.Log("Andando " + _agentNavimesh.remainingDistance + " min distance " + _minDistance);
        }else
        if (_agentNavimesh.remainingDistance > 10 && _agentNavimesh.remainingDistance < 30)
        {
            _andar = false;
            _correr = true;
            _velocidade = 2.5f;
            _agentNavimesh.Resume();
            Debug.Log("Correndo " + _agentNavimesh.remainingDistance + " min distance " + _minDistance);
        }
        else //(_agentNavimesh.remainingDistance > 30)
        {
            _andar = false;
            _correr = false;
            _agentNavimesh.Stop();
            Debug.Log("Parado Longe " + _agentNavimesh.remainingDistance + " min distance " + _minDistance);
        }
       
        if (_vida == 0)
        {
            _rigid.isKinematic=true;
            Destroy(gameObject, _timeDestroy);
        }
        //_rigid.AddForce(new Vector3(0,0,_velocidade*Time.deltaTime), ForceMode.Impulse);

        _ataque = false;
        if (_agentNavimesh.remainingDistance >= _minDistance && _agentNavimesh.remainingDistance <= _minDistanceAtack)
        {
            _ataque = true; 
            _andar = false;
            _correr = false;
            _agentNavimesh.Stop();
            Debug.Log("Atacar");
            int atack = Random.Range(0, 2);
            string ataque = "";
            /* switch (atack)
             {
                 case 0:
                     ataque = "usar_espada";
                     break;
                 case 1:
                     ataque = "ataqueUm";
                     break;
                 case 2:
                     ataque = "ataqueDois";
                     break;
             }*/
            /*if (atack == 0)
            {
                ataque = "usar_espada";
            }else if (atack==1)
            {
                ataque = "ataqueUm";
            }else {
                ataque = "ataqueDois";
            }

            _mutantAnimator.SetBool(ataque, _ataque);*/

            Debug.Log(atack);

        }

        _mutantAnimator.SetFloat("vida", _vida);
        _mutantAnimator.SetBool("andar", _andar);
        _mutantAnimator.SetBool("correr", _correr);
        _mutantAnimator.SetBool("usar_espada", _ataque);

    }
    public void setVida(float dano)
    {
        _vida -= dano;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
           collision.gameObject.GetComponent<PlayerController>().setVida(-(this._dano));
        }
    }

    private void Passos()
    {
        _passosAudioSource.PlayOneShot(_passosAudioClip[Random.Range(0, _passosAudioClip.Length)]);
    }
}
