using Chance_Cubes.Reward;
using Chance_Cubes.Reward.Parts;
using Chance_Cubes.Reward.Types;
using Newtonsoft.Json;
using StardewModdingAPI;
using System;
using System.Collections.Generic;
using System.IO;

namespace Chance_Cubes.config
{
    public class CustomRewardsLoader
    {
        public static void LoadCustomRewards(IDataHelper helper, string path)
        {
            System.IO.Directory.CreateDirectory(path + "/custom_rewards");
            foreach (string file in Directory.GetFiles(path + "/custom_rewards"))
            {
                Dictionary<string, object> values = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(file));

                string fileName = Path.GetFileName(file);

                foreach (string reward in values.Keys)
                {
                    /* BasicReward basicReward = parseReward(reward, (Dictionary<string, object>)values[reward]);
                     if (basicReward == null)
                     {
                         CCubesCore.logger.Info("Seems your reward is setup incorrectly, or is disabled for this version of minecraft with a depedency, and Chance Cubes was not able to parse the reward " + reward.getKey() + " for the file " + f.getName());
                         continue;
                     }

                     RewardRegistry.registerReward(basicReward);*/

                }
                CCubesCore.logger.Info("Loaded custom rewards file " + fileName);
            }
        }

        /*public static BasicReward parseReward(string rewardName, Dictionary<string, object> reward)
        {
            List<IType> rewards = new List<IType>();
            int chance = 0;
            foreach (string rewardElement in reward.Keys)
            {
                if (rewardElement.Equals("chance", StringComparison.OrdinalIgnoreCase))
                {
                    chance = int.Parse((string)reward[rewardElement]);
                    continue;
                }
                else if (rewardElement.Equals("dependencies", StringComparison.OrdinalIgnoreCase))
                {
                    bool gameversion = false;
                    bool mcversionused = false;
                    Dictionary<string, object> rewardElements = (Dictionary<string, object>)reward[rewardElement];
                    foreach (string dependencies in rewardElements.Keys)
                    {
                        if (dependencies.Equals("mod", StringComparison.OrdinalIgnoreCase))
                        {
                            //if (!Loader.isModLoaded(dependencies.getValue().getAsString()))
                              //  return new CustomEntry<BasicReward, Boolean>(null, false);
                        }
                        else if (dependencies.Equals("mcVersion", StringComparison.OrdinalIgnoreCase))
                        {
                            mcversionused = true;
                            String[] versionsToCheck = ((string)rewardElements[dependencies]).split(",");
                            for (String toCheckV : versionsToCheck)
                            {
                                String currentMCV = CCubesCore.gameVersion;
                                if (toCheckV.contains("*"))
                                {
                                    currentMCV = currentMCV.substring(0, currentMCV.lastIndexOf("."));
                                    toCheckV = toCheckV.substring(0, toCheckV.lastIndexOf("."));
                                }
                                if (currentMCV.equalsIgnoreCase(toCheckV))
                                    gameversion = true;
                            }
                        }
                    }
                    if (!gameversion && mcversionused)
                        return new CustomEntry<BasicReward, Boolean>(null, false);
                    continue;
                }
                else if (rewardElement.getKey().equalsIgnoreCase("isGiantCubeReward"))
                {
                    isGiantCubeReward = rewardElement.getValue().getAsBoolean();
                }

                try
                {
                    JsonArray rewardTypes = rewardElement.getValue().getAsJsonArray();
                    if (rewardElement.getKey().equalsIgnoreCase("Item"))
                        this.loadItemReward(rewardTypes, rewards);
                    else if (rewardElement.getKey().equalsIgnoreCase("Block"))
                        this.loadBlockReward(rewardTypes, rewards);
                    else if (rewardElement.getKey().equalsIgnoreCase("Message"))
                        this.loadMessageReward(rewardTypes, rewards);
                    else if (rewardElement.getKey().equalsIgnoreCase("Command"))
                        this.loadCommandReward(rewardTypes, rewards);
                    else if (rewardElement.getKey().equalsIgnoreCase("Entity"))
                        this.loadEntityReward(rewardTypes, rewards);
                    else if (rewardElement.getKey().equalsIgnoreCase("Experience"))
                        this.loadExperienceReward(rewardTypes, rewards);
                    else if (rewardElement.getKey().equalsIgnoreCase("Potion"))
                        this.loadPotionReward(rewardTypes, rewards);
                    else if (rewardElement.getKey().equalsIgnoreCase("Schematic"))
                        this.loadSchematicReward(rewardTypes, rewards);
                    else if (rewardElement.getKey().equalsIgnoreCase("Sound"))
                        this.loadSoundReward(rewardTypes, rewards);
                    else if (rewardElement.getKey().equalsIgnoreCase("Chest"))
                        this.loadChestReward(rewardTypes, rewards);
                    else if (rewardElement.getKey().equalsIgnoreCase("Particle"))
                        this.loadParticleReward(rewardTypes, rewards);
                }
                catch (Exception ex)
                {
                    CCubesCore.logger.log(Level.ERROR, "Failed to load a custom reward for some reason. I will try better next time.");
                    ex.printStackTrace();
                }
            }
            return new CustomEntry<BasicReward, Boolean>(new BasicReward(rewardName, chance, rewards.toArray(new IRewardType[rewards.size()])), isGiantCubeReward);
        }*/
    }
}
