using UnityEngine;

/// <summary>
/// ブロックを生成するコンポーネント
/// </summary>
public class BlockGenerator : MonoBehaviour
{
    /// <summary>生成するブロックのプレハブ</summary>
    [SerializeField] GameObject[] _blockPrefabs = default;
    /// <summary>ブロック生成間隔（秒）</summary>
    [SerializeField] float _generateInterval = 2f;
    float _timer = 0f;

    void Start()
    {
        _timer = _generateInterval;
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _generateInterval)
        {
            _timer = 0;
            // ランダムなブロックのプレハブを生成し、画面外に移動する
            int i = Random.Range(0, _blockPrefabs.Length);
            var go = Instantiate(_blockPrefabs[i], _blockPrefabs[i].transform.position, _blockPrefabs[i].transform.rotation);
            Vector2 pos = go.transform.position;
            pos.x = 20f;
            go.transform.position = pos;
        }
    }
}
