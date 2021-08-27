using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SystemsManager : MonoBehaviour
{
    public static SystemsManager Instance { get => _instance; }
    
    public bool OxygenOnline { get => oxygenOnline; set => oxygenOnline = value; }
    public bool LightsOnline { get => lightsOnline; set => lightsOnline = value; }
    public bool GravityOnline { get => gravityOnline; set => gravityOnline = value; }

    private static SystemsManager _instance;

    [SerializeField] private TextMeshProUGUI systemsText;
    // Start is called before the first frame update

    [SerializeField]
    private bool gravityOnline = true;

    [SerializeField]
    private bool oxygenOnline = true;

    [SerializeField]
    private bool lightsOnline = true; 

    void Start()
    {
        UpdateStatus(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateStatus()
    {
        string status = OxygenStatusText() + GravityStatusText() + LightsStatusText();

        systemsText.text = status; 
    }

    private string OxygenStatusText() => OxygenOnline ? "Oxygen System Online\n" : "Oxygen System Offline\n";
    private string GravityStatusText() => GravityOnline ? "Gravity System Online\n" : "Gravity System Offline\n";
    private string LightsStatusText() => LightsOnline ? "Light System Online\n" : "Light System Offline\n";
}
