using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusterSwordItem : Item
{
    public BusterSwordItem()
    {
        this.stationsLeft.Enqueue("Welding");
        this.stationsLeft.Enqueue("Forge");
        this.stationsLeft.Enqueue("Barrel");
    }

}

