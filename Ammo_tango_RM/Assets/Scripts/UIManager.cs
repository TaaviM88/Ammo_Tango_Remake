using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;

    [SerializeField]
    public GameObject[] sliders;

    private Slider armor;
    private Slider hp;

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

        armor = sliders[0].GetComponent<Slider>();
        hp = sliders[1].GetComponent<Slider>();
        
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
                armor.SetValueWithoutNotify(amount);

            //pelaaja1
            //slider 1 aktiiviseksi
            //slider
            break;

            case 2:
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
                hp.SetValueWithoutNotify(amount);

                //pelaaja1
                //slider 1 aktiiviseksi
                //slider
                break;

            default:
                Debug.Log("LUL");
                break;
        }
    }
}
