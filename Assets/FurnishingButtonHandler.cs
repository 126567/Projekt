using UnityEngine;
using System.Collections.Generic;

public class FurnishingButtonHandler : MonoBehaviour
{
    public GameObject furnishingPrefab; // Przedstawia prefabrykat wyposa�enia

    public Transform furnishingSpawnPoint; // Przydziel obiekt Transform, gdzie ma by� umieszczane wyposa�enie

    private List<GameObject> spawnedFurnishings = new List<GameObject>(); // Lista przechowuj�ca umieszczone wyposa�enie

    // Funkcja obs�uguj�ca klikni�cie przycisku "Dodaj wyposa�enie"
    public void OnAddFurnishingButtonClick()
    {
        // Upewnij si�, �e jest dost�pny prefabrykat wyposa�enia
        if (furnishingPrefab != null)
        {
            // Instancjuj prefabrykat wyposa�enia na pozycji spawnowania
            GameObject newFurnishing = Instantiate(furnishingPrefab, furnishingSpawnPoint.position, Quaternion.identity);

            // Dodaj instancj� do listy, aby mo�na by�o j� p�niej zarz�dza�
            spawnedFurnishings.Add(newFurnishing);
        }
    }
}
