﻿namespace TallyConnector.Core.Models;


[XmlRoot(ElementName = "COMPANY")]
public class Company : TallyXmlJson
{

    [XmlElement(ElementName = "NAME")]
    public string? Name { get; set; }

    [XmlElement(ElementName = "GUID")]
    [Column(TypeName = "nvarchar(100)")]
    public string? GUID { get; set; }

    [XmlElement(ElementName = "BASICCOMPANYFORMALNAME")]
    public string? FormalName { get; set; }

    [XmlElement(ElementName = "STATENAME")]
    public string? State { get; set; }

    [XmlElement(ElementName = "COUNTRYNAME")]
    public string? Country { get; set; }

    [XmlElement(ElementName = "PINCODE")]
    public string? PinCode { get; set; }

    [XmlElement(ElementName = "PHONENUMBER")]
    public string? PhoneNumber { get; set; }

    [XmlElement(ElementName = "MOBILENO")]
    public string? MobileNumber { get; set; }

    [XmlElement(ElementName = "REMOTEFULLLISTNAME")]
    public string? Address { get; set; }

    [XmlElement(ElementName = "FAXNUMBER")]
    public string? FaxNumber { get; set; }

    [XmlElement(ElementName = "EMAIL")]
    public string? Email { get; set; }


    [XmlElement(ElementName = "WEBSITE")]
    public string? Website { get; set; }

    [XmlElement(ElementName = "TANUMBER")]
    public string? TANNumber { get; set; }

    [XmlElement(ElementName = "TANREGNO")]
    public string? TANRegNumber { get; set; }

    [XmlElement(ElementName = "TDSDEDUCTORTYPE")]
    public string? TDSDeductorType { get; set; }

    [XmlElement(ElementName = "DEDUCTORBRANCH")]
    public string? TDSDeductorBranch { get; set; }


    [XmlElement(ElementName = "BOOKSFROM")]
    public string? BooksFrom { get; set; }

    [XmlElement(ElementName = "STARTINGFROM")]
    public string? StartingFrom { get; set; }

    [XmlElement(ElementName = "ENDINGAT")]
    public string? EndDate { get; set; }

    [XmlElement(ElementName = "COMPANYNUMBER")]
    public string? CompNum { get; set; }


    //Settings

    [XmlElement(ElementName = "ISINVENTORYON")]
    public string? IsInventoryOn { get; set; }

    [XmlElement(ElementName = "ISINTEGRATED")]
    public string? IntegrateAccountswithInventory { get; set; }

    [XmlElement(ElementName = "ISBILLWISEON")]
    public string? IsBillWiseOn { get; set; }

    [XmlElement(ElementName = "ISCOSTCENTRESON")]
    public string? IsCostCentersOn { get; set; }

    [XmlElement(ElementName = "ISTDSON")]
    public string? IsTDSOn { get; set; }


    [XmlElement(ElementName = "ISTCSON")]
    public string? IsTCSOn { get; set; }

    [XmlElement(ElementName = "ISGSTON")]
    public string? IsGSTOn { get; set; }


    [XmlElement(ElementName = "ISPAYROLLON")]
    public string? IsPayrollOn { get; set; }

    [XmlElement(ElementName = "ISINTERESTON")]
    public string? IsInterestOn { get; set; }

    public override string ToString()
    {
        return $"Company - {Name}";
    }


}

[XmlRoot(ElementName = "COMPANYONDISK")]
public class CompanyOnDisk : TallyXmlJson
{
    [XmlElement(ElementName = "NAME")]
    public string? Name { get; set; }

    [XmlElement(ElementName = "STARTINGFROM")]
    public string? StartDate { get; set; }

    [XmlElement(ElementName = "ENDINGAT")]
    public string? EndDate { get; set; }

    [XmlElement(ElementName = "COMPANYNUMBER")]
    public string? CompNum { get; set; }

    public override string ToString()
    {
        return $"Company - {Name}";
    }
}
