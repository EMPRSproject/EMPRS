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

        string nameL, nameF;    //patient last and first name
        int age;                //patient age
        DateTime DOB;           //patient DOB
        enum sex                //patient sex
        {
            M, F
        };
        int height;             //patient height
        int weight;             //patient weight

        //-----------------------------------//
        //----------------MAR----------------//
        //---medical administration record---// 
       
        private struct Medication   //information about medication given to patient
        {
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

        //electrolytes, protein, other (HCO3 = bicarbonate, BUN = blood urea nitrogen)
        float sodium, potassium, chloride, HCO3, BUN, creatinine, glucose, calcium;
        float magnesium, phosphate, protein, albumin, AST, ALT, LDH, ALP, bilirubin;

        //CBC
        float HCT, RBC, Hgb, WBC, PLT;

        //hemostasis labs
        float PT, PTT, INR;

        //cardiac enzymes
        float myoglobin, cTnI, cTnT, CPK_CKMB2;

        //IMAGING
        //does anything need to be here???
        //currently looking into server/database integration and what that means for images
        
        //-------------------------//
        //-----ASSESSMENT DATA-----//
        //-------------------------//

        //VITAL SIGNS

        //Blood pressure
        float SBP, DBP;
        enum bpLR   //side of bp
        {
            L, R
        };
        enum bpSite         //site of bp
        {
            upperArm, lowerArm, calf, thigh, wrist
        };

        //Respiratory
        float respRate;
        enum respRhythm     //description of breathing
        {
            Irregular, Distressed, Labored, Regular
        };

        //Pulse (in bpm)
        float pulseRate;
        enum pulseStrength   //strength of pulse
        {
            Absent, Thready, Normal, Increased, Full
        };
        enum pulseSite      //site of pulse measurement
        {
            Apical, Radial, Popliteal, Carotid, PostTibialis, DorsalPedis
        };

        //Temperature (in F or C)
        float temp;
        enum fahCel
        {
            F, C
        };
        enum tempSite       //site of temp reading
        {
            Oral, Temporal, Axillary, Rectal, Otic
        };

        //ASSESSMENT

        //General Survey

        //a&o
        bool person, time, place, situation;
        byte aAndO;      //alertness and orientation rating 0 - 4

        //family present
        bool spouse, children, parents, other;
        string otherText;

        //general affect
        bool calm, appropriate, alert, anxious, flat, unresponsive, agitated, aggressive;

        //readiness to learn
        bool engaged, receptive, questions, posFeed;    //Unengaged and Negative non-verbal feedback derived

        //HEENT

        //PERRLA
        bool pupilsEqual, round, reactLight, accommodating;

        //EOMs
        enum extraOcMov
        {
            Normal, GeneralNystagmus, CN3Impair, CN4Impair, CN6Impair
        };

        //Carotid artery [p1]
        bool carotidArtBruit;   //0 = no bruit, 1 = bruit auscultated

        //Upper extremities

        //skin
        bool upExSkinHot, upExSkinWarm, upExSkinCold, upExSkinDry, upExSkinMoist, upExSkinCracked;
        string uppExtPressureUlcer;

        //capillary refill
        enum upperExCapRefill
        {
            Absent, Slow, Two, One, Brisk
        };

        //strength/rom
        enum upperExStrength
        {
            None, Severe, Poor, Average, Slight, Normal
        };

        //edema
        enum upperExEdema
        {
            None, Barely, Less5Mil, FiveMil, Centi
        };

        //Pulmonary

        //overall
        enum pulmOverall
        {
            Absent, DimOverall, DimBases, Normal
        };

        //left upper lobe [mc]
        bool leftUpLobeNormal, leftUpLobeDim, leftUpLobeFine, leftUpLobeCoarse, leftUpLobeWheeze, leftUpLobeRhonchi, leftUpLobePleural, leftUpLobeAbsent;

        //left lower lobe
        bool leftLowLobeNormal, leftLowLobeDim, leftLowLobeFine, leftLowLobeCoarse, leftLowLobeWheeze, leftLowLobeRhonchi, leftLowLobePleural, leftLowLobeAbsent;

        //right upper lobe
        bool rightUpLobeNormal, rightUpLobeDim, rightUpLobeFine, rightUpLobeCoarse, rightUpLobeWheeze, rightUpLobeRhonchi, rightUpLobePleural, rightUpLobeAbsent;

        //right middle lobe
        bool rightMidLobeNormal, rightMidLobeDim, rightMidLobeFine, rightMidLobeCoarse, rightMidLobeWheeze, rightMidLobeRhonchi, rightMidLobePleural, rightMidLobeAbsent;

        //right lower lobe
        bool rightLowLobeNormal, rightLowLobeDim, rightLowLobeFine, rightLowLobeCoarse, rightLowLobeWheeze, rightLowLobeRhonchi, rightLowLobePleural, rightLowLobeAbsent;

        //Cardiac
        bool cardMurmS1_S2, cardMurmS3, cardMurmS4, cardMurmPres;

        //Abdomen

        //overall
        bool abTend;    //0 = non-tender, 1 = tender
        bool abDist;    //0 = non-distended, 1 = distended
        bool abBowelPres, abBowelHypo, abBowelAbsent;

        //right-upper quadrant
        bool abRUQBowelPres, abRUQBowelHypo, abRUQBowelAbsent, abRUQTympanic, abRUQResonant, abRUQHyper, abRUQFlat, abRUQDull;

        //left-upper quadrant
        bool abLUQBowelPres, abLUQBowelHypo, abLUQBowelAbsent, abLUQTympanic, abLUQResonant, abLUQHyper, abLUQFlat, abLUQDull;

        //right-lower quadrant
        bool abRLQBowelPres, abRLQBowelHypo, abRLQBowelAbsent, abRLQTympanic, abRLQResonant, abRLQHyper, abRLQFlat, abRLQDull;

        //left-lower quadrant
        bool abLLQBowelPres, abLLQBowelHypo, abLLQBowelAbsent, abLLQTympanic, abLLQResonant, abLLQHyper, abLLQFlat, abLLQDull;

        //Lower Extremities

        //skin
        bool lowExSkinHot, lowExSkinWarm, lowExSkinCold, lowExSkinDry, lowExSkinMoist, lowExSkinCracked;
        string lowExtpressureUlcer;

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
        enum lowerExEdema
        {
            None, Barely, Less5Mil, FiveMil, Centi
        };

        //SAFETY CHECKS

        //Braden

        //sensory perception
        enum sensePercep
        {
            CompLimit = 1, VeryLimit = 2, SlightLimit = 3, NoImpair = 4
        };

        //moisture
        enum moisture
        {
            ConstMoist = 1, VeryMoist = 2, OccMoist = 3, RareMoist = 4
        };

        //activity
        enum activity
        {
            Bedfast = 1, Chairfast = 2, WalksOcc = 3, WalksFreq = 4
        };

        //mobility
        enum mobility
        {
            Immobile = 1, VeryLimit = 2, SlightLimit = 3, NoLimit = 4
        };

        //nutrition
        enum nutrition
        {
            Poor = 1, Inadequate = 2, Adequate = 3, Excellent = 4
        };

        //friction and shear
        enum frictionShear
        {
            Problem = 1, PotProb = 2, NoProb = 3
        };

        //Morse

        //history
        enum fallHistory
        {
            No = 0, Yes = 25
        };

        //secondary diagnosis
        enum multDiagnosis
        {
            No = 0, Yes = 15
        };

        //ambulatory aid
        enum ambAid
        {
            None = 0, Crutch = 15, Furniture = 30
        };

        //IV therapy/heparin lock
        enum IVtherapy
        {
            No = 0, Yes = 20
        };

        //gait
        enum gait
        {
            Normal = 0, Weak = 10, Impaired = 20
        };

        //mental status
        enum mentalStatus
        {
            Oriented = 0, Overestimates = 15
        };

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
        Medication newMeds;
        Medication discMeds;
        Medication modMeds;
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
