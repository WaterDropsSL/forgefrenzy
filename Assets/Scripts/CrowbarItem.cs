using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowbarItem : Item
{
    public CrowbarItem()
    {
        this.stationsLeft.Enqueue("Forge");
        this.stationsLeft.Enqueue("Anvil");
        this.stationsLeft.Enqueue("Forge");
        this.stationsLeft.Enqueue("Barrel");
        //this.currentStation = "Forge";
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

}
