﻿using COLM_SYSTEM_LIBRARY.datasource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model.Payment_Folder
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int RegisteredStudentID { get; set; }
        public int SchoolYearID { get; set; }
        public int SemesterID { get; set; }
        public string ORNumber { get; set; }
        public string FeeCategory { get; set; }
        public string PaymentCategory { get; set; }
        public double AmountPaid { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public int UserID { get; set; }

        public static List<Payment> GetPayments(int RegisteredStudentID,int SchoolYearID, int SemesterID)
        {
            return Payment_DS.GetStudentPayment(RegisteredStudentID, SchoolYearID, SemesterID);
        }

        public static int InsertPayment(Payment payment)
        {
            return Payment_DS.InsertPayment(payment);
        }

        public static bool IsValidORNumber(string ORNumber)
        {
            return Payment_DS.IsValidORnumber(ORNumber);
        }

        public static int ChargeFee(StudentRegistered student, Fee fee, int Quantity)
        {
            return Payment_DS.ChargeFee(student, fee, Quantity);
        }

        public static List<AdditionalFee> GetAdditionalFees(int RegisteredStudentID, int SchoolYearID, int SemesterID)
        {
            return Payment_DS.GetAdditionalFees(RegisteredStudentID, SchoolYearID, SemesterID);
        }

        public static int InsertAdditionalFeePayment(int AssessmentAdditionalFeeID,double Payment)
        {
            return Payment_DS.InsertAdditionalFeePayment(AssessmentAdditionalFeeID, Payment);
        }

        public static int CancelReciept(string ORNumber)
        {
            return Payment_DS.CancelReciept(ORNumber);
        }
    }
}
