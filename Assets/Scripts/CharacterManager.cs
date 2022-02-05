using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    private AudioSource audioSource;
    public Character character;

    public GameObject customizePanel;
    public GameObject characterPanel;
    public GameObject animatePanel;
    public GameObject buttonsLayout;

    public AudioClip[] audios;

    private Button[] buttons;

    public CharacterObject chestObject= new CharacterObject();
    public CharacterObject faceObject= new CharacterObject();
    public CharacterObject headObject = new CharacterObject();
    public CharacterObject hairObject= new CharacterObject();
    public CharacterObject neckObject = new CharacterObject();
    public CharacterObject leftArmObject= new CharacterObject();
    public CharacterObject rightArmObject= new CharacterObject();
    public CharacterObject waistObject= new CharacterObject();
    public CharacterObject leftLegObject=new CharacterObject();
    public CharacterObject RightLegObject=new CharacterObject();
    public CharacterObject leftShoeObject= new CharacterObject();
    public CharacterObject rightShoeObject= new CharacterObject();


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        customizePanel.SetActive(true);
        characterPanel.SetActive(false);

        chestObject.image.sprite = chestObject.sprites[chestObject.count];
        chestObject.button.onClick.AddListener(CustomizeChest);

        hairObject.image.sprite = hairObject.sprites[hairObject.count];
        hairObject.button.onClick.AddListener(CustomizeHair);

        rightArmObject.image.sprite = rightArmObject.sprites[rightArmObject.count];
        rightArmObject.button.onClick.AddListener(CustomizeArms);

        buttons=buttonsLayout.GetComponentsInChildren<Button>();

        foreach (var item in buttons)
        {
            item.onClick.AddListener(PlayAudio);
        }
    }

    public void CreateCharacter()
    {
        Debug.Log(chestObject.count);

        audioSource.clip = audios[1];
        this.GetComponent<AudioSource>().Play();

        animatePanel.SetActive(true);
        characterPanel.SetActive(true);

        customizePanel.SetActive(false);

        character.chest/*.gameObject.GetComponent<Image>()*/.sprite = chestObject.sprites[chestObject.count];
        character.hair/*.gameObject.GetComponent<Image>()*/.sprite=hairObject.sprites[hairObject.count];
        character.rightArm/*.gameObject.GetComponent<Image>()*/.sprite=rightArmObject.sprites[rightArmObject.count];
        character.leftArm/*.gameObject.GetComponent<Image>()*/.sprite = rightArmObject.sprites[rightArmObject.count];
    }

    public void CustomizeChest()
    {
        if (chestObject.count == chestObject.sprites.Count-1)
            chestObject.count = 0;
        else
            chestObject.count++;

        chestObject.image.sprite= chestObject.sprites[chestObject.count];
    }

    public void CustomizeHair()
    {
        if (hairObject.count== hairObject.sprites.Count-1)
            hairObject.count = 0;
        else
            hairObject.count++;

        hairObject.image.sprite= hairObject.sprites[hairObject.count];
    }

    public void CustomizeArms()
    {
        if (rightArmObject.count==rightArmObject.sprites.Count-1)
            rightArmObject.count = 0;
        else
            rightArmObject.count++;

        rightArmObject.image.sprite=rightArmObject.sprites[rightArmObject.count];
        leftArmObject.image.sprite=leftArmObject.sprites[rightArmObject.count];
    }

    public void BackCustomize()
    {
        audioSource.clip = audios[2];
        this.GetComponent<AudioSource>().Play();

        animatePanel.SetActive(true);
        customizePanel.SetActive(true);

        characterPanel.SetActive(!customizePanel.active);
    }

    public void PlayAudio()
    {
        audioSource.clip=audios[0];
        this.GetComponent<AudioSource>().Play();
    }
}

[System.Serializable]
public class CharacterObject
{
    public List<Sprite> sprites = new List<Sprite>();
    public Image image;
    public Button button;
    public int count = 0;
}

[System.Serializable]
public class Character
{
    public Image face;
    public Image head;
    public Image hair;
    public Image neck;
    public Image chest;
    public Image leftArm;
    public Image rightArm;
    public Image waist;
    public Image leftLeg;
    public Image rightleg;
    public Image leftShoe;
    public Image rightShoe;
}

    /* default Chest Objects
    public List<Sprite> chest = new List<Sprite>();
    public Image chestImage;
    public GameObject chestButton;
    public int chestCount=0;
    */

    //public CharacterObject headObject= new CharacterObject();