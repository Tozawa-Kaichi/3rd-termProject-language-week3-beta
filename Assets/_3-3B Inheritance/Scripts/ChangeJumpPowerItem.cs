using UnityEngine;

/// <summary>
/// ジャンプ力を変更するコンポーネント
/// </summary>
public class ChangeJumpPowerItem : ItemBase
{
    [SerializeField] float _interval = 5f;
    [SerializeField] float _jumpPower = 22f;

    public override void Activate()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        if (player)
        {
            RunnerController rc = player.GetComponent<RunnerController>();

            if (rc)
            {
                rc.ChangeJumpPower(_interval, _jumpPower);
            }
        }
    }
}
