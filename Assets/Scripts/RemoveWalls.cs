using UnityEngine;

public class RemoveWalls : MonoBehaviour
{
    public LayerMask wallLayer; // Przypisz warstwê, na której znajduj¹ siê œciany

    void Update()
    {
        // SprawdŸ, czy u¿ytkownik klikn¹³ lewym przyciskiem myszy
        if (Input.GetMouseButtonDown(0))
        {
            // Pobierz pozycjê klikniêcia myszk¹ w przestrzeni gry
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0f; // Ustal pozycjê Z na 0 (w p³aszczyŸnie XY)

            // ZnajdŸ wszystkie kolidera œciany w promieniu 1 jednostki od klikniêtej pozycji
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(clickPosition, 1f, wallLayer);

            // Usuñ wszystkie znalezione œciany
            foreach (Collider2D collider in hitColliders)
            {
                Destroy(collider.gameObject);
            }
        }
    }
}
