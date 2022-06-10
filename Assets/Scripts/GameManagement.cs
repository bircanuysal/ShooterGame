using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameManagement : MonoBehaviour
{
    public static GameManagement Instance;
    public Slider HealtBar;
    public int Healt = 100;

    public GameObject ragdollObject;
    public int atilanMermi;
    public TextMeshProUGUI atilanMermiUI;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        atilanMermi = 0;
    }

    // Update is called once per frame
    void Update()
    {
        HealtBar.value = Healt;
        checkHealt();
        atilanMermiUI.text = atilanMermi.ToString();
    }
    public void checkHealt()
    {
        if (Healt < 1)
        {
            ragdollObject.GetComponent<Animator>().enabled = false;
        }
    }
}
