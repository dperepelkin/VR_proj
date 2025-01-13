using SimplePieMenu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuClickHandlerStunnigblow : MonoBehaviour, IMenuItemClickHandler
{
    public SpellManager spellManager;
    public void Handle()
    {
        spellManager.SelectSpell(2);
        Debug.Log("You cast stunnig blow");
    }
}
