using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CharacterObject
{
    public List<Sprite> chest = new List<Sprite>();
    public Image chestImage;
    public GameObject chestButton;
    public int chestCount = 0;
}

public class CharacterManager : MonoBehaviour
{
    public GameObject customizePanel;
    public GameObject characterPanel;
    public GameObject animatePanel;

    public CharacterObject chestObject= new CharacterObject();

    /* default Chest Objects
    public List<Sprite> chest = new List<Sprite>();
    public Image chestImage;
    public GameObject chestButton;
    public int chestCount=0;
    */

    //public CharacterObject headObject= new CharacterObject();
    
    void Start()
    {
        customizePanel.SetActive(true);
        characterPanel.SetActive(false);

       chestObject.chestImage.sprite = chestObject.chest[chestObject.chestCount];
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           CreateCharacter();   
        }
        
    }

    public void CustomizeChest()
    {
        if (chestObject.chestCount == chestObject.chest.Count-1)
        {
            chestObject.chestCount = 0;
        }
        else
        {
            chestObject.chestCount++;
        }

        chestObject.chestImage.sprite= chestObject.chest[chestObject.chestCount];
    }

    public void CreateCharacter()
    {
        Debug.Log(chestObject.chestCount);

        animatePanel.SetActive(true);
        characterPanel.SetActive(true);

        customizePanel.SetActive(false);

        characterPanel.gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = chestObject.chest[chestObject.chestCount];
    }

    public void BackCustomize()
    {
        animatePanel.SetActive(true);
        customizePanel.SetActive(true);

        characterPanel.SetActive(!customizePanel.active);
    }


    public void EnablePanel()
    {

    }
}

