using BingoBoardCore.Common;
using System.Collections.Generic;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using BingoBoardCore.AnimationHelpers;
using BingoBoardCore.Trackers;
using Terraria.GameContent.Achievements;
using BingoBoardCore.Icons;

namespace BingoSyncGoalPack.Content.Goals {
    public class GetGolfTrophy : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(
            ItemID.GolfTrophyBronze,
            ItemID.GolfTrophySilver,
            ItemID.GolfTrophyGold
        );
        public override int difficultyTier => 19;

        class Tracker : PlayerTracker {// todo: create ObtainItemTracker
            internal static Goal? goal = null;
        }

        public override void onGameStart(Player player) {
            Tracker.goal = this;
        }

        public override void onGameEnd(Player player) {
            Tracker.goal = null;
        }
    }
    public class Complete3FishingQuests : Goal {
        public override Item icon => VanillaIcons.Achievement.TroutMonkey;
        public override int difficultyTier => 19;
        public override IList<string> synergyTypes => ["ME.11"];
        public override string modifierText => "3";
        public override string? progressTextFor(Player player) => player.GetModPlayer<Tracker>().progressText();

        class Tracker : PlayerTracker {
            internal Goal? goal = null;
            internal int completeQuests = 0;
            internal string? progressText() => goal is null ? null : translate(
                "ProgressText.GenericCounter",
                completeQuests.ToString()
            );
            public void onFishingQuestComplete() {
                if (goal is null) {
                    return;
                }
                completeQuests++;
                if (completeQuests >= 3) {
                    goal.trigger(Player);
                    goal = null;
                } else {
                    goal.reportProgress(Player,completeQuests.ToString());
                }
            }
        }

        class Detour : TrackerSystem {
            public override void Load() {
                On_AchievementsHelper.HandleAnglerService += onFishingQuestComplete;
            }
            private void onFishingQuestComplete(On_AchievementsHelper.orig_HandleAnglerService orig) {
                Main.LocalPlayer.GetModPlayer<Tracker>().onFishingQuestComplete();
                orig();
            }
        }

        public override void onGameStart(Player player) {
            var tracker = player.GetModPlayer<Tracker>();
            tracker.goal = this;
            tracker.completeQuests = 0;
        }

        public override void onGameEnd(Player player) {
            player.GetModPlayer<Tracker>().goal = null;
        }
    }

    public class Obtain3Flails : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.Flails);
        public override int difficultyTier => 19;
        public override string modifierText => "3";

        class Tracker : PlayerTracker {// todo: create ObtainItemTracker
            internal Goal? goal = null;
            internal HashSet<int> obtainedFlails = [];
        }

        public override void onGameStart(Player player) {
            var tracker = player.GetModPlayer<Tracker>();
            tracker.goal = this;
            tracker.obtainedFlails.Clear();
        }

        public override void onGameEnd(Player player) {
            player.GetModPlayer<Tracker>().goal = null;
        }
    }

    public class CapSpawnsWithBees : Goal {
        public override Item icon => new(ItemID.BeeHive);
        public override int difficultyTier => 19;
        public override string modifierText => "30";

        class Tracker : PlayerTracker {// todo: create ObtainItemTracker
            internal Goal? goal = null;
            internal int obtainedBeeHives = 0;
        }

        public override void onGameStart(Player player) {
            var tracker = player.GetModPlayer<Tracker>();
            tracker.goal = this;
            tracker.obtainedBeeHives = 0;
        }

        public override void onGameEnd(Player player) {
            player.GetModPlayer<Tracker>().goal = null;
        }
    }

    public class MakePotions_DifficultyReduce : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(
            ItemID.FeatherfallPotion,
            ItemID.CalmingPotion
        );
        public override int difficultyTier => 19;

        class Tracker : PlayerTracker {// todo: create ObtainItemTracker
            internal Goal? goal = null;
            internal HashSet<int> obtainedPotions = [];
        }

        public override void onGameStart(Player player) {
            var tracker = player.GetModPlayer<Tracker>();
            tracker.goal = this;
            tracker.obtainedPotions.Clear();
        }

        public override void onGameEnd(Player player) {
            player.GetModPlayer<Tracker>().goal = null;
        }
    }

    public class MakePotions_Return : Goal {
        public override Item icon => new(ItemID.PotionOfReturn);
        public override int difficultyTier => 19;

        class Tracker : PlayerTracker {// todo: create ObtainItemTracker
            internal Goal? goal = null;
        }

        public override void onGameStart(Player player) {
            player.GetModPlayer<Tracker>().goal = this;
        }

        public override void onGameEnd(Player player) {
            player.GetModPlayer<Tracker>().goal = null;
        }
    }

    public class MakePotions_BuilderEndurance : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(
            ItemID.BuilderPotion,
            ItemID.EndurancePotion
        );
        public override int difficultyTier => 19;

        class Tracker : PlayerTracker {// todo: create ObtainItemTracker
            internal Goal? goal = null;
            internal HashSet<int> obtainedPotions = [];
        }

        public override void onGameStart(Player player) {
            var tracker = player.GetModPlayer<Tracker>();
            tracker.goal = this;
            tracker.obtainedPotions.Clear();
        }

        public override void onGameEnd(Player player) {
            player.GetModPlayer<Tracker>().goal = null;
        }
    }

    public class MakePotions_Shark : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(
            ItemID.GillsPotion,
            ItemID.HunterPotion
        );
        public override int difficultyTier => 19;

        class Tracker : PlayerTracker {// todo: create ObtainItemTracker
            internal Goal? goal = null;
            internal HashSet<int> obtainedPotions = [];
        }

        public override void onGameStart(Player player) {
            var tracker = player.GetModPlayer<Tracker>();
            tracker.goal = this;
            tracker.obtainedPotions.Clear();
        }

        public override void onGameEnd(Player player) {
            player.GetModPlayer<Tracker>().goal = null;
        }
    }
}