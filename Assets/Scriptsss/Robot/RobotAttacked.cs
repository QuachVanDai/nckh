using QuachDai.NinjaSchool.Character;
using UnityEngine;

public class RobotAttacked : MonoBehaviour
{
    Robot Robot=>GetComponent<Robot>();
    [SerializeField] Animator animator;
    void Update()
    {
        if(Robot.GetHp()<=0 && !Robot.IsDeath)
        {
            Robot.IsDeath = true;
            animator.SetBool("IsDeath", true);
        }
    }
}
