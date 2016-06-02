using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMPRS
{
    public class Patient
    {
        //---------------------------------//
        //--------BASIC INFORMATION--------//
        //---------------------------------//

        public string nameL, nameF;    //patient last and first name
        public int age;                //patient age
        public int patientID;          //patient ID
        public DateTime DOB;           //patient DOB
        public enum MF : int               //patient sex
        {
            M, F
        };
        public MF sex;
        public int height;             //patient height
        public int weight;             //patient weight
        public string allergies;       //patient allergies
        public string infections;      //patient infection risks

        //-----------------------------------//
        //----------------MAR----------------//
        //---medical administration record---// 
       
        private struct Medication   //information about medication given to patient
        {
            int medID;              //Id for specific patient med order
            string med;             //generic name of medication
            string freq;            //frequency of med administration (free type)
            bool prn;               //0 = not as-needed, 1 = as-needed medication
            double dose;            //dosage of medication to give patient
            enum doseUnit           //units of medication dose
            {
                mg, mg_mL, mcg, mEq, mL, mL_hr, L, g
            };
            string route;           //the...method of entry
            DateTime lastGiven;     //one-time administration date or last administration date
            DateTime nextGiven;     //next administration date (if applicable)
        }

        private Medication[] regSchedMeds = new Medication[20];     //array of Medications patient is on or has been given

        //--------------//
        //-----LABS-----//
        //--------------//

        //date of lab
        public DateTime labDate;

        //electrolytes, protein, other (HCO3 = bicarbonate, BUN = blood urea nitrogen)
        public float sodium, potassium, chloride, HCO3, BUN, creatinine, glucose, calcium;
        public float magnesium, phosphate, protein, albumin, AST, ALT, LDH, ALP, bilirubin;

        //CBC
        public float HCT, RBC, Hgb, WBC, PLT;

        //hemostasis labs
        public float PT, PTT, INR;

        //cardiac enzymes
        public float myoglobin, cTnI, cTnT, CPK_CKMB2;

        //IMAGING
        //does anything need to be here???
        //currently looking into server/database integration and what that means for images

        //-------------------------//
        //-----ASSESSMENT DATA-----//
        //-------------------------//

        //date of Assessment
        public DateTime assessmentDate;

        //VITAL SIGNS

        //Blood pressure
        public float SBP, DBP;
        public enum bpLR :int  //side of bp
        {
            L, R
        };
        public enum bpSite : int      //site of bp
        {
            upperArm, lowerArm, calf, thigh, wrist
        };

        //Respiratory
        public float respRate;
        public enum respRhythm  : int   //description of breathing
        {
            Irregular, Distressed, Labored, Regular
        };

        //Pulse (in bpm)
        public float pulseRate;
        public enum pulseStrength : int  //strength of pulse
        {
            Absent, Thready, Normal, Increased, Full
        };
        public enum pulseSite : int      //site of pulse measurement
        {
            Apical, Radial, Popliteal, Carotid, PostTibialis, DorsalPedis
        };

        //Temperature (in F or C)
        public float Temperature;//should change to Temperature to avoid ambiguity
        public enum fahCel : int
        {
            F, C
        };
        public enum tempSite : int      //site of temp reading
        {
            Oral, Temporal, Axillary, Rectal, Otic
        };

        //ASSESSMENT

        //General Survey

        //a&o
        public bool person, time, place, situation;
        public byte aAndO;      //alertness and orientation rating 0 - 4

        //family present
        public bool spouse, children, parents, other;
        public string otherText;

        //general affect
        public bool calm, appropriate, alert, anxious, flat, unresponsive, agitated, aggressive;

        //readiness to learn
        public bool engaged, receptive, questions, posFeed;    //Unengaged and Negative non-verbal feedback derived

        //HEENT

        //PERRLA
        public bool pupilsEqual, round, reactLight, accommodating;

        //EOMs
        public enum extraOcMov : int
        {
            Normal, GeneralNystagmus, CN3Impair, CN4Impair, CN6Impair
        };

        //Carotid artery [p1]
        public bool carotidArtBruit;   //0 = no bruit, 1 = bruit auscultated

        //Upper extremities

        //skin
        public bool upExSkinHot, upExSkinWarm, upExSkinCold, upExSkinDry, upExSkinMoist, upExSkinCracked;
        public string upExPressureUlcer;

        //capillary refill
        public enum upperExCapRefill : int
        {
            Absent, Slow, Two, One, Brisk
        };

        //strength/rom
        public enum upperExStrength : int
        {
            None, Severe, Poor, Average, Slight, Normal
        };

        //edema
        public enum upperExEdema : int
        {
            None, Barely, Less5Mil, FiveMil, Centi
        };

        //Pulmonary

        //overall
        public enum pulmOverall : int
        {
            Absent, DimOverall, DimBases, Normal
        };

        //left upper lobe [mc]
        public bool leftUpLobeNormal, leftUpLobeDim, leftUpLobeFine, leftUpLobeCoarse, leftUpLobeWheeze, leftUpLobeRhonchi, leftUpLobePleural, leftUpLobeAbsent;

        //left lower lobe
        public bool leftLowLobeNormal, leftLowLobeDim, leftLowLobeFine, leftLowLobeCoarse, leftLowLobeWheeze, leftLowLobeRhonchi, leftLowLobePleural, leftLowLobeAbsent;

        //right upper lobe
        public bool rightUpLobeNormal, rightUpLobeDim, rightUpLobeFine, rightUpLobeCoarse, rightUpLobeWheeze, rightUpLobeRhonchi, rightUpLobePleural, rightUpLobeAbsent;

        //right middle lobe
        public bool rightMidLobeNormal, rightMidLobeDim, rightMidLobeFine, rightMidLobeCoarse, rightMidLobeWheeze, rightMidLobeRhonchi, rightMidLobePleural, rightMidLobeAbsent;

        //right lower lobe
        public bool rightLowLobeNormal, rightLowLobeDim, rightLowLobeFine, rightLowLobeCoarse, rightLowLobeWheeze, rightLowLobeRhonchi, rightLowLobePleural, rightLowLobeAbsent;

        //Cardiac
        public bool cardMurmS1_S2, cardMurmS3, cardMurmS4, cardMurmPres;

        //Abdomen

        //overall
        public bool abTend;    //0 = non-tender, 1 = tender
        public bool abDist;    //0 = non-distended, 1 = distended
        public bool abBowelPres, abBowelHypo, abBowelAbsent;

        //right-upper quadrant
        public bool abRUQBowelPres, abRUQBowelHypo, abRUQBowelAbsent, abRUQTympanic, abRUQResonant, abRUQHyper, abRUQFlat, abRUQDull;

        //left-upper quadrant
        public bool abLUQBowelPres, abLUQBowelHypo, abLUQBowelAbsent, abLUQTympanic, abLUQResonant, abLUQHyper, abLUQFlat, abLUQDull;

        //right-lower quadrant
        public bool abRLQBowelPres, abRLQBowelHypo, abRLQBowelAbsent, abRLQTympanic, abRLQResonant, abRLQHyper, abRLQFlat, abRLQDull;

        //left-lower quadrant
        public bool abLLQBowelPres, abLLQBowelHypo, abLLQBowelAbsent, abLLQTympanic, abLLQResonant, abLLQHyper, abLLQFlat, abLLQDull;

        //Lower Extremities

        //skin
        public bool lowExSkinHot, lowExSkinWarm, lowExSkinCold, lowExSkinDry, lowExSkinMoist, lowExSkinCracked;
        public string lowExPressureUlcer;

        //capillary refill
        enum lowerExCapRefill
        {
            Absent, Slow, Two, One, Brisk
        };

        //strength/rom
        enum lowerExStrength
        {
            None, Severe, Poor, Average, Slight, Normal
        };

        //edema
        public enum lowerExEdema
        {
            None, Barely, Less5Mil, FiveMil, Centi
        };
        public lowerExEdema lowerExEdemaVar;

        //SAFETY CHECKS

        //Braden

        //sensory perception
        public int sensePercep;

        //moisture
        public int moisture;

        //activity
        public int activity;

        //mobility
        public int mobility;

        //nutrition
        public int nutrition;

        //friction and shear
        public int frictionShear;

        //Morse

        //history
        public int fallHistory;

        //secondary diagnosis
        public int multDiagnosis;

        //ambulatory aid
        public int ambAid;

        //IV therapy/heparin lock
        public int IVtherapy;

        //gait
        public int gait;

        //mental status
        public int mentalStatus;

        //-------------------------//
        //----------NOTES----------//
        //-------------------------//

        //PROVIDER NOTE
        string provChiefComplaint;
        string provContributingFactor;
        string provOther;

        //NURSING NOTE
        string nurseChiefComplaint;
        string nurseContributingFactor;
        string nurseOther;

        //-------------------------//
        //----------ORDERS---------//
        //-------------------------//

        //MEDICATIONS
        Medication asNeededMeds;
        Medication ongoingMeds;

        //NURSING ORDERS
        
        //Activity/Positioning

        //activity goal
        string activityGoal;

        //head of bed
        enum bedHead
        {
            LowFowlers, SemiFowlers, StandardFowlers, HighFowlers, Trendelenburg, RevTrendelenburg
        };

        //positioning
        enum positioning
        {
            Supine, Prone, Sims, DorsalRecumb, LateralRecumb, Standing, Sitting, Squatting, KneeChest
        };

        //Infection Precautions
        enum infectionPrec
        {
            Standard, Contact, ContactCDiff, Droplet, Airborne
        };

        //Other Requests
        string communication;
        string preferences;
        string irregularities;
    }
}
