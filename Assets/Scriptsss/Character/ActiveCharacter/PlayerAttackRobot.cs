using QuachDai.NinjaSchool.Character;
using QuachDai.NinjaSchool.Monsters;
using Unity.Collections;
using UnityEngine;

public class PlayerAttackRobot : MonoBehaviour
{
    [SerializeField] SkillAnimation skillAnimation;
    [SerializeField] PlayerSkill playerSkill;
    [SerializeField] float radiusAttack = 4f;
    [SerializeField] LayerMask target;
    [SerializeField, ReadOnly] Robot robot;
    float distance;
    Player player => Player.Instance;
    PlayerController2D playerController2D => PlayerController2D.Instance;
    private void Update()
    {
        if (GameManager.Instance.IsPlayGame == false) return;
        if (playerController2D.IsGround() == false) return;
        FindPlayer();
        if (robot != null)
        {
            distance = Vector2.Distance(transform.position, robot.transform.position);
            if (playerController2D.getInputSpace())
            {
                if (distance > 6)
                    TextTemplate.Instance.SetText(TagScript.khoangCach);
                else if (playerSkill.GetIDSkill() == IDSkill.SkillLv5)
                    TextTemplate.Instance.SetText(TagScript.useSkill);
                else if (playerSkill.IsActtack())
                    PlayerAttackRobots();
            }
        }
    }
    public void PlayerAttackRobots()
    {
        playerSkill.SkillAttack(Damgaed, null);
    }
    public void Damgaed()
    {
        float damage = player.GetDamage() + playerSkill.GetSkillDamage();
        robot.SetHp(-damage);
    }
    RaycastHit2D[] hits;

    public void FindPlayer()
    {
        hits = Physics2D.CircleCastAll(transform.position, radiusAttack, Vector2.zero, 0.0f, target);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.CompareTag("Robot"))
            {
                robot = hit.collider.GetComponent<Robot>();
                skillAnimation.spritePosMonster = robot.spriteRobotAttacked;
                return;
            }
        }
        robot = null;
    }
}
