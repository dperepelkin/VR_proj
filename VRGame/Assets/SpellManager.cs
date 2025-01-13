using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public Transform spellSpawnPoint; // “очка по€влени€ заклинани€
    public GameObject[] spells; // ћассив доступных заклинаний
    public Transform cameraTransform;
    private GameObject currentSpell; // “екущее активное заклинание
    private GameObject newSpell;
    private int spellInd;

    public void SelectSpell(int spellIndex)
    {
        this.spellInd = spellIndex;
        // ”далить предыдущее заклинание, если оно существует
        if (currentSpell != null)
        {
            Destroy(currentSpell);
        }

        // —оздать выбранное заклинание
        if (this.spellInd >= 0 && this.spellInd < spells.Length)
        {
            currentSpell = Instantiate(spells[this.spellInd], spellSpawnPoint.position, spellSpawnPoint.rotation, spellSpawnPoint);
            Debug.Log($"«аклинание создано на позиции: {spellSpawnPoint.position}");
        }
    }

    public void CastSpell()
    {
        if (currentSpell != null)
        {
            // —оздаем копию заклинани€ на позиции точки по€влени€
            newSpell = Instantiate(spells[this.spellInd], spellSpawnPoint.position, spellSpawnPoint.rotation, spellSpawnPoint);
            currentSpell.transform.SetParent(null); // ќткрепл€ем от родител€

            // ”станавливаем направление движени€ (например, вперед от точки по€влени€)
            SpellMovement spellMovement = currentSpell.GetComponent<SpellMovement>();
            Vector3 direction = cameraTransform.forward;
            if (spellMovement != null)
            {
                spellMovement.SetDirection(direction); // ƒвигаем вперед от точки по€влени€
            }
            else
            {
                Debug.LogError("SpellMovement не найден на заклинании!");
            }
            currentSpell = newSpell;
            newSpell = null;
        }
        else
        {
            Debug.LogWarning("Ќет выбранного заклинани€ дл€ кастовани€!");
        }
    }

}
