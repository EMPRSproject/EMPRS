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
        int patientID;          //patient ID
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
        enum bpSite         //site of bp: 'l', 'r', or NULL
        {
            upperArm, lowerArm, calf, thigh, wrist
        };

        //Respiratory
        float respRate;
        string respRhythm;      //description of breathing: "regular", "labored", "distressed", or "irregular"

        //Pulse
        float pulseRate, pulseStrength;
        bool apical, radial, popliteal, carotid, posteriorTibalis, dorsalisPedis;   //site of pulse: 0 = not measured here, 1 = measured here

        //Temperature
        float temp;
        enum tempSite       //site of temp reading: 0 = not measured here, 1 = measured here
        {
            
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
        enum upperExSkinTemp
        {
            Hot, Warm, Cold
        };

        enum upperExSkinHumid
        {
            Cracked, Dry, Moist
        };

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

        //left upper lobe
        enum leftUpLobe
        {
            Absent, Pleural, Rhonchi, Wheeze, Coarse, Fine, Dim, Normal
        };

        //left lower lobe
        enum leftLowLobe
        {
            Absent, Pleural, Rhonchi, Wheeze, Coarse, Fine, Dim, Normal
        };

        //right upper lobe
        enum rightUpLobe
        {
            Absent, Pleural, Rhonchi, Wheeze, Coarse, Fine, Dim, Normal
        };

        //right middle lobe
        enum rightMidLobe
        {
            Absent, Pleural, Rhonchi, Wheeze, Coarse, Fine, Dim, Normal
        };

        //right lower lobe
        enum rightLowLobe
        {
            Absent, Pleural, Rhonchi, Wheeze, Coarse, Fine, Dim, Normal
        };

        //Cardiac
        enum cardMurm
        {
            Murmur, S4, S3, S1_2
        };

        //Abdomen

        //overall
        bool abTend;    //0 = non-tender, 1 = tender
        bool abDist;    //0 = non-distended, 1 = distended
        enum abOverBowel
        {
            Absent, Hypoactive, Present
        };

        //right-upper quadrant
        enum abRUBowel
        {
            Absent, Hypoactive, Present
        };

        enum abRUQuality
        {
            Dull, Flat, Hyper, Resonant, Tympanic
        };

        //left-upper quadrant
        enum abLUBowel
        {
            Absent, Hypoactive, Present
        };

        enum abLUQuality
        {
            Dull, Flat, Hyper, Resonant, Tympanic
        };

        //right-lower quadrant
        enum abRLBowel
        {
            Absent, Hypoactive, Present
        };

        enum abRLQuality
        {
            Dull, Flat, Hyper, Resonant, Tympanic
        };

        //left-lower quadrant
        enum abLLBowel
        {
            Absent, Hypoactive, Present
        };

        enum abLLQuality
        {
            Dull, Flat, Hyper, Resonant, Tympanic
        };

        //Lower Extremities

        //skin
        enum lowerExSkinTemp
        {
            Hot, Warm, Cold
        };

        enum lowerExSkinHumid
        {
            Cracked, Dry, Moist
        };

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
            CompLimit, VeryLimit, SlightLimit, NoImpair
        };

        //moisture
        enum moisture
        {
            ConstMoist, VeryMoist, OccMoist, RareMoist
        };

        //activity
        enum activity
        {
            Bedfast, Chairfast, WalksOcc, WalksFreq
        };

        //mobility
        enum mobility
        {
            Immobile, VeryLimit, SlightLimit, NoLimit
        };

        //nutrition
        enum nutrition
        {
            Poor, Inadequate, Adequate, Excellent
        };

        //friction and shear
        enum frictionShear
        {
            Problem, PotProb, NoProb
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
        string newMeds;
        string discMeds;
        string modMeds;
        string ongoingMeds;

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
