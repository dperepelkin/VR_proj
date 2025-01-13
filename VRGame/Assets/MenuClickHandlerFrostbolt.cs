using SimplePieMenu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuClickHandlerFrostbolt : MonoBehaviour, IMenuItemClickHandler
{
    public SpellManager spellManager;
    public void Handle()
    {
        spellManager.SelectSpell(1);
        Debug.Log("you cast Frostbolt");
    }

}
