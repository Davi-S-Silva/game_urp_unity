using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    
    [SerializeField]
    private Canvas canvasPrincipal, canvasConfig, canvasCredito, canvasGame;
    [SerializeField]
    private GameObject panelUmJogador, panelConfigPrincipal, panelVideo, panelGeral, panelSom;
    [SerializeField]
    private InputField inputNomePlayer;
    [SerializeField]
    private AudioSource audioGame;
    [SerializeField]
    private AudioSource[] audioEfeitos;
    [SerializeField]
    private Slider volumeGame, volumeEfeitos;
    [SerializeField]
    private float _vida, _valorVolumeEfeitos;
    [SerializeField]
    private TMP_Dropdown dropDownRes;
    [SerializeField]
    private int QualityLevel;

    private List<string> quality = new List<string>();


    private void Awake()
    {
        if ( instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("AudioGame"))
        {
            audioGame.volume = PlayerPrefs.GetFloat("Audio_Game");
        }
        else
        {
            audioGame.volume = 0.2f;
        }
        volumeGame.value = PlayerPrefs.GetFloat("Volume_Game");

        if (PlayerPrefs.HasKey("Volume_Efeitos"))
        {
            _valorVolumeEfeitos = PlayerPrefs.GetFloat("Volume_Efeitos");
        }
        else
        {
            _valorVolumeEfeitos = 0.2f;
        }
        BuscaAudiosEfeitosGames(_valorVolumeEfeitos);


        Debug.Log(PlayerPrefs.GetFloat("Volume_Game").ToString());

        if (PlayerPrefs.HasKey("QualityLevel"))
        {
            QualityLevel = PlayerPrefs.GetInt("QualityLevel");
        }
        else
        {
            QualityLevel = 0;
        }
        QualitySettings.SetQualityLevel(QualityLevel);

        

       
    }


    public float getVida()
    {
        return _vida;
    }
    public void setVida(float vida)
    {
        _vida = vida;
    }
    void Update()
    {

    }

    public void InciarGame()
    {
        Players();
    }
    
   

    public void Creditos()
    {
        canvasCredito.gameObject.SetActive(true);
        canvasPrincipal.gameObject.SetActive(false);
    }

    public void Players()
    {
        canvasPrincipal.gameObject.SetActive(false);
        canvasGame.gameObject.SetActive(true);
    }
    public void umJogador()
    {
        panelUmJogador.transform.parent.gameObject.SetActive(true);
        panelUmJogador.gameObject.SetActive(true);
    }

    public void confirmaPlayer()
    {
        // Debug.Log(inputNomePlayer.textComponent.text);
        PlayerPrefs.SetString("NomePlayer", inputNomePlayer.textComponent.text.ToString());
       // Debug.Log(PlayerPrefs.GetString("NomePlayer").ToString());
        SceneManager.LoadScene("mapa_1");
    }

    public void carregarGame()
    {
        if (PlayerPrefs.GetString("NomePlayer")!="")
        {
            
            if (!PlayerPrefs.HasKey("Vida_Player"))
            {
                this.setVida(100f);
            }
            else
            {
                this.setVida(PlayerPrefs.GetFloat("Vida_Player"));
            }
            SceneManager.LoadScene("mapa_1");
        }
        else
        {
            SceneManager.LoadScene("tela_inicial");
        }
    }

    public void SaveGame()
    {
        //vida
        PlayerPrefs.SetFloat("Vida_Player", this._vida);
        //pontos

        //moedas

        //armas

        //level

        //xp

        
    }

    //opcoes
    public void ConfigGame()
    {
        canvasConfig.gameObject.SetActive(true);
        canvasPrincipal.gameObject.SetActive(false);
        panelConfigPrincipal.gameObject.SetActive(true);
    }

    //menu geral
    public void ConfigGeral()
    {
        panelVideo.gameObject.SetActive(false);
        panelGeral.gameObject.SetActive(true);
    }

    //menu video
    public void ConfigVideo()
    {
        panelGeral.gameObject.SetActive(false);
        panelVideo.gameObject.SetActive(true);
        
        //resolucao
        dropDownRes.options.Clear();
        quality = QualitySettings.names.ToList<string>();
        dropDownRes.AddOptions(quality);
        dropDownRes.value = QualitySettings.GetQualityLevel();

        //sombra
        Debug.Log(ShadowQuality.Disable);
        

    }
    public void SaveVideoConfig()
    {
        //Qualidade grafica
        PlayerPrefs.SetInt("QualityLevel", dropDownRes.value);
        QualitySettings.SetQualityLevel(dropDownRes.value);
        Debug.Log(dropDownRes.value.ToString());
    }

    public void VoltarConfigGame()
    {
        panelGeral.gameObject.SetActive(true);
        panelVideo.gameObject.SetActive(false);
        panelSom.gameObject.SetActive(false);
    }

    
    //menu som
    public void ConfigSom()
    {
        panelVideo.gameObject.SetActive(false);
        panelGeral.gameObject.SetActive(false);
        panelSom.gameObject.SetActive(true);
        volumeEfeitos.value = _valorVolumeEfeitos; 
    }

    public void SaveSomConfig()
    {
       configVolumeEfeitos();
       configVolumeAmbiente();
    }
    //som do ambiente do jogo
    private void configVolumeAmbiente()
    {
        PlayerPrefs.SetFloat("Volume_Game", volumeGame.value);
        audioGame.volume = volumeGame.value;
    }
    private void configVolumeEfeitos()
    {
        PlayerPrefs.SetFloat("Volume_Efeitos", volumeEfeitos.value);
        BuscaAudiosEfeitosGames(volumeEfeitos.value);
    }
    private void BuscaAudiosEfeitosGames(float volume)
    {
        audioEfeitos = FindObjectsOfType<AudioSource>();
        Debug.Log("Audios Sources: " + audioEfeitos.Length);

        foreach (AudioSource audioEfeito in audioEfeitos)
        {
            audioEfeito.volume = volume;
            Debug.Log("Audio Source nome:  " + audioEfeito.clip.name + " Volume: " + audioEfeito.volume);
        }
    }
   
}
