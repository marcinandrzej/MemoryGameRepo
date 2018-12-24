using UnityEngine;

public class IFirstClickState : IGameStates
{
    private GameManagerScriptGM gM;
    private GuiScriptGM gui;
    private SoundManagerScriptGM sM;

    public void ExecuteState(GameObject button, int x, int y)
    {
        gM.SetFirstClicked(button, gM.GetTableValue(x, y));
        gui.Reveal(button, gM.GetTableValue(x, y));
        sM.PlaySound(Sounds.BUTTON_SOUND);
        gM.ChangeState(new ISecondClickState());
    }

    public void OnStateEnter(GameObject gO)
    {
        gM = gO.GetComponent<GameManagerScriptGM>();
        gui = gO.GetComponent<GuiScriptGM>();
        sM = gO.GetComponent<SoundManagerScriptGM>();
    }
}
