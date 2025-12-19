using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] GameObject[] menuObject;

    public void OnClickMenu(int menuIndex)
    {
        //fixed buges and much better code:
        for (int i = 0; i < menuObject.Length; i++)
        {
            menuObject[i].SetActive(i == menuIndex && !menuObject[i].activeSelf);
        }
    }
}
