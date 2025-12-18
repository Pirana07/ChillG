using UnityEngine;


[CreateAssetMenu(fileName = "Coin", menuName = "Coin", order = 0)]
public class Coin : ScriptableObject {

    [Header("Description")]
    public new string name;
    public string desc;
    public Sprite artWork;

    [Header("MoneyRelated")]
    public int Income;
    public int Cost;
    
    [Header("Rarity")]
    public string rarity;
    public string chances;

}
