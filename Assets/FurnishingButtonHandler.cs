using UnityEngine;
using System.Collections.Generic;

public class FurnishingButtonHandler : MonoBehaviour
{
    public GameObject furnishingPrefab; // Przedstawia prefabrykat wyposa¿enia

    public Transform furnishingSpawnPoint; // Przydziel obiekt Transform, gdzie ma byæ umieszczane wyposa¿enie

    private List<GameObject> spawnedFurnishings = new List<GameObject>(); // Lista przechowuj¹ca umieszczone wyposa¿enie

    // Funkcja obs³uguj¹ca klikniêcie przycisku "Dodaj wyposa¿enie"
    public void OnAddFurnishingButtonClick()
    {
        // Upewnij siê, ¿e jest dostêpny prefabrykat wyposa¿enia
        if (furnishingPrefab != null)
        {
            // Instancjuj prefabrykat wyposa¿enia na pozycji spawnowania
            GameObject newFurnishing = Instantiate(furnishingPrefab, furnishingSpawnPoint.position, Quaternion.identity);

            // Dodaj instancjê do listy, aby mo¿na by³o j¹ póŸniej zarz¹dzaæ
            spawnedFurnishings.Add(newFurnishing);
        }
    }
}
