using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Arkada = BGU.DRPL.SignificantOwnership.EmpiricalData.Scraping.ArkadaOwnershipChainDescriptionParser;

namespace BGU.DRPL.SignificantOwnership.EmpiricalData.Scraping
{
	public class PivdennyiOwnershipChainDescriptionParser
	{
		protected const string PCT_RGX_PTRN = "[0-9\\.\\,]+\\%";
		protected const string SHAREHOLDER = @"\p{Lu}+";
		protected const string WHICH_POSSESSES_WORDING_START = @"якому\s+належить|якій\s+належить";

		public List<Arkada.WordingItem> Parse(string ownChainDescr)
		{
			var trimmed = ownChainDescr.Trim(';', '\n', ' ', '\r');
			var blocks = Regex.Split(trimmed, @"акцій\s+банку"); // get rid of the last item, which is an empty string
			List<Arkada.WordingItem> relationships = new List<Arkada.WordingItem>();

			foreach (var block in blocks)
			{
				var parts = Regex.Split(block, WHICH_POSSESSES_WORDING_START);

				// Taking the first link in the chain, the first owner.
				var matches = Regex.Matches(parts.First(), SHAREHOLDER);
				string ownerName = CombineMatchesIntoString(matches);

				// Going through the chain description except the first one (already taken) and the last one (always Pivdennyi).
				foreach (var part in parts.Skip(1).Take(parts.Count() - 2))
				{
					string assetName = CombineMatchesIntoString(Regex.Matches(part, SHAREHOLDER));
					string pct = Regex.Match(part, PCT_RGX_PTRN).Value;

					Arkada.WordingItem wi = new Arkada.WordingItem
					{
						Owner = ownerName,
						Asset = assetName,
						Pct = decimal.Parse(pct.Replace(',', '.').Substring(0, pct.Length - 1))
					};

					
					relationships.Add(wi);
					ownerName = assetName;
				}

				string pctOfBank = Regex.Match(parts.Last(), PCT_RGX_PTRN).Value;
				Arkada.WordingItem partOfPivdennyi = null;

				// Temp solution for getting rid of the last empty str.
				if (!string.IsNullOrEmpty(pctOfBank))
				{
					// The last link - "якому належить {percentage}% акцій банку".
					partOfPivdennyi = new Arkada.WordingItem
					{
						Owner = ownerName,
						Asset = "Південний",
						Pct = decimal.Parse(pctOfBank.Replace(',', '.').Substring(0, pctOfBank.Length - 1))
					};
				}

				relationships.Add(partOfPivdennyi);
			}

			return relationships;
		}

		private string CombineMatchesIntoString(MatchCollection matches)
		{
			StringBuilder sb = new StringBuilder();
			var parts = matches.Cast<Match>().Select(m => m.Value);

			foreach (var p in parts)
			{
				sb.Append(p).Append(" ");
			}

			return sb.ToString();
		}
	}
}
