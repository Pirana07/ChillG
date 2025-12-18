using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    int i = 0;
    bool isItActive;
    [SerializeField] GameObject[] menuObject;

    public void OnClickMenu(int menuIndex)
    {
        // 1 or 0 and turns on or off menu with index 
        i++;
        
        if(i == 1 && isItActive == false)
            isItActive = true;
        else if(i == 2 && isItActive == true || isItActive == true)
            isItActive = false;
        else{
            i = 0;
            isItActive = true;
        }
    
        menuObject[menuIndex].SetActive(isItActive);
        // Debug.Log(i);
    }
}
