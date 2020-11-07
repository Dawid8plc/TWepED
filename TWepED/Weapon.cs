using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TWepED
{
    public class Weapon
    {
        public string Name;

        public XmlNode weaponNode;
        public XmlNode storeNode;
        public XmlNode nameNode;
        public XmlNode stringVarNode;
        public XmlNode clusterNode;
        public XmlNode collectionNode;

        public WeaponType Type;
    }

    public enum WeaponType
    {
        Bazooka,
        Grenade,
        Airstrike,
        Unknown
    }

    public struct WeaponTemplate
    {
        public static string Bazooka = @"<TWepED.Type>0</TWepED.Type>
      <Name>REPLACENAMEHERE</Name>
      <Type>0</Type>
      <Detonate>0</Detonate>
      <Homing>false</Homing>
      <HomingAvoidLand>false</HomingAvoidLand>
      <EffectedByWind>true</EffectedByWind>
      <FireOnGround>false</FireOnGround>
      <Poison>true</Poison>
      <RetreatTime>-1</RetreatTime>
      <WormDamageRadius>0.75</WormDamageRadius>
      <WormDamageMagnitude>0</WormDamageMagnitude>
      <LandDamageRadius>0</LandDamageRadius>
      <ProjectileCollisionRadius>1</ProjectileCollisionRadius>
      <Push>0</Push>
      <FuseTime>-1</FuseTime>
      <GraphicalResourceID>Factory.BlasterGunBody</GraphicalResourceID>
      <GraphicalResourceID>Factory.BlasterGunBarrel</GraphicalResourceID>
      <GraphicalResourceID>Factory.BlasterGunButt</GraphicalResourceID>
      <GraphicalResourceID>Factory.BlasterGunSight</GraphicalResourceID>
      <GraphicalLocatorID>BLASTER_body_Root_locator</GraphicalLocatorID>
      <GraphicalLocatorID>BLASTER_Barrel_Root_locator</GraphicalLocatorID>
      <GraphicalLocatorID>BLASTER_Butt_Root_locator</GraphicalLocatorID>
      <GraphicalLocatorID>BLASTER_sight_Root_locator</GraphicalLocatorID>
      <LaunchFX></LaunchFX>
      <ArielFX>WXP_BazookaTrailPack</ArielFX>
      <DetonationFX>WXP_ExplosionX_Med</DetonationFX>
      <PayloadResourceId>54</PayloadResourceId>
      <ProjectileLaunchType>1</ProjectileLaunchType>
      <ProjectilePowersUp>true</ProjectilePowersUp>
      <ProjectileNumClusters>5</ProjectileNumClusters>
      <ProjectileMaxPower>0.5</ProjectileMaxPower>
      <ClusterSpread>0.1</ClusterSpread>
      <ClusterMaxSpeed>0</ClusterMaxSpeed>";

        public static string BazookaCluster = @"<Name>
      </Name>
      <Type>1</Type>
      <Detonate>3</Detonate>
      <Homing>false</Homing>
      <HomingAvoidLand>false</HomingAvoidLand>
      <EffectedByWind>false</EffectedByWind>
      <FireOnGround>false</FireOnGround>
      <Poison>false</Poison>
      <RetreatTime>0</RetreatTime>
      <WormDamageRadius>0.75</WormDamageRadius>
      <WormDamageMagnitude>0.3</WormDamageMagnitude>
      <LandDamageRadius>0.4</LandDamageRadius>
      <ProjectileCollisionRadius>1</ProjectileCollisionRadius>
      <Push>0.3</Push>
      <FuseTime>2000</FuseTime>
      <LaunchFX>
      </LaunchFX>
      <ArielFX>
      </ArielFX>
      <DetonationFX>WXP_ExploCluster</DetonationFX>
      <PayloadResourceId>16</PayloadResourceId>
      <ProjectileLaunchType>2</ProjectileLaunchType>
      <ProjectilePowersUp>false</ProjectilePowersUp>
      <ProjectileNumClusters>0</ProjectileNumClusters>
      <ProjectileMaxPower>0</ProjectileMaxPower>
      <ClusterSpread>0.1</ClusterSpread>
      <ClusterMaxSpeed>0</ClusterMaxSpeed>";

        public static string Grenade = @"<TWepED.Type>1</TWepED.Type>
      <Name>REPLACENAMEHERE</Name>
      <Type>0</Type>
      <Detonate>1</Detonate>
      <Homing>false</Homing>
      <HomingAvoidLand>false</HomingAvoidLand>
      <EffectedByWind>true</EffectedByWind>
      <FireOnGround>false</FireOnGround>
      <Poison>false</Poison>
      <RetreatTime>-1</RetreatTime>
      <WormDamageRadius>0.75</WormDamageRadius>
      <WormDamageMagnitude>0.5</WormDamageMagnitude>
      <LandDamageRadius>0.1</LandDamageRadius>
      <ProjectileCollisionRadius>1</ProjectileCollisionRadius>
      <Push>0</Push>
      <FuseTime>-1</FuseTime>
      <LaunchFX></LaunchFX>
      <ArielFX></ArielFX>
      <DetonationFX>WXP_ExplosionX_Med</DetonationFX>
      <PayloadResourceId>41</PayloadResourceId>
      <ProjectileLaunchType>2</ProjectileLaunchType>
      <ProjectilePowersUp>true</ProjectilePowersUp>
      <ProjectileNumClusters>3</ProjectileNumClusters>
      <ProjectileMaxPower>0.9</ProjectileMaxPower>
      <ClusterSpread>0.8</ClusterSpread>
      <ClusterMaxSpeed>0</ClusterMaxSpeed>";

        public static string GrenadeCluster = @"<Name></Name>
      <Type>1</Type>
      <Detonate>0</Detonate>
      <Homing>false</Homing>
      <HomingAvoidLand>false</HomingAvoidLand>
      <EffectedByWind>false</EffectedByWind>
      <FireOnGround>false</FireOnGround>
      <Poison>false</Poison>
      <RetreatTime>0</RetreatTime>
      <WormDamageRadius>0.75</WormDamageRadius>
      <WormDamageMagnitude>0.3</WormDamageMagnitude>
      <LandDamageRadius>0.5</LandDamageRadius>
      <ProjectileCollisionRadius>1</ProjectileCollisionRadius>
      <Push>0.9</Push>
      <FuseTime>-1</FuseTime>
      <LaunchFX></LaunchFX>
      <ArielFX></ArielFX>
      <DetonationFX>WXP_ExploCluster</DetonationFX>
      <PayloadResourceId>41</PayloadResourceId>
      <ProjectileLaunchType>2</ProjectileLaunchType>
      <ProjectilePowersUp>false</ProjectilePowersUp>
      <ProjectileNumClusters>0</ProjectileNumClusters>
      <ProjectileMaxPower>0</ProjectileMaxPower>
      <ClusterSpread>0.8</ClusterSpread>
      <ClusterMaxSpeed>0</ClusterMaxSpeed>";

        public static string Airstrike = @"<TWepED.Type>2</TWepED.Type>
      <Name>REPLACENAMEHERE</Name>
      <Type>0</Type>
      <Detonate>0</Detonate>
      <Homing>false</Homing>
      <HomingAvoidLand>false</HomingAvoidLand>
      <EffectedByWind>false</EffectedByWind>
      <FireOnGround>false</FireOnGround>
      <Poison>true</Poison>
      <RetreatTime>0</RetreatTime>
      <WormDamageRadius>0.75</WormDamageRadius>
      <WormDamageMagnitude>0.2</WormDamageMagnitude>
      <LandDamageRadius>0</LandDamageRadius>
      <ProjectileCollisionRadius>1</ProjectileCollisionRadius>
      <Push>1</Push>
      <FuseTime>-1</FuseTime>
      <GraphicalResourceID>Radio</GraphicalResourceID>
      <LaunchFX></LaunchFX>
      <ArielFX>WXP_AirstrikeArielA</ArielFX>
      <DetonationFX>WXP_ExplosionX_Med</DetonationFX>
      <PayloadResourceId>38</PayloadResourceId>
      <ProjectileLaunchType>0</ProjectileLaunchType>
      <ProjectilePowersUp>false</ProjectilePowersUp>
      <ProjectileNumClusters>1</ProjectileNumClusters>
      <ProjectileMaxPower>0</ProjectileMaxPower>
      <ClusterSpread>0.24</ClusterSpread>
      <ClusterMaxSpeed>0.5</ClusterMaxSpeed>";

        public static string AirstrikeCluster = @"<Name></Name>
      <Type>1</Type>
      <Detonate>0</Detonate>
      <Homing>false</Homing>
      <HomingAvoidLand>false</HomingAvoidLand>
      <EffectedByWind>false</EffectedByWind>
      <FireOnGround>false</FireOnGround>
      <Poison>false</Poison>
      <RetreatTime>0</RetreatTime>
      <WormDamageRadius>0.5</WormDamageRadius>
      <WormDamageMagnitude>0.5</WormDamageMagnitude>
      <LandDamageRadius>0.4</LandDamageRadius>
      <ProjectileCollisionRadius>1</ProjectileCollisionRadius>
      <Push>0.6</Push>
      <FuseTime>-1</FuseTime>
      <LaunchFX></LaunchFX>
      <ArielFX></ArielFX>
      <DetonationFX>WXP_ExploCluster</DetonationFX>
      <PayloadResourceId>38</PayloadResourceId>
      <ProjectileLaunchType>2</ProjectileLaunchType>
      <ProjectilePowersUp>false</ProjectilePowersUp>
      <ProjectileNumClusters>0</ProjectileNumClusters>
      <ProjectileMaxPower>0</ProjectileMaxPower>
      <ClusterSpread>0.3</ClusterSpread>
      <ClusterMaxSpeed>0</ClusterMaxSpeed>";
    }
}

