using SimplePieMenu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuClickHandlerFireball : MonoBehaviour, IMenuItemClickHandler
{
    public SpellManager spellManager;
    public void Handle() 
    {
        spellManager.SelectSpell(0);

        Debug.Log("you cast fireball");
    }
}
