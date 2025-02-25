using UnityEngine;
using UnityEngine.UI;

public class ButtonGroupManager : MonoBehaviour
{
    private Color32 selectedColor = new Color32( 16 , 176 , 0 , 255 );
    private Color32 unselectedColor = new Color32( 255 , 255 , 255 , 255 );

    [System.Serializable]
    
    public class ButtonGroup
    {
        public Button[] buttons;
        public Button activeButton;
    }

    public ButtonGroup[] buttonGroups;

    void Start()
    {
        foreach (var group in buttonGroups)
        {
            foreach (Button btn in group.buttons)
            {
                btn.onClick.AddListener(() => OnButtonClicked(group, btn));
            }
        }
    }

    void OnButtonClicked(ButtonGroup group, Button clickedButton)
    {
        if (group.activeButton != null)
        {
            ResetButtonVisuals(group.activeButton);
        }

        group.activeButton = clickedButton;
        SetButtonLit(clickedButton);
    }

    void SetButtonLit(Button btn)
    {
        ColorBlock cb = btn.colors;
        cb.normalColor = selectedColor;
        btn.colors = cb;
    }

    void ResetButtonVisuals(Button btn)
    {
        ColorBlock cb = btn.colors;
        cb.normalColor = unselectedColor;
        btn.colors = cb;
    }

    public void StartBattleGo()
    {
        GameManager.Instance.LoadBattle();
    }
}