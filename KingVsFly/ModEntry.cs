using EntityComponent;
using HarmonyLib;
using JumpKing;
using JumpKing.Mods;
using JumpKing.PauseMenu;
using JumpKing.PauseMenu.BT.Actions;
using JumpKing.Player;
using JumpKing.SaveThread;
using KingVsFly.Entities;
using KingVsFly.Game;
using KingVsFly.Nodes;
using KingVsFly.Patching;
using System.Collections.Generic;
using static KingVsFly.Game.GameState;

// It's ugly :)
// I don't want to patch everything with Harmony, I'm lazy.

namespace KingVsFly
{
    [JumpKingMod("Zebra.KingVsFly")]
    public static class ModEntry
    {
        public static bool isEnabled;
        public static bool isCheckpoint;

        public static GameState gameState;
        public static EntityCheckpoint entityCheckpoint;
        public static EntityFly entityFly;

        public static Harmony harmony;
        public static GameLoopDraw gameLoopDraw;

        // DO NOT REMOVE object and GuiFormat even if they are unused!
        #region Menu Items
        [MainMenuItemSetting]
        public static ITextToggle AddToggleEnabled(object factory, GuiFormat format)
        {
            return new NodeToggleEnabled(isEnabled);
        }

        [MainMenuItemSetting]
        public static ITextToggle AddToggleCheckpoint(object factory, GuiFormat format)
        {
            return new NodeToggleCheckpoint(isCheckpoint);
        }
        #endregion

        [BeforeLevelLoad]
        public static void BeforeLevelLoad()
        {
            // Debugger.Launch();
            isEnabled = false;
            isCheckpoint = true;

            harmony = new Harmony("Zebra.KingVsFly");
            gameLoopDraw = new GameLoopDraw(harmony);
        }

        /// <summary>
        /// Called by Jump King when the Level Starts
        /// </summary>
        [OnLevelStart]
        public static void OnLevelStart()
        {
            if (!isEnabled)
            {
                return;
            }
            if (Game1.instance.contentManager.root != "Content")
            {
                return;
            }

            EntityManager entityManager = EntityManager.instance;

            PlayerEntity entityPlayer = entityManager.Find<PlayerEntity>();
            if (entityPlayer == null)
            {
                return;
            }

            if (EventFlagsSave.ContainsFlag(StoryEventFlags.StartedGhost))
            {
                gameState = new GameState(Map.GhostBabe);
            }
            else if (EventFlagsSave.ContainsFlag(StoryEventFlags.StartedNBP))
            {
                gameState = new GameState(Map.NewBabe);
            }
            else
            {
                gameState = new GameState(Map.MainBabe);
            }

            List<Entity> toRemoveEntities = new List<Entity>();
            foreach (var entity in entityManager.Entities)
            {
                // Removing the majority of entities to give the feel of "After the events of Jump King".
                // Whatever that is supposed to mean :)
                string type = entity.GetType().ToString();
                if ((type.Contains("Props") && !type.Contains("LoopingProp"))
                    || type.Contains("MiscEntities")
                    || type.Contains("MultiEnding"))
                {
                    toRemoveEntities.Add(entity);
                }
            }
            foreach (var entity in toRemoveEntities)
            {
                entityManager.RemoveObject(entity);
            }

            entityFly = new EntityFly(gameState, entityPlayer);
            entityManager.AddObject(entityFly);

            if (isCheckpoint)
            {
                entityCheckpoint = new EntityCheckpoint(gameState, entityPlayer);
                entityManager.AddObject(entityCheckpoint);
            }
        }

        /// <summary>
        /// Called by Jump King when the Level Ends
        /// </summary>
        [OnLevelEnd]
        public static void OnLevelEnd()
        {
            if (!isEnabled)
            {
                return;
            }

            EntityManager entityManager = EntityManager.instance;

            entityManager.RemoveObject(entityFly);
            entityManager.RemoveObject(entityCheckpoint);

            entityFly = null;
            entityCheckpoint = null;

            gameState = null;

            SaveManager.instance?.StopSaving();
            SaveManager.instance?.AddTaskDeleteSaveFile();
        }
    }
}
