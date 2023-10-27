using BingoGoalPackBingoSyncGoals.Icons;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BingoBoardCore.Common.Systems;
using Terraria.GameContent;
using System;

namespace BingoGoalPackBingoSyncGoals.Content {
    internal class RegisterGoals : ModSystem {
        static Item die => BingoBoardCore.BingoBoardCore.dieIcon;
        static Item disallow => BingoBoardCore.BingoBoardCore.disallowIcon;
        static readonly Item craft = new(ItemID.WorkBench);

        Item tileGoalsIcon = new(ItemID.DirtBlock);
        int[] tiles = new int[] {ItemID.DirtBlock};

        Item spearGoalIcon = new(ItemID.Spear);
        int[] spears = new int[] {ItemID.Spear};

        Item accessoryGoalsIcon = new(ItemID.Shackle);
        int[] accessories = new int[] {ItemID.Shackle};

        Item woodToolsGoalIcon = new(ItemID.WoodenSword);
        int[] woodTools = new int[] {ItemID.WoodenSword, ItemID.WoodenBow, ItemID.WoodenHammer};

        Item phmCampfiresGoalIcon = new(ItemID.Campfire);
        int[] phmCampfires = new int[] {
            ItemID.Campfire, ItemID.CoralCampfire, ItemID.CorruptCampfire,
            ItemID.CrimsonCampfire, ItemID.DemonCampfire, ItemID.DesertCampfire,
            ItemID.FrozenCampfire, ItemID.JungleCampfire, ItemID.MushroomCampfire
        };

        Item questGoalsIcon = new(ItemID.AmanitaFungifin);
        int[] questFish = new int[] {ItemID.AmanitaFungifin};

        Item herbsGoalIcon = new(ItemID.Daybloom);
        int[] herbs = new int[] {
            ItemID.Blinkroot, ItemID.Daybloom, ItemID.Deathweed,
            ItemID.Fireblossom, ItemID.Moonglow, ItemID.Shiverthorn,
            ItemID.Waterleaf
        };

        Item lowTierBarsGoalIcon = new(ItemID.CopperBar);
        int[] lowTierBars = new int[] {
            // Tier 1
            ItemID.CopperBar, ItemID.TinBar,
            // Tier 2
            ItemID.IronBar, ItemID.LeadBar,
            // Tier 3
            ItemID.SilverBar, ItemID.TungstenBar,
            // Tier 4
            ItemID.GoldBar, ItemID.PlatinumBar,
        };

        Item dungeonIcon = new(ItemID.BlueBrick);
        int[] dungeonBricks = new int[] {ItemID.BlueBrick, ItemID.GreenBrick, ItemID.PinkBrick};

        Item cactusArmourGoalIcon = new(ItemID.CactusHelmet);
        int[] cactusArmour = new int[] {ItemID.CactusHelmet, ItemID.CactusBreastplate, ItemID.CactusLeggings};

        Item gemTreeGoalIcon = new(ItemID.GemTreeAmberSeed);
        int[] gemcorns = new int[] {
            ItemID.GemTreeAmberSeed, ItemID.GemTreeAmethystSeed, ItemID.GemTreeDiamondSeed,
            ItemID.GemTreeEmeraldSeed, ItemID.GemTreeRubySeed, ItemID.GemTreeSapphireSeed,
            ItemID.GemTreeTopazSeed,
        };

        Item anyBarIcon = new(ItemID.CopperBar);
        int[] bars = new int[23] {
            // Tier 1
            ItemID.CopperBar, ItemID.TinBar,
            // Tier 2
            ItemID.IronBar, ItemID.LeadBar,
            // Tier 3
            ItemID.SilverBar, ItemID.TungstenBar,
            // Tier 4
            ItemID.GoldBar, ItemID.PlatinumBar,
            // Tier 5
            ItemID.MeteoriteBar,
            // Tier 6
            ItemID.DemoniteBar, ItemID.CrimtaneBar,
            // Tier 7
            ItemID.HellstoneBar,
            // Tier 8
            ItemID.CobaltBar, ItemID.PalladiumBar,
            // Tier 9
            ItemID.MythrilBar, ItemID.OrichalcumBar,
            // Tier 10
            ItemID.AdamantiteBar, ItemID.TitaniumBar,
            // Tier 11
            ItemID.HallowedBar,
            // Tier 12
            ItemID.ChlorophyteBar,
            // Tier 13
            ItemID.ShroomiteBar, ItemID.SpectreBar,
            // Tier 14
            ItemID.LunarBar,
        };

        private AnimatedIcon[] animatedIcons = Array.Empty<AnimatedIcon>();
        private (Item, int[])[] seqAnimations = Array.Empty<(Item, int[])>();
        private (Item, int[])[] randAnimations = Array.Empty<(Item, int[])>();

        internal void loadItemAnimations() {
            tiles = ContentSamples.ItemsByType.Where(val => val.Value.createTile != -1).Select(val => val.Key).ToArray();
            tileGoalsIcon.type = tiles[0];

            spears = ItemID.Sets.Spears.Select((isSpear, id) => new { isSpear, id }).Where(val => val.isSpear).Select(val => val.id).ToArray();
            spearGoalIcon.type = spears[0];

            accessories = ContentSamples.ItemsByType.Where(val => val.Value.accessory).Select(val => val.Key).ToArray();
            accessoryGoalsIcon.type = accessories[0];

            questFish = ContentSamples.ItemsByType.Where(val => val.Value.questItem).Select(val => val.Key).ToArray();
            questGoalsIcon.type = questFish[0];

            animatedIcons = new AnimatedIcon[] {ModContent.GetInstance<AnyBuff>(), ModContent.GetInstance<AnyDebuff>()};
            seqAnimations = new[] {
                (cactusArmourGoalIcon, cactusArmour),
                (dungeonIcon, dungeonBricks),
                (herbsGoalIcon, herbs),
                (lowTierBarsGoalIcon, lowTierBars),
                (woodToolsGoalIcon, woodTools),
            };
            randAnimations = new[] {
                (accessoryGoalsIcon, accessories),
                (anyBarIcon, bars),
                (gemTreeGoalIcon, gemcorns),
                (phmCampfiresGoalIcon, phmCampfires),
                (questGoalsIcon, questFish),
                (spearGoalIcon, spears),
                (tileGoalsIcon, tiles),
            };
        }

        private Random rng = new();

        public override void PreUpdateItems() {
            if (Main.GameUpdateCount % animationPeriod == 0) {
                var frame = Main.GameUpdateCount / animationPeriod;
                foreach ((Item icon, int[] frames) in seqAnimations) {
                    icon.type = frames[frame % frames.Length];
                }
                foreach ((Item icon, int[] frames) in randAnimations) {
                    icon.type = frames[rng.Next(frames.Length)];
                }
                foreach (var animation in animatedIcons) {
                    animation.animate(frame);
                }
            }
        }

        internal void registerGoals() {
            register(
                "DownEoC",
                difficulty: 0,
                new Item(ItemID.EyeofCthulhuTrophy),
                new[] {"ME.5.1", "ME.5.2"}
            );
            register(
                "DownKS",
                difficulty: 0,
                new Item(ItemID.KingSlimeTrophy),
                new[] {"ME.3.1", "ME.3.2"}
            );
            register(
                "PutFoodOnPlate",
                difficulty: 0,
                new Item(ItemID.FoodPlatter)
            );
            register(
                "Get999OfTile",
                difficulty: 0,
                tileGoalsIcon,
                text: "999"
            );
            register(
                "FillPiggyBank",
                difficulty: 0,
                new Item(ItemID.PiggyBank)
            );
            register(
                "EatCookedFish",
                difficulty: 0,
                new Item(ItemID.CookedFish)
            );
            register(
                "Suffocate7s",
                difficulty: 0,
                ModContent.GetInstance<Suffocation>().Item,
                text: "7s"
            );
            register(
                "DieToThorns",
                difficulty: 0,
                ModContent.GetInstance<Thorns>().Item,
                modifier: die
            );

            register(
                "Get2Spears",
                difficulty: 1,
                spearGoalIcon,
                text: "2"
            );
            register(
                "Get2Plat",
                difficulty: 1,
                new Item(ItemID.PlatinumCoin),
                text: "2"
            );
            register(
                "DieToAltar",
                difficulty: 1,
                ModContent.GetInstance<Altars>().Item,
                modifier: die
            );
            register(
                "Equip5Accessories",
                difficulty: 1,
                accessoryGoalsIcon,
                text: "5",
                synergyTypes: new[] {"ME.15"}
            );
            register(
                "GetModifiedWoodSwordBowHammer",
                difficulty: 1,
                woodToolsGoalIcon,
                modifier: craft
            );
            register(
                "ExplodeVillagerEnemySelf",
                difficulty: 1,
                new Item(ItemID.ExplosiveBunny),
                modifier: die,
                text: "3"
            );
            register(
                "GetCookedMarshmallow",
                difficulty: 1,
                new Item(ItemID.CookedMarshmallow)
            );
            register(
                "NoChopTrees",
                difficulty: 1,
                new Item(ItemID.CopperAxe),
                modifier: disallow,
                shouldEnable: (mode, _) => mode != BingoMode.Lockout,
                synergyTypes: new[] {"ME.1"}
            );
            register(
                "OpponentChopTrees",
                difficulty: 1,
                new Item(ItemID.CopperAxe),
                modifier: disallow,
                shouldEnable: (mode, teams) => mode == BingoMode.Lockout && teams == 2,
                synergyTypes: new[] {"ME.1"}
            );

            register(
                "CompleteFishingQuest",
                difficulty: 2,
                questGoalsIcon,
                text: "1",
                synergyTypes: new[] {"ME.11"}
            );
            register(
                "Get3FrogLegs",
                difficulty: 2,
                new Item(ItemID.SauteedFrogLegs),
                text: "3"
            );
            register(
                "GetRockLobster",
                difficulty: 2,
                new Item(ItemID.RockLobster)
            );
            register(
                "PlaceAllSandcastles",
                difficulty: 2,
                new Item(ItemID.SandcastleBucket),
                text: "4"
            );
            register(
                "PlantAllHerbs",
                difficulty: 2,
                herbsGoalIcon,
                text: "7",
                modifier: new Item(ItemID.ClayPot)
            );
            register(
                "InvFullOfBlocks",
                difficulty: 2,
                tileGoalsIcon
            );
            register(
                "Have12Buffs",
                difficulty: 2,
                ModContent.GetInstance<AnyBuff>().Item,
                text: "12"
            );

            register(
                "KillAnglerWithBoulder",
                difficulty: 3,
                ModContent.GetInstance<Angler>().Item,
                modifier: new Item(ItemID.Boulder)
            );
            register(
                "Stack4BarsOnDungeon",
                difficulty: 3,
                lowTierBarsGoalIcon,
                modifier: dungeonIcon,
                text: "4"
            );
            register(
                "DrownWithBreathingReed",
                difficulty: 3,
                new Item(ItemID.BreathingReed),
                modifier: die
            );
            register(
                "WearCactusArmour",
                difficulty: 3,
                cactusArmourGoalIcon
            );
            register(
                "GrowGemTree",
                difficulty: 3,
                gemTreeGoalIcon
            );
            register(
                "TrashSharkBait",
                difficulty: 3,
                new Item(ItemID.SharkBait),
                modifier: new Item(ItemID.TrashCan)
            );
            register(
                "FillHouseWithBars",
                difficulty: 3,
                anyBarIcon,
                modifier: ModContent.GetInstance<House>().Item
            );
            register(
                "GetAllCampfires",
                difficulty: 3,
                phmCampfiresGoalIcon,
                text: "9"
            );
        }

        public override void PostSetupContent() {
            loadItemAnimations();
            registerGoals();
        }
    }
}
