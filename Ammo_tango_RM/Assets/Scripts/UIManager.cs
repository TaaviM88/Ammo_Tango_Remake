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

    void Awake()
    {
        /*
        if (instance = null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        */
    }

    // Start is called before the first frame update
    void Start()
    {

        foreach(GameObject slider in sliders)
        {
            sliderlist.Add(slider.GetComponent<Slider>());
        }

        /*
        armor = sliders[0].GetComponent<Slider>();
        hp = sliders[1].GetComponent<Slider>();
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateShieldBar(float amount,int pID)
    {
        //slider(amount)

        switch(pID)
        {
            case 1: 
                sliderlist[0].SetValueWithoutNotify(amount);

            //pelaaja1
            //slider 1 aktiiviseksi
            //slider
            break;

            case 2:
                sliderlist[2].SetValueWithoutNotify(amount);
                break;

            case 3:
                sliderlist[4].SetValueWithoutNotify(amount);
                break;

            case 4:
                sliderlist[6].SetValueWithoutNotify(amount);
                break;


            default:
                Debug.Log("LUL");
                break;
        }
    }
    public void UpdateHealthBar(float amount, int pID)
    {
        //slider(amount)

        switch (pID)
        {
            case 1:
                sliderlist[1].SetValueWithoutNotify(amount);

                //pelaaja1
                //slider 1 aktiiviseksi
                //slider
                break;

            case 2:
                sliderlist[3].SetValueWithoutNotify(amount);
                break;

            case 3:
                sliderlist[5].SetValueWithoutNotify(amount);
                break;

            case 4:
                sliderlist[7].SetValueWithoutNotify(amount);
                break;

            default:
                Debug.Log("LUL");
                break;
        }
    }
}
