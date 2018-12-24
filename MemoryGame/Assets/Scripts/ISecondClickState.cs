using UnityEngine;

public class ISecondClickState : IGameStates
{
    private GameManagerScriptGM gM;
    private GuiScriptGM gui;
    private SoundManagerScriptGM sM;

    public void ExecuteState(GameObject button, int x, int y)
    {
        if (!button.Equals(gM.GetFirstClicked()))
        {
            gM.SetSecondClicked(button, gM.GetTableValue(x, y));
            gui.Reveal(button, gM.GetTableValue(x, y));
            sM.PlaySound(Sounds.BUTTON_SOUND);
            gM.ChangeState(new IThirdState());
        }
    }

    public void OnStateEnter(GameObject gO)
    {
        gM = gO.GetComponent<GameManagerScriptGM>();
        gui = gO.GetComponent<GuiScriptGM>();
        sM = gO.GetComponent<SoundManagerScriptGM>();
    }
}

