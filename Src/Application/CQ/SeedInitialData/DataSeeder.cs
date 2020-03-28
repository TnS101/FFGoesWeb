namespace Application.SeedInitialData
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities.Common.Social;
    using Domain.Entities.Game.Units;
    using Domain.Entities.Moderation;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using global::Common;
    using global::Domain.Entities.Common;

    public class DataSeeder
    {
        private readonly IFFDbContext context;

        public DataSeeder(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task SeedAsync(CancellationToken cancellationToken)
        {
            await this.SeedUsersAsync(cancellationToken);

            await this.SeedPlayerSpellsAsync(cancellationToken);

            await this.SeedFigthingClassesAsync(cancellationToken);

            await this.SeedEnemySpellsAsync(cancellationToken);

            await this.SeedMonstersAsync(cancellationToken);

            await this.SeedMonsterRaritiesAsync(cancellationToken);

            await this.SeedSampleDataAsync(cancellationToken);

            await this.SeedStatusesAsync(cancellationToken);
        }

        private async Task SeedSampleDataAsync(CancellationToken cancellationToken)
        {
            this.context.Tickets.Add(new Ticket
            {
                AdditionalInformation = string.Format(GConst.SampleEntityDescription, "ticket"),
            });

            this.context.Feedbacks.Add(new Feedback
            {
                Content = string.Format(GConst.SampleEntityDescription, "feedback"),
            });

            this.context.Feedbacks.Add(new Feedback
            {
                Content = string.Format(GConst.SampleEntityDescription, "feedback"),
                IsAccepted = true,
            });

            await this.context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedUsersAsync(CancellationToken cancellationToken)
        {
            this.context.AppUsers.Add(new AppUser
            {
                UserName = "Pesho the Slayer [Not a real user]",
                Heroes = new List<Hero>(),
            });

            await this.context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedMonsterRaritiesAsync(CancellationToken cancellationToken)
        {
            this.context.MonsterRarities.Add(new MonsterRarity
            {
                MonsterName = "Beast",
                Rarity = "Rare",
                ImageURL = "https://i.ibb.co/YhPcrdk/Beast-Rare.png",
                StatAmplifier = 0.15,
            });

            this.context.MonsterRarities.Add(new MonsterRarity
            {
                MonsterName = "Beast",
                Rarity = "Heroic",
                ImageURL = "https://i.ibb.co/NVdyxh5/Bear-Heroic.png",
                StatAmplifier = 0.3,
            });

            this.context.MonsterRarities.Add(new MonsterRarity
            {
                MonsterName = "Demon",
                Rarity = "Rare",
                ImageURL = "https://i.ibb.co/tYPNYVr/Demon-Rare.png",
                StatAmplifier = 0.15,
            });

            this.context.MonsterRarities.Add(new MonsterRarity
            {
                MonsterName = "Demon",
                Rarity = "Heroic",
                ImageURL = "https://i.ibb.co/rHVZhHM/Demon-Heroic.png",
                StatAmplifier = 0.3,
            });

            this.context.MonsterRarities.Add(new MonsterRarity
            {
                MonsterName = "Giant",
                Rarity = "Rare",
                ImageURL = "https://i.ibb.co/8XjdXby/Giant-Rare.png",
                StatAmplifier = 0.15,
            });

            this.context.MonsterRarities.Add(new MonsterRarity
            {
                MonsterName = "Giant",
                Rarity = "Heroic",
                ImageURL = "https://i.ibb.co/XjvgFxk/Giant-Heroic.png",
                StatAmplifier = 0.3,
            });

            this.context.MonsterRarities.Add(new MonsterRarity
            {
                MonsterName = "Gryphon",
                Rarity = "Rare",
                ImageURL = "https://i.ibb.co/1J3KskV/Gryphon-Rare.png",
                StatAmplifier = 0.15,
            });

            this.context.MonsterRarities.Add(new MonsterRarity
            {
                MonsterName = "Gryphon",
                Rarity = "Heroic",
                ImageURL = "https://i.ibb.co/8dbFYx7/Gryphon-Heroic.png",
                StatAmplifier = 0.3,
            });

            this.context.MonsterRarities.Add(new MonsterRarity
            {
                MonsterName = "Reptile",
                Rarity = "Rare",
                ImageURL = "https://i.ibb.co/59VHzwY/Reptile-Rare.png",
                StatAmplifier = 0.15,
            });

            this.context.MonsterRarities.Add(new MonsterRarity
            {
                MonsterName = "Reptile",
                Rarity = "Heroic",
                ImageURL = "https://i.ibb.co/wd1HqhQ/Reptile-Heroic.png",
                StatAmplifier = 0.3,
            });

            this.context.MonsterRarities.Add(new MonsterRarity
            {
                MonsterName = "Saint",
                Rarity = "Rare",
                ImageURL = "https://i.ibb.co/tJQKJcx/Saint-Rare.png",
                StatAmplifier = 0.15,
            });

            this.context.MonsterRarities.Add(new MonsterRarity
            {
                MonsterName = "Saint",
                Rarity = "Heroic",
                ImageURL = "https://i.ibb.co/dgGbS3t/Saint-Heroic.png",
                StatAmplifier = 0.3,
            });

            this.context.MonsterRarities.Add(new MonsterRarity
            {
                MonsterName = "Skeleton",
                Rarity = "Rare",
                ImageURL = "https://i.ibb.co/rQPCZWf/Skeleton-Rare.png",
                StatAmplifier = 0.15,
            });

            this.context.MonsterRarities.Add(new MonsterRarity
            {
                MonsterName = "Skeleton",
                Rarity = "Heroic",
                ImageURL = "https://i.ibb.co/TqDMrY5/Skeleton-Heroic.png",
                StatAmplifier = 0.3,
            });

            this.context.MonsterRarities.Add(new MonsterRarity
            {
                MonsterName = "Wyrm",
                Rarity = "Rare",
                ImageURL = "https://i.ibb.co/BgjswQW/WyrmRare.png",
                StatAmplifier = 0.15,
            });

            this.context.MonsterRarities.Add(new MonsterRarity
            {
                MonsterName = "Wyrm",
                Rarity = "Heroic",
                ImageURL = "https://i.ibb.co/V9gh3KY/Wyrm-Heroic.png",
                StatAmplifier = 0.3,
            });

            this.context.MonsterRarities.Add(new MonsterRarity
            {
                MonsterName = "Zombie",
                Rarity = "Rare",
                ImageURL = "https://i.ibb.co/3rJB9hG/Zombie-Rare.png",
                StatAmplifier = 0.15,
            });

            this.context.MonsterRarities.Add(new MonsterRarity
            {
                MonsterName = "Zombie",
                Rarity = "Heroic",
                ImageURL = "https://i.ibb.co/9crHfr7/Zombie-Heroic.png",
                StatAmplifier = 0.3,
            });

            await this.context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedMonstersAsync(CancellationToken cancellationToken)
        {
            this.context.Monsters.Add(new Monster
            {
                Name = "Beast",
                MaxHP = 110,
                HealthRegen = 2,
                MaxMana = 75,
                ManaRegen = 5,
                AttackPower = 12,
                MagicPower = 5,
                ArmorValue = 5,
                RessistanceValue = 1,
                CritChance = 2,
                ImageURL = "https://i.ibb.co/tm9p0Bq/Beast.png",
                Description = "A bloodthirsty animal,which also likes to party for some reason...",
            });

            this.context.Monsters.Add(new Monster
            {
                Name = "Reptile",
                MaxHP = 70,
                HealthRegen = 1,
                MaxMana = 60,
                ManaRegen = 7,
                AttackPower = 14,
                MagicPower = 5,
                ArmorValue = 3,
                RessistanceValue = 3,
                CritChance = 5,
                ImageURL = "https://i.ibb.co/PskPtmp/Reptile.png",
                Description = "Actually kind of a dinosaur/lizard thingy... not very sure.",
            });

            this.context.Monsters.Add(new Monster
            {
                Name = "Zombie",
                MaxHP = 105,
                HealthRegen = 5,
                MaxMana = 80,
                ManaRegen = 5,
                AttackPower = 12,
                MagicPower = 3,
                ArmorValue = 2.6,
                RessistanceValue = 2,
                CritChance = 2,
                ImageURL = "https://i.ibb.co/NLF8yxW/Zombie.png",
                Description = "Sapiosexual. Not very smart.",
            });

            this.context.Monsters.Add(new Monster
            {
                Name = "Skeleton",
                MaxHP = 80,
                HealthRegen = 10,
                MaxMana = 80,
                ManaRegen = 3,
                AttackPower = 18,
                MagicPower = 3,
                ArmorValue = 1,
                RessistanceValue = 2,
                CritChance = 9,
                ImageURL = "https://i.ibb.co/72jY07Q/Skeleton.png",
                Description = "{Insert a /Spooky/ joke here.}",
            });

            this.context.Monsters.Add(new Monster
            {
                Name = "Wyrm",
                MaxHP = 110,
                HealthRegen = 2,
                MaxMana = 95,
                ManaRegen = 18,
                AttackPower = 10,
                MagicPower = 15,
                ArmorValue = 5,
                RessistanceValue = 2,
                CritChance = 3,
                ImageURL = "https://i.ibb.co/0QcMBhp/Wyrm.png",
                Description = "Picture this guy beneath the toilet seat next time you take a dump. I dare you!",
            });

            this.context.Monsters.Add(new Monster
            {
                Name = "Giant",
                MaxHP = 200,
                HealthRegen = 1,
                MaxMana = 90,
                ManaRegen = 10,
                AttackPower = 9,
                MagicPower = 5,
                ArmorValue = 5,
                RessistanceValue = 5,
                CritChance = 3,
                ImageURL = "https://i.ibb.co/HpF09kD/Giant.png",
                Description = "Not to be confused with the Iron Giant.",
            });

            this.context.Monsters.Add(new Monster
            {
                Name = "Gryphon",
                MaxHP = 90,
                HealthRegen = 2,
                MaxMana = 110,
                ManaRegen = 8,
                AttackPower = 15,
                MagicPower = 5,
                ArmorValue = 4,
                RessistanceValue = 4,
                CritChance = 10,
                ImageURL = "https://i.ibb.co/ydLmqmL/Gryphon.png",
                Description = "These halfbreeds don't just exist in World of Warcraft!",
            });

            this.context.Monsters.Add(new Monster
            {
                Name = "Saint",
                MaxHP = 170,
                HealthRegen = 5,
                MaxMana = 120,
                ManaRegen = 10,
                AttackPower = 10,
                MagicPower = 22,
                ArmorValue = 3,
                RessistanceValue = 8,
                CritChance = 8,
                ImageURL = "https://i.ibb.co/bgdLZny/Saint.png",
                Description = "You'll pay for not going to church on sundays!",
            });

            this.context.Monsters.Add(new Monster
            {
                Name = "Demon",
                MaxHP = 150,
                HealthRegen = 4,
                MaxMana = 115,
                ManaRegen = 6,
                AttackPower = 20,
                MagicPower = 8,
                ArmorValue = 8,
                RessistanceValue = 4,
                CritChance = 5,
                ImageURL = "https://i.ibb.co/Mf1WWjq/Demon.png",
                Description = "Fearsome and cunning! Something is wrong with his head (I mean the PNG file).",
            });

            await this.context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedFigthingClassesAsync(CancellationToken cancellationToken)
        {
            this.context.FightingClasses.Add(new FightingClass
            {
                ClassType = "Warrior",
                MaxHP = 240,
                HealthRegen = 2,
                MaxMana = 100,
                ManaRegen = 5,
                AttackPower = 25,
                MagicPower = 10,
                ArmorValue = 5,
                RessistanceValue = 3,
                CritChance = 3,
                ImageURL = "https://i.ibb.co/XVJ5cHJ/Warrior.png",
                Description = "If you want to spam one button and lose brain cells simultaneously, you should probably play CS: GO." +
                "Main Stat: Strength.",
                IconURL = "https://i.ibb.co/wyMw3jR/Warrior-Icon.png",
            });
            this.context.FightingClasses.Add(new FightingClass
            {
                ClassType = "Hunter",
                MaxHP = 200,
                HealthRegen = 2,
                MaxMana = 100,
                ManaRegen = 5,
                AttackPower = 32,
                MagicPower = 12,
                ArmorValue = 3.5,
                RessistanceValue = 2.5,
                CritChance = 6,
                ImageURL = "https://i.ibb.co/DDPXJbv/Hunter.png",
                Description = "He could have a shotgun but that would be way too much OP." +
               "Main Stat: Agility.",
                IconURL = "https://i.ibb.co/FDj0HbP/Hunter-Icon.png",
            });
            this.context.FightingClasses.Add(new FightingClass
            {
                ClassType = "Mage",
                MaxHP = 200,
                HealthRegen = 3,
                MaxMana = 130,
                ManaRegen = 10,
                AttackPower = 18,
                MagicPower = 26,
                ArmorValue = 2,
                RessistanceValue = 8,
                CritChance = 2,
                ImageURL = "https://i.ibb.co/n6q7zgb/Mage.png",
                Description = "Like cards? Go to Vegas. Like bunnies? Open a rabbit farm. Want to 1-shot someone? [CLICK ME]!" +
                "Main Stat: Intellect.",
                IconURL = "https://i.ibb.co/k55MXgG/MageIcon.png",
            });
            this.context.FightingClasses.Add(new FightingClass
            {
                ClassType = "Naturalist",
                MaxHP = 220,
                HealthRegen = 3,
                MaxMana = 120,
                ManaRegen = 12,
                AttackPower = 15,
                MagicPower = 28,
                ArmorValue = 5,
                RessistanceValue = 2.2,
                CritChance = 2,
                ImageURL = "https://i.ibb.co/Ht6ZBtv/Druid.png",
                Description = "Don't worry. I've already donated 5 bucks to that *Beast* guy." +
                "Main Stat: Spirit.",
                IconURL = "https://i.ibb.co/gmK4VjW/Druid-Icon.png",
            });
            this.context.FightingClasses.Add(new FightingClass
            {
                ClassType = "Necroid",
                MaxHP = 180,
                HealthRegen = 4,
                MaxMana = 140,
                ManaRegen = 10,
                AttackPower = 15,
                MagicPower = 30,
                ArmorValue = 2.5,
                RessistanceValue = 2,
                CritChance = 2,
                ImageURL = "https://i.ibb.co/Ms0bv1v/Necroid.png",
                Description = "Actually, you don't wanna know about this guy. I've warned you." +
                "Main Stat: Intellect.",
                IconURL = "https://i.ibb.co/0rf3kG3/Necroid-Icon.png",
            });
            this.context.FightingClasses.Add(new FightingClass
            {
                ClassType = "Paladin",
                MaxHP = 220,
                HealthRegen = 2,
                MaxMana = 110,
                ManaRegen = 6,
                AttackPower = 22,
                MagicPower = 18,
                ArmorValue = 4,
                RessistanceValue = 5,
                CritChance = 3,
                ImageURL = "https://i.ibb.co/yNX0SZn/Paladin.png",
                Description = "Damage? Got it. Health? Got it. Girlfriend? ... :(" +
               "Main Stat: Strength.",
                IconURL = "https://i.ibb.co/yVVp9Md/Paladin-Icon.png",
            });
            this.context.FightingClasses.Add(new FightingClass
            {
                ClassType = "Priest",
                MaxHP = 170,
                HealthRegen = 5,
                MaxMana = 180,
                ManaRegen = 10,
                AttackPower = 15,
                MagicPower = 30,
                ArmorValue = 2,
                RessistanceValue = 4,
                CritChance = 2,
                ImageURL = "https://i.ibb.co/xhDTxW6/Priest.png",
                Description = "Don't worry. He won't molest you." +
               "Main Stat: Spirit.",
                IconURL = "https://i.ibb.co/pWd8pbq/Priest-Icon.png",
            });
            this.context.FightingClasses.Add(new FightingClass
            {
                ClassType = "Rogue",
                MaxHP = 180,
                HealthRegen = 3,
                MaxMana = 100,
                ManaRegen = 5,
                AttackPower = 33,
                MagicPower = 8,
                ArmorValue = 3,
                RessistanceValue = 1,
                CritChance = 8,
                ImageURL = "https://i.ibb.co/K5YgbHG/Rogue.png",
                Description = "He steals money. Enough said, you greedy bastard." +
               "Main Stat: Agility.",
                IconURL = string.Empty,
            });
            this.context.FightingClasses.Add(new FightingClass
            {
                ClassType = "Shaman",
                MaxHP = 180,
                HealthRegen = 2,
                MaxMana = 115,
                ManaRegen = 12,
                AttackPower = 20,
                MagicPower = 20,
                ArmorValue = 3,
                RessistanceValue = 5,
                CritChance = 2,
                ImageURL = "https://i.ibb.co/fStYvFC/Shaman.png",
                Description = "Freezing, zapping and stoning people to death was never such fun." +
               "Main Stat: Stamina.",
                IconURL = "https://i.ibb.co/kDrCmXw/Shaman-Icon.png",
            });

            await this.context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedEnemySpellsAsync(CancellationToken cancellationToken)
        {
            // Beast
            this.context.Spells.Add(new Spell
            {
                Name = "Furious Roar",
                ManaRequirment = 20,
                ClassType = "Beast",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Bite",
                ManaRequirment = 20,
                ClassType = "Beast",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Thick Hide",
                ManaRequirment = 50,
                ClassType = "Beast",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Lick Wounds",
                ManaRequirment = 20,
                ClassType = "Beast",
                UserType = "Enemy",
            });

            // Demon
            this.context.Spells.Add(new Spell
            {
                Name = "Corruption",
                ManaRequirment = 30,
                ClassType = "Demon",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Shadow Blast",
                ManaRequirment = 30,
                ClassType = "Demon",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Eye Of The Void",
                ManaRequirment = 20,
                ClassType = "Demon",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Ripping Hell-Fire",
                ManaRequirment = 80,
                ClassType = "Demon",
                UserType = "Enemy",
            });

            // Giant
            this.context.Spells.Add(new Spell
            {
                Name = "Overgrowth",
                ManaRequirment = 40,
                ClassType = "Giant",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Calming Mind",
                ManaRequirment = 10,
                ClassType = "Giant",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Raging Mind",
                ManaRequirment = 50,
                ClassType = "Giant",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Overpowering Fist",
                ManaRequirment = 50,
                ClassType = "Giant",
                UserType = "Enemy",
            });

            // Gryphon
            this.context.Spells.Add(new Spell
            {
                Name = "Diving Claw",
                ManaRequirment = 30,
                ClassType = "Gryphon",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Petryfying Gaze",
                ManaRequirment = 50,
                ClassType = "Gryphon",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Gust",
                ManaRequirment = 30,
                ClassType = "Gryphon",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Peck",
                ManaRequirment = 30,
                ClassType = "Gryphon",
                UserType = "Enemy",
            });

            // Reptile
            this.context.Spells.Add(new Spell
            {
                Name = "Poison Spit",
                ManaRequirment = 30,
                ClassType = "Reptile",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Reflelcting Scales",
                ManaRequirment = 30,
                ClassType = "Reptile",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Skin Change",
                ManaRequirment = 40,
                ClassType = "Reptile",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Scratch",
                ManaRequirment = 15,
                ClassType = "Reptile",
                UserType = "Enemy",
            });

            // Saint
            this.context.Spells.Add(new Spell
            {
                Name = "Sacred Words",
                ManaRequirment = 40,
                ClassType = "Saint",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Illumination",
                ManaRequirment = 30,
                ClassType = "Saint",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Holy Smite",
                ManaRequirment = 15,
                ClassType = "Saint",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Judgement Day",
                ManaRequirment = 50,
                ClassType = "Saint",
                UserType = "Enemy",
            });

            // Skeleton
            this.context.Spells.Add(new Spell
            {
                Name = "Tombstone",
                ManaRequirment = 30,
                ClassType = "Skeleton",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Wrath Of The Necropolis",
                ManaRequirment = 50,
                ClassType = "Skeleton",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Suffocation",
                ManaRequirment = 30,
                ClassType = "Skeleton",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Horrifying Scream",
                ManaRequirment = 30,
                ClassType = "Skeleton",
                UserType = "Enemy",
            });

            // Wyrm
            this.context.Spells.Add(new Spell
            {
                Name = "Tidal Slash",
                ManaRequirment = 15,
                ClassType = "Wyrm",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Dive",
                ManaRequirment = 30,
                ClassType = "Wyrm",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Hyper Speed",
                ManaRequirment = 30,
                ClassType = "Wyrm",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Thunder",
                ManaRequirment = 50,
                ClassType = "Wyrm",
                UserType = "Enemy",
            });

            // Zombie
            this.context.Spells.Add(new Spell
            {
                Name = "Infecting Bite",
                ManaRequirment = 40,
                ClassType = "Zombie",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Feed",
                ManaRequirment = 50,
                ClassType = "Zombie",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Mutation",
                ManaRequirment = 50,
                ClassType = "Zombie",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Decay",
                ManaRequirment = 10,
                ClassType = "Zombie",
                UserType = "Enemy",
            });
            await this.context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedPlayerSpellsAsync(CancellationToken cancellationToken)
        {
            // Hunter
            this.context.Spells.Add(new Spell
            {
                Name = "Hasting Arrow",
                ManaRequirment = 20,
                ClassType = "Hunter",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Grass Hop",
                ManaRequirment = 50,
                ClassType = "Hunter",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Volley Shot",
                ManaRequirment = 30,
                ClassType = "Hunter",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Sharp Eye",
                ManaRequirment = 50,
                ClassType = "Hunter",
                UserType = "Player",
            });

            // Mage
            this.context.Spells.Add(new Spell
            {
                Name = "Water Ball",
                ManaRequirment = 30,
                ClassType = "Mage",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Fire Ball",
                ManaRequirment = 25,
                ClassType = "Mage",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Mana Conversion",
                ManaRequirment = 0,
                ClassType = "Mage",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "All-Out Blast!",
                ManaRequirment = 100,
                ClassType = "Mage",
                UserType = "Player",
            });

            // Naturalist
            this.context.Spells.Add(new Spell
            {
                Name = "Nature's Touch",
                ManaRequirment = 50,
                ClassType = "Naturalist",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Thorn Blast",
                ManaRequirment = 35,
                ClassType = "Naturalist",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Nature's Gift",
                ManaRequirment = 0,
                ClassType = "Naturalist",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Pouring Raind",
                ManaRequirment = 0,
                ClassType = "Naturalist",
                UserType = "Player",
            });

            // Necroid
            this.context.Spells.Add(new Spell
            {
                Name = "Shadow Touch",
                ManaRequirment = 25,
                ClassType = "Necroid",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Life Drain",
                ManaRequirment = 35,
                ClassType = "Necroid",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Blind",
                ManaRequirment = 15,
                ClassType = "Necroid",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Mutual Darkness",
                ManaRequirment = 0,
                ClassType = "Necroid",
                UserType = "Player",
            });

            // Paladin
            this.context.Spells.Add(new Spell
            {
                Name = "Holy Strike",
                ManaRequirment = 15,
                ClassType = "Paladin",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Burning Light",
                ManaRequirment = 15,
                ClassType = "Paladin",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Vicious Spell-Guard",
                ManaRequirment = 30,
                ClassType = "Paladin",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Divine Rune",
                ManaRequirment = 15,
                ClassType = "Paladin",
                UserType = "Player",
            });

            // Priest
            this.context.Spells.Add(new Spell
            {
                Name = "Holy Light",
                ManaRequirment = 30,
                ClassType = "Priest",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Mana Drain",
                ManaRequirment = 10,
                ClassType = "Priest",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Staff Smash",
                ManaRequirment = 12,
                ClassType = "Priest",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Blessing",
                ManaRequirment = 50,
                ClassType = "Priest",
                UserType = "Player",
            });

            // Rogue
            this.context.Spells.Add(new Spell
            {
                Name = "Stab",
                ManaRequirment = 12,
                ClassType = "Rogue",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Poison Dagger",
                ManaRequirment = 30,
                ClassType = "Rogue",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Evasion",
                ManaRequirment = 50,
                ClassType = "Rogue",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Thievery",
                ManaRequirment = 50,
                ClassType = "Rogue",
                UserType = "Player",
            });

            // Shaman
            this.context.Spells.Add(new Spell
            {
                Name = "Thunder Strike",
                ManaRequirment = 50,
                ClassType = "Shaman",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Earth Strike",
                ManaRequirment = 50,
                ClassType = "Shaman",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Flame Strike",
                ManaRequirment = 25,
                ClassType = "Shaman",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Water Strike",
                ManaRequirment = 25,
                ClassType = "Shaman",
                UserType = "Player",
            });

            // Warrior
            this.context.Spells.Add(new Spell
            {
                Name = "Head Smash",
                ManaRequirment = 50,
                ClassType = "Warrior",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Hyper Strength",
                ManaRequirment = 50,
                ClassType = "Warrior",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Raging Blow",
                ManaRequirment = 12,
                ClassType = "Warrior",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Disarm",
                ManaRequirment = 50,
                ClassType = "Warrior",
                UserType = "Player",
            });

            await this.context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedStatusesAsync(CancellationToken cancellationToken)
        {
            this.context.Statuses.Add(new Status
            {
                DisplayName = "UnSet",
                IClass = "far fa-meh-blank",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "Meh",
                IClass = "far fa-meh",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "Happy",
                IClass = "far fa-smile",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "Star",
                IClass = "far fa-grin-stars",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "Tired",
                IClass = "far fa-tired",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "In Love",
                IClass = "far fa-grin-hearts",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "Fresh",
                IClass = "far fa-grin-tongue-wink",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "Status",
                IClass = "far fa-frown",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "WTF",
                IClass = "fas fa-flushed",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "LUL",
                IClass = "far fa-grin-squint-tears",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "Angry",
                IClass = "far fa-angry",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "Focused",
                IClass = "fas fa-podcast",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "Chilling",
                IClass = "far fa-hand-peace",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "Home With My Cat",
                IClass = "fas fa-cat",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "Home With My Dog",
                IClass = "fas fa-dog",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "Sick",
                IClass = "fas fa-head-side-cough",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "Having A Snack",
                IClass = "fas fa-drumstick-bite",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "9000+ IQ",
                IClass = "fas fa-brain",
            });

            await this.context.SaveChangesAsync(cancellationToken);
        }
    }
}
