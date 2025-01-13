using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem; // Для работы с новой системой ввода

public class SpellCasterInput : MonoBehaviour
{
    public SpellManager spellManager;
    public InputAction triggerAction; // Ввод для кнопки (например, для кнопки на контроллере)

    private void OnEnable()
    {
        triggerAction.Enable(); // Включаем действие при старте
    }

    private void OnDisable()
    {
        triggerAction.Disable(); // Отключаем действие при выходе
    }

    void Update()
    {
        // Проверяем, нажата ли клавиша G
        if (Keyboard.current.gKey.isPressed)  // Это будет работать при использовании XR Device Simulator
        {
            spellManager.CastSpell();
            Thread.Sleep(500);
        }

        // Если вам нужно отслеживать нажатие кнопок на контроллере (например, кнопка на правом контроллере):
        if (triggerAction.triggered)  // Можно использовать для отслеживания нажатий кнопок через InputAction
        {
            spellManager.CastSpell();
        }
    }
}
