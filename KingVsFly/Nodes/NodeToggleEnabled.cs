using JumpKing.PauseMenu.BT.Actions;

namespace KingVsFly.Nodes
{
    public class NodeToggleEnabled : ITextToggle
    {
        public NodeToggleEnabled(bool p_start_value) : base(p_start_value)
        {
        }

        protected override string GetName()
        {
            return "Enabled";
        }

        protected override void OnToggle()
        {
            ModEntry.isEnabled = toggle;
        }
    }
}
