using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public Image chestImage;
    public List<Sprite> chest = new List<Sprite>();
    public int chestCount=0;
    public GameObject chestButton;
  
    void Start()
    {
        chestImage.sprite = chest[chestCount];
    }


    void Update()
    {
        
    }

    public void CustomizeChest()
    {
        if (chestCount == chest.Count-1)
        {
            chestCount = 0;
        }
        else
        {
            chestCount++;
        }

        chestImage.sprite= chest[chestCount];
    }
}
