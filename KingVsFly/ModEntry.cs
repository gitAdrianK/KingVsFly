using EntityComponent;
using HarmonyLib;
using JumpKing;
using JumpKing.Mods;
using JumpKing.PauseMenu;
using JumpKing.PauseMenu.BT.Actions;
using JumpKing.Player;
using JumpKing.SaveThread;
using KingVsFly.Entities;
using KingVsFly.Nodes;
using KingVsFly.Patching;
using System.Collections.Generic;

// Patching with Harmony was a crashfest for some reason,
// so for now its "workarounds".

namespace KingVsFly
{
    [JumpKingMod("Zebra.KingVsFly")]
    public static class ModEntry
    {
        public static bool isEnabled;
        public static bool isCheckpoint;

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

            List<Entity> toRemoveEntities = new List<Entity>();
            foreach (var entity in entityManager.Entities)
            {
                // Removing the majority of entities to give the feel of "After the events of Jump King".
                // Whatever that is supposed to mean :)
                // Making so many exceptions I might just go positive logic
                string type = entity.GetType().ToString();
                if ((type.Contains("Props") && !type.Contains("LoopingProp"))
                    || type.Contains("MiscEntities")
                    || type.Contains("MultiEnding")
                    || type.Contains("Rayman"))
                {
                    toRemoveEntities.Add(entity);
                }
            }
            foreach (var entity in toRemoveEntities)
            {
                entityManager.RemoveObject(entity);
            }

            entityFly = new EntityFly(entityPlayer);
            if (isCheckpoint)
            {
                entityCheckpoint = new EntityCheckpoint(entityPlayer);

                entityFly.entityCheckpoint = entityCheckpoint;
                entityCheckpoint.entityFly = entityFly;

                entityManager.AddObject(entityCheckpoint);
            }
            entityManager.AddObject(entityFly);
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

            SaveManager.instance?.StopSaving();
            SaveManager.instance?.AddTaskDeleteSaveFile();
        }
    }
}
