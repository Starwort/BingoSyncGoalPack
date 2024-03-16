global using static BingoGoalPackBingoSyncGoals.BingoGoalPackBingoSyncGoals;
using BingoGoalPackBingoSyncGoals.MonitorHooks;
using System.Linq;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace BingoGoalPackBingoSyncGoals {
    public class BingoGoalPackBingoSyncGoals : Mod {
        public static string GithubUserName => "Starwort";
        public static string GithubProjectName => "BingoGoalPack-BingoSyncGoals";

        internal static string translate(string key, params string[] substitutions) {
            return Language.GetTextValue(
                "Mods.BingoGoalPackBingoSyncGoals." + key,
                substitutions.Select(
                    sub => Language.GetTextValue(sub)
                ).ToArray()
            );
        }

        public override void PostSetupContent() {
            BingoBoardCore.BingoBoardCore.onGameStart(() => {
                foreach (var player in Main.player) {
                    if (player.TryGetModPlayer(out PlayerHooks hooks)) {
                        hooks.onGameStart();
                    }
                }
            });
        }
    }
}