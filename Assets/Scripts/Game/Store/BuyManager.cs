using UnityEngine;

//Резюме:
//главный минус не вижу точки сборки, не ясно как от кого идут зависимости, посмотреть на справку Composition Root, EntryPoint концепты
//слишком много комментариев, код должен говорить сам за себя в 90% случаев

//Слово Manager мусорное, не несёт смысловой нагрузки
public class BuyManager : MonoBehaviour
{
    [SerializeField]
    private ShopManager shopManager; // Ссылка на менеджер магазина.
    [SerializeField]
    private CoinCollect coinCollect; // Ссылка на сборщика монет.
    [SerializeField]
    private ChangeFish changeFish; // Ссылка на компонент смены рыбы.
    [SerializeField]
    private AbstractMetrics metrics; // Ссылка на абстрактный компонент аналитики.

    // Покупает выбранную рыбу по указанному индексу.
    public void BuyFish(int fishIndex)
    {
        int fishPrice = shopManager.CalculateFishPrice(fishIndex);

        // Проверяем, достаточно ли монет для покупки рыбы.
        if (coinCollect.Coins < fishPrice) return;

        metrics.Send("BuyFISH"); // Отправляем аналитику о покупке рыбы.

        coinCollect.Coins -= fishPrice; // Вычитаем стоимость рыбы из монет.

        shopManager.SavePlayerData(); // Сохраняем данные игрока.

        shopManager._coinText.text = $"x{coinCollect.Coins}"; // Обновляем текст с количеством монет.

        shopManager.UpdateFishMesh(fishIndex); // Обновляем внешний вид рыбы в магазине.

        Mesh newFishMesh = shopManager.GetCurrentFishMesh();

        // Применяем новый меш к рыбе, если он доступен.
        if (newFishMesh != null)
        {
            changeFish.ApplyNewFishMesh(newFishMesh);
        }
    }
}