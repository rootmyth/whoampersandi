using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using whoampersandi.Interfaces;
using whoampersandi.User;
using whoampersandi.Visuals;
using whoampersandi.OuterWorld;
using whoampersandi.InnerWorld;
using whoampersandi.State;

namespace whoampersandi.Events.Repository
{
    internal class NewGame : IEvent
    {
        private Renderer Display = new();
        private Dialogue Text = new();
        private TextInput NameInput = new();
        private Notification Notify = new();
        public string EventName { get; } = "NewGame";
        public void EventSequence(IArea area, Player player, Dictionary<IEntity, (int, int)> entities, Dictionary<IObject, (int, int)> objects, OuterWorldMap outerWorld, InnerWorldMap innerWorld, EventState state)
        {
            string GS = "Good Samaritan";

            Display.RenderLevelBar(true);
            Display.RenderWorldViewer();
            Display.RenderStatusBar(true);

            Display.RenderDialogueBox(Text.CreateDialogueBoxText("Hello?", 60, 5));
            Display.RenderDialogueBox(Text.CreateDialogueBoxText("Hey!", 60, 5));
            Display.RenderDialogueBox(Text.CreateDialogueBoxText("Are you okay?", 60, 5));

            Display.RenderLevelBar(player, area);
            Display.RenderWorldViewer(player, entities, objects, area);
            Display.RenderStatusBar(player);

            Display.RenderDialogueBox(Text.CreateDialogueBoxText($"{GS}: You look pretty beat up, what happened?", 60, 5));
            Display.RenderDialogueBox(Text.CreateDialogueBoxText($"{GS}: Not totally sure, huh?  Well I can tell you that I was crossing the bridge on the other side of this pen and I heard people shouting and a pig squealing.  Either one of these pigs got the best of you, or some other ill-intentioned character was about.", 60, 5));
            NameInput.CreateUserStringInput(GS, "What's your name, anyway?", "Please type a name 1-16 letters long, then hit enter", 16);
            player.Name = NameInput.UsersEnteredInput;
            Display.RenderDialogueBox(Text.CreateDialogueBoxText($"{GS}: Well ~, sorry to find you in such circumstances. I am travelling from BOGOSORTON to the thriving markets around the castle in the northeast. I've collected many furs this season and I'm trying to sell off my excess to make a little money and feed my family. You've been to the castle before haven't you? In any case, I'm going to rest here for a few more minutes before I take off. You take care of yourself. I've been hearing more talk of crime and malicious deeds than ever before. If you travel alone, stay vigilant!", 60, 5, player));
            Display.RenderDialogueBox();
            Notify.RenderNotification(Text.CreateDialogueBoxText("Use the W, D, S, and A keys to move around.", 32, 8));

            state.newGame = false;
        }
    }
}
