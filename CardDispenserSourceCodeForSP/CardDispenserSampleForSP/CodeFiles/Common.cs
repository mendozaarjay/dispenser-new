using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace CardDispenserSampleForSP
{
    public static class Common
    {
        public static byte CalculateXorForSRD2000(byte[] msg)
        {
            byte caluculatedXor = 0;
            for (int i = 0; i < msg.Length - 1; i++)
            {
                caluculatedXor ^= msg[i];
            }

            return caluculatedXor;

        }





        public static void SerialPortListReNEW(ComboBox cmb)
        {
            cmb.Items.Clear();
            string[] portList = System.IO.Ports.SerialPort.GetPortNames();
            foreach (string portName in portList)
            {
                string pName;
                if (portName.Length > 5)//I don't know why but for USB card reader, portname was a strange very long string started with COM7 then I removed rest of it in case of long portName
                    pName = portName.Substring(0, 4);
                else
                    pName = portName;


                cmb.Items.Add(pName);
            }

            cmb.Items.Add(string.Empty);//for selectring nothing

        }


    }


    public partial class IntermediateTransitForMainUI
    {
        public int TransitID { get; set; }

        public Nullable<System.DateTime> EntranceDT { get; set; }
        public Nullable<System.DateTime> ExitDT { get; set; }
        public Nullable<System.DateTime> PaymentDT { get; set; }
        public Nullable<int> TransitTypeNum { get; set; }
        public Nullable<bool> ParkerIsRegular { get; set; }
        public Nullable<int> MediaType { get; set; }

        public string EntranceGateName { get; set; }
        public Nullable<int> EntranceUserID { get; set; }
        public Nullable<int> EntranceGateID { get; set; }
        public Nullable<int> ExitGateID { get; set; }
        public Nullable<int> ExitUserID { get; set; }
        public Nullable<int> PaymentGateID { get; set; }
        public Nullable<int> PaymentUserID { get; set; }

        public string EntranceUserName { get; set; }
        public Bitmap EntranceImage1 { get; set; }
        public Bitmap EntranceImage2 { get; set; }
        public Bitmap ExitImage1 { get; set; }
        public Bitmap ExitImage2 { get; set; }
        public Bitmap PosImage1 { get; set; }

        public Bitmap EntranceThumbnail1 { get; set; }
        public Bitmap EntranceThumbnail2 { get; set; }
        public Bitmap ExitThumbnail1 { get; set; }
        public Bitmap ExitThumbnail2 { get; set; }
        public Bitmap PosThumbnail1 { get; set; }

        public Nullable<decimal> FeeAmount { get; set; }
        public Nullable<decimal> DiscountAmount { get; set; }
        //public Nullable<decimal> FinesAmount { get; set; }
        public Nullable<decimal> VatAmount { get; set; }
        public Nullable<decimal> PrepaidAmount { get; set; }
        public Nullable<decimal> DueAmount { get; set; }
        public Nullable<decimal> TenderedAmount { get; set; }
        public Nullable<decimal> ChangeAmount { get; set; }

        public string LPN { get; set; }
        public Nullable<bool> CardIsEjected { get; set; }
        public Nullable<decimal> CardIssueString { get; set; }
        public Nullable<bool> CardCaptured { get; set; }
        public Nullable<bool> CardLostOrDamaged { get; set; }


        public Nullable<bool> Exited { get; set; }

        public Nullable<bool> EntryIsSavedAutomatically { get; set; }//When a regular parker want to go out and it has no pending entry to save exit for it, an automatic entry would be save for him to be able to save the exit
        public Nullable<bool> ExitIsSavedAutomatically { get; set; }//When a regular parker want to come in and it has another pending entry that is not finalized, to be able to save a new entry for him, an automatic exit would be saved for him to be able to save a new enter


        public Nullable<bool> IsEntering { get; set; }//this field added to distinguish between exiting vehicles and the entring vehicles at the POS


        public Nullable<bool> EntryConfirmedByCloseLoop { get; set; }
        public Nullable<bool> EntrySavedManually { get; set; }
        public Nullable<bool> ExitSavedManually { get; set; }

        public Nullable<bool> PaidBeforeExit { get; set; }

        public int RticketID { get; set; }//this ID is the FK from RticketNumbers Table, using this ID, we can get the corresponding RtciketNumber from that table
        public string RtNoString { get; set; }
        public int FticketID { get; set; }//this ID is the FK from FticketNumbers Table, using this ID, we can get the corresponding FtciketNumber from that table
        public string FtNoString { get; set; }

        public int OrNumber { get; set; }
        public int OrReceiptID { get; set; }
        public int FrNumber { get; set; }
        public int FrReceiptID { get; set; }

        public string WhyThisRateIsSelected { get; set; }

        public bool IgnoreGraceMinutesBecasueItIsAsecondPayment { get; set; }


        public string DiscountAppliedForPersonName { get; set; }
        public string DiscountAppliedForPersonAddress { get; set; }
        public string DiscountAppliedForPersonTin { get; set; }
        public string DiscountAppliedForPersonScPwdID { get; set; }

        public Nullable<int> DiscountTypeID { get; set; }

        public string EraseRemark { get; set; }

        public Nullable<bool> CashlessPayment { get; set; }
        public Nullable<int> CashlessTypeID { get; set; }
        public string CashlessRefrenceNo { get; set; }


        public Nullable<System.DateTime> FreeDaysBeginAtDate { get; set; }
        public Nullable<System.DateTime> FreeDaysEndAtDate { get; set; }


        public string LostCardOrCrNo { get; set; }
        public string LostCardLicenseName { get; set; }
        public string LostCardLicenseNo { get; set; }

        public Nullable<decimal> LostCardPenaltyAmount { get; set; }
        public Nullable<decimal> OvernightPenaltyAmount { get; set; }

        public Nullable<int> NumberOfCoupons { get; set; }

        public Nullable<int> PredefinedRateId { get; set; }

        public Nullable<bool> PaymentIsZeroBecasueInGraceMinutes { get; set; }

    }

}
