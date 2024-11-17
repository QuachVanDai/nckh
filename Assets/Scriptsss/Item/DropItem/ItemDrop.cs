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
        public ItemSlot slotItem;
        Player player => Player.Instance;
        private void Start()
        {
            Destroy(gameObject, 10f);
        }
        public Transform GetItems()
        {
            int index = Random.Range(0, junkSO.itemList.Count);
            slotItem.Item = junkSO.itemList[index];
            spriteRenderer.sprite = slotItem.Item.Icon;
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
                if (slotItem.Item.Name == ItemName.Hp)
                    InventoryUpdate.Instance.UpdateHP(slotItem, 1);
                else if (slotItem.Item.Name == ItemName.Mp)
                    InventoryUpdate.Instance.UpdateMP(slotItem, 1);
                else if (slotItem.Item.Name == ItemName.Xu)
                {
                    MoneySO money = (MoneySO)slotItem.Item.getItemSO();
                    Player.Instance.SetXu(money.Xu);
                    _xu = money.Xu.ToString();
                }
                TextTemplate.Instance.SetText("You receive " + _xu + " " + slotItem.Item.Name.ToString());
                yield return new WaitForSeconds(0.2f);
                Destroy(gameObject);
            }
        }
    }
}
