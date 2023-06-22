using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace UnofficialCalamityWhips
{
	public class UnofficialCalamityWhipsConfig : ModConfig
	{
		// ConfigScope.ClientSide should be used for client side, usually visual or audio tweaks.
		// ConfigScope.ServerSide should be used for basically everything else, including disabling items or changing NPC behaviours
		public override ConfigScope Mode => ConfigScope.ServerSide;

		// The "$" character before a name means it should interpret the name as a translation key and use the loaded translation with the same key.
		// The things in brackets are known as "Attributes".
		[Header("Config")] // Headers are like titles in a config. You only need to declare a header on the item it should appear over, not every item in the category.
		[Label("Whip Damage Modifer")] // A label is the text displayed next to the option. This should usually be a short description of what it does.
		[Tooltip("Modifies the damage of every whip in this mod by the chosen number. Use this to buff or nerf the mod as you see fit")] // A tooltip is a description showed when you hover your mouse over the option. It can be used as a more in-depth explanation of the option.
		[Range(.5f, 1.5f)]
		[Increment(.1f)]
		[DrawTicks]
		[DefaultValue(1f)]
		[ReloadRequired] // Marking it with [ReloadRequired] makes tModLoader force a mod reload if the option is changed. It should be used for things like item toggles, which only take effect during mod loading
		public float WhipDamageModifier;

		[Label("Add Whip Stats to Calamity Armors")]
		[Tooltip("Adds extra whip stats to some calamity armors while enabled, to make whips more viable")] // A tooltip is a description showed when you hover your mouse over the option. It can be used as a more in-depth explanation of the option.
		[DefaultValue(false)]
		[ReloadRequired]
		public bool AddArmorStats;

		[Label("Enable Tag Debuff Stacking")]
		[Tooltip("Allows whips in this mod to stack their tag effects. If set to false, all previous tag effects will be removed on applying a new one")] // A tooltip is a description showed when you hover your mouse over the option. It can be used as a more in-depth explanation of the option.
		[DefaultValue(true)]
		[ReloadRequired]
		public bool AllowTagStacking;

		[Label("Catalyst Disclaimer")]
		[Tooltip("Disable this to remove the disclaimer advertising the Catalyst Mod")] // A tooltip is a description showed when you hover your mouse over the option. It can be used as a more in-depth explanation of the option.
		[DefaultValue(true)]
		[ReloadRequired]
		public bool CatalystDisclaimer;
		
	}
}
