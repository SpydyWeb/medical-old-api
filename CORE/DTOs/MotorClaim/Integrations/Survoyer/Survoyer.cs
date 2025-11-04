namespace CORE.DTOs.MotorClaim.Survoyer
{
	public class Survoyer
	{
		public int Id { get; set; }

		public long ClaimId { get; set; }

		public bool? Front_B_Rubber { get; set; }

		public bool? Front_B_Reinforcement { get; set; }

		public bool? Front_B_Guard { get; set; }

		public bool? Front_H_Panel { get; set; }

		public bool? Front_R_Panel { get; set; }

		public bool? Front_Grill { get; set; }

		public bool? Front_IndicatorLight { get; set; }

		public bool? Front_H_Light { get; set; }

		public bool? Front_E_HoobLock { get; set; }

		public bool? Front_WindShield { get; set; }

		public bool? Front_Wipers { get; set; }

		public bool? Front_W_S_Rubber { get; set; }

		public bool? Front_RightTire { get; set; }

		public bool? Front_LeftTire { get; set; }

		public bool? Front_RightRim { get; set; }

		public bool? Front_LeftRim { get; set; }

		public bool? Front_RightWheelCaps { get; set; }

		public bool? Front_LeftWheelCaps { get; set; }

		public bool? Front_Others { get; set; }

		public bool? Rear_B_Rubber { get; set; }

		public bool? Rear_B_Reinforcement { get; set; }

		public bool? Rear_Lamps { get; set; }

		public bool? Rear_Truck { get; set; }

		public bool? Rear_Lid { get; set; }

		public bool? Rear_Glass { get; set; }

		public bool? Rear_Roof { get; set; }

		public bool? Rear_R_Window { get; set; }

		public bool? Rear_R_Rubber { get; set; }

		public bool? Rear_B_Guard { get; set; }

		public bool? Rear_Others { get; set; }

		public bool? Rear_W_S_Rubber { get; set; }

		public bool? Rear_RightTire { get; set; }

		public bool? Rear_LeftTire { get; set; }

		public bool? Rear_RightRim { get; set; }

		public bool? Rear_LeftRim { get; set; }

		public bool? Rear_RightWheelCaps { get; set; }

		public bool? Rear_LeftWheelCaps { get; set; }

		public bool? Interior_DashBoard { get; set; }

		public bool? Interior_AirBag { get; set; }

		public bool? Interior_R_C_Antil { get; set; }

		public bool? Interior_F_Seats { get; set; }

		public bool? Interior_R_Seats { get; set; }

		public bool? Interior_FloorMats { get; set; }

		public bool? Interior_DoorTrim { get; set; }

		public bool? Interior_Others { get; set; }

		public bool? Engine_Engine { get; set; }

		public bool? Engine_W_Radiator { get; set; }

		public bool? Engine_A_CRadiator { get; set; }

		public bool? Engine_Fan { get; set; }

		public bool? Engine_Battery { get; set; }

		public bool? Engine_Others { get; set; }

		public bool? Underneath_LeftSteeringJoint { get; set; }

		public bool? Underneath_RightSteeringJoint { get; set; }

		public bool? Underneath_SteeringBox { get; set; }

		public bool? Underneath_LeftSuspension { get; set; }

		public bool? Underneath_RightSuspension { get; set; }

		public bool? Underneath_LeftShockObserver { get; set; }

		public bool? Underneath_RightShockObserver { get; set; }

		public bool? Underneath_Muffler { get; set; }

		public bool? Underneath_Pro_Shaft { get; set; }

		public bool? Underneath_E_Mounting { get; set; }

		public bool? Underneath_Chassis { get; set; }

		public bool? Underneath_Others { get; set; }

		public bool? Sides_F_Fender { get; set; }

		public bool? Sides_R_Fender { get; set; }

		public bool? Sides_F_Door { get; set; }

		public bool? Sides_R_Door { get; set; }

		public bool? Sides_CentralPillar { get; set; }

		public bool? Sides_RunningBoard { get; set; }

		public bool? Sides_F_W_Glass { get; set; }

		public bool? Sides_R_W_Glass { get; set; }

		public bool? Sides_LeftMirror { get; set; }

		public bool? Sides_RightMirror { get; set; }

		public bool? Sides_Others { get; set; }

		public int? RepairCondition { get; set; }

		public int? PartProvider { get; set; }

		public int? WorkShop { get; set; }

		public int? Recommended { get; set; }

		public int? Status { get; set; }

		public decimal? EstimatedSPAmount { get; set; }

		public decimal? EstimatedLabourAmount { get; set; }

		public int? EstimatedRepairDays { get; set; }

		public decimal? SparePartAmount { get; set; }

		public decimal? LabourAmount { get; set; }

		public decimal? OtherAmount { get; set; }

		public string? Note { get; set; }
	}
}
