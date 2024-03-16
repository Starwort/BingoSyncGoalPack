// Copied with permission from https://github.com/Cypheriel/UnnamedTechMod/blob/main/Common/Systems/LocalizationILEdit.cs
using MonoMod.Cil;
using MonoMod.RuntimeDetour;
using System.Reflection;
using System;
using Terraria.Localization;
using Terraria.ModLoader;

namespace BingoSyncGoalPack.Localization {
    /// <summary>
    /// Refuse to call <see cref="LocalizationLoader.UpdateLocalizationFilesForMod"/> for this mod.
    /// This solves issues with tModLoader's autoformatting for hjson.
    /// </summary>
    internal class TMLGetOffMyLocale : ModSystem {
        private static ILHook? hook;

        public override void Load() {
            var methInfo = typeof(LocalizationLoader)
                .GetMethod(
                    "UpdateLocalizationFiles",
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Default
                ) ?? throw new InvalidOperationException("UpdateLocalizationFiles method not found.");

            Mod.Logger.Debug("tModLoader wouldn't keep its grubby little hands off of my poor locale files.");
            hook = new ILHook(methInfo, UpdateLocalizationFiles_ILEdit);
        }

        public override void Unload() {
            hook?.Dispose();
        }

        private static void UpdateLocalizationFiles_ILEdit(
            ILContext context
        ) {
            var methInfo = typeof(LocalizationLoader)
                .GetMethod(
                    "UpdateLocalizationFilesForMod",
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static
                ) ?? throw new InvalidOperationException("UpdateLocalizationFilesForMod method not found.");
            var methDelegate = methInfo
                .CreateDelegate<Action<Mod, string, GameCulture>>();

            var cursor = new ILCursor(context);
            cursor.GotoNext(MoveType.Before,
                instruction => instruction.MatchCall(methInfo)
            );
            cursor.Remove();
            cursor.EmitDelegate<Action<Mod, string, GameCulture>>((mod, arg1, arg2) =>
            {
                if (mod is BingoSyncGoalPack)
                    return;
                methDelegate.Invoke(mod, arg1, arg2);
            });
        }
    }
}
