using System.Collections;
using UnityEngine;

/// <summary>
/// プレイヤーを制御するコンポーネント
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class RunnerController : MonoBehaviour
{
    /// <summary>既定のジャンプ速度</summary>
    [SerializeField] float _defaultJumpSpeed = 3f;
    Rigidbody2D _rb = default;
    Animator _anim = default;
    /// <summary>現在のジャンプ速度</summary>
    float _jumpSpeed = 0f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _jumpSpeed = _defaultJumpSpeed;
    }

    void Update()
    {
        // ジャンプ処理
        if (Input.GetButtonDown("Jump"))
        {
            _rb.velocity = Vector2.up * _jumpSpeed;
            _anim.Play("Jump");
        }
    }

    /// <summary>
    /// ジャンプ力を変更する
    /// </summary>
    /// <param name="interval">ジャンプ力が変更されている期間（秒）</param>
    /// <param name="newJumpSpeed">この値にジャンプ力を変更する</param>
    public void ChangeJumpPower(float interval, float newJumpSpeed)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeJumpPowerRoutine(interval, newJumpSpeed));
    }

    IEnumerator ChangeJumpPowerRoutine(float interval, float newJumpSpeed)
    {
        _jumpSpeed = newJumpSpeed;
        yield return new WaitForSeconds(interval);
        _jumpSpeed = _defaultJumpSpeed;
    }
}
