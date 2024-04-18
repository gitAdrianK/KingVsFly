using HarmonyLib;
using JumpKing;
using JumpKing.GameManager;
using JumpKing.Util;
using JumpKing.XnaWrappers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Reflection;

namespace KingVsFly.Patching
{
    public class GameLoopDraw
    {
        public static EndingState state;
        private static int duration;

        private static Texture2D pixel;
        private static SpriteBatch spriteBatch;

        private static OneShotSound land;
        private static JKSound flyswatter;

        private static SpriteFont font;
        private static string text;
        private static Vector2 textSize;

        public enum EndingState
        {
            Waiting,
            Blackscreen,
            Stats,
            Image,
            ToMenu,
        }

        public GameLoopDraw(Harmony harmony)
        {
            state = EndingState.Waiting;
            // Oh look, I'm tying stuff to the framerate again.
            duration = 60;
            pixel = new Texture2D(Game1.graphics.GraphicsDevice, 1, 1);
            pixel.SetData(new[] { Color.White });
            spriteBatch = Game1.spriteBatch;

            char sep = Path.DirectorySeparatorChar;
            string directory = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{sep}flyswatter";
            JKContentManager contentManager = Game1.instance.contentManager;

            flyswatter = new JKSound(contentManager.Load<SoundEffect>(directory), SoundType.SFX);
            land = contentManager.audio.player.Land;
            font = contentManager.font.MenuFont;


            var original = typeof(GameLoop).GetMethod(nameof(GameLoop.Draw));
            var patch = new HarmonyMethod(AccessTools.Method(typeof(GameLoopDraw), nameof(Draw)));
            harmony.Patch(
                original,
                postfix: patch
            );
        }

        ~GameLoopDraw()
        {
            pixel.Dispose();
        }

        public static void Draw(object __instance)
        {
            if (__instance == null || state == EndingState.Waiting)
            {
                return;
            }
            duration--;
            switch (state)
            {
                case EndingState.Blackscreen:
                    if (duration <= 0)
                    {
                        land.Play();
                        duration = 120;
                        state = EndingState.Stats;
                        if (ModEntry.isCheckpoint)
                        {
                            text = $"Checkpoint Resets: {ModEntry.entityCheckpoint.resets}";
                        }
                        else
                        {
                            text = "No checkpoints used.";
                        }
                        textSize = font.MeasureString(text);
                    }
                    spriteBatch.Draw(pixel, new Rectangle(0, 0, Game1.WIDTH, Game1.HEIGHT), Color.Black);
                    break;
                case EndingState.Stats:
                    if (duration <= 0)
                    {
                        duration = 60;
                        flyswatter.Play();
                        state = EndingState.Image;
                    }
                    spriteBatch.Draw(pixel, new Rectangle(0, 0, Game1.WIDTH, Game1.HEIGHT), Color.Black);
                    TextHelper.DrawString(
                        Game1.instance.contentManager.font.MenuFont,
                        text,
                        new Vector2(
                            Game1.WIDTH / 2.0f - textSize.X / 2.0f,
                            Game1.HEIGHT / 2.0f - textSize.Y / 2.0f
                            ),
                        Color.White, Vector2.Zero, true
                    );
                    break;
                case EndingState.Image:
                    if (duration <= 0)
                    {
                        state = EndingState.ToMenu;
                    }
                    spriteBatch.Draw(pixel, new Rectangle(0, 0, Game1.WIDTH, Game1.HEIGHT), Color.Black);
                    // Image would go here
                    break;
                case EndingState.ToMenu:
                    state = EndingState.Waiting;
                    duration = 60;
                    var pauseManager = Traverse.Create(GameLoop.instance).Field("m_pause_manager").GetValue();
                    Traverse.Create(pauseManager).Field("_exit_to_menu").SetValue(true);
                    break;
            }
            return;
        }
    }
}
