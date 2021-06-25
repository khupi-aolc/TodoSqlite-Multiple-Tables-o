using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BellApp.Models
{
    public class RiskAssessData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Created_at { get; set; }
        public string PermitNo { get; set; }
        public string JobCardNo { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public int Country_Code { get; set; }
        
        //Protective Gear fields
        public bool ProtectiveClothing { get; set; }
        public bool SafetyGloves { get; set; }
        public bool FaceShield { get; set; }
        public bool SefetyHarness { get; set; }
        public bool SafetyBoots { get; set; }
        public bool UserSafetyCage { get; set; }
        public bool SafetyGoogles { get; set; }
        public bool HighVisibilityClothing { get; set; }
        public bool UseScreening { get; set; }
        public bool EarProtection { get; set; }
        public bool WeldingMask { get; set; }
        public bool HardHat { get; set; }
        public bool RespiratoryProtection { get; set; }
        
        //StepBack Fields
        /*public bool KnowWhatHasTobeDone { get; set; }
        public bool KnowHowToDoIt { get; set; }
        public bool HaveSafeAccess { get; set; }
        public bool PermitsLockOutsPlaces { get; set; }
        public bool PeopleBeAffected { get; set; }
        public bool EquipAroundCanAffect { get; set; }
        public bool CorrectToolsJobAvail { get; set; }
        public bool CorrectPPEJob { get; set; }
        public bool ExposedHighNoise { get; set; }
        public bool WeatherCondition { get; set; }
        public bool SOPAvailable { get; set; }
        public bool NewHazardzs { get; set; }
        public string StopStepBackThinkComment { get; set; }*/
        
        //Mitigation Elimnitate Control
        /*public bool HazardRemoved { get; set; }
        public bool HazardMitigation { get; set; }
        public bool HazardIsolated { get; set; }
        public bool CommunicatedTeamMembers { get; set; }
        public bool DoneIncaseEmergency { get; set; }
        public bool EmergencyEquipmentAvail { get; set; }
        public string MitigateEliminateControlComment { get; set; }*/
        
        //Proceed Fields
       /* public bool TaskContinueSafely { get; set; }
        public bool GoWrong { get; set; }
        public bool ConditionStartAgain { get; set; }
        public bool ObserveWorkArea { get; set; }
        public bool SaveDoingJob { get; set; }
        public bool OtherAroundWorking { get; set; }
        public string ProceedsComment { get; set; }
        
        public string ReviewCommentary { get; set; }
        public string Status { get; set; }
        public string ErrorCode { get; set; }*/
        
        //Authorized User ID
        //public int UserFKId { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<IdentityAssess> IdentityAssesses { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<TeamMember> TeamMembers { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<StepBack> StepBacks { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Proceed> Proceeds { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<MitigateEliminateControl> MitigateEliminateControls { get; set; }
    }

    //Team members table
    public class TeamMember
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string ErrorCode { get; set; }

        [ForeignKey(typeof(RiskAssessData))]
        public int UserCredentialsFKId { get; set; }

    }

    //Protective gear table
    /* public class ProtectiveGear
     {
         [PrimaryKey, AutoIncrement]
         public int Id { get; set; }
         public string Description { get; set; }
         public bool Selection { get; set; }
         public string Status { get; set; }
         public string ErrorCode { get; set; }
         [ForeignKey(typeof(UserCredentials))]
         public int UserCredentialsFKId { get; set; }
     }*/

    //StepBack Table
    public class StepBack
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Selection { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }
        public string ErrorCode { get; set; }
        [ForeignKey(typeof(RiskAssessData))]
        public int UserCredentialsFKId { get; set; }
    }

    //Mitigation Table
    public class MitigateEliminateControl
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Selection { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }
        public string ErrorCode { get; set; }
        [ForeignKey(typeof(RiskAssessData))]
        public int UserCredentialsFKId { get; set; }
    }

    //Proceed table
    public class Proceed
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Selection { get; set; }
        public string Status { get; set; }
        public string ErrorCode { get; set; }
        [ForeignKey(typeof(RiskAssessData))]
        public int UserCredentialsFKId { get; set; }
    }

    public class IdentityAssess
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string SlipTripFall { get; set; }
        public string HandFinger { get; set; }
        public string ElectricShock { get; set; }
        public string ExtremeTemperature { get; set; }
        public string MovingMachinery { get; set; }
        public string FallingObjects { get; set; }
        public string HazardousSubstance { get; set; }
        public string ConfinedSpace { get; set; }
        public string WorkingHeights { get; set; }
        public string VehicleForklifts { get; set; }
        public string Status { get; set; }
        public string ErrorCode { get; set; }
        [ForeignKey(typeof(RiskAssessData))]
        public int UserCredentialsFKId { get; set; }
        
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<IdentityAssessDetail> IdentityAssesseDetails { get; set; }
        
    }

    public class IdentityAssessDetail
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ProbAlmostCertain { get; set; }
        public int ProbLikely { get; set; }
        public int ProbPossible { get; set; }
        public int ProbUnlikey { get; set; }
        public int ProbRare { get; set; }
        public int ImpactExtremeFatal { get; set; }
        public int ImpactMajorPerm { get; set; }
        public int ImpactModerateImpact { get; set; }
        public int ImpactSignificantLostTime { get; set; }
        public int ImpactMinorFirstAid { get; set; }
        public int ControlUncontrollable { get; set; }
        public int ControlWeak { get; set; }
        public int ControlModerateControl { get; set; }
        public int ControlGood { get; set; }
        public int ControlVeryGood { get; set; }
        public int Results { get; set; }
        public string Status { get; set; }
        public string ErrorCode { get; set; }
        
        [ForeignKey(typeof(IdentityAssess))]
        public int IdentityAssessFKId { get; set; }
    }
}
