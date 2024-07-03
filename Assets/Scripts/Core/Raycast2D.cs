using Core;
using UnityEngine;

public class Raycast2D : MonoBehaviour
{
    private void Update()
    {
        // Проверяем, было ли нажатие левой кнопки мыши
        if (Input.GetMouseButtonDown(0))
        {
            // Получаем позицию курсора в мировых координатах
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Создаем луч из позиции курсора в направлении вперед от камеры
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            // Проверяем, попал ли луч в какой-либо коллайдер
            if (hit.collider != null)
            {
                var clickableObject = hit.transform.GetComponent<IClickableObject>();
                if (clickableObject != null)
                    clickableObject.OnClickAction();
            }
        }
    }
}