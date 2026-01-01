using UnityEngine;


[CreateAssetMenu(fileName = "Mans", menuName = "Mans", order = 0)]
public class Mans : ScriptableObject {

    [Header("Description")]
    public new string name;
    public string desc;
    public Sprite artWork;

    [Header("MoneyRelated")]
    public int Income;
    public int Cost;
    

}
