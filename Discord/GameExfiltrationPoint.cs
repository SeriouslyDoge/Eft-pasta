using System;
using EFT.Interactive;
using UnityEngine;

namespace Discord
{
	// Token: 0x02000016 RID: 22
	internal class GameExfiltrationPoint
	{
		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x0000AB72 File Offset: 0x00008D72
		public ExfiltrationPoint ExfiltrationPoint { get; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x0000AB7A File Offset: 0x00008D7A
		public Vector3 ScreenPosition
		{
			get
			{
				return this.screenPosition;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x0000AB82 File Offset: 0x00008D82
		// (set) Token: 0x060000BA RID: 186 RVA: 0x0000AB8A File Offset: 0x00008D8A
		public bool IsOnScreen { get; private set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000BB RID: 187 RVA: 0x0000AB93 File Offset: 0x00008D93
		// (set) Token: 0x060000BC RID: 188 RVA: 0x0000AB9B File Offset: 0x00008D9B
		public float Distance { get; private set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000BD RID: 189 RVA: 0x0000ABA4 File Offset: 0x00008DA4
		// (set) Token: 0x060000BE RID: 190 RVA: 0x0000ABAC File Offset: 0x00008DAC
		public string Name { get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000BF RID: 191 RVA: 0x0000ABB5 File Offset: 0x00008DB5
		public string FormattedDistance
		{
			get
			{
				return string.Format("{0}m", Math.Round((double)this.Distance));
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000ABD4 File Offset: 0x00008DD4
		public GameExfiltrationPoint(ExfiltrationPoint exfiltrationPoint)
		{
			bool flag = exfiltrationPoint == null;
			if (flag)
			{
				throw new ArgumentNullException("exfiltrationPoint");
			}
			this.ExfiltrationPoint = exfiltrationPoint;
			this.screenPosition = default(Vector3);
			this.Distance = 0f;
			this.Name = this.ExtractionNameToSimpleName(exfiltrationPoint.name);
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000AC34 File Offset: 0x00008E34
		public void RecalculateDynamics()
		{
			bool flag = !GameUtils.IsExfiltrationPointValid(this.ExfiltrationPoint);
			if (!flag)
			{
				this.screenPosition = GameUtils.WorldPointToScreenPoint(this.ExfiltrationPoint.transform.position);
				this.IsOnScreen = GameUtils.IsScreenPointVisible(this.screenPosition);
				this.Distance = Vector3.Distance(Misc.MainCamera.transform.position, this.ExfiltrationPoint.transform.position);
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000ACB0 File Offset: 0x00008EB0
		private string ExtractionNameToSimpleName(string extractionName)
		{
			bool flag = extractionName.Contains("exit (3)");
			string result;
			if (flag)
			{
				result = "Cellars";
			}
			else
			{
				bool flag2 = extractionName.Contains("exit (1)");
				if (flag2)
				{
					result = "Gate 3";
				}
				else
				{
					bool flag3 = extractionName.Contains("exit (2)");
					if (flag3)
					{
						result = "Gate 0";
					}
					else
					{
						bool flag4 = extractionName.Contains("exit_scav_gate3");
						if (flag4)
						{
							result = "Gate 3";
						}
						else
						{
							bool flag5 = extractionName.Contains("exit_scav_camer");
							if (flag5)
							{
								result = "Blinking Light";
							}
							else
							{
								bool flag6 = extractionName.Contains("exit_scav_office");
								if (flag6)
								{
									result = "Office";
								}
								else
								{
									bool flag7 = extractionName.Contains("eastg");
									if (flag7)
									{
										result = "East Gate";
									}
									else
									{
										bool flag8 = extractionName.Contains("scavh");
										if (flag8)
										{
											result = "House";
										}
										else
										{
											bool flag9 = extractionName.Contains("deads");
											if (flag9)
											{
												result = "Dead Mans Place";
											}
											else
											{
												bool flag10 = extractionName.Contains("var1_1_constant");
												if (flag10)
												{
													result = "Outskirts";
												}
												else
												{
													bool flag11 = extractionName.Contains("scav_outskirts");
													if (flag11)
													{
														result = "Outskirts";
													}
													else
													{
														bool flag12 = extractionName.Contains("water");
														if (flag12)
														{
															result = "Outskirts Water";
														}
														else
														{
															bool flag13 = extractionName.Contains("boat");
															if (flag13)
															{
																result = "The Boat";
															}
															else
															{
																bool flag14 = extractionName.Contains("mountain");
																if (flag14)
																{
																	result = "Mountain Stash";
																}
																else
																{
																	bool flag15 = extractionName.Contains("oldstation");
																	if (flag15)
																	{
																		result = "Old Station";
																	}
																	else
																	{
																		bool flag16 = extractionName.Contains("UNroad");
																		if (flag16)
																		{
																			result = "UN Road Block";
																		}
																		else
																		{
																			bool flag17 = extractionName.Contains("var2_1_const");
																			if (flag17)
																			{
																				result = "UN Road Block";
																			}
																			else
																			{
																				bool flag18 = extractionName.Contains("gatetofactory");
																				if (flag18)
																				{
																					result = "Gate to Factory";
																				}
																				else
																				{
																					bool flag19 = extractionName.Contains("RUAF");
																					if (flag19)
																					{
																						result = "RUAF Gate";
																					}
																					else
																					{
																						bool flag20 = extractionName.Contains("roadtoc");
																						if (flag20)
																						{
																							result = "Road to Customs";
																						}
																						else
																						{
																							bool flag21 = extractionName.Contains("lighthouse");
																							if (flag21)
																							{
																								result = "Lighthouse";
																							}
																							else
																							{
																								bool flag22 = extractionName.Contains("tunnel");
																								if (flag22)
																								{
																									result = "Tunnel";
																								}
																								else
																								{
																									bool flag23 = extractionName.Contains("wreckedr");
																									if (flag23)
																									{
																										result = "Wrecked Road";
																									}
																									else
																									{
																										bool flag24 = extractionName.Contains("deadend");
																										if (flag24)
																										{
																											result = "Dead End";
																										}
																										else
																										{
																											bool flag25 = extractionName.Contains("housefence");
																											if (flag25)
																											{
																												result = "Ruined House Fence";
																											}
																											else
																											{
																												bool flag26 = extractionName.Contains("gyment");
																												if (flag26)
																												{
																													result = "Gym Entrance";
																												}
																												else
																												{
																													bool flag27 = extractionName.Contains("southfence");
																													if (flag27)
																													{
																														result = "South Fence Passage";
																													}
																													else
																													{
																														bool flag28 = extractionName.Contains("adm_base");
																														if (flag28)
																														{
																															result = "Admin Basement";
																														}
																														else
																														{
																															bool flag29 = extractionName.Contains("administrationg");
																															if (flag29)
																															{
																																result = "Administration Gate";
																															}
																															else
																															{
																																bool flag30 = extractionName.Contains("factoryfar");
																																if (flag30)
																																{
																																	result = "Factory Far Corner";
																																}
																																else
																																{
																																	bool flag31 = extractionName.Contains("oldazs");
																																	if (flag31)
																																	{
																																		result = "Old Gate";
																																	}
																																	else
																																	{
																																		bool flag32 = extractionName.Contains("milkp_sh");
																																		if (flag32)
																																		{
																																			result = "Shack";
																																		}
																																		else
																																		{
																																			bool flag33 = extractionName.Contains("beyondfuel");
																																			if (flag33)
																																			{
																																				result = "Beyond Fuel Tank";
																																			}
																																			else
																																			{
																																				bool flag34 = extractionName.Contains("railroadtom");
																																				if (flag34)
																																				{
																																					result = "Railroad to Mil Base";
																																				}
																																				else
																																				{
																																					bool flag35 = extractionName.Contains("_pay_car");
																																					if (flag35)
																																					{
																																						result = "V-Exit";
																																					}
																																					else
																																					{
																																						bool flag36 = extractionName.Contains("oldroadgate");
																																						if (flag36)
																																						{
																																							result = "Old Road Gate";
																																						}
																																						else
																																						{
																																							bool flag37 = extractionName.Contains("sniperroad");
																																							if (flag37)
																																							{
																																								result = "Sniper Road Block";
																																							}
																																							else
																																							{
																																								bool flag38 = extractionName.Contains("warehouse17");
																																								if (flag38)
																																								{
																																									result = "Warehouse 17";
																																								}
																																								else
																																								{
																																									bool flag39 = extractionName.Contains("factoryshacks");
																																									if (flag39)
																																									{
																																										result = "Factory Shacks";
																																									}
																																									else
																																									{
																																										bool flag40 = extractionName.Contains("railroadtotarkov");
																																										if (flag40)
																																										{
																																											result = "Railroad to Tarkov";
																																										}
																																										else
																																										{
																																											bool flag41 = extractionName.Contains("trailerpark");
																																											if (flag41)
																																											{
																																												result = "Trailer Park";
																																											}
																																											else
																																											{
																																												bool flag42 = extractionName.Contains("crossroads");
																																												if (flag42)
																																												{
																																													result = "Crossroads";
																																												}
																																												else
																																												{
																																													bool flag43 = extractionName.Contains("railroadtoport");
																																													if (flag43)
																																													{
																																														result = "Railroad to Port";
																																													}
																																													else
																																													{
																																														bool flag44 = extractionName.Contains("NW_Exfil");
																																														if (flag44)
																																														{
																																															result = "North West Extract";
																																														}
																																														else
																																														{
																																															bool flag45 = extractionName.Contains("SE_Exfil");
																																															if (flag45)
																																															{
																																																result = "Emmercom";
																																															}
																																															else
																																															{
																																																result = extractionName;
																																															}
																																														}
																																													}
																																												}
																																											}
																																										}
																																									}
																																								}
																																							}
																																						}
																																					}
																																				}
																																			}
																																		}
																																	}
																																}
																															}
																														}
																													}
																												}
																											}
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x04000074 RID: 116
		private Vector3 screenPosition;
	}
}
