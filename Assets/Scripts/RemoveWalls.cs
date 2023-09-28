using UnityEngine;

public class RemoveWalls : MonoBehaviour
{
    public LayerMask wallLayer; // Przypisz warstw�, na kt�rej znajduj� si� �ciany

    void Update()
    {
        // Sprawd�, czy u�ytkownik klikn�� lewym przyciskiem myszy
        if (Input.GetMouseButtonDown(0))
        {
            // Pobierz pozycj� klikni�cia myszk� w przestrzeni gry
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0f; // Ustal pozycj� Z na 0 (w p�aszczy�nie XY)

            // Znajd� wszystkie kolidera �ciany w promieniu 1 jednostki od klikni�tej pozycji
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(clickPosition, 1f, wallLayer);

            // Usu� wszystkie znalezione �ciany
            foreach (Collider2D collider in hitColliders)
            {
                Destroy(collider.gameObject);
            }
        }
    }
}
