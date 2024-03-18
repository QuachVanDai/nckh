

using UnityEngine;
namespace QuachDai.NinjaSchool.Monsters
{
    public class DestroyMonsterWeaponsByPlayer : Destroys
    {
        bool isDestroy;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "player")
            {
                isDestroy = true;
            }
        }
        public override bool CanDestroy()
        {
            return isDestroy;
        }
    }
}
