using UnityEngine;
using UnityEngine.UI;

public class ScrollingAnimation : MonoBehaviour
{
    [SerializeField]
    private RawImage _img; // Ссылка на компонент RawImage, на котором будет происходить анимация.

    [SerializeField]
    private float _x, _y; // Скорость смещения текстурных координат по осям X и Y.

    private void Update()
    {
        // Обновляем текстурные координаты компонента RawImage с учетом времени и скорости.
        // Это создает эффект анимации прокрутки текстуры.
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, _img.uvRect.size);
    }
}