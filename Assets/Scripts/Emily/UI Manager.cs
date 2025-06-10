using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Material & Shader")]
    public Material carMaterial;
    public SpriteRenderer carSprite;
   
    [Header("UI")]
    public Toggle toggle;
    public Button playButton;
    
   [Header("Left Group Buttons (changes _Color_A)")]
   public Button redButtonA;
   public Button blueButtonA;
   public Button yellowButtonA;
   public Button greenButtonA;

    [Header("Right Group Buttons (changes _Color_B)")]
    public Button redButtonB;
    public Button blueButtonB;
    public Button yellowButtonB;
    public Button greenButtonB;
    
    [Header("Toggle Sprites")]
    public Sprite onSprite;
    public Sprite offSprite;

    private Image _image;

    void Start()
    {
        _image = toggle.targetGraphic as Image;

        UpdateToggleVisuals(toggle.isOn);
        SetWhatCar(toggle.isOn);

        toggle.onValueChanged.AddListener(OnToggleChanged);
        
        redButtonA.onClick.AddListener(() => SetCarColor("_Color_A", Color.red));
        blueButtonA.onClick.AddListener(() => SetCarColor("_Color_A", Color.blue));
        yellowButtonA.onClick.AddListener(() => SetCarColor("_Color_A", Color.yellow));
        greenButtonA.onClick.AddListener(() => SetCarColor("_Color_A", Color.green));
        redButtonB.onClick.AddListener(() => SetCarColor("_Color_B", Color.red));
        blueButtonB.onClick.AddListener(() => SetCarColor("_Color_B", Color.blue));
        yellowButtonB.onClick.AddListener(() => SetCarColor("_Color_B", Color.yellow));
        greenButtonB.onClick.AddListener(() => SetCarColor("_Color_B", Color.green));
        
        toggle.interactable = false;

        redButtonA.interactable = false;
        blueButtonA.interactable = false;
        yellowButtonA.interactable = false;
        greenButtonA.interactable = false;

        redButtonB.interactable = false;
        blueButtonB.interactable = false;
        yellowButtonB.interactable = false;
        greenButtonB.interactable = false;

        playButton.onClick.AddListener(EnableUI);
    }

    private void OnToggleChanged(bool isOn)
    {
        UpdateToggleVisuals(isOn);
        SetWhatCar(isOn);
    }

    private void UpdateToggleVisuals(bool isOn)
    {
        if (_image != null)
            _image.sprite = isOn ? onSprite : offSprite;
    }

    private void SetWhatCar(bool isCarA)
    {
        if (carMaterial != null)
            carMaterial.SetFloat("_WhatCar", isCarA ? 1f : 0f);
    }
    
    private void EnableUI()
    {
        toggle.interactable = true;

        redButtonA.interactable = true;
        blueButtonA.interactable = true;
        yellowButtonA.interactable = true;
        greenButtonA.interactable = true;

        redButtonB.interactable = true;
        blueButtonB.interactable = true;
        yellowButtonB.interactable = true;
        greenButtonB.interactable = true;
    }
    
    public void SetCarColor(string colorPropertyName, Color newColor)
    {
        if (carMaterial != null)
        {
            carMaterial.SetColor(colorPropertyName, newColor);
        }
    }
}