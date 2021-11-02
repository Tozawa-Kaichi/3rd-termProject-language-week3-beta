using UnityEngine;

/// <summary>
/// アイテムのベースクラス
/// </summary>
[RequireComponent(typeof(Collider2D))]
public abstract class ItemBase : MonoBehaviour
{
    [SerializeField] AudioClip _audioClip = default;

    /// <summary>
    /// アイテムの効果を発揮する
    /// </summary>
    public abstract void Activate();

    void OnTriggerEnter2D(Collider2D collision)
    {
        // プレイヤーに衝突したら効果音を鳴らし、アイテムの効果を発動して破棄する
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(_audioClip, Camera.main.transform.position);
            this.Activate();
            Destroy(this.gameObject);
        }
    }
}
