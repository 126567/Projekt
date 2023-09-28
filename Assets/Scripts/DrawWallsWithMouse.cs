using UnityEngine;

public class DrawWallsWithCollisionAndMouse : MonoBehaviour
{
    public GameObject wallPrefab; // Przypisz prefabrykat �ciany
    public GameObject floorPrefab; // Przypisz prefabrykat pod�ogi

    private bool isDrawing = false;
    private Vector3 startPosition;
    private GameObject currentWall;
    private Collider2D wallCollider; // Komponent Collider2D �ciany

    void Update()
    {
        // Sprawd�, czy jeste� w trybie rysowania �ciany
        if (isDrawing)
        {
            // Aktualizuj pozycj� ko�cow� �ciany na bie��cej pozycji myszy
            Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentMousePosition.z = 0f; // Ustal pozycj� Z na 0 (w p�aszczy�nie XY)

            // Aktualizuj pozycj� ko�ca �ciany
            currentWall.transform.position = (startPosition + currentMousePosition) / 2f;
            currentWall.transform.localScale = new Vector3(Vector3.Distance(startPosition, currentMousePosition), 1f, 1f);

            // Sprawd�, czy u�ytkownik pu�ci� lewy przycisk myszy
            if (Input.GetMouseButtonUp(0))
            {
                isDrawing = false;

                // Sprawd�, czy �ciana jest zamkni�t� figur� na podstawie kolizji
                if (IsWallClosed())
                {
                    CreateFloor();
                }
            }
        }
    }

    void OnMouseDown()
    {
        // Rozpocznij rysowanie �ciany po klikni�ciu lewym przyciskiem myszy
        isDrawing = true;
        startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        startPosition.z = 0f; // Ustal pozycj� Z na 0 (w p�aszczy�nie XY)

        // Tw�rz prefabrykat �ciany na pozycji pocz�tkowej
        currentWall = Instantiate(wallPrefab, startPosition, Quaternion.identity);

        // Pobierz komponent Collider2D �ciany
        wallCollider = currentWall.GetComponent<Collider2D>();
    }

    bool IsWallClosed()
    {
        // Sprawd�, czy Collider2D �ciany koliduje z innymi Collider2D w grze
        Collider2D[] colliders = Physics2D.OverlapCollider(wallCollider, new ContactFilter2D(), new Collider2D[1]);

        // Je�eli s� kolizje, to �ciana jest zamkni�t� figur�
        return colliders.Length > 0;
    }

    void CreateFloor()
    {
        // Tw�rz prefabrykat pod�ogi na podstawie zamkni�tej �ciany
        Vector3 floorPosition = currentWall.transform.position;
        floorPosition.y = -0.5f; // Ustal wysoko�� pod�ogi poni�ej �ciany

        Instantiate(floorPrefab, floorPosition, Quaternion.identity);
    }
}
