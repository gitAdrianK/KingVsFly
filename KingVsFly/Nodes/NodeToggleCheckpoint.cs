using JumpKing.PauseMenu.BT.Actions;

namespace KingVsFly.Nodes
{
    public class NodeToggleCheckpoint : ITextToggle
    {
        public NodeToggleCheckpoint(bool p_start_value) : base(p_start_value)
        {
        }

        protected override string GetName()
        {
            return "Use Checkpoint";
        }

        protected override void OnToggle()
        {
            ModEntry.isCheckpoint = toggle;
        }
    }
}
