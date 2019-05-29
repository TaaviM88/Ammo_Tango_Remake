using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;

    [SerializeField]
    public GameObject[] sliders;

    public List<Slider> sliderlist;

    //hudElements = portraits + name
    [SerializeField]
    public GameObject[] hudElements;
    public Sprite[] playericons;

    // Start is called before the first frame update
    void Start()
    {

        foreach(GameObject slider in sliders)
        {
            sliderlist.Add(slider.GetComponent<Slider>());
        }

    }


    public void UpdateShieldBar(float amount,int pID)
    {

        switch(pID)
        {
            case 1:
                if (!(sliders[0].activeSelf))
                {
                    sliders[0].SetActive(true);
                }
                sliderlist[0].SetValueWithoutNotify(amount);

            break;

            case 2:
                if (!(sliders[2].activeSelf))
                {
                    sliders[2].SetActive(true);
                }
                sliderlist[2].SetValueWithoutNotify(amount);
                break;

            case 3:
                if (!(sliders[4].activeSelf))
                {
                    sliders[4].SetActive(true);
                }
                sliderlist[4].SetValueWithoutNotify(amount);
                break;

            case 4:
                if (!(sliders[6].activeSelf))
                {
                    sliders[6].SetActive(true);
                }
                sliderlist[6].SetValueWithoutNotify(amount);
                break;


            default:
                Debug.Log("LUL");
                break;
        }
    }
    public void UpdateHealthBar(float amount, int pID)
    {
        

        switch (pID)
        {

            case 1:
                if (!(sliders[1].activeSelf))
                {
                    sliders[1].SetActive(true);
                    hudElements[0].SetActive(true);
                    hudElements[1].SetActive(true);

                    if(GameManager.playerList[0].GetComponent<Player>().characterName == Player.CharacterName.Slippy)
                    {
                        hudElements[0].GetComponent<Image>().sprite = playericons[0];
                    }
                    if (GameManager.playerList[0].GetComponent<Player>().characterName == Player.CharacterName.John)
                    {
                        hudElements[0].GetComponent<Image>().sprite = playericons[1];
                    }
                    if (GameManager.playerList[0].GetComponent<Player>().characterName == Player.CharacterName.Darius)
                    {
                        hudElements[0].GetComponent<Image>().sprite = playericons[2];
                    }
                    if (GameManager.playerList[0].GetComponent<Player>().characterName == Player.CharacterName.Anya)
                    {
                        hudElements[0].GetComponent<Image>().sprite = playericons[3];
                    }


                }

                sliderlist[1].SetValueWithoutNotify(amount);

                break;

            case 2:
                if (!(sliders[3].activeSelf))
                {
                    sliders[3].SetActive(true);
                    hudElements[2].SetActive(true);
                    hudElements[3].SetActive(true);

                    if (GameManager.playerList[1].GetComponent<Player>().characterName == Player.CharacterName.Slippy)
                    {
                        hudElements[2].GetComponent<Image>().sprite = playericons[0];
                    }
                    if (GameManager.playerList[1].GetComponent<Player>().characterName == Player.CharacterName.John)
                    {
                        hudElements[2].GetComponent<Image>().sprite = playericons[1];
                    }
                    if (GameManager.playerList[1].GetComponent<Player>().characterName == Player.CharacterName.Darius)
                    {
                        hudElements[2].GetComponent<Image>().sprite = playericons[2];
                    }
                    if (GameManager.playerList[1].GetComponent<Player>().characterName == Player.CharacterName.Anya)
                    {
                        hudElements[2].GetComponent<Image>().sprite = playericons[3];
                    }
                }
                sliderlist[3].SetValueWithoutNotify(amount);
                break;

            case 3:
                if (!(sliders[5].activeSelf))
                {
                    sliders[5].SetActive(true);
                    hudElements[4].SetActive(true);
                    hudElements[5].SetActive(true);

                    if (GameManager.playerList[2].GetComponent<Player>().characterName == Player.CharacterName.Slippy)
                    {
                        hudElements[4].GetComponent<Image>().sprite = playericons[0];
                    }
                    if (GameManager.playerList[2].GetComponent<Player>().characterName == Player.CharacterName.John)
                    {
                        hudElements[4].GetComponent<Image>().sprite = playericons[1];
                    }
                    if (GameManager.playerList[2].GetComponent<Player>().characterName == Player.CharacterName.Darius)
                    {
                        hudElements[4].GetComponent<Image>().sprite = playericons[2];
                    }
                    if (GameManager.playerList[2].GetComponent<Player>().characterName == Player.CharacterName.Anya)
                    {
                        hudElements[4].GetComponent<Image>().sprite = playericons[3];
                    }
                }

                sliderlist[5].SetValueWithoutNotify(amount);
                break;

            case 4:
                if (!(sliders[7].activeSelf))
                {
                    sliders[7].SetActive(true);
                    hudElements[6].SetActive(true);
                    hudElements[7].SetActive(true);

                    if (GameManager.playerList[3].GetComponent<Player>().characterName == Player.CharacterName.Slippy)
                    {
                        hudElements[6].GetComponent<Image>().sprite = playericons[0];
                    }
                    if (GameManager.playerList[3].GetComponent<Player>().characterName == Player.CharacterName.John)
                    {
                        hudElements[6].GetComponent<Image>().sprite = playericons[1];
                    }
                    if (GameManager.playerList[3].GetComponent<Player>().characterName == Player.CharacterName.Darius)
                    {
                        hudElements[6].GetComponent<Image>().sprite = playericons[2];
                    }
                    if (GameManager.playerList[3].GetComponent<Player>().characterName == Player.CharacterName.Anya)
                    {
                        hudElements[6].GetComponent<Image>().sprite = playericons[3];
                    }
                }
                sliderlist[7].SetValueWithoutNotify(amount);
                break;

            default:
                Debug.Log("LUL");
                break;
        }
    }
}
