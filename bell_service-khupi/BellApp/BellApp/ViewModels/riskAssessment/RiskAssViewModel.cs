using System;
using System.Windows.Input;
using Xamarin.CommunityToolkit.UI.Views;
using System.Collections.Generic;
using System.Text;
using BellApp.Views;
using BellApp.Views.riskAssessment;
using Xamarin.Forms;
using Rg.Plugins.Popup.Extensions;
using BellApp.Models;
using BellApp.Datas;
using System.Collections.ObjectModel;

namespace BellApp.ViewModels.riskAssessment
{
    public class RiskAssViewModel : BaseViewModel
    {
        public RiskAssessData _riskAssessData = new RiskAssessData();
        public StepBack _stepBack = new StepBack();

        private ObservableCollection<StepBack> _stepBackObserve;
        
        private ObservableCollection<RiskAssessData> _riskAssessDataObserve;
        private RiskAssessData _riskAssessDataItem;

        public Command BackCommand { get; }

        public Command SignaturesCommand { get; }

        public Command ExpandCommand { get; }
        // public string BenTest = "False";
        public Command RememberMeCommand { get; }

        private ImageButton theItem;
        public ImageButton accessOpacity { get; set; }
        private Command assessInjury1 { get; set; }
        private Command hazardousSubstance { get; set; }
        public bool collapsed { get; set; }
        public static string _PopupType1 { get; set; }
        // public Command ExpandCommand { get; }
        //  RiskAssPage1 page = new RiskAssPage1();

        public INavigation Navigation { get; set; }

        public double ScreenWidthFirstCol = Application.Current.MainPage.Width - (Application.Current.MainPage.Width / 2);



        public void OnExpanderTapped(object sender, EventArgs e)
        {
            Label label = sender as Label;
            Expander expander = label.Parent.Parent.Parent as Expander;

            if (label.FontSize == Device.GetNamedSize(NamedSize.Default, label))
            {
                label.FontSize = Device.GetNamedSize(NamedSize.Large, label);
            }
            else
            {
                label.FontSize = Device.GetNamedSize(NamedSize.Default, label);
            }
            expander.ForceUpdateSize();

        }


        public bool Expand
        {
            get { return collapsed; }
            set
            {
                if (collapsed == value) return;
                collapsed = value;
                OnPropertyChanged(nameof(Expand));
            }

        }

        public Command TripAndFall
        {
            get
            {
                return new Command(() =>
                Navigation.PushPopupAsync(new RiskPopUpPage1(" Slip, Trip and Fall")));
            }
        }

        public Command FingerInjury
        {
            get
            {
                return new Command(() =>
                Navigation.PushPopupAsync(new RiskPopUpPage1(" Hand And Finger Injury")));
            }
        }

        public Command EyeInjury
        {
            get
            {
                return new Command(() =>
                  Navigation.PushPopupAsync(new RiskPopUpPage1(" Eye Injury")));
            }
        }

        public Command Electricshock
        {
            get
            {
                return new Command(() =>
                  Navigation.PushPopupAsync(new RiskPopUpPage1(" Electric Shock")));
            }
        }

        public Command ExtremeTemperature
        {
            get
            {
                return new Command(() =>
                  Navigation.PushPopupAsync(new RiskPopUpPage1(" Extreme Temperature")));
            }
        }

        public Command MovingMachinery
        {
            get
            {
                return new Command(() =>
                  Navigation.PushPopupAsync(new RiskPopUpPage1(" Moving Machinery")));
            }
        }

        public Command FallingObjects
        {
            get
            {
                return new Command(() =>
                  Navigation.PushPopupAsync(new RiskPopUpPage1(" Falling Objects")));
            }
        }
        public Command HazardousSubstance
        {
            get
            {
                return new Command(() =>
                Navigation.PushPopupAsync(new RiskPopUpPage1(" Hazardous Substance")));

            }
            set {
                hazardousSubstance = value;
                OnPropertyChanged(nameof(HazardousSubstance));
            }

        }

        public Command ConfinedSpace
        {
            get
            {
                return new Command(() =>
                  Navigation.PushPopupAsync(new RiskPopUpPage1("Confined Space")));
            }
        }

        public Command WorkingHeights
        {
            get
            {
                return new Command(() =>
                  Navigation.PushPopupAsync(new RiskPopUpPage1(" Working at Heights")));
            }
        }

        public Command VehicleForklifts
        {
            get
            {
                return new Command(() =>
                  Navigation.PushPopupAsync(new RiskPopUpPage1(" Vehicle/Forklifts")));
            }
        }


        public double screenWidthFirst
        {
            get { return Application.Current.MainPage.Width - (Application.Current.MainPage.Width / 4.0); }
            set
            {
                if (ScreenWidthFirstCol == value) return;
                ScreenWidthFirstCol = Application.Current.MainPage.Width - (Application.Current.MainPage.Width / 4.0); ;

            }
        }

        public double screenWidthSec
        {
            get { return Application.Current.MainPage.Width - (Application.Current.MainPage.Width / 3); }
            set
            {
                if (ScreenWidthFirstCol == value) return;
                ScreenWidthFirstCol = Application.Current.MainPage.Width - (Application.Current.MainPage.Width / 3); ;

            }

        }





        public double screenWidthThird
        {
            get { return Application.Current.MainPage.Width - (Application.Current.MainPage.Width / 1.7); }
            set
            {
                if (ScreenWidthFirstCol == value) return;
                ScreenWidthFirstCol = Application.Current.MainPage.Width - (Application.Current.MainPage.Width / 1.7); ;

            }

        }

        public void OnScrollViewScrolled(object sender, ScrolledEventArgs e)
        {
            Console.WriteLine($"ScrollX: {e.ScrollX}, ScrollY: {e.ScrollY}");

            if (e.ScrollY > 200)
            {
                // tabbed.accessOpacity.Opacity = 1;
            }
        }


        public ImageButton opacity
        {
            get { return accessOpacity; }
            set
            {
                if (accessOpacity == value) return;
                accessOpacity = value;

            }

        }




        public bool StartExpand()
        {
            OnPropertyChanged(nameof(Expand));

            if (collapsed == false)
            {
                collapsed = true;
                return collapsed;
            }
            else if (collapsed == true)
            {
                collapsed = false;
                return collapsed;
            }

            return collapsed;



        }



        public RiskAssViewModel()
        {
            _PopupType1 = "Probablity";

            BackCommand = new Command(OnBackClicked);

            SignaturesCommand = new Command(StartSigning);


            RememberMeCommand = new Command(() => Expand = !Expand);

        }

        

        public DateTime Created_at { get; set; }
        string permitno;
        public string PermitNo 
        {
            get 
            {
                return permitno;
            }
            set 
            {
                var initial = "BL";
                DateTime dt = DateTime.Now;
                string d = dt.ToString("MMddyyyy");
                string t = dt.ToString("HHmmss");

                permitno = d+initial+t;
            }
        }
        public string JobCardNo { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public int Country_Code { get; set; }
        public ObservableCollection<RiskAssessData> RiskAssessDataObserveItems
        {
            get { return _riskAssessDataObserve; }
            set
            {
                _riskAssessDataObserve = value;
                //RaisePropertyChanged();
            }
        }
        public RiskAssessData RiskAssessDataItem
        {
            get 
            { 
                return _riskAssessDataItem; 
            }
            set
            {
                _riskAssessDataItem = value;
                //RaisePropertyChanged();
            }
        }

        public ObservableCollection<StepBack> StepBackDataObserveItems
        {
            get 
            { 
                return _stepBackObserve; 
            }
            set
            {
                _stepBackObserve = value;
                //RaisePropertyChanged();
            }
        }

        bool protectiveClothing;
        //Protective Gear fields
        public bool ProtectiveClothing
        {
            get 
            {
                return protectiveClothing;
            }
            set 
            {
                protectiveClothing = value;

                
            } 
        }
        bool safetyGloves;
        public bool SafetyGloves 
        {
            get 
            {
                return safetyGloves;
            }
            set 
            {
                safetyGloves = value;
                
            }
        }
        bool faceshield;
        public bool FaceShield 
        {
            get 
            {
                return faceshield;
            } 
            set 
            {
                faceshield = value;
                
            }
        }
        bool safetyHarness;
        public bool SefetyHarness 
        {
            get 
            {
                return safetyHarness;
            } 
            set 
            {
                safetyHarness = value;
                
            } 
        }
        bool safetyBoots;
        public bool SafetyBoots 
        {
            get 
            {
                return safetyBoots;
            }
            set 
            {
                safetyBoots = value;
                
            }
        }
        bool userSafetyCage;
        public bool UserSafetyCage 
        {
            get 
            {
                return userSafetyCage;
            }
            set 
            {
                userSafetyCage = value;
                
            }
        }
        bool safetyGoogles;
        public bool SafetyGoogles 
        {
            get 
            {
                return safetyGoogles;
            }
            set 
            {
                safetyGoogles = value;
                
            }
        }
        bool highVisibilityClothing;
        public bool HighVisibilityClothing 
        {
            get 
            {
                return highVisibilityClothing;
            } 
            set 
            {
                highVisibilityClothing = value;
            }
        }
        bool useScreening;
        public bool UseScreening
        {
            get 
            {
                return useScreening;
            } 
            set 
            {
                useScreening = value;
                
            } 
        }
        bool earProtection;
        public bool EarProtection 
        {
            get 
            {
                return earProtection;
            } 
            set 
            {
                earProtection = value;
                
            } 
        }
        bool weldingMask;
        public bool WeldingMask 
        {
            get 
            {
                return weldingMask;
            } set 
            {
                weldingMask = value;
                
            }
        }
        bool hardhat;
        public bool HardHat
        {
            get 
            {
                return hardhat;
            } 
            set 
            {
                hardhat = value;
                
            } 
        }
        bool respiratoryProtection;
        public bool RespiratoryProtection
        {
            get 
            {
                return respiratoryProtection;
            }
            set 
            {
                respiratoryProtection = value;
                
            }
        }

        //StepBack Fields
        bool knowWhatHasTobeDone;
        public bool KnowWhatHasTobeDone 
        {
            get 
            {
                return knowWhatHasTobeDone;
            }
            set 
            {
                knowWhatHasTobeDone = value;
            } 
        }
        bool knowHowToDoIt;
        public bool KnowHowToDoIt 
        {
            get 
            {
                return knowHowToDoIt;
            }
            set 
            {
                knowHowToDoIt = value;
            }
        }
        bool haveSafeAccess;
        public bool HaveSafeAccess 
        {
            get 
            {
                return haveSafeAccess;
            }
            set 
            {
                haveSafeAccess = value;
            }
        }
        bool permitsLockOutsPlaces;
        public bool PermitsLockOutsPlaces 
        {
            get 
            {
                return permitsLockOutsPlaces;
            } 
            set
            {
                permitsLockOutsPlaces = value;
            }
        }
        bool peopleBeAffected;
        public bool PeopleBeAffected 
        {
            get 
            {
                return peopleBeAffected;
            }
            set 
            {
                peopleBeAffected = value;
            }
        }
        bool equipAroundCanAffect;
        public bool EquipAroundCanAffect 
        {
            get 
            {
                return equipAroundCanAffect;
            } 
            set
            {
                equipAroundCanAffect = value;
            }
        }
        bool correctToolsJobAvail;
        public bool CorrectToolsJobAvail 
        {
            get 
            {
                return correctToolsJobAvail;
            }
            set 
            {
                correctToolsJobAvail = value;
            } 
        }
        bool correctPPEJob;
        public bool CorrectPPEJob 
        {
            get 
            {
               return correctPPEJob;
            }
            set 
            {
                correctPPEJob = value;
            }
        }
        bool exposedHighNoise;
        public bool ExposedHighNoise 
        {
            get 
            {
                return exposedHighNoise;
            } 
            set 
            {
                exposedHighNoise = value;
            }
        }
        bool weatherCondition;
        public bool WeatherCondition 
        {
            get 
            {
                return weatherCondition;
            }
            set 
            {
                weatherCondition = value;
            } 
        }
        bool sopAvailable;
        public bool SOPAvailable
        {
            get
            {
                return sopAvailable;
            }
            set
            {
                sopAvailable = value;
            }
        }
        bool newHazardzs;
        public bool NewHazardzs 
        {
            get 
            {
                return newHazardzs;
            } 
            set 
            {
                newHazardzs = value;
            }
        }
        public string StopStepBackThinkComment { get; set; }

        //Mitigation Elimnitate Control
        bool hazardRemoved;
        public bool HazardRemoved
        {
            get
            {
                return hazardRemoved;
            }
            set
            {
                hazardRemoved = value;
            }
        }
        bool hazardMitigation;
        public bool HazardMitigation
        {
            get
            {
                return hazardMitigation;
            }
            set
            {
                hazardMitigation = value;
            }
        }
        bool hazardIsolated;
        public bool HazardIsolated
        {
            get
            {
                return hazardIsolated;
            }
            set
            {
                hazardIsolated = value;
            }
        }
        bool communicatedTeamMembers;
        public bool CommunicatedTeamMembers
        {
            get
            {
                return communicatedTeamMembers;
            }
            set
            {
                communicatedTeamMembers = value;
            }
        }
        bool doneIncaseEmergency;
        public bool DoneIncaseEmergency
        {
            get
            {
                return doneIncaseEmergency;
            }
            set
            {
                doneIncaseEmergency = value;
            }
        }
        bool emergencyEquipmentAvail;
        public bool EmergencyEquipmentAvail
        {
            get
            {
                return emergencyEquipmentAvail;
            }
            set
            {
                emergencyEquipmentAvail = value;
            }
        }

        public string MitigateEliminateControlComment { get; set; }

        //Proceed Fields
        public bool TaskContinueSafely { get; set; }
        public bool GoWrong { get; set; }
        public bool ConditionStartAgain { get; set; }
        public bool ObserveWorkArea { get; set; }
        public bool SaveDoingJob { get; set; }
        public bool OtherAroundWorking { get; set; }
        public string ProceedsComment { get; set; }

        public string ReviewCommentary { get; set; }

        public List<IdentityAssess> IdentityAssesses { get; set; }
        public List<TeamMember> TeamMembers { get; set; }
        /*public List<StepBack> StepBacks { get; set; }
        public List<Proceed> Proceeds { get; set; }
        public List<MitigateEliminateControl> MitigateEliminateControls { get; set; }*/

        //Submission initiation
        public void StartSigning()
        {

            try
            {


                Database database = new Database();
                DateTime dt = DateTime.Now;
                var initial = "BL";
                string s = dt.ToString("dddd, dd MMMM yyyy HH:mm:ss");
                string d = dt.ToString("MMddyyyy");
                string t = dt.ToString("HHmmss");

                _riskAssessData.Created_at = s;
                _riskAssessData.PermitNo = d+initial+t;
                _riskAssessData.JobCardNo = JobCardNo;
                _riskAssessData.Company = Company;
                _riskAssessData.Location = Location;
                _riskAssessData.Country_Code = Country_Code;
                _riskAssessData.ProtectiveClothing = ProtectiveClothing;
                _riskAssessData.SafetyGloves = SafetyGloves;
                _riskAssessData.FaceShield = FaceShield;
                _riskAssessData.SefetyHarness = SefetyHarness;
                _riskAssessData.SafetyBoots = SafetyBoots;
                _riskAssessData.UserSafetyCage = UserSafetyCage;
                _riskAssessData.SafetyGoogles = SafetyGoogles;
                _riskAssessData.HighVisibilityClothing = HighVisibilityClothing;
                _riskAssessData.UseScreening = UseScreening;
                _riskAssessData.EarProtection = EarProtection;
                _riskAssessData.WeldingMask = WeldingMask;
                _riskAssessData.HardHat = HardHat;
                _riskAssessData.RespiratoryProtection = RespiratoryProtection;
                //StepBacks = new ObservableCollection<StepBack>(RiskAssessDataItem.StepBacks);
                //_riskAssessData.StepBacks = StepBacks;
                _stepBack.Selection = KnowWhatHasTobeDone;
                _stepBack.Selection = KnowHowToDoIt;
                _stepBack.Selection = HaveSafeAccess;
                _stepBack.Selection = PermitsLockOutsPlaces;
                _stepBack.Selection = PeopleBeAffected;
                _stepBack.Selection = EquipAroundCanAffect;
                _stepBack.Selection = CorrectToolsJobAvail;
                _stepBack.Selection = CorrectPPEJob;
                _stepBack.Selection = ExposedHighNoise;
                _stepBack.Selection = WeatherCondition;
                _stepBack.Selection = SOPAvailable;
                _stepBack.Selection = NewHazardzs;

                /*_stepBack.Selection = HazardRemoved;
                _stepBack.Selection = HazardMitigation;
                _stepBack.Selection = HazardIsolated;
                _riskAssessData.CommunicatedTeamMembers = CommunicatedTeamMembers;
                _riskAssessData.DoneIncaseEmergency = DoneIncaseEmergency;
                _riskAssessData.EmergencyEquipmentAvail = EmergencyEquipmentAvail;
                _riskAssessData.TaskContinueSafely = TaskContinueSafely;
                _riskAssessData.GoWrong = GoWrong;
                _riskAssessData.ConditionStartAgain = ConditionStartAgain;
                _riskAssessData.ObserveWorkArea = ObserveWorkArea;
                _riskAssessData.SaveDoingJob = SaveDoingJob;
                _riskAssessData.OtherAroundWorking = OtherAroundWorking;*/

                //protective gear switch buttons
                /*var ProtectiveClothing = new Switch();
                ProtectiveClothing.SetBinding(Switch.IsToggledProperty, "ProtectiveClothing");
                if (ProtectiveClothing.IsToggled)
                {
                    _riskAssessData.ProtectiveClothing = true;
                }
                else
                {
                    _riskAssessData.ProtectiveClothing = false;
                }*/

                /*var SafetyGloves = new Switch();
                if (SafetyGloves.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }

                var FaceShield = new Switch();
                if (FaceShield.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }

                var SefetyHarness = new Switch();
                if (SefetyHarness.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }

                var SafetyBoots = new Switch();
                if (SafetyBoots.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }

                var UserSafetyCage = new Switch();
                if (UserSafetyCage.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }
                var SafetyGoogles = new Switch();
                if (SafetyGoogles.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }

                var HighVisibilityClothing = new Switch();
                if (HighVisibilityClothing.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }
                var UseScreening = new Switch();
                if (UseScreening.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }
                var EarProtection = new Switch();
                if (EarProtection.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }

                var WeldingMask = new Switch();
                if (WeldingMask.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }

                var HardHat = new Switch();
                if (HardHat.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }

                var RespiratoryProtection = new Switch();
                if (RespiratoryProtection.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }

                //StepBack switch Buttons
                var KnowWhatHasTobeDone = new Switch();
                if (KnowWhatHasTobeDone.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }
                
                var KnowHowToDoIt = new Switch();
                if (KnowHowToDoIt.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }

                var HaveSafeAccess = new Switch();
                if (HaveSafeAccess.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }

                var PermitsLockOutsPlaces = new Switch();
                if (PermitsLockOutsPlaces.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }

                var PeopleBeAffected = new Switch();
                if (PeopleBeAffected.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }
                var EquipAroundCanAffect = new Switch();
                if (EquipAroundCanAffect.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }

                var CorrectToolsJobAvail = new Switch();
                if (CorrectToolsJobAvail.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }

                var CorrectPPEJob = new Switch();
                if (CorrectPPEJob.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }

                var ExposedHighNoise = new Switch();
                if (ExposedHighNoise.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }

                var WeatherCondition = new Switch();
                if (WeatherCondition.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }

                var SOPAvailable = new Switch();
                if (SOPAvailable.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }

                var NewHazardzs = new Switch();
                if (NewHazardzs.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }

                //Mitigation Elimnitate Control Switch Buttons
                var HazardRemoved = new Switch();
                if (HazardRemoved.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }

                var HazardMitigation = new Switch();
                if (HazardMitigation.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }

                var HazardIsolated = new Switch();
                if (HazardIsolated.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }
                var CommunicatedTeamMembers = new Switch();
                if (CommunicatedTeamMembers.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }
                var DoneIncaseEmergency = new Switch();
                if (DoneIncaseEmergency.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }
                var EmergencyEquipmentAvail = new Switch();
                if (EmergencyEquipmentAvail.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }
                var MitigateEliminateControl = new Switch();
                if (MitigateEliminateControl.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }

                //Proceed Switch Buttons
                var TaskContinueSafely = new Switch();
                if (TaskContinueSafely.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }
                var GoWrong = new Switch();
                if (GoWrong.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }
                var ConditionStartAgain = new Switch();
                if (ConditionStartAgain.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }
                var ObserveWorkArea = new Switch();
                if (ObserveWorkArea.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }
                var SaveDoingJob = new Switch();
                if (SaveDoingJob.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }
                var OtherAroundWorking = new Switch();
                if (OtherAroundWorking.IsToggled)
                {
                    _riskAssessData.SafetyGloves = true;
                }
                else
                {
                    _riskAssessData.SafetyGloves = false;
                }*/

                /*_riskAssessData.ProceedsComment = ProceedsComment;
                _riskAssessData.ReviewCommentary = StopStepBackThinkComment;
                _riskAssessData.ReviewCommentary = ReviewCommentary;
                _riskAssessData.IdentityAssesses = IdentityAssesses;*/
                _riskAssessData.TeamMembers = TeamMembers;
                /*_riskAssessData.StepBacks = StepBacks;
                _riskAssessData.Proceeds = Proceeds;
                _riskAssessData.MitigateEliminateControls = MitigateEliminateControls;*/
                database.Insert(_riskAssessData);

                /*ObserveItems = new ObservableCollection<Ste>();

                var selc = _stepBack.Selection;
                
                foreach (var i in result)
                {
                    
             
                }
*/
                var getIdQ = database.GetUserCredentialsData(_riskAssessData.Id);

                
                //Get all data display in list
                /*var result = database.GetAllData();

                RiskAssessDataObserveItems = new ObservableCollection<RiskAssessData>();
                
                foreach (var item in result)
                {
                    //RiskAssessDataObserveItems.Add(item);
                    database.InsertStepBack(_stepBack).Add(item);
                }*/

                /*var PermitNoQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var CompanyQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var LocationQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var Country_CodeQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var ProtectiveClothingQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var SafetyGlovesQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var FaceShieldQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var SefetyHarnessQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var SafetyBootsQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var UserSafetyCageQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var SafetyGooglesQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var HighVisibilityClothingQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var UseScreeningQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var EarProtectionQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var WeldingMaskQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var HardHatQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var RespiratoryProtectionQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var KnowWhatHasTobeDoneQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var KnowHowToDoItQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var HaveSafeAccessQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var PermitsLockOutsPlacesQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var PeopleBeAffectedQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var EquipAroundCanAffectQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var CorrectToolsJobAvailQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var CorrectPPEJobQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var ExposedHighNoiseQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var WeatherConditionQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var SOPAvailableQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var NewHazardzsQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var StopStepBackThinkCommentQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var HazardRemovedQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var HazardMitigationQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var HazardIsolatedQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var CommunicatedTeamMembersQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var DoneIncaseEmergencyQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var EmergencyEquipmentAvailQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var MitigateEliminateControlQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var TaskContinueSafelyQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var GoWrongQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var ConditionStartAgainQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var ObserveWorkAreaQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var SaveDoingJobQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var OtherAroundWorkingQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var ProceedsCommentQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var ReviewCommentaryQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var IdentityAssessesQ = database.GetUserCredentialsData(_riskAssessData.Id);
                var TeamMembersQ = database.GetUserCredentialsData(_riskAssessData.Id);*/



                App.Current.MainPage.DisplayAlert("Success",
                    "Application Details \n" +
                    "Date Created: " + getIdQ.Created_at + "\n" +
                    "PermitNo: " + getIdQ.PermitNo + "\n" +
                    "Job Card No: " + getIdQ.JobCardNo + "\n" +
                    "Company: " + getIdQ.Company + "\n" +
                    "Location: "+ getIdQ.Location + "\n" +
                    "Country_Code: "+ getIdQ.Country_Code + "\n" +
                    "ProtectiveClothingQ: " + getIdQ.ProtectiveClothing + "\n" +
                    "SafetyGlovesQ: " + getIdQ.SafetyGloves + "\n" +
                    "FaceShieldQ: " + getIdQ.FaceShield + "\n" +
                    "SefetyHarnessQ: " + getIdQ.SefetyHarness + "\n" +
                    "SafetyBootsQ: " + getIdQ.SafetyBoots + "\n" +
                    "UserSafetyCageQ: " + getIdQ.UserSafetyCage + "\n" +
                    "SafetyGooglesQ: " + getIdQ.SafetyGoogles + "\n" +
                    "HighVisibilityClothingQ: " + getIdQ.HighVisibilityClothing + "\n" +
                    "UseScreeningQ: " + getIdQ.UseScreening + "\n" +
                    "EarProtectionQ: " + getIdQ.EarProtection + "\n" +
                    "WeldingMaskQ: " + getIdQ.WeldingMask + "\n" +
                    "HardHatQ: " + getIdQ.HardHat + "\n" +
                    "RespiratoryProtectionQ: " + getIdQ.RespiratoryProtection + "\n" +
                     /*"KnowWhatHasTobeDoneQ: " + getIdQ.KnowWhatHasTobeDone + "\n" +
                     "KnowHowToDoItQ: " + getIdQ.KnowHowToDoIt + "\n" +
                     "HaveSafeAccessQ: " + getIdQ.HaveSafeAccess + "\n" +
                     "PermitsLockOutsPlacesQ: " + getIdQ.PermitsLockOutsPlaces + "\n" +
                     "PeopleBeAffectedQ: " + getIdQ.PeopleBeAffected + "\n" +
                     "EquipAroundCanAffectQ: " + getIdQ.EquipAroundCanAffect + "\n" +
                     "CorrectToolsJobAvailQ: " + getIdQ.CorrectToolsJobAvail + "\n" +
                     "CorrectPPEJobQ: " + getIdQ.CorrectPPEJob + "\n" +
                     "ExposedHighNoiseQ: " + getIdQ.ExposedHighNoise + "\n" +
                     "SOPAvailableQ: " + getIdQ.SOPAvailable + "\n" +
                     "NewHazardzsQ: " + getIdQ.NewHazardzs + "\n" +
                     "StopStepBackThinkCommentQ: " + getIdQ.StopStepBackThinkComment + "\n" +
                     "HazardRemovedQ: " + getIdQ.HazardRemoved + "\n" +
                     "HazardMitigationQ: " + getIdQ.HazardMitigation + "\n" +
                     "HazardIsolatedQ: " + getIdQ.HazardIsolated + "\n" +
                     "CommunicatedTeamMembersQ: " + getIdQ.CommunicatedTeamMembers + "\n" +
                     "DoneIncaseEmergencyQ: " + getIdQ.DoneIncaseEmergency + "\n" +
                     "EmergencyEquipmentAvailQ: " + getIdQ.EmergencyEquipmentAvail + "\n" +
                     "MitigateEliminateControlQ: " + getIdQ.MitigateEliminateControlComment + "\n" +
                     "TaskContinueSafelyQ: " + getIdQ.TaskContinueSafely + "\n" +
                     "GoWrongQ: " + getIdQ.GoWrong + "\n" +
                     "ConditionStartAgainQ: " + getIdQ.ConditionStartAgain + "\n" +
                     "ObserveWorkAreaQ: " + getIdQ.ObserveWorkArea + "\n" +
                     "SaveDoingJobQ: " + getIdQ.SaveDoingJob + "\n" +
                     "OtherAroundWorkingQ: " + getIdQ.OtherAroundWorking + "\n" +
                     "ProceedsCommentQ: " + getIdQ.ProceedsComment + "\n" +*/
                     "IdentityAssesses: " + getIdQ.StepBacks + "\n" +
                    "IdentityAssesses: " + getIdQ.IdentityAssesses + "\n" +
                    "Team Memeber: "+ getIdQ.TeamMembers + "\n" +
                    //"Review Commentary: " + getIdQ.ReviewCommentary + "\n" +
                    " Created Succesfully"
                    , "Ok");
                //await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
                
            }
            catch (Exception e)
            {
                App.Current.MainPage.DisplayAlert("Failed", "Something went wrong, please try to create the account again" + e +"", "Ok");
            }

            //Signature Initiation prior to submission
            //Application.Current.MainPage = new NavigationPage(new PopSignature());
        }

        private void OnBackClicked(object obj)
        {
            Application.Current.MainPage = new LoginPage();
        }








    }

}
