using UnityEngine;

/// <summary>
/// ブロックを移動するコンポーネント
/// </summary>
public class BlockController : MonoBehaviour
{
    [SerializeField] float _speed = 2f;

    void Update()
    {
        this.transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }
}
