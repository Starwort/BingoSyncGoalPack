using BingoGoalPackBingoSyncGoals.Icons;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BingoBoardCore.Common.Systems;
using BingoBoardCore.AnimationHelpers;
using System;

namespace BingoGoalPackBingoSyncGoals.Content {
    internal class RegisterGoals : ModSystem {
        static Item die => BingoBoardCore.BingoBoardCore.dieIcon;
        static Item disallow => BingoBoardCore.BingoBoardCore.disallowIcon;
        static readonly Item craft = new(ItemID.WorkBench);

        internal void registerGoals() {
            var kill = new Item(ItemID.CopperShortsword);
            var mine = new Item(ItemID.CopperPickaxe);
            var trash = new Item(ItemID.TrashCan);
            var sell = BestiaryIcon.Bag;
            var swordOrSpear = IconAnimationSystem.registerRandAnimation(
                Sets.Swords.Concat(Sets.Spears).ToArray()
            );

            var tiles = IconAnimationSystem.registerRandAnimation(Sets.Tiles);
            var accessories = IconAnimationSystem.registerRandAnimation(Sets.Accessories);
            var evilBoss = IconAnimationSystem.registerCycleAnimation(ItemID.BrainofCthulhuTrophy, ItemID.EaterofWorldsTrophy);
            var questFish = IconAnimationSystem.registerRandAnimation(Sets.QuestFish);
            var platforms = IconAnimationSystem.registerRandAnimation(Sets.Platforms);

            Func<BingoMode, int, bool> notLockout = (mode, _) => mode != BingoMode.Lockout;
            Func<BingoMode, int, bool> twoLockout = (mode, teams) => mode == BingoMode.Lockout && teams == 2;
            Func<BingoMode, int, bool> anyLockout = (mode, _) => mode == BingoMode.Lockout;

            #region Difficulty 0 goals
            register(
                "DownEoC",
                difficulty: 0,
                new(ItemID.EyeofCthulhuTrophy),
                new[] {"ME.5.1", "ME.5.2"}
            );
            register(
                "DownKS",
                difficulty: 0,
                new(ItemID.KingSlimeTrophy),
                new[] {"ME.3.1", "ME.3.2"}
            );
            register(
                "PutFoodOnPlate",
                difficulty: 0,
                new(ItemID.FoodPlatter)
            );
            register(
                "Get999OfTile",
                difficulty: 0,
                tiles,
                text: "999"
            );
            register(
                "FillPiggyBank",
                difficulty: 0,
                new(ItemID.PiggyBank)
            );
            register(
                "EatCookedFish",
                difficulty: 0,
                new(ItemID.CookedFish)
            );
            register(
                "Suffocate7s",
                difficulty: 0,
                Buff.Suffocation,
                text: "7s"
            );
            register(
                "DieToThorns",
                difficulty: 0,
                ModContent.GetInstance<Thorns>().Item,
                modifier: die
            );
            #endregion

            #region Difficulty 1 goals
            register(
                "Get2Spears",
                difficulty: 1,
                IconAnimationSystem.registerRandAnimation(Sets.Spears),
                text: "2"
            );
            register(
                "Get2Plat",
                difficulty: 1,
                new(ItemID.PlatinumCoin),
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
                accessories,
                text: "5",
                synergyTypes: new[] {"ME.15"}
            );
            register(
                "GetModifiedWoodSwordBowHammer",
                difficulty: 1,
                IconAnimationSystem.registerCycleAnimation(ItemID.WoodenSword, ItemID.WoodenBow, ItemID.WoodenHammer),
                modifier: craft
            );
            register(
                "ExplodeVillagerEnemySelf",
                difficulty: 1,
                new(ItemID.ExplosiveBunny),
                modifier: die,
                text: "3"
            );
            register(
                "GetCookedMarshmallow",
                difficulty: 1,
                new(ItemID.CookedMarshmallow)
            );
            register(
                "NoChopTrees",
                difficulty: 1,
                AchievementIcon.Timber,
                modifier: disallow,
                shouldEnable: notLockout,
                synergyTypes: new[] {"ME.1"}
            );
            register(
                "OpponentChopTrees",
                difficulty: 1,
                AchievementIcon.Timber,
                modifier: disallow,
                shouldEnable: twoLockout,
                synergyTypes: new[] {"ME.1"}
            );
            #endregion

            #region Difficulty 2 goals
            register(
                "CompleteFishingQuest",
                difficulty: 2,
                questFish,
                text: "1",
                synergyTypes: new[] {"ME.11"}
            );
            register(
                "Get3FrogLegs",
                difficulty: 2,
                new(ItemID.SauteedFrogLegs),
                text: "3"
            );
            register(
                "GetRockLobster",
                difficulty: 2,
                new(ItemID.RockLobster)
            );
            register(
                "PlaceAllSandcastles",
                difficulty: 2,
                new(ItemID.SandcastleBucket),
                text: "4"
            );
            register(
                "PlantAllHerbs",
                difficulty: 2,
                IconAnimationSystem.registerRandAnimation(Sets.Herbs),
                text: "7",
                modifier: new Item(ItemID.ClayPot)
            );
            register(
                "InvFullOfBlocks",
                difficulty: 2,
                tiles
            );
            register(
                "Have12Buffs",
                difficulty: 2,
                Buff.Any,
                text: "12"
            );
            #endregion

            #region Difficulty 3 goals
            register(
                "KillAnglerWithBoulder",
                difficulty: 3,
                NPCIcon.Angler,
                modifier: new Item(ItemID.Boulder)
            );
            register(
                "Stack4BarsOnDungeon",
                difficulty: 3,
                IconAnimationSystem.registerRandAnimation(Sets.LowTierBars),
                modifier: BestiaryIcon.Dungeon,
                text: "4"
            );
            register(
                "DrownWithBreathingReed",
                difficulty: 3,
                new(ItemID.BreathingReed),
                modifier: die
            );
            register(
                "WearCactusArmour",
                difficulty: 3,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.CactusHelmet,
                    ItemID.CactusBreastplate,
                    ItemID.CactusLeggings
                )
            );
            ;
            register(
                "GrowGemTree",
                difficulty: 3,
                IconAnimationSystem.registerRandAnimation(
                    ItemID.GemTreeAmberSeed,
                    ItemID.GemTreeAmethystSeed,
                    ItemID.GemTreeDiamondSeed,
                    ItemID.GemTreeEmeraldSeed,
                    ItemID.GemTreeRubySeed,
                    ItemID.GemTreeSapphireSeed,
                    ItemID.GemTreeTopazSeed
                )
            );
            register(
                "TrashSharkBait",
                difficulty: 3,
                new(ItemID.SharkBait),
                modifier: trash
            );
            register(
                "FillHouseWithBars",
                difficulty: 3,
                IconAnimationSystem.registerRandAnimation(Sets.AnyBars),
                modifier: ModContent.GetInstance<House>().Item
            );
            register(
                "GetAllCampfires",
                difficulty: 3,
                IconAnimationSystem.registerRandAnimation(Sets.PreHardmodeCampfires),
                text: "9"
            );
            #endregion

            #region Difficulty 4 goals
            register(
                "DownEvilBoss",
                difficulty: 4,
                evilBoss,
                synergyTypes: new[] {"ME.4.1", "ME.4.2"}
            );
            register(
                "WearEvilArmour",
                difficulty: 4,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.CrimsonHelmet,
                    ItemID.CrimsonScalemail,
                    ItemID.CrimsonGreaves,
                    ItemID.ShadowHelmet,
                    ItemID.ShadowScalemail,
                    ItemID.ShadowGreaves
                ),
                synergyTypes: new[] {"ME.14"}
            );
            register(
                "KillEvilCritter",
                difficulty: 4,
                ModContent.GetInstance<EvilCritter>().Item,
                modifier: kill
            );
            register(
                "Sell100Hellstone",
                difficulty: 4,
                new(ItemID.Hellstone),
                modifier: sell,
                text: "100"
            );
            register(
                "SellFlamingMace",
                difficulty: 4,
                new(ItemID.FlamingMace),
                modifier: sell
            );
            #endregion

            #region Difficulty 5 goals
            register(
                "BreakLivingTreeLeaves",
                difficulty: 5,
                ModContent.GetInstance<LivingLeaf>().Item,
                modifier: mine
            );
            register(
                "EatGrubSoup",
                difficulty: 5,
                new(ItemID.GrubSoup)
            );
            register(
                "Get4CritterContainers",
                difficulty: 5,
                IconAnimationSystem.registerRandAnimation(Sets.CritterCages),
                text: "4"
            );
            register(
                "GetLemonadeOrAppleJuice",
                difficulty: 5,
                IconAnimationSystem.registerCycleAnimation(ItemID.Lemonade, ItemID.AppleJuice),
                modifier: craft
            );
            register(
                "WearVanityWinnerSet",
                difficulty: 5,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.PlaguebringerHelmet,
                    ItemID.PlaguebringerChestplate,
                    ItemID.PlaguebringerGreaves,
                    ItemID.RoninHat,
                    ItemID.RoninShirt,
                    ItemID.RoninPants,
                    ItemID.TimelessTravelerHood,
                    ItemID.TimelessTravelerRobe,
                    ItemID.TimelessTravelerBottom,
                    ItemID.FloretProtectorHelmet,
                    ItemID.FloretProtectorChestplate,
                    ItemID.FloretProtectorLegs,
                    ItemID.CapricornMask,
                    ItemID.CapricornChestplate,
                    ItemID.CapricornLegs,
                    ItemID.CapricornTail,
                    ItemID.TVHeadMask,
                    ItemID.TVHeadSuit,
                    ItemID.TVHeadPants
                )
            );
            register(
                "Get4Shrooms",
                difficulty: 5,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.GlowingMushroom,
                    ItemID.GreenMushroom,
                    ItemID.Mushroom,
                    ItemID.StrangeGlowingMushroom,
                    ItemID.TealMushroom,
                    ItemID.ViciousMushroom,
                    ItemID.VileMushroom
                ),
                text: "4"
            );
            register(
                "Get3Watches",
                difficulty: 5,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.CopperWatch,
                    ItemID.TinWatch,
                    ItemID.SilverWatch,
                    ItemID.TungstenWatch,
                    ItemID.GoldWatch,
                    ItemID.PlatinumWatch
                ),
                text: "3"
            );
            register(
                "GetTrash",
                difficulty: 5,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.FishingSeaweed,
                    ItemID.OldShoe,
                    ItemID.TinCan
                ),
                text: "3"
            );
            #endregion

            #region Difficulty 6 goals
            register(
                "MakePotions.Magic",
                difficulty: 6,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.MagicPowerPotion,
                    ItemID.ManaRegenerationPotion
                ),
                modifier: craft
            );
            register(
                "MakePotions.Explore",
                difficulty: 6,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.MiningPotion,
                    ItemID.ShinePotion,
                    ItemID.NightOwlPotion
                ),
                modifier: craft
            );
            register(
                "MakePotions.Water",
                difficulty: 6,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.WaterWalkingPotion,
                    ItemID.FlipperPotion
                ),
                modifier: craft
            );
            register(
                "MakePotions.Trans",
                difficulty: 6,
                new(ItemID.GenderChangePotion),
                modifier: craft
            );
            register(
                "FindBiome.SurfaceMushroom",
                difficulty: 6,
                BestiaryIcon.Mushroom
            );
            register(
                "FindBiome.EvilOcean",
                difficulty: 6,
                IconAnimationSystem.registerCycleAnimation(
                    BestiaryIcon.Corrupt.type,
                    BestiaryIcon.Crimson.type
                ),
                modifier: BestiaryIcon.Ocean
            );
            register(
                "FindBiome.EvilDesert",
                difficulty: 6,
                IconAnimationSystem.registerCycleAnimation(
                    BestiaryIcon.CorruptDesert.type,
                    BestiaryIcon.CrimsonDesert.type
                )
            );
            register(
                "MakePotions.Titan",
                difficulty: 6,
                new(ItemID.TitanPotion),
                modifier: craft
            );
            #endregion

            #region Difficulty 7 goals
            register(
                "DeadMenTellNoTales",
                difficulty: 7,
                AchievementIcon.DeadMenTellNoTales,
                synergyTypes: new[] {"ME.9"}
            );
            register(
                "Get5WoodArmour",
                difficulty: 7,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.WoodHelmet,
                    ItemID.WoodBreastplate,
                    ItemID.WoodGreaves,
                    ItemID.RichMahoganyHelmet,
                    ItemID.RichMahoganyBreastplate,
                    ItemID.RichMahoganyGreaves,
                    ItemID.EbonwoodHelmet,
                    ItemID.EbonwoodBreastplate,
                    ItemID.EbonwoodGreaves,
                    ItemID.ShadewoodHelmet,
                    ItemID.ShadewoodBreastplate,
                    ItemID.ShadewoodGreaves,
                    ItemID.PearlwoodHelmet,
                    ItemID.PearlwoodBreastplate,
                    ItemID.PearlwoodGreaves,
                    ItemID.BorealWoodHelmet,
                    ItemID.BorealWoodBreastplate,
                    ItemID.BorealWoodGreaves,
                    ItemID.PalmWoodHelmet,
                    ItemID.PalmWoodBreastplate,
                    ItemID.PalmWoodGreaves,
                    ItemID.AshWoodHelmet,
                    ItemID.AshWoodBreastplate,
                    ItemID.AshWoodGreaves,
                    ItemID.SpookyHelmet,
                    ItemID.SpookyBreastplate,
                    ItemID.SpookyLeggings
                ),
                text: "5",
                synergyTypes: new[] {"ME.14"}
            );
            register(
                "WearPumpkinArmour",
                difficulty: 7,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.PumpkinHelmet,
                    ItemID.PumpkinBreastplate,
                    ItemID.PumpkinLeggings
                )
            );
            register(
                "WearFossilArmour",
                difficulty: 7,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.FossilHelm,
                    ItemID.FossilShirt,
                    ItemID.FossilPants
                )
            );
            register(
                "GetSummons",
                difficulty: 7,
                IconAnimationSystem.registerRandAnimation(Sets.SummonStaves),
                text: "7"
            );
            register(
                "Get100Gel",
                difficulty: 7,
                new(ItemID.Gel),
                text: "100"
            );
            register(
                "StackHighTierBars",
                difficulty: 7,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.CrimtaneBar,
                    ItemID.MeteoriteBar,
                    ItemID.HellstoneBar,
                    ItemID.DemoniteBar,
                    ItemID.MeteoriteBar,
                    ItemID.HellstoneBar
                ),
                modifier: new(ItemID.SnowBlock)
            );
            register(
                "Get4GrassSeeds",
                difficulty: 7,
                IconAnimationSystem.registerRandAnimation(Sets.GrassSeeds),
                text: "4"
            );
            #endregion

            #region Difficulty 8 goals
            register(
                "GetGemCritterCage",
                difficulty: 8,
                IconAnimationSystem.registerRandAnimation(Sets.GemCritterCages)
            );
            register(
                "Get99Seeds",
                difficulty: 8,
                new(ItemID.Seed),
                text: "99"
            );
            register(
                "HelpGolfer",
                difficulty: 8,
                NPCIcon.Golfer,
                shouldEnable: anyLockout
            );
            register(
                "Get6Arrows",
                difficulty: 8,
                IconAnimationSystem.registerRandAnimation(Sets.Arrows),
                text: "6"
            );
            register(
                "GetSilverBullets",
                difficulty: 8,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.SilverBullet,
                    ItemID.TungstenBullet
                )
            );
            register(
                "Get8Hooks",
                difficulty: 8,
                IconAnimationSystem.registerRandAnimation(Sets.Hooks),
                text: "8"
            );
            register(
                "Have5Debuffs",
                difficulty: 8,
                Buff.AnyDebuff,
                text: "5"
            );
            #endregion

            #region Difficulty 9 goals
            register(
                "HaveMaxHealth",
                difficulty: 9,
                new(ItemID.LifeCrystal),
                text: "400"
            );
            register(
                "HaveMaxMana",
                difficulty: 9,
                new(ItemID.ManaCrystal),
                text: "200"
            );
            register(
                "UseFairy",
                difficulty: 9,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.FairyCritterPink,
                    ItemID.FairyCritterGreen,
                    ItemID.FairyCritterBlue
                )
            );
            register(
                "DownArmy",
                difficulty: 9,
                new(ItemID.GoblinBattleStandard),
                modifier: kill
            );
            register(
                "UsePoisonDart",
                difficulty: 9,
                new(ItemID.PoisonDart),
                modifier: IconAnimationSystem.registerCycleAnimation(
                    ItemID.Blowpipe,
                    ItemID.Blowgun
                )
            );
            register(
                "Get5Minecarts",
                difficulty: 9,
                IconAnimationSystem.registerRandAnimation(Sets.Minecarts),
                text: "5"
            );
            register(
                "DownKSMelee",
                difficulty: 9,
                new(ItemID.KingSlimeTrophy),
                modifier: swordOrSpear,
                synergyTypes: new[] {"ME.3.2"}
            );
            register(
                "GetTorchGodsFavour",
                difficulty: 9,
                new(ItemID.TorchGodsFavor)
            );
            #endregion

            #region Difficulty 10 goals
            register(
                "MakePiano",
                difficulty: 10,
                IconAnimationSystem.registerRandAnimation(Sets.CraftablePianos),
                modifier: craft
            );
            register(
                "ThrowBonesAtTargetDummy",
                difficulty: 10,
                new(ItemID.Bone),
                modifier: new(ItemID.TargetDummy),
                text: "35"
            );
            register(
                "DownSkele",
                difficulty: 10,
                new(ItemID.SkeletronTrophy),
                synergyTypes: new[] {"ME.7.1", "ME.7.2"}
            );
            register(
                "NoEquipAccessories",
                difficulty: 10,
                accessories,
                modifier: disallow,
                synergyTypes: new[] {"ME.1", "ME.15"},
                shouldEnable: notLockout
            );
            register(
                "OpponentEquipAccessories",
                difficulty: 10,
                accessories,
                modifier: disallow,
                synergyTypes: new[] {"ME.1", "ME.15"},
                shouldEnable: twoLockout
            );
            register(
                "NoPlatforms",
                difficulty: 10,
                platforms,
                modifier: disallow,
                synergyTypes: new[] {"ME.1"},
                shouldEnable: notLockout
            );
            register(
                "OpponentPlatforms",
                difficulty: 10,
                platforms,
                modifier: disallow,
                synergyTypes: new[] {"ME.1"},
                shouldEnable: twoLockout
            );
            register(
                "GetAnnouncementBox",
                difficulty: 10,
                new(ItemID.AnnouncementBox)
            );
            register(
                "TrashDungeonWeapon",
                difficulty: 10,
                IconAnimationSystem.registerRandAnimation(Sets.DungeonWeapons),
                modifier: trash
            );
            register(
                "TrashWaterBolt",
                difficulty: 10,
                new(ItemID.WaterBolt),
                modifier: trash
            );
            #endregion

            #region Difficulty 11 goals
            register(
                "RockBottom",
                difficulty: 11,
                AchievementIcon.RockBottom
            );
            register(
                "HelpStylist",
                difficulty: 11,
                NPCIcon.Stylist,
                shouldEnable: anyLockout
            );
            register(
                "IntoOrbit",
                difficulty: 11,
                AchievementIcon.IntoOrbit
            );
            register(
                "DownKSSpace",
                difficulty: 11,
                new(ItemID.KingSlimeTrophy),
                modifier: BestiaryIcon.Island,
                synergyTypes: new[] {"ME.3.1"}
            );
            register(
                "See3BlazingWheels",
                difficulty: 11,
                NPCIcon.BlazingWheel,
                text: "3"
            );
            register(
                "TraverseWholeWorld",
                difficulty: 11,
                ModContent.GetInstance<Map>().Item
            );
            register(
                "FindTemple",
                difficulty: 11,
                BestiaryIcon.Temple
            );
            register(
                "Get5GemStaves",
                difficulty: 11,
                IconAnimationSystem.registerRandAnimation(Sets.GemStaves),
                text: "5"
            );
            #endregion

            #region Difficulty 12 goals
            register(
                "WearNecroArmour",
                difficulty: 12,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.NecroHelmet,
                    ItemID.NecroBreastplate,
                    ItemID.NecroGreaves
                ),
                synergyTypes: new[] {"ME.14"}
            );
            register(
                "WearHeroHat",
                difficulty: 12,
                new(ItemID.HerosHat)
            );
            register(
                "LavaBath",
                difficulty: 12,
                new(ItemID.BottomlessLavaBucket),
                text: "10s"
            );
            register(
                "GetManaFlower",
                difficulty: 12,
                new(ItemID.ManaFlower)
            );
            register(
                "NoTorches",
                difficulty: 12,
                IconAnimationSystem.registerRandAnimation(Sets.Torches),
                modifier: disallow,
                shouldEnable: notLockout,
                synergyTypes: new[] {"ME.1"}
            );
            register(
                "OpponentTorches",
                difficulty: 12,
                IconAnimationSystem.registerRandAnimation(Sets.Torches),
                modifier: disallow,
                shouldEnable: twoLockout,
                synergyTypes: new[] {"ME.1"}
            );
            register(
                "PlaceArt",
                difficulty: 12,
                IconAnimationSystem.registerRandAnimation(Sets.Paintings)
            );
            register(
                "DownQB",
                difficulty: 12,
                new(ItemID.QueenBeeTrophy),
                synergyTypes: new[] {"ME.6.1", "ME.6.2"}
            );
            register(
                "DownEoCMelee",
                difficulty: 12,
                new(ItemID.EyeofCthulhuTrophy),
                modifier: swordOrSpear,
                synergyTypes: new[] {"ME.5.2"}
            );
            #endregion

            #region Difficulty 13 goals
            register(
                "Get2Crates",
                difficulty: 13,
                IconAnimationSystem.registerRandAnimation(Sets.Crates),
                text: "2"
            );
            register(
                "Stinky",
                difficulty: 13,
                Buff.Stinky
            );
            register( // this one might be difficult to implement fairly, I.E. avoiding breaking/replacing the chest
                "Loot6GoldChests",
                difficulty: 13,
                new(ItemID.GoldChest),
                text: "6"
            );
            register(
                "Get4Yoyos",
                difficulty: 13,
                IconAnimationSystem.registerRandAnimation(Sets.Yoyos),
                text: "4"
            );
            register(
                "Complete2FishingQuests",
                difficulty: 13,
                questFish,
                text: "2",
                synergyTypes: new[] {"ME.11"}
            );
            register(
                "DieToDG",
                difficulty: 13,
                NPCIcon.DungeonGuardian
            );
            register(
                "KillVillagerwithDG",
                difficulty: 13,
                NPCIcon.AnyTown,
                modifier: NPCIcon.DungeonGuardian
            );
            register(
                "DrinkFlask",
                difficulty: 13,
                IconAnimationSystem.registerRandAnimation(Sets.Flasks)
            );
            #endregion

            #region Difficulty 14 goals
            register(
                "Get2Pylons",
                difficulty: 14,
                IconAnimationSystem.registerRandAnimation(Sets.Pylons),
                text: "2",
                synergyTypes: new[] {"ME.12"}
            );
            register(
                "KillClothier",
                difficulty: 14,
                NPCIcon.Clothier,
                modifier: kill
            );
            register(
                "Get40Def",
                difficulty: 14,
                ModContent.GetInstance<DefenceShield>().Item,
                text: "40"
            );
            register(
                "PetDog",
                difficulty: 14,
                NPCIcon.Dog
            );
            register(
                "GetMoss",
                difficulty: 14,
                IconAnimationSystem.registerRandAnimation(Sets.GlowingMosses)
            );
            register(
                "GetFountain",
                difficulty: 14,
                IconAnimationSystem.registerRandAnimation(Sets.Fountains)
            );
            register(
                "UpgradeSkull",
                difficulty: 14,
                IconAnimationSystem.registerRandAnimation(Sets.ObsidianSkullUpgrades)
            );
            #endregion

            #region Difficulty 15 goals
            register(
                "GetTragicUmbrella",
                difficulty: 15,
                new(ItemID.TragicUmbrella)
            );
            register(
                "GetQuadShotgun",
                difficulty: 15,
                new(ItemID.QuadBarrelShotgun)
            );
            register(
                "UseFogboundDye",
                difficulty: 15,
                new(ItemID.FogboundDye)
            );
            register(
                "Get5GoldGraves",
                difficulty: 15,
                IconAnimationSystem.registerCycleAnimation(Sets.GoldGraves),
                text: "5"
            );
            register(
                "KillWithCoffin",
                difficulty: 15,
                new(ItemID.CoffinMinecart),
                modifier: AchievementIcon.VehicularManslaughter
            );
            register(
                "ExcavateWithShovel",
                difficulty: 15,
                new(ItemID.GravediggerShovel),
                text: "500"
            );
            register(
                "MakeEvilOrbDrop",
                difficulty: 15,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.BandofStarpower,
                    ItemID.PanicNecklace
                ),
                modifier: craft
            );
            register(
                "KillGraveyardMobs",
                difficulty: 15,
                IconAnimationSystem.registerCycleAnimation(
                    NPCIcon.MaggotZombie.type,
                    NPCIcon.Ghost.type,
                    NPCIcon.Raven.type
                ),
                text: "3"
            );
            #endregion

            #region Difficulty 16 goals
            register(
                "FillEquipPage2",
                difficulty: 16,
                ModContent.GetInstance<FillEquipPage2>().Item
            );
            register(
                "Get5Toilets",
                difficulty: 16,
                IconAnimationSystem.registerRandAnimation(Sets.Toilets),
                text: "5"
            );
            register(
                "GetBINGO",
                difficulty: 16,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.AlphabetStatueB,
                    ItemID.AlphabetStatueI,
                    ItemID.AlphabetStatueN,
                    ItemID.AlphabetStatueG,
                    ItemID.AlphabetStatueO
                )
            );
            register(
                "KillWithSandgun",
                difficulty: 16,
                new Item(ItemID.Sandgun)
            );
            register(
                "Get99Anvils",
                difficulty: 16,
                IconAnimationSystem.registerRandAnimation(Sets.Anvils),
                text: "99"
            );
            register(
                "GetTongued",
                difficulty: 16,
                Buff.TheTongue,
                synergyTypes: new[] {"ME.8.1"}
            );
            register(
                "Hellevator",
                difficulty: 16,
                IconAnimationSystem.registerCycleAnimation(
                    AchievementIcon.IntoOrbit.type,
                    AchievementIcon.RockBottom.type
                )
            );
            #endregion

            #region Difficulty 17 goals
            #endregion

            #region Difficulty 18 goals
            #endregion

            #region Difficulty 19 goals
            #endregion

            #region Difficulty 20 goals
            #endregion

            #region Difficulty 21 goals
            #endregion

            #region Difficulty 22 goals
            #endregion

            #region Difficulty 23 goals
            #endregion

            #region Difficulty 24 goals
            #endregion
        }

        public override void Load() {
            AchievementIcon.registerItems();
            BestiaryIcon.registerItems();
            Buff.registerItems();
            NPCIcon.registerItems();
        }

        public override void PostSetupContent() {
            Sets.load();
            registerGoals();
        }
    }
}
