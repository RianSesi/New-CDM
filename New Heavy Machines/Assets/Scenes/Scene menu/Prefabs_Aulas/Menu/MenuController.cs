using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MenuController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject menuInicial, menuOptions, rawImage;
    public AudioSource selectSound;
    public string newGameScene;
    private Animator animatorRawImage;

    public Dropdown resolution, quality;
    public InputField textFPS;
    public Toggle limitFPS, windowMode, vSinc, bloom, occlusion, reflection, autoSave;
    public Slider globalVol, musicsVol, effectVol;

    // Start is called before the first frame update
    void Start()
    {
        rawImage.SetActive(false);
        menuOptions.SetActive(false);
        animatorRawImage = rawImage.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!videoPlayer.isPlaying && UnityEngine.Input.anyKeyDown)
        {
            selectSound.Play();
            videoPlayer.Play();
            animatorRawImage.SetTrigger("FadeIn");
            rawImage.SetActive(true);
            menuInicial.SetActive(true);
        }
    }

    public void Options()
    {
        menuInicial.SetActive(false);
        menuOptions.SetActive(true);
    }

    public void Salvar()
    {
        SaveConfigs();
        ReturnMenuInicial();
    }

    public void ReturnMenuInicial()
    {
        menuInicial.SetActive(true);
        menuOptions.SetActive(false);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    private void SaveConfigs()
    {
        var configs = new ConfigsModel()
        {


        };

        var resolutionModel = new Resolution();

        switch (resolution.value)
        {
            case 0:
                resolutionModel.width = 800;
                resolutionModel.height = 600;
                break;
            case 1:
                resolutionModel.width = 1280;
                resolutionModel.height = 720;
                break;
            case 2:
                resolutionModel.width = 1920;
                resolutionModel.height = 1080;
                break;

        }

        var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/MenuResolution/";

        if(!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        var binaryFormatter = new BinaryFormatter();
        var file = File.Create(path + "ConfigData.save");
        
        binaryFormatter.Serialize(file, configs);
        file.Close();        
    }
}
