using UnityEngine;


[CreateAssetMenu(fileName = "Coin", menuName = "Coin", order = 0)]
public class Coin : ScriptableObject {

    public new string name;
    public string desc;

    public Sprite artWork;

    public int Income;
    public int Cost;
    

}
