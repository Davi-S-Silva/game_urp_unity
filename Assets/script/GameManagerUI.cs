using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class GameManagerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nickNamePlayer, moedasPlayer;
    [SerializeField]
    private Image _vidaSlider;

    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.GetFloat("Moedas_Player")==0)
        {
            int moeda = 0;
            moedasPlayer.text = moeda.ToString();

        }
        else
        {
            moedasPlayer.text = PlayerPrefs.GetFloat("Moedas_Player").ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(PlayerPrefs.GetString("NomePlayer").ToString());
        nickNamePlayer.text = PlayerPrefs.GetString("NomePlayer").ToString();
        moedasPlayer.text = PlayerPrefs.GetFloat("Moedas_Player").ToString();
        //_vidaSlider.fillAmount = (GameManager.instance.getVida()/100);
    }
}
