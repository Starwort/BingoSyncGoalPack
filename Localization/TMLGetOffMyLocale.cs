// based on code from https://github.com/JavidPack/SummonersAssociation/blob/1.4/Items/MinionControlRod.cs
using System.Reflection;
using System;
using Terraria.Localization;
using Terraria.ModLoader;
using MonoMod.RuntimeDetour;

namespace BingoSyncGoalPack.Localization {
    /// <summary>
    /// Refuse to call <see cref="LocalizationLoader.UpdateLocalizationFilesForMod"/> for this mod.
    /// This solves issues with tModLoader's autoformatting for hjson.
    /// </summary>
    internal class TMLGetOffMyLocale : ModSystem {
        internal delegate void orig_UpdateLocalizationFilesForMod(Mod mod, string? outputPath = null, GameCulture? specificCulture = null);
        internal delegate void hook_UpdateLocalizationFilesForMod(orig_UpdateLocalizationFilesForMod orig, Mod mod, string? outputPath = null, GameCulture? specificCulture = null);

        // private static void UpdateLocalizationFilesForMod(Mod mod, string outputPath = null, GameCulture specificCulture = null)
        private static readonly MethodInfo m_UpdateLocalizationFiles = typeof(LocalizationLoader).GetMethod(
            "UpdateLocalizationFilesForMod",
            BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Default
        ) ?? throw new InvalidOperationException("UpdateLocalizationFilesForMod method not found.");

        private static Hook? hook;

        public override void Load() {
            try {
                hook = new Hook(m_UpdateLocalizationFiles, new hook_UpdateLocalizationFilesForMod(noRuiningMyFiles));
            } catch {
                Mod.Logger.Error($"Failed to hook UpdateLocalizationFilesForMod!");
            }
        }

        private void noRuiningMyFiles(orig_UpdateLocalizationFilesForMod orig, Mod mod, string? outputPath, GameCulture? specificCulture) {
            if (mod is not BingoSyncGoalPack) {
                orig(mod, outputPath, specificCulture);
            }
        }

        public override void Unload() {
            hook?.Dispose();
        }
    }
}
