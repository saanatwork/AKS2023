using AKS.BOL.Accounts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.DAL.ObjectMapper
{
    public class AccountsObjectMapper
    {
        string objPath = "AKS.DAL.ObjectMapper.AccountsObjectMapper";

        public Journal4DT Map_Journal4DT(DataRow dr, ref string pMsg)
        {
            Journal4DT result = new Journal4DT();
            try
            {
                if (dr != null)
                {
                    if (!DBNull.Value.Equals(dr["RowNum"]))
                        result.RowNum = int.Parse(dr["RowNum"].ToString());
                    if (!DBNull.Value.Equals(dr["TotalCount"]))
                        result.TotalCount = int.Parse(dr["TotalCount"].ToString());
                    if (!DBNull.Value.Equals(dr["TotalRecords"]))
                        result.TotalRecords = int.Parse(dr["TotalRecords"].ToString());
                    if (!DBNull.Value.Equals(dr["VoucherNumber"]))
                        result.VoucherNumber =dr["VoucherNumber"].ToString();
                    if (!DBNull.Value.Equals(dr["VoucherDate"]))
                        result.VoucherDate =DateTime.Parse(dr["VoucherDate"].ToString());
                    if (!DBNull.Value.Equals(dr["VoucherType"]))
                        result.VoucherType = dr["VoucherType"].ToString();
                    if (!DBNull.Value.Equals(dr["RefDocNo"]))
                        result.RefDocNo = dr["RefDocNo"].ToString();
                    if (!DBNull.Value.Equals(dr["CreatedByID"]))
                        result.CreatedByID =int.Parse(dr["CreatedByID"].ToString());
                    if (!DBNull.Value.Equals(dr["CreatorName"]))
                        result.CreatorName = dr["CreatorName"].ToString();
                    if (!DBNull.Value.Equals(dr["VrStatus"]))
                        result.VrStatus = dr["VrStatus"].ToString();
                    if (!DBNull.Value.Equals(dr["IsUpdated"]))
                        result.IsUpdated =bool.Parse(dr["IsUpdated"].ToString());

                    result.VoucherDateStr = result.VoucherDate.ToString("dd-MM-yyyy");
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_Journal4DT(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }
        public Journal Map_Journal(DataTable dt,string JVRemarks, ref string pMsg)
        {
            Journal result = new Journal();
            try
            {
                if (dt != null && dt.Rows.Count > 0) 
                {
                    JournalHeading hdr = Map_JournalHeading(dt.Rows[0], ref pMsg);
                    hdr.JVRemarks = JVRemarks;
                    List <JournalDetails> dtls = new List<JournalDetails>();
                    for (int i = 0; i < dt.Rows.Count; i++) 
                    {
                        dtls.Add(Map_JournalDetails(dt.Rows[i], ref pMsg));
                    }
                    result.Header = hdr;
                    result.Details = dtls;
                }
                    
            }
            catch (Exception ex) { pMsg = objPath + ".Map_Journal(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }
        public JournalHeading Map_JournalHeading(DataRow dr, ref string pMsg)
        {
            JournalHeading result = new JournalHeading();
            try
            {
                if (dr != null)
                {
                    if (!DBNull.Value.Equals(dr["VoucherNumber"]))
                        result.VoucherNumber = dr["VoucherNumber"].ToString();
                    if (!DBNull.Value.Equals(dr["VoucherDate"]))
                        result.VoucherDate = DateTime.Parse(dr["VoucherDate"].ToString());
                    if (!DBNull.Value.Equals(dr["IsUpdated"]))
                        result.IsUpdated = bool.Parse(dr["IsUpdated"].ToString());
                    if (!DBNull.Value.Equals(dr["VoucherType"]))
                        result.VoucherType = dr["VoucherType"].ToString();
                    if (!DBNull.Value.Equals(dr["RefDocNo"]))
                        result.RefDocNo = dr["RefDocNo"].ToString();
                    if (!DBNull.Value.Equals(dr["CreatedByID"]))
                        result.CreatedByID = int.Parse(dr["CreatedByID"].ToString());
                    if (!DBNull.Value.Equals(dr["ApprovedBy"]))
                        result.ApprovedBy = int.Parse(dr["ApprovedBy"].ToString());
                    if (!DBNull.Value.Equals(dr["CreatorName"]))
                        result.CreatorName = dr["CreatorName"].ToString();
                    if (!DBNull.Value.Equals(dr["ApproverName"]))
                        result.CreatorName = dr["ApproverName"].ToString();
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_JournalHeading(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }
        public JournalDetails Map_JournalDetails(DataRow dr, ref string pMsg)
        {
            JournalDetails result = new JournalDetails();
            try
            {
                if (dr != null)
                {
                    if (!DBNull.Value.Equals(dr["ProfitCentreID"]))
                        result.ProfitCentreID = int.Parse(dr["ProfitCentreID"].ToString());
                    if (!DBNull.Value.Equals(dr["ProfitCentreDesc"]))
                        result.ProfitCentreDesc = dr["ProfitCentreDesc"].ToString();
                    if (!DBNull.Value.Equals(dr["ACD"]))
                        result.ACD =dr["ACD"].ToString();
                    if (!DBNull.Value.Equals(dr["ACDDesc"]))
                        result.ACDDesc = dr["ACDDesc"].ToString();
                    if (!DBNull.Value.Equals(dr["SCD"]))
                        result.SCD =int.Parse(dr["SCD"].ToString());
                    if (!DBNull.Value.Equals(dr["SCDDesc"]))
                        result.SCDDesc = dr["SCDDesc"].ToString();
                    if (!DBNull.Value.Equals(dr["Amount"]))
                        result.Amount = double.Parse(dr["Amount"].ToString());
                    if (!DBNull.Value.Equals(dr["CD"]))
                        result.CD = dr["CD"].ToString();
                    if (!DBNull.Value.Equals(dr["VoucherDescription"]))
                        result.VoucherDescription = dr["VoucherDescription"].ToString();
                    if (!DBNull.Value.Equals(dr["DAmount"]))
                        result.DAmount = double.Parse(dr["DAmount"].ToString());
                    if (!DBNull.Value.Equals(dr["CAmount"]))
                        result.CAmount = double.Parse(dr["CAmount"].ToString());
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_JournalDetails(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }
        public GLSummary Map_GLSummary(DataRow dr, ref string pMsg)
        {
            GLSummary result = new GLSummary();
            try
            {
                if (dr != null)
                {                    
                    if (!DBNull.Value.Equals(dr["ACD"]))
                        result.ACD = dr["ACD"].ToString();
                    if (!DBNull.Value.Equals(dr["SCD"]))
                        result.SCD = int.Parse(dr["SCD"].ToString());
                    if (!DBNull.Value.Equals(dr["SCDDesc"]))
                        result.SCDDesc = dr["SCDDesc"].ToString();
                    if (!DBNull.Value.Equals(dr["Amount"]))
                        result.Amount = double.Parse(dr["Amount"].ToString());
                    if (!DBNull.Value.Equals(dr["CD"]))
                        result.CD = dr["CD"].ToString();
                    if (!DBNull.Value.Equals(dr["DAmount"]))
                        result.DAmount = double.Parse(dr["DAmount"].ToString());
                    if (!DBNull.Value.Equals(dr["CAmount"]))
                        result.CAmount = double.Parse(dr["CAmount"].ToString());
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_GLSummary(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }
        public COA Map_COA(DataRow dr, ref string pMsg) 
        {
            COA result = new COA();
            try
            {
                if (dr != null)
                {
                    if (!DBNull.Value.Equals(dr["ACD"]))
                        result.ACD = dr["ACD"].ToString();
                    if (!DBNull.Value.Equals(dr["ACDShortText"]))
                        result.ACDShortText =dr["ACDShortText"].ToString();
                    if (!DBNull.Value.Equals(dr["ACDLongText"]))
                        result.ACDLongText = dr["ACDLongText"].ToString();
                    if (!DBNull.Value.Equals(dr["CD"]))
                        result.CD = dr["CD"].ToString();
                    if (!DBNull.Value.Equals(dr["ACDType"]))
                        result.ACDType = dr["ACDType"].ToString();                    
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_COA(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }




    }
}
