using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    private AudioSource audioSource;
    public Character character;

    public CharacterData characterData;

    public GameObject customizePanel;
    public GameObject characterPanel;
    public GameObject animatePanel;
    public GameObject buttonsLayout;

    public AudioClip[] audios;

    private Button[] buttons;

    #region bodyObjects

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

    #endregion bodyObjects


    /// <summary>
    /// adds the audio clips to the string.
    /// </summary>
    [SerializeField]
    public Dictionary<string,AudioClip> characterSounds = new Dictionary<string, AudioClip>();


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        characterSounds.Add("Change", audios[0]);
        characterSounds.Add("Confirmation", audios[1]);
        characterSounds.Add("Back",audios[2]);

    }

    void Start()
    {
        Debug.Log(characterData.bodyData[0].Name);

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

    /// <summary>
    /// Creates characters.
    /// </summary>
    public void CreateCharacter()
    {
        //audioSource.clip = audios[1];
        audioSource.clip = characterSounds["Confirmation"];
        audioSource.Play();

        bool createCharacterState = true;

        animatePanel.SetActive(createCharacterState);

        characterPanel.SetActive(createCharacterState);
        customizePanel.SetActive(!createCharacterState);

        character.chest/*.gameObject.GetComponent<Image>()*/.sprite = chestObject.sprites[chestObject.count];
        character.hair/*.gameObject.GetComponent<Image>()*/.sprite=hairObject.sprites[hairObject.count];
        character.rightArm/*.gameObject.GetComponent<Image>()*/.sprite=rightArmObject.sprites[rightArmObject.count];
        character.leftArm/*.gameObject.GetComponent<Image>()*/.sprite = rightArmObject.sprites[rightArmObject.count];
    }

    /// <summary>
    /// back to the customize panel.
    /// </summary>
    public void BackCustomize()
    {
        bool backState = true;

        //audioSource.clip = audios[2];
        audioSource.clip = characterSounds["Back"];
        audioSource.Play();

        animatePanel.SetActive(backState);

        customizePanel.SetActive(backState);
        characterPanel.SetActive(!backState);
    }


    /// <summary>
    /// This function changes the chest sprite.
    /// </summary>
    public void CustomizeChest()
    {
        if (chestObject.count == chestObject.sprites.Count-1)
            chestObject.count = 0;
        else
            chestObject.count++;

        chestObject.image.sprite= chestObject.sprites[chestObject.count];
    }

    /// <summary>
    /// Similarly to chest, it changes its sprites.
    /// </summary>
    public void CustomizeArms()
    {
        if (rightArmObject.count==rightArmObject.sprites.Count-1)
            rightArmObject.count = 0;
        else
            rightArmObject.count++;

        rightArmObject.image.sprite=rightArmObject.sprites[rightArmObject.count];
        leftArmObject.image.sprite=leftArmObject.sprites[rightArmObject.count];
    }


    /// <summary>
    /// Same as this go.
    /// </summary>
    public void CustomizeHair()
    {
        if (hairObject.count== hairObject.sprites.Count-1)
            hairObject.count = 0;
        else
            hairObject.count++;

        hairObject.image.sprite= hairObject.sprites[hairObject.count];
    }

    /// <summary>
    /// Plays audio sound to the buttons.
    /// </summary>
    public void PlayAudio()
    {
        //audioSource.clip = audios[0];
        audioSource.clip = characterSounds["Change"];
        audioSource.Play();
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