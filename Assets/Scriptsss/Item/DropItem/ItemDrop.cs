using DG.Tweening;
using QuachDai.NinjaSchool.Character;
using System.Collections;
using UnityEngine;
namespace QuachDai.NinjaSchool.Item
{
    public class ItemDrop : MonoBehaviour
    {
        public JunkSO junkSO;
        public SpriteRenderer spriteRenderer;
        public Slot slotItem;
        Player player => Player.Instance;
        private void Start()
        {
            Destroy(gameObject, 4f);
        }
        public Transform GetItems()
        {
            int index = Random.Range(0, junkSO.itemList.Count);
            slotItem.item = junkSO.itemList[index];
            spriteRenderer.sprite = slotItem.item.Icon;
            return transform;
        }

        float distanceFromThisToPlayer;
        public void OnMouseDown()
        {
            distanceFromThisToPlayer = Vector2.Distance(this.transform.position, player.transform.position);
            if (distanceFromThisToPlayer >= 4) return;
            ItemMove();
        }
        public void ItemMove()
        {
            transform.DOMove(player.transform.position, 0.22f).OnComplete(() =>
            {
                StartCoroutine(PickUpItems());

            });
            IEnumerator PickUpItems()
            {
                string _xu = "";
                if (slotItem.item.itemName == ItemName.Hp)
                    InventoryUpdate.Instance.UpdateMP(slotItem, 1);
                else if (slotItem.item.itemName == ItemName.Mp)
                    InventoryUpdate.Instance.UpdateMP(slotItem, 1);
                else if (slotItem.item.itemName == ItemName.Xu)
                {
                    MoneySO money = (MoneySO)slotItem.item.getItemSO();
                    Player.Instance.SetXu(money.Xu);
                    _xu = money.Xu.ToString();
                }
                TextTemplate.Instance.SetText("Ban nhận được " + _xu + " " + slotItem.item.itemName.ToString());
                yield return new WaitForSeconds(0.2f);
                Destroy(gameObject);
            }
        }
    }
}
