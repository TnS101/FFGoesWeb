namespace Persistence.Context
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities.Common;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Units;
    using Domain.Entities.Game.Units.OneToOne;
    using Domain.Entities.Social;

    public class DataSeeder
    {
        public static async Task Seed(FFDbContext context)
        {
            var seeder = new DataSeeder();
            await seeder.SeedAsync(context, CancellationToken.None);
        }

        public async Task SeedAsync(FFDbContext context, CancellationToken cancellationToken)
        {
            context.Database.EnsureCreated();

            if (context.Spells.Any())
            {
                return;
            }

            await this.SeedSampleUsers(context, cancellationToken);

            await this.SeedMonstersAsync(context, cancellationToken);

            await this.SeedMonsterRaritiesAsync(context, cancellationToken);

            await this.SeedFigthingClassesAsync(context, cancellationToken);

            await this.SeedPlayerSpellsAsync(context, cancellationToken);

            await this.SeedMonsterSpellsAsync(context, cancellationToken);

            await this.SeedStatusesAsync(context, cancellationToken);

            await this.SeedToolsAsync(context, cancellationToken);

            await this.SeedMainMaterialsAsync(context, cancellationToken);

            await this.SeedLootBoxesAsync(context, cancellationToken);

            await this.SeedLootKeysAsync(context, cancellationToken);
        }

        private async Task SeedConsumeablesAsync(FFDbContext context, CancellationToken cancellationToken)
        {
            context.Consumeables.Add(new Consumeable
            {
                Name = "Tomato",
                Type = "Edible",
                Stat = "HP",
                StatReplenish = 0.05,
                HungerReplenish = 1,
                IsRefineable = true,
                RelatedMaterials = "Salad",
                ZoneName = "Any",
                Slot = "Consumeable",
                BuyPrice = 10,
                SellPrice = 10,
                ImagePath = "",
            });
        }

        private async Task SeedLootBoxesAsync(FFDbContext context, CancellationToken cancellationToken)
        {
            context.LootBoxes.Add(new LootBox
            {
                Name = "Bronze Lockbox",
                Type = "Bronze",
                Slot = "Loot Box",
                ImagePath = "/images/Items/Loot Boxes/06_4.png",
                RequiresKey = true,
                RewardAmplifier = 1,
            });

            context.LootBoxes.Add(new LootBox
            {
                Name = "Bronze Case",
                Type = "Bronze",
                Slot = "Loot Box",
                ImagePath = "/images/Items/Loot Boxes/06_4.png",
                RequiresKey = true,
                RewardAmplifier = 2,
            });

            context.LootBoxes.Add(new LootBox
            {
                Name = "Bronze Trunk",
                Type = "Bronze",
                Slot = "Loot Box",
                ImagePath = "/images/Items/Loot Boxes/06_4.png",
                RequiresKey = true,
                RewardAmplifier = 3,
            });

            context.LootBoxes.Add(new LootBox
            {
                Name = "Silver Lockbox",
                Type = "Silver",
                Slot = "Loot Box",
                ImagePath = "/images/Items/Loot Boxes/06_4.png",
                RequiresKey = true,
                RewardAmplifier = 4,
            });

            context.LootBoxes.Add(new LootBox
            {
                Name = "Silver Case",
                Type = "Silver",
                Slot = "Loot Box",
                ImagePath = "/images/Items/Loot Boxes/06_4.png",
                RequiresKey = true,
                RewardAmplifier = 5,
            });

            context.LootBoxes.Add(new LootBox
            {
                Name = "Silver Trunk",
                Type = "Silver",
                Slot = "Loot Box",
                ImagePath = "/images/Items/Loot Boxes/06_4.png",
                RequiresKey = true,
                RewardAmplifier = 6,
            });

            context.LootBoxes.Add(new LootBox
            {
                Name = "Golden Lockbox",
                Type = "Golden",
                Slot = "Loot Box",
                ImagePath = "/images/Items/Loot Boxes/06_4.png",
                RequiresKey = true,
                RewardAmplifier = 7,
            });

            context.LootBoxes.Add(new LootBox
            {
                Name = "Golden Case",
                Type = "Golden",
                Slot = "Loot Box",
                ImagePath = "/images/Items/Loot Boxes/06_4.png",
                RequiresKey = true,
                RewardAmplifier = 8,
            });

            context.LootBoxes.Add(new LootBox
            {
                Name = "Golden Trunk",
                Type = "Golden",
                Slot = "Loot Box",
                ImagePath = "/images/Items/Loot Boxes/06_4.png",
                RequiresKey = true,
                RewardAmplifier = 10,
            });

            context.LootBoxes.Add(new LootBox
            {
                Name = "Small Material Package",
                Type = "Material",
                Slot = "Loot Box",
                ImagePath = "/images/Items/Loot Boxes/06_4.png",
                RequiresKey = false,
                RewardAmplifier = 2,
            });

            context.LootBoxes.Add(new LootBox
            {
                Name = "Old Salvage Box",
                Type = "Material",
                Slot = "Loot Box",
                ImagePath = "/images/Items/Loot Boxes/06_4.png",
                RequiresKey = false,
                RewardAmplifier = 3,
            });

            context.LootBoxes.Add(new LootBox
            {
                Name = "Craftsman's Crate",
                Type = "Material",
                Slot = "Loot Box",
                ImagePath = "/images/Items/Loot Boxes/06_4.png",
                RequiresKey = false,
                RewardAmplifier = 4,
            });

            context.LootBoxes.Add(new LootBox
            {
                Name = "Lunchbox",
                Type = "Consumeable",
                Slot = "Loot Box",
                ImagePath = "/images/Items/Loot Boxes/06_4.png",
                RequiresKey = true,
                RewardAmplifier = 2,
            });

            context.LootBoxes.Add(new LootBox
            {
                Name = "Bento!!",
                Type = "Consumeable",
                Slot = "Loot Box",
                ImagePath = "/images/Items/Loot Boxes/06_4.png",
                RequiresKey = true,
                RewardAmplifier = 3,
            });

            context.LootBoxes.Add(new LootBox
            {
                Name = "Provision Crate",
                Type = "Consumeable",
                Slot = "Loot Box",
                ImagePath = "/images/Items/Loot Boxes/06_4.png",
                RequiresKey = true,
                RewardAmplifier = 4,
            });

            context.LootBoxes.Add(new LootBox
            {
                Name = "Small Tool Package",
                Type = "Tool",
                Slot = "Loot Box",
                ImagePath = "/images/Items/Loot Boxes/06_4.png",
                RequiresKey = true,
                RewardAmplifier = 1,
            });

            context.LootBoxes.Add(new LootBox
            {
                Name = "Toolkit",
                Type = "Tool",
                Slot = "Loot Box",
                ImagePath = "/images/Items/Loot Boxes/06_4.png",
                RequiresKey = true,
                RewardAmplifier = 2,
            });

            context.LootBoxes.Add(new LootBox
            {
                Name = "Dirty Plastic Bag",
                Type = "Junk",
                Slot = "Loot Box",
                ImagePath = "/images/Items/Loot Boxes/06_4.png",
                RequiresKey = true,
                RewardAmplifier = 2,
            });

            context.LootBoxes.Add(new LootBox
            {
                Name = "Dustbin",
                Type = "Junk",
                Slot = "Loot Box",
                ImagePath = "/images/Items/Loot Boxes/06_4.png",
                RequiresKey = true,
                RewardAmplifier = 3,
            });

            context.LootBoxes.Add(new LootBox
            {
                Name = "Trash Can",
                Type = "Junk",
                Slot = "Loot Box",
                ImagePath = "/images/Items/Loot Boxes/06_4.png",
                RequiresKey = true,
                RewardAmplifier = 4,
            });

            context.LootBoxes.Add(new LootBox
            {
                Name = "Mysterious Toy Pack",
                Type = "Toy",
                Slot = "Loot Box",
                ImagePath = "/images/Items/Loot Boxes/06_4.png",
                RequiresKey = true,
                RewardAmplifier = 1,
            });

            context.LootBoxes.Add(new LootBox
            {
                Name = "Toy Bag",
                Type = "Toy",
                Slot = "Loot Box",
                ImagePath = "/images/Items/Loot Boxes/06_4.png",
                RequiresKey = true,
                RewardAmplifier = 2,
            });

            context.LootBoxes.Add(new LootBox
            {
                Name = "Random Lock Opener",
                Type = "Key",
                Slot = "Loot Box",
                ImagePath = "/images/Items/Loot Boxes/06_4.png",
                RequiresKey = true,
                RewardAmplifier = 1,
            });

            context.LootBoxes.Add(new LootBox
            {
                Name = "Keychain",
                Type = "Key",
                Slot = "Loot Box",
                ImagePath = "/images/Items/Loot Boxes/06_4.png",
                RequiresKey = true,
                RewardAmplifier = 2,
            });

            await context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedLootKeysAsync(FFDbContext context, CancellationToken cancellationToken)
        {
            context.LootKeys.Add(new LootKey
            {
                Name = "Basic Bronze Key",
                Type = "Bronze",
                Slot = "Loot Key",
                ImagePath = "/images/Items/Loot Keys/Basic Bronze Key.png",
            });
            context.LootKeys.Add(new LootKey
            {
                Name = "Basic Silver Key",
                Type = "Silver",
                Slot = "Loot Key",
                ImagePath = "/images/Items/Loot Keys/Basic Silver Key.png",
            });
            context.LootKeys.Add(new LootKey
            {
                Name = "Basic Golden Key",
                Type = "Golden",
                Slot = "Loot Key",
                ImagePath = "/images/Items/Loot Keys/Basic Golden Key.png",
            });

            await context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedSampleUsers(FFDbContext context, CancellationToken cancellationToken)
        {
            context.AppUsers.Add(new AppUser
            {
                UserName = "random123",
                Email = "random@mail.com",
            });

            await context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedMainMaterialsAsync(FFDbContext context, CancellationToken cancellationToken)
        {
            // Main
            context.Materials.Add(new Material
            {
                Name = "Oak Log",
                Type = "Wood",
                ImagePath = "/images/Items/Materials/Oak-Log.png",
                IsRefineable = true,
                FuelCount = 1,
            });

            context.Materials.Add(new Material
            {
                Name = "Walnut Log",
                Type = "Wood",
                ImagePath = "/images/Items/Materials/Walnut-Log.png",
                IsRefineable = true,
                FuelCount = 2,
            });
            context.Materials.Add(new Material
            {
                Name = "Birch Log",
                Type = "Wood",
                ImagePath = "/images/Items/Materials/Birch-Log.png",
                IsRefineable = true,
                FuelCount = 1,
            });

            context.Materials.Add(new Material
            {
                Name = "Mahogany Log",
                Type = "Wood",
                ImagePath = "/images/Items/Materials/Mahogany-Log.png",
                IsRefineable = true,
                FuelCount = 1,
            });

            context.Materials.Add(new Material
            {
                Name = "Coal Ore",
                Type = "Ore",
                ImagePath = "/images/Items/Materials/Coal-Ore.png",
                FuelCount = 3,
            });

            context.Materials.Add(new Material
            {
                Name = "Copper Ore",
                Type = "Ore",
                ImagePath = "/images/Items/Materials/Copper-Ore.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Iron Ore",
                Type = "Ore",
                ImagePath = "/images/Items/Materials/Iron-Ore.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Gold Ore",
                Type = "Ore",
                ImagePath = "/images/Items/Materials/Gold-Ore.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Leather Scraps",
                Type = "Leather",
                ImagePath = "/images/Items/Materials/Leather-Scraps.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Animal Fur",
                Type = "Leather",
                ImagePath = "/images/Items/Materials/Animal-Fur.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Light Leather",
                Type = "Leather",
                ImagePath = "/images/Items/Materials/Light-Leather.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Fine Leather",
                Type = "Leather",
                ImagePath = "/images/Items/Materials/Fine-Leather.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Cotton",
                Type = "Cloth",
                ImagePath = "/images/Items/Materials/Cotton.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Linen Cloth",
                Type = "Cloth",
                ImagePath = "/images/Items/Materials/Linen-Cloth.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Silk",
                Type = "Cloth",
                ImagePath = "/images/Items/Materials/Silk.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Mint",
                Type = "Herb",
                ImagePath = "/images/Items/Materials/Mint.png",
            });

            context.Materials.Add(new Material
            {
                Name = "Coriander",
                Type = "Herb",
                ImagePath = "/images/Items/Materials/Coriander.png",
            });

            context.Materials.Add(new Material
            {
                Name = "Lavender",
                Type = "Herb",
                ImagePath = "/images/Items/Materials/Lavender.png",
            });

            context.Materials.Add(new Material
            {
                Name = "Buttercup",
                Type = "Herb",
                ImagePath = "/images/Items/Materials/Butter-Cup.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Water Essence",
                Type = "Essence",
                ImagePath = "/images/Items/Materials/Water-Essence.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Earth Essence",
                Type = "Essence",
                ImagePath = "/images/Items/Materials/Earth-Essence.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Air Essence",
                Type = "Essence",
                ImagePath = "/images/Items/Materials/Air-Essence.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Fire Essence",
                Type = "Essence",
                ImagePath = "/images/Items/Materials/Fire-Essence.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Shiny Scale",
                Type = "Scale",
                ImagePath = "/images/Items/Materials/Shiny-Scale.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Transparent Scale",
                Type = "Scale",
                ImagePath = "/images/Items/Materials/Transparent-Scale.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Golden Necklace",
                Type = "Metal",
                RelatedMaterials = "Gold Scraps 2,Iron Scraps 2",
                ImagePath = "/images/Items/Materials/Golden-Necklace.png",
                IsDisolveable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Hard Scale",
                Type = "Scale",
                ImagePath = "/images/Items/Materials/Hard-Scale.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Tomato",
                Type = "Vegetables",
                ImagePath = "/images/Items/Materials/Tomato.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Lettuce",
                Type = "Vegetables",
                ImagePath = "/images/Items/Materials/Lettuce.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Turnip",
                Type = "Vegetables",
                ImagePath = "/images/Items/Materials/Turnip.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Pumpkin",
                Type = "Vegetables",
                ImagePath = "/images/Items/Materials/Pumpkin.png",
                IsRefineable = true,
            });

            // Profession
            context.Materials.Add(new Material
            {
                Name = "Dry Branch",
                Type = "Wood",
                ImagePath = "/images/Items/Materials/Dry-Branch.png",
            });

            context.Materials.Add(new Material
            {
                Name = "Green Leaves",
                Type = "Wood",
                ImagePath = "/images/Items/Materials/Green-Leaves.png",
            });

            context.Materials.Add(new Material
            {
                Name = "Tree Stump",
                Type = "Wood",
                ImagePath = "/images/Items/Materials/Tree-Stump.png",
                IsRefineable = true,
                FuelCount = 1,
            });

            context.Materials.Add(new Material
            {
                Name = "Acorn",
                Type = "Wood",
                ImagePath = "/images/Items/Materials/Acorn.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Granite",
                Type = "Rock",
                ImagePath = "/images/Items/Materials/Granite.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Marble",
                Type = "Rock",
                ImagePath = "/images/Items/Materials/Marble.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Quartzite",
                Type = "Rock",
                ImagePath = "/images/Items/Materials/Quartzite.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Obsidian",
                Type = "Rock",
                ImagePath = "/images/Items/Materials/Obsidian.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Animal Stomach",
                Type = "Meat",
                ImagePath = "/images/Items/Materials/Animal-Stomach.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Animal Skull",
                Type = "Bones",
                RelatedMaterials = "Bone Dust 1,Bone Shards 2",
                ImagePath = "/images/Items/Materials/Animal-Skull.png",
                IsDisolveable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Animal Bones",
                Type = "Bones",
                RelatedMaterials = "Bone Dust 2,Bone Shards 1",
                ImagePath = "/images/Items/Materials/Animal-Bones.png",
                IsDisolveable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Fangs",
                Type = "Bones",
                ImagePath = "/images/Items/Materials/Fangs.png",
            });

            context.Materials.Add(new Material
            {
                Name = "T-Shirt",
                Type = "Cloth",
                RelatedMaterials = "Cloth 1,String 2",
                ImagePath = "/images/Items/Materials/T-Shirt.png",
                IsDisolveable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Shoes",
                Type = "Leather",
                RelatedMaterials = "Leather 1,String 2",
                ImagePath = "/images/Items/Materials/Shoes.png",
                IsDisolveable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Pants",
                Type = "Leather",
                RelatedMaterials = "Leather 1,Cloth 1,String 1",
                ImagePath = "/images/Items/Materials/Pants.png",
                IsDisolveable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Human Soul",
                Type = "Essence",
                ImagePath = "/images/Items/Materials/Human-Soul.png",
            });

            context.Materials.Add(new Material
            {
                Name = "Rose",
                Type = "Plant",
                ImagePath = "/images/Items/Materials/Rose.png",
            });

            context.Materials.Add(new Material
            {
                Name = "Daisy",
                Type = "Plant",
                ImagePath = "/images/Items/Materials/Daisy.png",
            });

            context.Materials.Add(new Material
            {
                Name = "Clay Pot",
                Type = "Furniture",
                RelatedMaterials = "Clay Dust 1,Clay Block 2",
                ImagePath = "/images/Items/Materials/Clay-Pot.png",
                IsDisolveable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Plastic Vase",
                Type = "Furniture",
                ImagePath = "/images/Items/Materials/Plastic-Vase.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Life Essence",
                Type = "Essence",
                ImagePath = "/images/Items/Materials/Life-Essence.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Light Essence",
                Type = "Essence",
                ImagePath = "/images/Items/Materials/Light-Essence.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Shadow Essence",
                Type = "Essence",
                ImagePath = "/images/Items/Materials/Shadow-Essence.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Death Essence",
                Type = "Essence",
                ImagePath = "/images/Items/Materials/Death-Essence.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "String",
                Type = "Cloth",
                ImagePath = "/images/Items/Materials/String.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Puffer Fish",
                Type = "Fish",
                RelatedMaterials = "Poison Vial 1,Fish Meat 1",
                ImagePath = "/images/Items/Materials/Puffer-Fish.png",
                IsDisolveable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Turtle Eggs",
                Type = "Egg",
                ImagePath = "/images/Items/Materials/Turtle-Eggs.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Bottled Message",
                Type = "Junk",
                RelatedMaterials = "Glass 1,Paper 1",
                ImagePath = "/images/Items/Materials/Bottled-Message.png",
                IsDisolveable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Potato",
                Type = "Vegetable",
                ImagePath = "/images/Items/Materials/Potato.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Corn",
                Type = "Vegetable",
                ImagePath = "/images/Items/Materials/Corn.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Garden Shovel",
                Type = "Junk",
                RelatedMaterials = "Stick 1,Copper Chunks 1,Dirt 1",
                ImagePath = "/images/Items/Materials/Garden-Shovel.png",
                IsDisolveable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Watering Can",
                Type = "Junk",
                RelatedMaterials = "Water Flask 1,Iron Chunks 1",
                ImagePath = "/images/Items/Materials/Watering-Can.png",
                IsDisolveable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Broken Glass Cup",
                Type = "Junk",
                ImagePath = "/images/Items/Materials/Broken-Glass-Cup.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Stale Hotdog",
                Type = "Junk",
                ImagePath = "/images/Items/Materials/Stale-Hotdog.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Crushed Can",
                Type = "Junk",
                ImagePath = "/images/Items/Materials/Crushed-Can.png",
                IsRefineable = true,
            });

            // Junk
            context.Materials.Add(new Material
            {
                Name = "Rubber Band",
                Type = "Junk",
                ImagePath = "/images/Items/Materials/Rubber-Band.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Animal Blood",
                Type = "Junk",
                ImagePath = "/images/Items/Materials/Animal-Blood.png",
            });

            context.Materials.Add(new Material
            {
                Name = "Dead Critters",
                Type = "Junk",
                ImagePath = "/images/Items/Materials/Dead-Critters.png",
            });

            context.Materials.Add(new Material
            {
                Name = "Broken Skull",
                Type = "Junk",
                ImagePath = "/images/Items/Materials/Broken-Skull.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Broken Watch",
                Type = "Junk",
                RelatedMaterials = "Gold Scraps 1,Iron Scraps 1,Copper Scraps 1",
                ImagePath = "/images/Items/Materials/Broken-Watch.png",
                IsDisolveable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Empty Plastic Bottle",
                Type = "Junk",
                RelatedMaterials = "Plastic 1",
                ImagePath = "/images/Items/Materials/Empty-Plastic-Bottle.png",
                IsDisolveable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Broken Cogs",
                Type = "Junk",
                RelatedMaterials = "Copper Scraps 1,Iron Scraps 1",
                ImagePath = "/images/Items/Materials/Broken-Cogs.png",
                IsDisolveable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Rusty Pipes",
                Type = "Junk",
                RelatedMaterials = "Copper Scraps 2",
                ImagePath = "/images/Items/Materials/Rusty-Pipes.png",
                IsDisolveable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Dead Battery",
                Type = "Junk",
                RelatedMaterials = "Iron Scraps 1,Golden Scraps 1",
                ImagePath = "/images/Items/Materials/Dead-Battery.png",
                IsDisolveable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Cracked Water Orb",
                Type = "Junk",
                RelatedMaterials = "Water Vial 1,Glass 1",
                ImagePath = "/images/Items/Materials/Cracked-Water-Orb.png",
                IsDisolveable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Coal Piece",
                Type = "Junk",
                ImagePath = "/images/Items/Materials/Coal-Piece.png",
                IsRefineable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Water Flask",
                Type = "Junk",
                ImagePath = "/images/Items/Materials/Water-Flask.png",
            });

            context.Materials.Add(new Material
            {
                Name = "Worm",
                Type = "Junk",
                ImagePath = "/images/Items/Materials/Worm.png",
            });

            context.Materials.Add(new Material
            {
                Name = "Withered Roots",
                Type = "Junk",
                RelatedMaterials = "Stick 1,Dirt 1",
                ImagePath = "/images/Items/Materials/Withered-Roots.png",
                IsDisolveable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Mud",
                Type = "Junk",
                RelatedMaterials = "Water Flask 1,Dirt 1",
                ImagePath = "/images/Items/Materials/Mud.png",
                IsDisolveable = true,
            });

            context.Materials.Add(new Material
            {
                Name = "Broken Branches",
                Type = "Junk",
                ImagePath = "/images/Items/Materials/Broken-Branches.png",
                IsRefineable = true,
            });

            await context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedToolsAsync(FFDbContext context, CancellationToken cancellationToken)
        {
            context.Tools.Add(new Tool
            {
                Name = "Saw",
                Durability = 10,
                ImagePath = "/images/Items/Tools/Saw.png",
                BuyPrice = 20,
            });

            context.Tools.Add(new Tool
            {
                Name = "Hammer",
                Durability = 10,
                ImagePath = "/images/Items/Tools/Hammer.png",
                BuyPrice = 20,
            });

            context.Tools.Add(new Tool
            {
                Name = "Sandpaper",
                Durability = 10,
                ImagePath = "/images/Items/Tools/Sandpaper.png",
                BuyPrice = 10,
            });

            context.Tools.Add(new Tool
            {
                Name = "Anvil",
                Durability = 30,
                ImagePath = "/images/Items/Tools/Anvil.png",
                BuyPrice = 60,
            });

            context.Tools.Add(new Tool
            {
                Name = "Knife",
                Durability = 10,
                ImagePath = "/images/Items/Tools/Knife.png",
                BuyPrice = 20,
            });

            context.Tools.Add(new Tool
            {
                Name = "Needle",
                Durability = 20,
                ImagePath = "/images/Items/Tools/Needle.png",
                BuyPrice = 10,
            });

            context.Tools.Add(new Tool
            {
                Name = "Ruler",
                Durability = 50,
                ImagePath = "/images/Items/Tools/Ruler.png",
                BuyPrice = 30,
            });

            context.Tools.Add(new Tool
            {
                Name = "Scissors",
                Durability = 20,
                ImagePath = "/images/Items/Tools/Scissors.png",
                BuyPrice = 40,
            });

            context.Tools.Add(new Tool
            {
                Name = "Knitting Kit",
                Durability = 20,
                ImagePath = "/images/Items/Tools/Knitting-Kit.png",
                BuyPrice = 10,
            });

            context.Tools.Add(new Tool
            {
                Name = "Mortar and Pestle",
                Durability = 30,
                ImagePath = "/images/Items/Tools/Mortar-and-Pestle.png",
                BuyPrice = 60,
            });

            context.Tools.Add(new Tool
            {
                Name = "Protective Mask",
                Durability = 10,
                ImagePath = "/images/Items/Tools/Protective-Mask.png",
                BuyPrice = 20,
            });

            context.Tools.Add(new Tool
            {
                Name = "Cooling Rod",
                Durability = 20,
                ImagePath = "/images/Items/Tools/Cooling-Rod.png",
                BuyPrice = 40,
            });

            context.Tools.Add(new Tool
            {
                Name = "Heavy Sandpaper",
                Durability = 20,
                ImagePath = "/images/Items/Tools/Heavy-Sandpaper.png",
                BuyPrice = 30,
            });

            context.Tools.Add(new Tool
            {
                Name = "Mixing Bowl",
                Durability = 30,
                ImagePath = "/images/Items/Tools/Mixing-Bowl.png",
                BuyPrice = 50,
            });

            context.Tools.Add(new Tool
            {
                Name = "Cutting Board",
                Durability = 30,
                ImagePath = "/images/Items/Tools/Cutting-Board.png",
                BuyPrice = 30,
            });

            await context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedMonsterRaritiesAsync(FFDbContext context, CancellationToken cancellationToken)
        {
            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Bear",
                Rarity = "Rare",
                ImagePath = "/images/Monsters/Bear-Rare.png",
                StatAmplifier = 0.1,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Bear",
                Rarity = "Heroic",
                ImagePath = "/images/Monsters/Bear-Heroic.png",
                StatAmplifier = 0.2,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Demon",
                Rarity = "Rare",
                ImagePath = "/images/Monsters/Demon-Rare.png",
                StatAmplifier = 0.1,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Demon",
                Rarity = "Heroic",
                ImagePath = "/images/Monsters/Demon-Heroic.png",
                StatAmplifier = 0.2,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Giant",
                Rarity = "Rare",
                ImagePath = "/images/Monsters/Giant-Rare.png",
                StatAmplifier = 0.1,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Giant",
                Rarity = "Heroic",
                ImagePath = "/images/Monsters/Giant-Heroic.png",
                StatAmplifier = 0.2,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Gryphon",
                Rarity = "Rare",
                ImagePath = "/images/Monsters/Gryphon-Rare.png",
                StatAmplifier = 0.1,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Gryphon",
                Rarity = "Heroic",
                ImagePath = "/images/Monsters/Gryphon-Heroic.png",
                StatAmplifier = 0.2,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Reptile",
                Rarity = "Rare",
                ImagePath = "/images/Monsters/Reptile-Rare.png",
                StatAmplifier = 0.1,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Reptile",
                Rarity = "Heroic",
                ImagePath = "/images/Monsters/Reptile-Heroic.png",
                StatAmplifier = 0.2,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Saint",
                Rarity = "Rare",
                ImagePath = "/images/Monsters/Saint-Rare.png",
                StatAmplifier = 0.1,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Saint",
                Rarity = "Heroic",
                ImagePath = "/images/Monsters/Saint-Heroic.png",
                StatAmplifier = 0.2,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Skeleton",
                Rarity = "Rare",
                ImagePath = "/images/Monsters/Skeleton-Rare.png",
                StatAmplifier = 0.1,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Skeleton",
                Rarity = "Heroic",
                ImagePath = "/images/Monsters/Skeleton-Heroic.png",
                StatAmplifier = 0.2,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Wyrm",
                Rarity = "Rare",
                ImagePath = "/images/Monsters/Wyrm-Rare.png",
                StatAmplifier = 0.1,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Wyrm",
                Rarity = "Heroic",
                ImagePath = "/images/Monsters/Wyrm-Heroic.png",
                StatAmplifier = 0.2,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Zombie",
                Rarity = "Rare",
                ImagePath = "/images/Monsters/Zombie-Rare.png",
                StatAmplifier = 0.1,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Zombie",
                Rarity = "Heroic",
                ImagePath = "/images/Monsters/Zombie-Heroic.png",
                StatAmplifier = 0.2,
            });

            await context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedMonstersAsync(FFDbContext context, CancellationToken cancellationToken)
        {
            context.Monsters.Add(new Monster
            {
                Name = "Bear",
                Type = "Beast",
                MaxHP = 80,
                HealthRegen = 3,
                MaxMana = 75,
                ManaRegen = 5,
                AttackPower = 10,
                MagicPower = 5,
                ArmorValue = 5,
                ResistanceValue = 1,
                CritChance = 2,
                ImagePath = "/images/Monsters/Bear.png",
                Description = "A bloodthirsty animal,which also likes to party for some reason...",
            });

            context.Monsters.Add(new Monster
            {
                Name = "Reptile",
                Type = "Reptile",
                MaxHP = 60,
                HealthRegen = 2,
                MaxMana = 60,
                ManaRegen = 7,
                AttackPower = 12,
                MagicPower = 5,
                ArmorValue = 3,
                ResistanceValue = 3,
                CritChance = 5,
                ImagePath = "/images/Monsters/Reptile.png",
                Description = "Actually kind of a dinosaur/lizard thingy... not very sure.",
            });

            context.Monsters.Add(new Monster
            {
                Name = "Zombie",
                Type = "Humanoid",
                MaxHP = 72,
                HealthRegen = 4,
                MaxMana = 80,
                ManaRegen = 5,
                AttackPower = 8,
                MagicPower = 3,
                ArmorValue = 2.6,
                ResistanceValue = 2,
                CritChance = 2,
                ImagePath = "/images/Monsters/Zombie.png",
                Description = "Sapiosexual. Not very smart.",
            });

            context.Monsters.Add(new Monster
            {
                Name = "Skeleton",
                Type = "Humanoid",
                MaxHP = 62,
                HealthRegen = 8,
                MaxMana = 70,
                ManaRegen = 2,
                AttackPower = 12,
                MagicPower = 3,
                ArmorValue = 1.5,
                ResistanceValue = 2,
                CritChance = 9,
                ImagePath = "/images/Monsters/Skeleton.png",
                Description = "{Insert a /Spooky/ joke here.}",
            });

            context.Monsters.Add(new Monster
            {
                Name = "Wyrm",
                Type = "Reptile",
                MaxHP = 100,
                HealthRegen = 2,
                MaxMana = 80,
                ManaRegen = 10,
                AttackPower = 8.3,
                MagicPower = 11.6,
                ArmorValue = 4.6,
                ResistanceValue = 3,
                CritChance = 3,
                ImagePath = "/images/Monsters/Wyrm.png",
                Description = "Picture this guy beneath the toilet seat next time you take a dump. I dare you!",
            });

            context.Monsters.Add(new Monster
            {
                Name = "Giant",
                Type = "Mechanical",
                MaxHP = 186,
                HealthRegen = 3,
                MaxMana = 90,
                ManaRegen = 10,
                AttackPower = 7.8,
                MagicPower = 6,
                ArmorValue = 5,
                ResistanceValue = 5,
                CritChance = 2,
                ImagePath = "/images/Monsters/Giant.png",
                Description = "Not to be confused with the Iron Giant.",
            });

            context.Monsters.Add(new Monster
            {
                Name = "Gryphon",
                Type = "Beast",
                MaxHP = 65,
                HealthRegen = 2,
                MaxMana = 110,
                ManaRegen = 8,
                AttackPower = 12,
                MagicPower = 5,
                ArmorValue = 4,
                ResistanceValue = 4,
                CritChance = 7,
                ImagePath = "/images/Monsters/Gryphon.png",
                Description = "These halfbreeds don't just exist in World of Warcraft!",
            });

            context.Monsters.Add(new Monster
            {
                Name = "Saint",
                Type = "Elemental",
                MaxHP = 120,
                HealthRegen = 2,
                MaxMana = 120,
                ManaRegen = 8,
                AttackPower = 8,
                MagicPower = 15,
                ArmorValue = 2,
                ResistanceValue = 6,
                CritChance = 3,
                ImagePath = "/images/Monsters/Saint.png",
                Description = "You'll pay for not going to church on sundays!",
            });

            context.Monsters.Add(new Monster
            {
                Name = "Demon",
                Type = "Elemental",
                MaxHP = 120,
                HealthRegen = 3.6,
                MaxMana = 100,
                ManaRegen = 6,
                AttackPower = 14,
                MagicPower = 8,
                ArmorValue = 7.3,
                ResistanceValue = 3.2,
                CritChance = 5.6,
                ImagePath = "/images/Monsters/Demon.png",
                Description = "Fearsome and cunning! Something is wrong with his head (I mean the PNG file).",
            });

            await context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedFigthingClassesAsync(FFDbContext context, CancellationToken cancellationToken)
        {
            context.FightingClasses.Add(new FightingClass
            {
                Type = "Warrior",
                MaxHP = 260,
                HealthRegen = 6.1,
                MaxMana = 110,
                ManaRegen = 6.2,
                AttackPower = 23,
                MagicPower = 8,
                ArmorValue = 5.8,
                ResistanceValue = 4,
                CritChance = 3.8,
                ImagePath = "/images/Classes/Warrior.png",
                Description = "If you want to spam one button and lose brain cells simultaneously, you should probably play CS: GO." +
                "Main Stat: Strength.",
                IconPath = "/images/Icons/Warrior-Icon.png",
            });

            context.FightingClasses.Add(new FightingClass
            {
                Type = "Hunter",
                MaxHP = 215,
                HealthRegen = 4,
                MaxMana = 110,
                ManaRegen = 6.6,
                AttackPower = 29,
                MagicPower = 13,
                ArmorValue = 4.5,
                ResistanceValue = 3.5,
                CritChance = 6,
                ImagePath = "/images/Classes/Hunter.png",
                Description = "He could have a shotgun but that would be way too much OP." +
               "Main Stat: Agility.",
                IconPath = "/images/Icons/Hunter-Icon.png",
            });

            context.FightingClasses.Add(new FightingClass
            {
                Type = "Mage",
                MaxHP = 210,
                HealthRegen = 3.8,
                MaxMana = 140,
                ManaRegen = 10,
                AttackPower = 18,
                MagicPower = 24,
                ArmorValue = 3,
                ResistanceValue = 8.8,
                CritChance = 2.8,
                ImagePath = "/images/Classes/Mage.png",
                Description = "Like cards? Go to Vegas. Like bunnies? Open a rabbit farm. Want to 1-shot someone? [CLICK ME]!" +
                "Main Stat: Intellect.",
                IconPath = "/images/Icons/Mage-Icon.png",
            });

            context.FightingClasses.Add(new FightingClass
            {
                Type = "Naturalist",
                MaxHP = 225,
                HealthRegen = 5,
                MaxMana = 130,
                ManaRegen = 12,
                AttackPower = 15,
                MagicPower = 22,
                ArmorValue = 4.8,
                ResistanceValue = 3.2,
                CritChance = 4,
                ImagePath = "/images/Classes/Druid.png",
                Description = "Don't worry. I've already donated 5 bucks to that *Beast* guy." +
                "Main Stat: Spirit.",
                IconPath = "/images/Icons/Druid-Icon.png",
            });

            context.FightingClasses.Add(new FightingClass
            {
                Type = "Necroid",
                MaxHP = 200,
                HealthRegen = 4,
                MaxMana = 150,
                ManaRegen = 10,
                AttackPower = 15,
                MagicPower = 30,
                ArmorValue = 3.6,
                ResistanceValue = 4,
                CritChance = 3,
                ImagePath = "/images/Classes/Necroid.png",
                Description = "Actually, you don't wanna know about this guy. I've warned you." +
                "Main Stat: Intellect.",
                IconPath = "/images/Icons/Necroid-Icon.png",
            });

            context.FightingClasses.Add(new FightingClass
            {
                Type = "Paladin",
                MaxHP = 225,
                HealthRegen = 6,
                MaxMana = 120,
                ManaRegen = 8,
                AttackPower = 22,
                MagicPower = 16,
                ArmorValue = 6,
                ResistanceValue = 7.3,
                CritChance = 4,
                ImagePath = "/images/Classes/Paladin.png",
                Description = "Damage? Got it. Health? Got it. Girlfriend? ... :(" +
               "Main Stat: Strength.",
                IconPath = "/images/Icons/Paladin-Icon.png",
            });

            context.FightingClasses.Add(new FightingClass
            {
                Type = "Priest",
                MaxHP = 190,
                HealthRegen = 5,
                MaxMana = 180,
                ManaRegen = 12,
                AttackPower = 15.6,
                MagicPower = 28,
                ArmorValue = 3,
                ResistanceValue = 5.6,
                CritChance = 3,
                ImagePath = "/images/Classes/Priest.png",
                Description = "Don't worry. He won't molest you." +
               "Main Stat: Spirit.",
                IconPath = "/images/Icons/Priest-Icon.png",
            });

            context.FightingClasses.Add(new FightingClass
            {
                Type = "Rogue",
                MaxHP = 195,
                HealthRegen = 3,
                MaxMana = 110,
                ManaRegen = 6,
                AttackPower = 26,
                MagicPower = 7.2,
                ArmorValue = 3.8,
                ResistanceValue = 2.5,
                CritChance = 6.3,
                ImagePath = "/images/Classes/Rogue.png",
                Description = "He steals money. Enough said, you greedy bastard." +
               "Main Stat: Agility.",
                IconPath = "/images/Icons/Rogue-Icon.png",
            });

            context.FightingClasses.Add(new FightingClass
            {
                Type = "Shaman",
                MaxHP = 210,
                HealthRegen = 5,
                MaxMana = 130,
                ManaRegen = 11,
                AttackPower = 20,
                MagicPower = 18,
                ArmorValue = 4,
                ResistanceValue = 6,
                CritChance = 4,
                ImagePath = "/images/Classes/Shaman.png",
                Description = "Freezing, zapping and stoning people to death was never such fun." +
               "Main Stat: Stamina.",
                IconPath = "/images/Icons/Shaman-Icon.png",
            });

            await context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedMonsterSpellsAsync(FFDbContext context, CancellationToken cancellationToken)
        {
            // Bear
            context.Spells.Add(new Spell
            {
                Name = "Furious Roar",
                ManaRequirement = 0.2,
                MonsterId = 9,
                Type = "Buff,Attack,Self,Positive",
                Power = 0.2,
                BuffOrEffectTarget = "Self",
            });

            context.Spells.Add(new Spell
            {
                Name = "Bite",
                ManaRequirement = 0.2,
                MonsterId = 9,
                Type = "Damage,Physical,Self",
                Power = 1.2,
                AdditionalEffect = "hRegen,Negative",
                EffectPower = 0.2,
                BuffOrEffectTarget = "Target",
                ResistanceAffect = 1,
            });

            context.Spells.Add(new Spell
            {
                Name = "Thick Hide",
                ManaRequirement = 0.5,
                MonsterId = 9,
                Type = "Buff,Armor,Self,Positive",
                Power = 0.8,
                BuffOrEffectTarget = "Self",
            });

            context.Spells.Add(new Spell
            {
                Name = "Lick Wounds",
                ManaRequirement = 0.4,
                MonsterId = 9,
                Type = "Heal,Health,Self",
                Power = 0.22,
                BuffOrEffectTarget = "Self",
            });

            // Demon
            context.Spells.Add(new Spell
            {
                Name = "Corruption",
                ManaRequirement = 0.3,
                MonsterId = 1,
                Type = "Buff,hRegen,Target,Negative",
                Power = 0.2,
                BuffOrEffectTarget = "Target",
            });

            context.Spells.Add(new Spell
            {
                Name = "Shadow Punch",
                ManaRequirement = 0.25,
                MonsterId = 1,
                Type = "Damage,Physical,Self",
                Power = 1.2,
                ResistanceAffect = 0.9,
            });

            context.Spells.Add(new Spell
            {
                Name = "Eye Of The Void",
                ManaRequirement = 0.25,
                MonsterId = 1,
                Type = "Buff,Armor,Target,Negative",
                Power = 0.33,
                BuffOrEffectTarget = "Target",
            });

            context.Spells.Add(new Spell
            {
                Name = "Ripping Hell-Fire",
                ManaRequirement = 0.65,
                MonsterId = 1,
                Type = "Damage,Magical,Self",
                Power = 1.42,
                ResistanceAffect = 0.88,
            });

            // Giant
            context.Spells.Add(new Spell
            {
                Name = "Overgrowth",
                ManaRequirement = 0.22,
                MonsterId = 4,
                Type = "Buff,Armor,Self,Positive",
                Power = 0.36,
                AdditionalEffect = "hRegen,Negative",
                EffectPower = 0.18,
                BuffOrEffectTarget = "Self",
            });

            context.Spells.Add(new Spell
            {
                Name = "Calming Mind",
                ManaRequirement = 0.12,
                MonsterId = 4,
                Type = "Buff,mRegen,Self,Positive",
                Power = 0.3,
                BuffOrEffectTarget = "Self",
            });

            context.Spells.Add(new Spell
            {
                Name = "Raging Mind",
                ManaRequirement = 0.4,
                MonsterId = 4,
                Type = "Buff,Attack,Self,Positive",
                Power = 0.3,
                AdditionalEffect = "Health,Negative",
                EffectPower = 0.18,
                BuffOrEffectTarget = "Self",
            });

            context.Spells.Add(new Spell
            {
                Name = "Overpowering Fist",
                ManaRequirement = 0.4,
                MonsterId = 4,
                Type = "Damage,Physical,Self",
                Power = 1.2,
                ResistanceAffect = 0.65,
            });

            // Gryphon
            context.Spells.Add(new Spell
            {
                Name = "Diving Claw",
                ManaRequirement = 0.3,
                MonsterId = 3,
                Type = "Damage,Physical,Self",
                Power = 1.18,
                ResistanceAffect = 0.5,
            });

            context.Spells.Add(new Spell
            {
                Name = "Petryfying Gaze",
                ManaRequirement = 0.5,
                MonsterId = 3,
                Type = "Buff,hRegen,Target,Negative",
                Power = 0.42,
                BuffOrEffectTarget = "Target",
            });

            context.Spells.Add(new Spell
            {
                Name = "Gust",
                ManaRequirement = 0.3,
                MonsterId = 3,
                Type = "Buff,Attack,Target,Negative",
                Power = 0.2,
                BuffOrEffectTarget = "Target",
            });

            context.Spells.Add(new Spell
            {
                Name = "Peck",
                ManaRequirement = 0.2,
                MonsterId = 3,
                Type = "Damage,Physical,Self",
                Power = 1.15,
                ResistanceAffect = 0.85,
            });

            // Reptile
            context.Spells.Add(new Spell
            {
                Name = "Poison Spit",
                ManaRequirement = 0.3,
                MonsterId = 8,
                Type = "Damage,Magical,Self",
                Power = 1.2,
                ResistanceAffect = 0.9,
            });

            context.Spells.Add(new Spell
            {
                Name = "Reflelcting Scales",
                ManaRequirement = 0.3,
                MonsterId = 8,
                Type = "Damage,Physical,Target",
                Power = 0.4,
                AdditionalEffect = "Armor,Positive",
                EffectPower = 0.25,
                BuffOrEffectTarget = "Self",
                ResistanceAffect = 1,
            });

            context.Spells.Add(new Spell
            {
                Name = "Skin Change",
                ManaRequirement = 0.3,
                MonsterId = 8,
                Type = "Buff,Res,Self,Positive",
                Power = 0.6,
                AdditionalEffect = "Armor,Negative",
                EffectPower = 0.25,
                BuffOrEffectTarget = "Self",
            });

            context.Spells.Add(new Spell
            {
                Name = "Scratch",
                ManaRequirement = 0.15,
                MonsterId = 8,
                Type = "Damage,Physical,Self",
                Power = 1.22,
                ResistanceAffect = 1,
            });

            // Saint
            context.Spells.Add(new Spell
            {
                Name = "Sacred Words",
                ManaRequirement = 0.4,
                MonsterId = 2,
                Type = "Heal,Magical,Self",
                Power = 1.8,
            });

            context.Spells.Add(new Spell
            {
                Name = "Illumination",
                ManaRequirement = 0.35,
                MonsterId = 2,
                Type = "Buff,Magic,Target,Negative",
                Power = 0.28,
                AdditionalEffect = "mRegen,Negative",
                EffectPower = 0.2,
                BuffOrEffectTarget = "Target",
            });

            context.Spells.Add(new Spell
            {
                Name = "Holy Smite",
                ManaRequirement = 0.12,
                MonsterId = 2,
                Type = "Damage,Magical,Self",
                Power = 1,
                ResistanceAffect = 1,
            });

            context.Spells.Add(new Spell
            {
                Name = "Judgement Day",
                ManaRequirement = 0.42,
                MonsterId = 2,
                Type = "Damage,Magical,Self",
                Power = 1.22,
                AdditionalEffect = "Mana,Negative",
                EffectPower = 0.2,
                BuffOrEffectTarget = "Target",
                ResistanceAffect = 0.5,
            });

            // Skeleton
            context.Spells.Add(new Spell
            {
                Name = "Tombstone",
                ManaRequirement = 0.15,
                MonsterId = 6,
                Type = "Buff,Res,Self,Positive",
                Power = 1.2,
                AdditionalEffect = "hRegen,Negative",
                EffectPower = 0.1,
                BuffOrEffectTarget = "Self",
            });

            context.Spells.Add(new Spell
            {
                Name = "Wrath Of The Necropolis",
                ManaRequirement = 0.4,
                MonsterId = 6,
                Type = "Damage,Physical/Magical,Self",
                Power = 1,
                SecondaryPower = 0.65,
                ResistanceAffect = 0.7,
            });

            context.Spells.Add(new Spell
            {
                Name = "Suffocation",
                ManaRequirement = 0.3,
                MonsterId = 6,
                Type = "Damage,Physical,Self",
                Power = 1.1,
                AdditionalEffect = "hRegen,Negative,mRegen,Negative",
                EffectPower = 0.12,
                SecondaryPower = 0.15,
                BuffOrEffectTarget = "Target",
                ResistanceAffect = 0,
            });

            context.Spells.Add(new Spell
            {
                Name = "Horrifying Scream",
                ManaRequirement = 0.3,
                MonsterId = 6,
                Type = "Buff,Attack,Target,Negative",
                Power = 0.2,
                BuffOrEffectTarget = "Target",
            });

            // Wyrm
            context.Spells.Add(new Spell
            {
                Name = "Tidal Slash",
                ManaRequirement = 0.18,
                MonsterId = 5,
                Type = "Damage,Physical,Self",
                Power = 1.15,
                AdditionalEffect = "Magic,Positive",
                EffectPower = 0.2,
                BuffOrEffectTarget = "Self",
                ResistanceAffect = 1,
            });

            context.Spells.Add(new Spell
            {
                Name = "Dive",
                ManaRequirement = 0.3,
                MonsterId = 5,
                Type = "Buff,Armor,Self,Positive",
                Power = 0.2,
                AdditionalEffect = "Res,Positive",
                EffectPower = 0.35,
                BuffOrEffectTarget = "Self",
            });

            context.Spells.Add(new Spell
            {
                Name = "Hyper Speed",
                ManaRequirement = 0.3,
                MonsterId = 5,
                Type = "Buff,mRegen,Self,Positve",
                Power = 0.6,
                BuffOrEffectTarget = "Self",
            });

            context.Spells.Add(new Spell
            {
                Name = "Thunder",
                ManaRequirement = 0.5,
                MonsterId = 5,
                Type = "Damage,Magical,Self",
                Power = 1.3,
                AdditionalEffect = "Res,Negative",
                EffectPower = 0.28,
                BuffOrEffectTarget = "Target",
                ResistanceAffect = 0.8,
            });

            // Zombie
            context.Spells.Add(new Spell
            {
                Name = "Infecting Bite",
                ManaRequirement = 0.4,
                MonsterId = 7,
                Type = "Damage,Physical,Self",
                Power = 1,
                AdditionalEffect = "hRegen,Negative",
                EffectPower = 1,
                BuffOrEffectTarget = "Target",
                ResistanceAffect = 1,
            });

            context.Spells.Add(new Spell
            {
                Name = "Feed",
                ManaRequirement = 0.3,
                MonsterId = 7,
                Type = "Damage,Physical,Self",
                Power = 1.2,
                AdditionalEffect = "Health,Positive",
                EffectPower = 0.25,
                BuffOrEffectTarget = "Self",
                ResistanceAffect = 1,
            });

            context.Spells.Add(new Spell
            {
                Name = "Mutation",
                ManaRequirement = 0.4,
                MonsterId = 7,
                Type = "Buff,Attack,Self,Positive",
                Power = 0.4,
                AdditionalEffect = "mRegen,Positive",
                EffectPower = 0.6,
                BuffOrEffectTarget = "Self",
            });

            context.Spells.Add(new Spell
            {
                Name = "Decay",
                ManaRequirement = 0.15,
                MonsterId = 7,
                Type = "Buff,Armor,Self,Positive",
                Power = 0.5,
                AdditionalEffect = "hRegen,Negative",
                EffectPower = 0.2,
                BuffOrEffectTarget = "Self",
            });

            await context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedPlayerSpellsAsync(FFDbContext context, CancellationToken cancellationToken)
        {
            // Hunter
            context.Spells.Add(new Spell
            {
                Name = "Hasting Arrow",
                ManaRequirement = 0.12,
                FightingClassId = 8,
                Type = "Damage,Physical,Self",
                Power = 1.2,
                ResistanceAffect = 1,
                AdditionalEffect = "Crit,Positive",
                BuffOrEffectTarget = "Self",
                EffectPower = 0.05,
            });

            context.Spells.Add(new Spell
            {
                Name = "Grass Hop",
                ManaRequirement = 0.5,
                FightingClassId = 8,
                Type = "Buff,Armor,Self,Positive",
                Power = 0.7,
                BuffOrEffectTarget = "Self",
            });

            context.Spells.Add(new Spell
            {
                Name = "Poison Shot",
                ManaRequirement = 0.25,
                FightingClassId = 8,
                Type = "Damage,Physical/Magical,Self",
                Power = 0.5,
                SecondaryPower = 0.7,
                ResistanceAffect = 0.5,
            });

            context.Spells.Add(new Spell
            {
                Name = "Sharp Eye",
                ManaRequirement = 0.5,
                FightingClassId = 8,
                Type = "Buff,Attack,Self,Positive",
                Power = 0.3,
                BuffOrEffectTarget = "Self",
            });

            // Mage
            context.Spells.Add(new Spell
            {
                Name = "Water Ball",
                ManaRequirement = 0.2,
                FightingClassId = 7,
                Type = "Damage,Magical,Self",
                Power = 0.7,
                AdditionalEffect = "mRegen,Positive",
                EffectPower = 0.22,
                BuffOrEffectTarget = "Self",
                ResistanceAffect = 1,
            });

            context.Spells.Add(new Spell
            {
                Name = "Fire Ball",
                ManaRequirement = 0.25,
                FightingClassId = 7,
                Type = "Damage,Magical/MaxHP,Self/Target",
                Power = 0.8,
                SecondaryPower = 0.05,
                AdditionalEffect = "hRegen,Negative",
                EffectPower = 0.35,
                BuffOrEffectTarget = "Target",
                ResistanceAffect = 0.7,
            });

            context.Spells.Add(new Spell
            {
                Name = "Mana Conversion",
                ManaRequirement = 0,
                FightingClassId = 7,
                Type = "Buff,Mana,Self,Positive",
                Power = 0.25,
                AdditionalEffect = "Armor,Negative",
                EffectPower = 0.2,
                BuffOrEffectTarget = "Self/Target",
            });

            context.Spells.Add(new Spell
            {
                Name = "All-Out Blast!",
                ManaRequirement = 0.8,
                FightingClassId = 7,
                Type = "Damage,Magical,Self",
                Power = 2,
                AdditionalEffect = "mRegen,Negative",
                EffectPower = 0.2,
                BuffOrEffectTarget = "Self",
                ResistanceAffect = 0,
            });

            // Naturalist
            context.Spells.Add(new Spell
            {
                Name = "Nature's Touch",
                ManaRequirement = 0.4,
                FightingClassId = 6,
                Type = "Heal,Magical,Self",
                Power = 0.5,
                AdditionalEffect = "Armor,Positive",
                EffectPower = 0.3,
                BuffOrEffectTarget = "Self",
            });

            context.Spells.Add(new Spell
            {
                Name = "Thorn Blast",
                ManaRequirement = 0.28,
                FightingClassId = 6,
                Type = "Damage,Magical,Self",
                Power = 0.75,
                AdditionalEffect = "Armor,Negative",
                EffectPower = 0.3,
                BuffOrEffectTarget = "Target",
                ResistanceAffect = 1,
            });

            context.Spells.Add(new Spell
            {
                Name = "Nature's Gift",
                ManaRequirement = 0,
                FightingClassId = 6,
                Type = "Buff,hRegen,Self,Positive",
                Power = 1.2,
                AdditionalEffect = "Magic,Positive,Health,Negative",
                EffectPower = 0.1,
                SecondaryPower = 0.05,
                BuffOrEffectTarget = "Caster/Target",
            });

            context.Spells.Add(new Spell
            {
                Name = "Pouring Rain",
                ManaRequirement = 0,
                FightingClassId = 6,
                Type = "Buff,Mana,Self,Positive",
                Power = 0.3,
                AdditionalEffect = "mRegen,Negative",
                EffectPower = 0.15,
                BuffOrEffectTarget = "Caster",
            });

            // Necroid
            context.Spells.Add(new Spell
            {
                Name = "Shadow Touch",
                ManaRequirement = 0.28,
                FightingClassId = 5,
                Type = "Damage,CurrentMana/MaxHP,Self/Target",
                Power = 0.11,
                SecondaryPower = 0.08,
                AdditionalEffect = "Res,Negative",
                EffectPower = 0.3,
                BuffOrEffectTarget = "Target",
                ResistanceAffect = 1,
            });

            context.Spells.Add(new Spell
            {
                Name = "Life Syphon",
                ManaRequirement = 0.4,
                FightingClassId = 5,
                Type = "Damage,Magical/MaxHP,Self/Target",
                Power = 0.5,
                SecondaryPower = 0.08,
                AdditionalEffect = "Health,Positive",
                EffectPower = 0.1,
                BuffOrEffectTarget = "Self",
                ResistanceAffect = 1,
            });

            context.Spells.Add(new Spell
            {
                Name = "Arcane Bane",
                ManaRequirement = 0.2,
                FightingClassId = 5,
                Type = "Buff,Magic,Target,Negative",
                Power = 0.2,
                BuffOrEffectTarget = "Target",
            });

            context.Spells.Add(new Spell
            {
                Name = "Mutual Darkness",
                ManaRequirement = 0,
                FightingClassId = 5,
                Type = "Damage,MaxHP,Self",
                Power = 0.15,
                AdditionalEffect = "Health,Negative",
                EffectPower = 0.07,
                BuffOrEffectTarget = "Self",
                ResistanceAffect = 1,
            });

            // Paladin
            context.Spells.Add(new Spell
            {
                Name = "Holy Strike",
                ManaRequirement = 0.15,
                FightingClassId = 4,
                Type = "Damage,Physical,Self",
                Power = 1,
                AdditionalEffect = "Magic,Positive",
                EffectPower = 0.1,
                BuffOrEffectTarget = "Self",
                ResistanceAffect = 0.7,
            });

            context.Spells.Add(new Spell
            {
                Name = "Burning Light",
                ManaRequirement = 0.15,
                FightingClassId = 4,
                Type = "Damage,Magical,Self",
                Power = 1.1,
                ResistanceAffect = 1,
            });

            context.Spells.Add(new Spell
            {
                Name = "Vicious Spell-Guard",
                ManaRequirement = 0.35,
                FightingClassId = 4,
                Type = "Buff,Res,Self,Positive",
                Power = 0.55,
                BuffOrEffectTarget = "Self",
            });

            context.Spells.Add(new Spell
            {
                Name = "Divine Rune",
                ManaRequirement = 0.2,
                FightingClassId = 4,
                Type = "Buff,Attack,Self,Positive",
                Power = 0.15,
                BuffOrEffectTarget = "Self",
            });

            // Priest
            context.Spells.Add(new Spell
            {
                Name = "Holy Light",
                ManaRequirement = 0.3,
                FightingClassId = 3,
                Type = "Heal,Magical,Self",
                Power = 1.1,
            });

            context.Spells.Add(new Spell
            {
                Name = "Mana Drain",
                ManaRequirement = 0.08,
                FightingClassId = 3,
                Type = "Buff,Mana,Target,Negative",
                Power = 0.2,
                AdditionalEffect = "Mana,Positive",
                SecondaryPower = 0.2,
                BuffOrEffectTarget = "Target/Self",
            });

            context.Spells.Add(new Spell
            {
                Name = "Staff Smash",
                ManaRequirement = 0.14,
                FightingClassId = 3,
                Type = "Damage,Physical,Self",
                Power = 1.2,
                AdditionalEffect = "Armor,Negative",
                EffectPower = 0.18,
                BuffOrEffectTarget = "Target",
                ResistanceAffect = 1,
            });

            context.Spells.Add(new Spell
            {
                Name = "Blessing",
                ManaRequirement = 0.35,
                FightingClassId = 3,
                Type = "Buff,Magic,Self,Positive",
                Power = 0.25,
                AdditionalEffect = "hRegen,Negative",
                EffectPower = 0.4,
                BuffOrEffectTarget = "Self",
            });

            // Rogue
            context.Spells.Add(new Spell
            {
                Name = "Stab",
                ManaRequirement = 0.12,
                FightingClassId = 2,
                Type = "Damage,Physical,Self",
                Power = 1.05,
                AdditionalEffect = "Attack,Positive",
                EffectPower = 0.08,
                BuffOrEffectTarget = "Self",
                ResistanceAffect = 1,
            });

            context.Spells.Add(new Spell
            {
                Name = "Poison Dagger",
                ManaRequirement = 0.28,
                FightingClassId = 2,
                Type = "Damage,Physical/Magical,Self",
                Power = 0.2,
                SecondaryPower = 1.1,
                ResistanceAffect = 0.6,
            });

            context.Spells.Add(new Spell
            {
                Name = "Evasion",
                ManaRequirement = 0.4,
                FightingClassId = 2,
                Type = "Buff,Armor,Self,Positive",
                Power = 0.55,
                AdditionalEffect = "mRegen,Positive",
                EffectPower = 0.35,
                BuffOrEffectTarget = "Self",
            });

            context.Spells.Add(new Spell
            {
                Name = "Thievery",
                ManaRequirement = 0.45,
                FightingClassId = 2,
                Type = "Buff,Gold,Self,Positive",
                Power = 4,
                BuffOrEffectTarget = "Self",
            });

            // Shaman
            context.Spells.Add(new Spell
            {
                Name = "Thunder Strike",
                ManaRequirement = 0.45,
                FightingClassId = 1,
                Type = "Damage,Magical/Physical,Self",
                Power = 1.2,
                SecondaryPower = 0.2,
                AdditionalEffect = "Res,Negative",
                EffectPower = 0.4,
                ResistanceAffect = 1,
                BuffOrEffectTarget = "Target",
            });

            context.Spells.Add(new Spell
            {
                Name = "Earth Strike",
                ManaRequirement = 0.45,
                FightingClassId = 1,
                Type = "Damage,Physical/Magical,Self",
                Power = 1.2,
                SecondaryPower = 0.2,
                AdditionalEffect = "Health,Positive",
                EffectPower = 0.08,
                ResistanceAffect = 1,
                BuffOrEffectTarget = "Self",
            });

            context.Spells.Add(new Spell
            {
                Name = "Flame Strike",
                ManaRequirement = 0.25,
                FightingClassId = 1,
                Type = "Damage,Physical/Magical,Self",
                Power = 1.15,
                SecondaryPower = 0.11,
                AdditionalEffect = "Attack,Positive",
                EffectPower = 0.15,
                ResistanceAffect = 1,
                BuffOrEffectTarget = "Self",
            });
            context.Spells.Add(new Spell
            {
                Name = "Water Strike",
                ManaRequirement = 0.24,
                FightingClassId = 1,
                Type = "Damage,Magical,Self",
                Power = 1.1,
                AdditionalEffect = "mRegen,Positive",
                EffectPower = 0.22,
                ResistanceAffect = 1,
                BuffOrEffectTarget = "Self",
            });

            // Warrior
            context.Spells.Add(new Spell
            {
                Name = "Head Smash",
                ManaRequirement = 0.35,
                FightingClassId = 9,
                Type = "Damage,Physical,Self",
                Power = 1.3,
                AdditionalEffect = "Health,Negative",
                EffectPower = 0.08,
                ResistanceAffect = 1,
                BuffOrEffectTarget = "Self",
            });

            context.Spells.Add(new Spell
            {
                Name = "Hyper Strength",
                ManaRequirement = 0.35,
                FightingClassId = 9,
                Type = "Buff,Attack,Self,Positive",
                Power = 0.2,
                BuffOrEffectTarget = "Self",
            });

            context.Spells.Add(new Spell
            {
                Name = "Raging Blow",
                ManaRequirement = 0.13,
                FightingClassId = 9,
                Type = "Damage,Physical,Self",
                Power = 1,
                AdditionalEffect = "mRegen,Positive",
                EffectPower = 0.24,
                ResistanceAffect = 0.8,
                BuffOrEffectTarget = "Self",
            });

            context.Spells.Add(new Spell
            {
                Name = "Disarm",
                ManaRequirement = 0.50,
                FightingClassId = 9,
                Type = "Buff,Attack,Target,Negative",
                Power = 0.2,
                BuffOrEffectTarget = "Target",
            });

            await context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedStatusesAsync(FFDbContext context, CancellationToken cancellationToken)
        {
            context.Statuses.Add(new Status
            {
                DisplayName = "UnSet",
                IClass = "far fa-meh-blank",
            });

            context.Statuses.Add(new Status
            {
                DisplayName = "Meh",
                IClass = "far fa-meh",
            });

            context.Statuses.Add(new Status
            {
                DisplayName = "Happy",
                IClass = "far fa-smile",
            });

            context.Statuses.Add(new Status
            {
                DisplayName = "Star",
                IClass = "far fa-grin-stars",
            });

            context.Statuses.Add(new Status
            {
                DisplayName = "Tired",
                IClass = "far fa-tired",
            });

            context.Statuses.Add(new Status
            {
                DisplayName = "In Love",
                IClass = "far fa-grin-hearts",
            });

            context.Statuses.Add(new Status
            {
                DisplayName = "Fresh",
                IClass = "far fa-grin-tongue-wink",
            });

            context.Statuses.Add(new Status
            {
                DisplayName = "Status",
                IClass = "far fa-frown",
            });

            context.Statuses.Add(new Status
            {
                DisplayName = "WTF",
                IClass = "fas fa-flushed",
            });

            context.Statuses.Add(new Status
            {
                DisplayName = "LUL",
                IClass = "far fa-grin-squint-tears",
            });

            context.Statuses.Add(new Status
            {
                DisplayName = "Angry",
                IClass = "far fa-angry",
            });

            context.Statuses.Add(new Status
            {
                DisplayName = "Focused",
                IClass = "fas fa-podcast",
            });

            context.Statuses.Add(new Status
            {
                DisplayName = "Chilling",
                IClass = "far fa-hand-peace",
            });

            context.Statuses.Add(new Status
            {
                DisplayName = "Home With My Cat",
                IClass = "fas fa-cat",
            });

            context.Statuses.Add(new Status
            {
                DisplayName = "Home With My Dog",
                IClass = "fas fa-dog",
            });

            context.Statuses.Add(new Status
            {
                DisplayName = "Having A Snack",
                IClass = "fas fa-drumstick-bite",
            });

            context.Statuses.Add(new Status
            {
                DisplayName = "9000+ IQ",
                IClass = "fas fa-brain",
            });

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
