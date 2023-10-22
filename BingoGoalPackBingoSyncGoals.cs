global using static BingoGoalPackBingoSyncGoals.BingoGoalPackBingoSyncGoals;
using BingoBoardCore.Common.Systems;
using BingoGoalPackBingoSyncGoals.MonitorHooks;
using System;
using Terraria;
using Terraria.ModLoader;

namespace BingoGoalPackBingoSyncGoals {
    public class BingoGoalPackBingoSyncGoals : Mod {
        public static string GithubUserName => "Starwort";
        public static string GithubProjectName => "BingoGoalPack-BingoSyncGoals";

        public const int animationPeriod = 30;

        internal const string goalNamespace = "BingoSyncPack.";
        internal static void triggerGoal(string goal, Player player) {
            BingoBoardCore.BingoBoardCore.triggerGoal(goalNamespace + goal, player);
        }
        internal static void untriggerGoal(string goal, Player player) {
            BingoBoardCore.BingoBoardCore.untriggerGoal(goalNamespace + goal, player);
        }

        internal static void progress(string goal, params string[] substitutions) {
            BingoBoardCore.BingoBoardCore.reportProgress(goalNamespace + goal, "Mods.BingoGoalPackBingoSyncGoals.Progress." + goal, substitutions);
        }

        internal static void badProgress(string goal, params string[] substitutions) {
            BingoBoardCore.BingoBoardCore.reportBadProgress(goalNamespace + goal, "Mods.BingoGoalPackBingoSyncGoals.BadProgress." + goal, substitutions);
        }

        internal static void register(string goalId, int difficulty, Item icon, string[] synergyTypes = null!, Func<BingoMode, int, bool> shouldEnable = null!, string text = "", Item? modifier = null) {
            BingoBoardCore.BingoBoardCore.registerGoal(icon, "Mods.BingoGoalPackBingoSyncGoals." + goalId, goalNamespace + goalId, difficulty, synergyTypes ?? Array.Empty<string>(), shouldEnable, text, modifier);
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