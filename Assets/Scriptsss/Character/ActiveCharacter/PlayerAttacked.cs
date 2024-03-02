using System.Collections;
using UnityEngine;

public class PlayerAttacked :MonoBehaviour
{
    public GameObject AniAttacked;
    public void Attacked(int damage)
    {
        // Player.Instance.numberTxt.aniTextY(Player.Instance.currentName, Player.Instance.canvas, Player.Instance.currentName.transform, damage*(-1), new Vector3(0,1.2f,0), 1, 0.3f, Color.red);
        Player.Instance.PlayerEffect.TextGUI((int)damage*-1, Color.red);
        //StartCoroutine(aniAcctacked());
        if (Player.Instance.CurrHp < 0)
        {
          //CharacterController2D.Instance.Animator.SetBool("isDeath",true);
           Destroy(gameObject, 0.5f);
        }
        Player.Instance.PlayerEffect.UpdateHp(-damage);
    }
    IEnumerator aniAcctacked()
    {
        AniAttacked.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        AniAttacked.SetActive(false);
    }
}
