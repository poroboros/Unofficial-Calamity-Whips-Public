using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using UnofficialCalamityWhips.Weapons.HM.DaedalusWhip;
using UnofficialCalamityWhips.Weapons.HM.BrimstoneLash;
using UnofficialCalamityWhips.Weapons.HM.SandstoneReigns;
using UnofficialCalamityWhips.Weapons.HM.PrismBreak;
using UnofficialCalamityWhips.Weapons.HM.SirensSerenity;
using UnofficialCalamityWhips.Weapons.HM.StarScraper;
using UnofficialCalamityWhips.Weapons.HM.StellarWind;
using UnofficialCalamityWhips.Weapons.HM.SulphuricScourge;
using UnofficialCalamityWhips.Weapons.PostML.RighteousDawn;
using UnofficialCalamityWhips.Weapons.PostML.UnrelentingTorment;
using UnofficialCalamityWhips.Weapons.PreHM.CoralCrusher;
using UnofficialCalamityWhips.Weapons.PreHM.SkySplitter;
using UnofficialCalamityWhips.Weapons.PostML.DevourersMaw;
using UnofficialCalamityWhips.Weapons.PostML.BlossomsBlessing;
using UnofficialCalamityWhips.Weapons.PostML.Centauri;
using UnofficialCalamityWhips.Weapons.PostML.ResonateStriker;
using UnofficialCalamityWhips.Weapons.PreHM.CongeledDuoWhip;
using UnofficialCalamityWhips.Weapons.PreHM.StaticScourge;
using UnofficialCalamityWhips.Weapons.PreHM.FungalFlail;

using System.Collections.Generic;
using Terraria.DataStructures;

namespace UnofficialCalamityWhips.Globals
{
	public class GlobalTagDebuffs : GlobalNPC
	{
        public override bool InstancePerEntity => true;
        public int brimstoneIndex = -1;
        public int daedalusIndex = -1;
        public int prismIndex = -1;
        public int predatorIndex = -1;
        public int sirenIndex = -1;
        int sirenCooldown = 0;
        public int scraperIndex = -1;
        public int stellarIndex = -1;
        public int sulphuricIndex = -1;
        public int blossomIndex = -1;
        public int centauriIndex = -1;
        public int resonateIndex = -1;
        public int righteousIndex = -1;
        public int tormentIndex = -1;
        public int congeledIndex = -1;
        public int coralIndex = -1;
        public int fungalIndex = -1;
        public int skyIndex = -1;
        public int staticIndex = -1;

        public int devourerIndex = -1;

        public int activeTag = -1;

        int removedTagImmunity = -1;

        
		public override void UpdateLifeRegen(NPC npc, ref int damage) {
			if (sirenCooldown > 0) {
				sirenCooldown--;

            }
            removedTagImmunity--;
            //Main.NewText(removedTagImmunity);
		}

        public override void ResetEffects(NPC npc) {
		    brimstoneIndex = -1;
            daedalusIndex = -1;
            prismIndex = -1;
            predatorIndex = -1;
            sirenIndex = -1;
            //sirenCooldown = 0;
            scraperIndex = -1;
            stellarIndex = -1;
            sulphuricIndex = -1;
            blossomIndex = -1;
            centauriIndex = -1;
            resonateIndex = -1;
            righteousIndex = -1;
            tormentIndex = -1;
            congeledIndex = -1;
            coralIndex = -1;
            fungalIndex = -1;
            skyIndex = -1;
            staticIndex = -1;
            devourerIndex  = -1;
            activeTag = -1;
		}


        public void RemoveTagDebuffs(NPC npc) {
            foreach (int buff in npc.buffType) {
                if (buff < BuffID.Sets.IsAnNPCWhipDebuff.Length && buff > -1) {
                    //Main.NewText(buff + " " + BuffID.Sets.IsAnNPCWhipDebuff.Length);
                    if (BuffID.Sets.IsAnNPCWhipDebuff[buff] == true) {
                        if (npc.FindBuffIndex(buff) < npc.buffType.Length && npc.FindBuffIndex(buff) >= 0) {
                            npc.DelBuff(npc.FindBuffIndex(buff));
                        }
                    }
                }
            }
            ResetEffects(npc);
        }

        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) {

            NewPlayerStats newStats = Main.player[projectile.owner].GetModPlayer<NewPlayerStats>();
            UnofficialCalamityWhipsConfig config = ModContent.GetInstance<UnofficialCalamityWhipsConfig>();
            //Tag debuffs conditions
            if (!projectile.trap && (projectile.minion || ProjectileID.Sets.MinionShot[projectile.type])) {

                //brimstone whip tag debuff
               // Main.NewText((!config.AllowTagStacking + " active "  + (activeTag == ModContent.BuffType<BrimstoneTagDebuff>()) +  " brimmy " +(brimstoneIndex > -1)));
                if (((!config.AllowTagStacking && activeTag == ModContent.BuffType<BrimstoneTagDebuff>() && brimstoneIndex > -1) || (config.AllowTagStacking && brimstoneIndex > -1)&& newStats.brimstoneCooldown <= 0)) {
                    int proj = Projectile.NewProjectile(Projectile.InheritSource(projectile), npc.position, Vector2.Zero, UnofficialCalamityWhips.calamity.Find<ModProjectile>("BrimstoneSwordExplosion").Type, projectile.damage/2, projectile.knockBack, projectile.owner);
                    Main.projectile[proj].DamageType = DamageClass.Summon;
                    npc.DelBuff(brimstoneIndex);
                    brimstoneIndex = -1;
                    newStats.brimstoneCooldown = 20;
                }

                //daedalus whip tag debuff
                if ((!config.AllowTagStacking && activeTag == ModContent.BuffType<DaedalusWhipDebuff>() && daedalusIndex > -1) || (config.AllowTagStacking && daedalusIndex > -1)) {
                    damage = damage + (damage * 11) / 100;

                    if (newStats.daedalusCooldown <= 0) {
                        int proj = Projectile.NewProjectile(Entity.InheritSource(projectile), npc.position, Microsoft.Xna.Framework.Vector2.Normalize(projectile.velocity)*5, ModContent.ProjectileType<SnowBall>(), damage/2, 0.0f, projectile.owner);
                        Main.projectile[proj].DamageType = DamageClass.Summon;
                        newStats.daedalusCooldown = 60;
                        //Main.NewText(true);
                    }
                    //Main.NewText(System.DateTime.Now);
                }


                //prism break tag debuff
                if (((!config.AllowTagStacking && activeTag == ModContent.BuffType<PrismTagDebuff>() && prismIndex > -1) || (config.AllowTagStacking && prismIndex > -1)) && newStats.prismCooldown <= 0) {

                    for (int i = 0; i < Main.rand.Next(3,5); i++)	{
                        int rand = Main.rand.Next(0,4);
                        float s = 5f;
                        Vector2 rvector = new Vector2(s * (Main.rand.Next(-15,15) /10f),-s * (Main.rand.Next(-10,10) /10f));
                        if (UnofficialCalamityWhips.calamity != null) {
                            ModProjectile proj = null;
                            UnofficialCalamityWhips.calamity.TryFind<ModProjectile>("AquashardSplit", out proj);
                            if(proj != null) {
                                int shot = Projectile.NewProjectile(Projectile.InheritSource(projectile), projectile.Center, rvector, proj.Type, projectile.damage/3, projectile.knockBack, projectile.owner);
                                Main.projectile[shot].DamageType = DamageClass.Summon;
                            }
                        } 
                    }
                    npc.DelBuff(prismIndex);
                    prismIndex = -1;
                    newStats.prismCooldown = 20;
                }


                //forgotten predator tag debuff
                if ((!config.AllowTagStacking && activeTag == ModContent.BuffType<SandstoneTagDebuff>() && predatorIndex > -1) || (config.AllowTagStacking && predatorIndex > -1)) {
					newStats.whipTarget = npc;
					//newStats.sandstoneSoldier = true;
					int spawnDir = Main.rand.NextBool(2) ? -1 : 1; //Randomly chooses direction

					Vector2 position = npc.Center + new Vector2(Main.rand.Next(-800,-650), Main.rand.Next(650,800)); 
					//Spawns shark on a random side at a random height

					for (int i = 0; i < 4; i++)
					{
						int dust = Dust.NewDust(position, projectile.width, projectile.height, DustID.SandstormInABottle ,Main.rand.Next(-5,5), Main.rand.Next(-5,5), 25, default(Color), 1f);
					}

					Projectile.NewProjectile(Projectile.InheritSource(projectile), position, Vector2.Zero, ModContent.ProjectileType<SandstoneShark>(), projectile.damage, 0, projectile.owner);
					//Spawns the shark
					
					npc.DelBuff(predatorIndex);
					//Removes the tag on activation like firecracker
					//Must be reapplied
                }

                //siren's serenity tag debuff
                if (((!config.AllowTagStacking && activeTag == ModContent.BuffType<SirensSerenityDebuff>() && sirenIndex > -1) || (config.AllowTagStacking && sirenIndex > -1))&& Main.player[projectile.owner].GetModPlayer<NewPlayerStats>().sirenCooldown < 1) {
                    damage = damage + (damage * 18) / 100;
                    NewPlayerStats stats = Main.player[projectile.owner].GetModPlayer<NewPlayerStats>();
					stats.sirenCooldown = 480;
					if(stats.healingOrbCount < 3) {
						stats.healingOrbCount++;
						Item.NewItem(npc.GetSource_DropAsItem(), npc.position, Vector2.Zero, ModContent.ItemType<BuffOrb>());
					}
					else {
                        stats.healingOrbCount = 0;
						Item.NewItem(npc.GetSource_DropAsItem(), npc.position, Vector2.Zero, ModContent.ItemType<HealingOrb>());
					}
                }

                //star scrapper tag debuff
                if ((!config.AllowTagStacking && activeTag == ModContent.BuffType<StarScraperDebuff>() && scraperIndex > -1) || (config.AllowTagStacking && scraperIndex > -1)) {
                    Vector2 launchVelocity = new Vector2(-4, 0); 
                    newStats.whipTarget = npc;
                    for (int i = 0; i < 4; i++) {
                        launchVelocity = launchVelocity.RotatedBy(MathHelper.PiOver2);
                        int proj = Projectile.NewProjectile(Entity.InheritSource(projectile), npc.position, launchVelocity, ModContent.ProjectileType<StarScrapperDisjoint>(), damage/2, 0.0f, projectile.owner, 0.0f, 0.0f);
                        Main.projectile[proj].DamageType = DamageClass.Summon;
                    }
                    npc.DelBuff(scraperIndex);
                    scraperIndex = -1;
                }

                //stellar wind tag debuff
                if ((!config.AllowTagStacking && activeTag == ModContent.BuffType<StellarWindDebuff>() && stellarIndex > -1) || (config.AllowTagStacking && stellarIndex > -1)) {
                    if (UnofficialCalamityWhips.calamity.TryFind("AstralStar", out ModProjectile modProj)) {
                        for (int i = 0; i < 2; i++) {
                            Vector2 position = Main.player[projectile.owner].position + new Vector2((-(float)Main.rand.Next(0, 401) * projectile.direction), -600f);
                            position.Y -= 100;
                            Vector2 heading = projectile.Center - position;
                            if (heading.Y < 0f)
                            {
                                heading.Y *= -1f;
                            }
                            if (heading.Y < 20f)
                            {
                                heading.Y = 20f;
                            }
                            heading.Normalize();
                            float speedX = heading.X * 20;
                            float speedY = heading.Y * 20;
                            heading *= new Vector2(speedX, speedY).Length();
                            Projectile.NewProjectile(Projectile.InheritSource(projectile), position, new Vector2(speedX, speedY), modProj.Type, projectile.damage / 4, projectile.knockBack, projectile.owner);
                        }
                        npc.DelBuff(stellarIndex);
                    }
				}

                //sulphuric scourge tage debuff
                if (((!config.AllowTagStacking && activeTag == ModContent.BuffType<SulphuricTagDebuff>() && sulphuricIndex > -1) || (config.AllowTagStacking && sulphuricIndex > -1)) && newStats.sulphuricCooldown <= 0) {
                    for (int i = 0; i < Main.rand.Next(6,10); i++)	{
                        int rand = Main.rand.Next(0,4);
                        float s = 2f;
                        Vector2 rvector = new Vector2(s * (Main.rand.Next(-15,15) /10f),-s * (Main.rand.Next(-10,10) /10f));
                        int proj = Projectile.NewProjectile(Projectile.InheritSource(projectile), projectile.Center, rvector, ProjectileID.ToxicCloud, projectile.damage/2, projectile.knockBack, projectile.owner);
                        Main.projectile[proj].DamageType = DamageClass.Summon;
                    }
                    npc.DelBuff(sulphuricIndex);
                    newStats.sulphuricCooldown = 20;
			    }

                //blossom's blessing tag debuff
                if ((!config.AllowTagStacking && activeTag == ModContent.BuffType<BlossomsBlessingDebuff>() && blossomIndex > -1) || (config.AllowTagStacking && blossomIndex > -1)) {
				    damage = damage+(damage*30)/100;
			    }

                //centauri tag debuff
                if ((!config.AllowTagStacking && activeTag == ModContent.BuffType<CentauriDebuff>() && centauriIndex > -1) || (config.AllowTagStacking && centauriIndex > -1)) {
                    damage = damage + (damage * 50) / 100;
                }

                //resonate tag debuff
                if ((!config.AllowTagStacking && activeTag == ModContent.BuffType<ResonateTagDebuff>() && resonateIndex > -1) || (config.AllowTagStacking && resonateIndex > -1)) {
                    damage += (int)(damage*.2f);
                }


                //righteous dawn tag debuff
                if (((!config.AllowTagStacking && activeTag == ModContent.BuffType<RighteousTagDebuff>() && righteousIndex > -1) || (config.AllowTagStacking && righteousIndex > -1)) && (npc.type != NPCID.TargetDummy && newStats.righteousCooldown <= 0)) {
                    float distance = 500f;
                    if (Vector2.Distance(npc.Center, Main.player[projectile.owner].Center) < distance) {
                        Main.player[projectile.owner].AddBuff(ModContent.BuffType<RighteousBlessing>(), 120);
                    }

                    int proj = Projectile.NewProjectile(Projectile.InheritSource(projectile), projectile.Center, Vector2.Zero, UnofficialCalamityWhips.calamity.Find<ModProjectile>("AegisBlast").Type, projectile.damage/2, projectile.knockBack, projectile.owner);
                    Main.player[projectile.owner].Heal(5);
                    
                    Main.projectile[proj].DamageType = DamageClass.Summon;

                    npc.DelBuff(righteousIndex);
                    newStats.righteousCooldown = 20;
                    righteousIndex = -1;
                }

                //relentless torment tag debuff
                if((((!config.AllowTagStacking && activeTag == ModContent.BuffType<TormentTagDebuff>() && tormentIndex > -1) || (config.AllowTagStacking && tormentIndex > -1)) && newStats.handCooldown <= 0)) {
                    // Only player attacks should benefit from this buff, hence the NPC and trap checks.
                    newStats.whipTarget = npc;
                    for (int i = 0; i < 5; i++) {
                        Vector2 position = npc.Center + new Vector2((float)Main.rand.Next(-1000, 1000), 1000f);
                        Projectile.NewProjectile(Projectile.InheritSource(projectile), position, projectile.velocity, ModContent.ProjectileType<GhastlyHandProjectile>(), 10+(projectile.damage/15), 0, projectile.owner);
                    }
                    npc.DelBuff(tormentIndex);
                    tormentIndex = -1;
                    newStats.handCooldown = 30;
                }

                //duo-whip tag debuff
                if ((!config.AllowTagStacking && activeTag == ModContent.BuffType<CongeledTagDebuff>() && congeledIndex > -1) || (config.AllowTagStacking && congeledIndex > -1))  {
                    damage += (int)(damage*.1f);
                }

                //coral crusher tag debuff
                if ((!config.AllowTagStacking && activeTag == ModContent.BuffType<CoralCrusherDebuff>() && coralIndex > -1) || (config.AllowTagStacking && coralIndex > -1))
                 {
                    damage = damage + (damage * 6) / 100;      
                    if (Main.rand.NextBool(1)) {
                        int projType = Main.rand.NextBool(2) ? ModContent.ProjectileType<CoralProj>() : ModContent.ProjectileType<CoralProj2>();
                        int Proj2 = Projectile.NewProjectile(Entity.InheritSource(projectile), npc.position, projectile.velocity.RotatedByRandom(360) *0.90f, projType, damage/2, 0.0f, projectile.owner, 0.0f, 0.0f);
                        npc.DelBuff(coralIndex);
                        coralIndex = -1;
                    }
                }

                //fungal flail tag debuff
                if (((!config.AllowTagStacking && activeTag == ModContent.BuffType<FungalFlailDebuff>() && fungalIndex > -1) || (config.AllowTagStacking && fungalIndex > -1)) && newStats.fungalCooldown <= 0) {
                    damage += (int)(damage * .04f); //multiplicative tag damage
                    if (Main.rand.NextBool(3)) {
                        if (UnofficialCalamityWhips.calamity != null && UnofficialCalamityWhips.calamity.TryFind<ModProjectile>("FungiOrb", out ModProjectile FungiOrb)) {
                            int proj = Projectile.NewProjectile(Entity.InheritSource(projectile), npc.position, projectile.velocity, FungiOrb.Type, 10, 0.0f, projectile.owner, 0.0f, 0.0f);
                            Main.projectile[proj].DamageType = DamageClass.Summon;
                            Main.projectile[proj].extraUpdates = 2;
                            Main.player[projectile.owner].Heal(2);
                            npc.DelBuff(fungalIndex);
                            fungalIndex = -1;

                            newStats.fungalCooldown = 20;
                        }
                    }
                }

                //sky splitter tag debuff
                //TODO: fix this
                if ((!config.AllowTagStacking && activeTag == ModContent.BuffType<SkySplitterDebuff>() && skyIndex > -1) || (config.AllowTagStacking && skyIndex > -1)) {
                    Player player = Main.player[projectile.owner];
                    Random rnd = new Random();
                    damage = damage + (damage * 5) / 100;
                    // mapping of chance
                    // maxMinion = 0 --> probability = 1
                    // maxMinion = 30 --> probability = 0.05

                    int inv = 30-player.maxMinions;
                    if (inv < 0) { inv = 0; }

                    float probability;
                    probability = ((float)inv / 30) + 0.04f;

                    int Rand = rnd.Next(0,2);

                    if (Rand > probability) {
                        inv = player.maxMinions;
                        int chance = 1 + inv;
                        //Main.NewText(chance);
                        if (Main.rand.NextBool(chance)) {
                            player.AddBuff(ModContent.BuffType<SkyBuff>(), 120);
                        }
                    }
                }

                if (((!config.AllowTagStacking && activeTag == ModContent.BuffType<StaticTagDebuff>() && staticIndex > -1) || (config.AllowTagStacking && staticIndex > -1)) && newStats.staticCooldown <= 0)  {
					for (int i = 0; i < 4; i++)
					{
						Projectile.NewProjectile(Projectile.InheritSource(projectile), projectile.position, new Vector2(Main.rand.Next(-5,5), Main.rand.Next(-5,5)), UnofficialCalamityWhips.calamity.Find<ModProjectile>("EutrophicSpark").Type, 5, 0, projectile.owner);
					}
                    //npc.DelBuff(staticIndex);
                    newStats.staticCooldown = 20;
                    staticIndex = -1;
                }

                if ((!config.AllowTagStacking && activeTag == ModContent.BuffType<DevourerTagDebuff>() && devourerIndex > -1) || (config.AllowTagStacking && devourerIndex > -1)) {
                    damage = damage + (damage * 30) / 100;
                    Player player = Main.player[projectile.owner];
                }
            }
        }
    }
}