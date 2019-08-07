using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float CoinSpawnHeight;
    public float CointFallHeight;
    public float CoinUpHeight;
    public float CoinSpeed;
    public GameObject SpawnCoin(Vector2 StartPos)
    {
        GameObject coin = Instantiate(Resources.Load("Perfab/cherry", typeof(GameObject))) as GameObject;
        coin.transform.SetParent(this.transform);
        coin.transform.position = new Vector2(StartPos.x, StartPos.y + CoinSpawnHeight);
        StartCoroutine(CoinBounce(coin,StartPos));
        return coin;
    }
    public IEnumerator CoinBounce(GameObject Coin, Vector2 StartPos)
    {
        while (true)
        {
            Coin.transform.position = new Vector2(Coin.transform.position.x, Coin.transform.position.y + Time.deltaTime * CoinSpeed);
            if (Coin.transform.position.y >= StartPos.y + CoinUpHeight + CoinSpawnHeight)
            {
                break;
            }
            yield return null;
        }
        while (true)
        {
            Coin.transform.position = new Vector3(StartPos.x, Coin.transform.position.y - Time.deltaTime * CoinSpeed);
            if (Coin.transform.position.y <= StartPos.y + CointFallHeight + CoinSpawnHeight)
            {
                Coin.transform.position = new Vector2(StartPos.x, StartPos.y + CoinSpawnHeight + CointFallHeight);
                break;
            }
            yield return null;
        }
    }
}
