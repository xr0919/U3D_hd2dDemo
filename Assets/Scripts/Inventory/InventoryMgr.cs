using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMgr
{
    private static InventoryMgr instance = new InventoryMgr();
    private InventoryMgr() { }
    public static InventoryMgr Instance { 
        get { return instance; }
    }
    
    public bool objId1 = false;
    public bool objId2 = false;
    public int numObjId2 = 0;
}
