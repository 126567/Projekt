using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void Exit()
    {
        // Wyjd� z gry (tylko w trybie stanu buildu, nie dzia�a w Unity Edytor)
        Application.Quit();
    }
}
