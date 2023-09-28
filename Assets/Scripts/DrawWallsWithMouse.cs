using UnityEngine;

public class DrawWallsWithCollisionAndMouse : MonoBehaviour
{
    public GameObject wallPrefab; // Przypisz prefabrykat œciany
    public GameObject floorPrefab; // Przypisz prefabrykat pod³ogi

    private bool isDrawing = false;
    private Vector3 startPosition;
    private GameObject currentWall;
    private Collider2D wallCollider; // Komponent Collider2D œciany

    void Update()
    {
        // SprawdŸ, czy jesteœ w trybie rysowania œciany
        if (isDrawing)
        {
            // Aktualizuj pozycjê koñcow¹ œciany na bie¿¹cej pozycji myszy
            Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentMousePosition.z = 0f; // Ustal pozycjê Z na 0 (w p³aszczyŸnie XY)

            // Aktualizuj pozycjê koñca œciany
            currentWall.transform.position = (startPosition + currentMousePosition) / 2f;
            currentWall.transform.localScale = new Vector3(Vector3.Distance(startPosition, currentMousePosition), 1f, 1f);

            // SprawdŸ, czy u¿ytkownik puœci³ lewy przycisk myszy
            if (Input.GetMouseButtonUp(0))
            {
                isDrawing = false;

                // SprawdŸ, czy œciana jest zamkniêt¹ figur¹ na podstawie kolizji
                if (IsWallClosed())
                {
                    CreateFloor();
                }
            }
        }
    }

    void OnMouseDown()
    {
        // Rozpocznij rysowanie œciany po klikniêciu lewym przyciskiem myszy
        isDrawing = true;
        startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        startPosition.z = 0f; // Ustal pozycjê Z na 0 (w p³aszczyŸnie XY)

        // Twórz prefabrykat œciany na pozycji pocz¹tkowej
        currentWall = Instantiate(wallPrefab, startPosition, Quaternion.identity);

        // Pobierz komponent Collider2D œciany
        wallCollider = currentWall.GetComponent<Collider2D>();
    }

    bool IsWallClosed()
    {
        // SprawdŸ, czy Collider2D œciany koliduje z innymi Collider2D w grze
        Collider2D[] colliders = Physics2D.OverlapCollider(wallCollider, new ContactFilter2D(), new Collider2D[1]);

        // Je¿eli s¹ kolizje, to œciana jest zamkniêt¹ figur¹
        return colliders.Length > 0;
    }

    void CreateFloor()
    {
        // Twórz prefabrykat pod³ogi na podstawie zamkniêtej œciany
        Vector3 floorPosition = currentWall.transform.position;
        floorPosition.y = -0.5f; // Ustal wysokoœæ pod³ogi poni¿ej œciany

        Instantiate(floorPrefab, floorPosition, Quaternion.identity);
    }
}
