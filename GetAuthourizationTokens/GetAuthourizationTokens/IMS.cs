/// <summary>
/// IMS class to define all the Properties related to IMS request and Response
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GetAuthorizationTokens
{
    public class IMSResponse
    {
        public string guid { get; set; }

        public string completeProfileLink { get; set; }

        public string authorizationCode { get; set; }
    }

    public class Token
    {
        public string access_token { get; set; }

        public string refresh_token { get; set; }

        public double expires_in { get; set; }
    }

    public class IMSRequest
    {
        [DataMember(EmitDefaultValue = false)]
        public Person person { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Targetclient targetClient { get; set; }
    }

    [DataContract]
    public class Person
    {
        [DataMember(EmitDefaultValue = false)]
        public string email { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string firstName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string lastName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string countryCode { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string locale { get; set; }
    }

    [DataContract]
    public class Targetclient
    {
        [DataMember(EmitDefaultValue = false)]
        public string clientId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string scopes { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string responseType { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string callbackUrl { get; set; }
    }

    #region Country and Region

    [DataContract]
    public class IMSCountryResponse
    {
        [DataMember(Name = "countries", EmitDefaultValue = false)]
        public List<CountryDetail> countrylist { get; set; }
    }

    [DataContract]
    public class CountryDetail
    {
        [DataMember(EmitDefaultValue = false)]
        public string countryCode { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string countryName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string countryCodeISO3 { get; set; }
    }

    [DataContract]
    public class IMSRegionResponse
    {
        [DataMember(Name = "regions", EmitDefaultValue = false)]
        public List<RegionDetail> Regionlist { get; set; }
    }

    [DataContract]
    public class RegionDetail
    {
        [DataMember(EmitDefaultValue = false)]
        public string regionName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string regionCode { get; set; }
    }

    [DataContract]
    public class Region
    {
        [DataMember(EmitDefaultValue = false)]
        public string regionName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string regionCode { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Guid countryCRMId { get; set; }
    }

    #endregion

    #region Org

    [DataContract(Name = "orgRef")]
    public class OrgRef
    {
        [DataMember(Name = "ident", EmitDefaultValue = false)]
        public string ident { get; set; }


        [DataMember(Name = "authSrc", EmitDefaultValue = false)]
        public string authSrc { get; set; }
    }

    [DataContract(Name = "groups")]
    public class Groups
    {
        [DataMember(Name = "groupName", EmitDefaultValue = false)]
        public string groupName { get; set; }

        [DataMember(Name = "role", EmitDefaultValue = false)]
        public string role { get; set; }


        [DataMember(Name = "ident", EmitDefaultValue = false)]
        public string ident { get; set; }


        [DataMember(Name = "groupType", EmitDefaultValue = false)]
        public string groupType { get; set; }
    }

    //Org Domains
    [DataContract]
    public class OrganizationDetail
    {
        [DataMember(Name = "orgName", EmitDefaultValue = false)]
        public string orgName { get; set; }

        [DataMember(Name = "orgRef", EmitDefaultValue = false)]
        public OrgRef orgRef { get; set; }

        [DataMember(Name = "orgType", EmitDefaultValue = false)]
        public string orgType { get; set; }

        [DataMember(Name = "groups", EmitDefaultValue = false)]
        public List<Groups> groups { get; set; }

        //Added by MKEER 09/11/2018 
        public List<OrganizationDomainItem> OrganizationDomainItem { get; set; }
    }


    [DataContract]
    public class OrganizationDomainResponse
    {
        [DataMember(Name = "startIndex", EmitDefaultValue = false)]
        public int StartIndex { get; set; }

        [DataMember(Name = "batchSize", EmitDefaultValue = false)]
        public int BatchSize { get; set; }

        [DataMember(Name = "totalSize", EmitDefaultValue = false)]
        public int TotalSize { get; set; }

        [DataMember(Name = "items", EmitDefaultValue = false)]
        public List<OrganizationDomainItem> OrganizationDomainItem { get; set; }
    }

    [DataContract(Name = "items")]
    public class OrganizationDomainItem
    {
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "status", EmitDefaultValue = false)]
        public string Status { get; set; }


    }
    [DataContract]
    public class AccountTypeResponse
    {
        [DataMember(Name = "account_type", EmitDefaultValue = false)]
        public string AccountType { get; set; }
    }

    #endregion

    #region Customer 360

    [DataContract]
    public class ContactRoleResponse
    {
        [DataMember(Name = "userId", EmitDefaultValue = false)]
        public string RengaId { get; set; }

        [DataMember(Name = "account_type", EmitDefaultValue = false)]
        public string AccountType { get; set; }

        [DataMember(Name = "preferred_languages", EmitDefaultValue = false)]
        public List<string> PreferredLanguages { get; set; }

        [DataMember(Name = "roles", EmitDefaultValue = false)]
        public List<ContactRole> ContactRoleList { get; set; }

        [DataMember(Name = "first_name", EmitDefaultValue = false)]
        public string ContactFirstName { get; set; }

        [DataMember(Name = "last_name", EmitDefaultValue = false)]
        public string ContactLastName { get; set; }

        [DataMember(Name = "address.mail_to", EmitDefaultValue = false)]
        public Address Address { get; set; }

        [DataMember(Name = "email", EmitDefaultValue = false)]
        public string AdobeID { get; set; }

        [DataMember(Name = "phoneNumber", EmitDefaultValue = false)]
        public string PhoneNumber { get; set; }

        [DataMember(Name = "countryCode", EmitDefaultValue = false)]
        public string Country { get; set; }

    }

    [DataContract(Name = "roles")]
    public class ContactRole
    {
        [DataMember(Name = "principal", EmitDefaultValue = false)]
        public string Principal { get; set; }

        [DataMember(Name = "organization", EmitDefaultValue = false)]
        public string Organization { get; set; }

        [DataMember(Name = "named_role", EmitDefaultValue = false)]
        public string NamedRole { get; set; }

        [DataMember(Name = "target", EmitDefaultValue = false)]
        public string Target { get; set; }

        [DataMember(Name = "target_type", EmitDefaultValue = false)]
        public string TargetType { get; set; }

        [DataMember(Name = "target_data", EmitDefaultValue = false)]
        public ContactRoleTargetData TargetData { get; set; }
    }

    [DataContract(Name = "target_data")]
    public class ContactRoleTargetData
    {
        [DataMember(Name = "gid", EmitDefaultValue = false)]
        public string Gid { get; set; }

        [DataMember(Name = "group_name", EmitDefaultValue = false)]
        public string GroupName { get; set; }
    }

    #endregion

    #region Contact

    //ContactType
    [DataContract]
    public class ContactTypeResponse
    {
        [DataMember(Name = "account_type", EmitDefaultValue = false)]
        public string ContactType { get; set; }

        [DataMember(Name = "first_name", EmitDefaultValue = false)]
        public string FirstName { get; set; }

        [DataMember(Name = "last_name", EmitDefaultValue = false)]
        public string LastName { get; set; }

        [DataMember(Name = "userId", EmitDefaultValue = false)]
        public string RengaID { get; set; }

        [DataMember(Name = "email", EmitDefaultValue = false)]
        public string AdobeID { get; set; }

        [DataMember(Name = "phoneNumber", EmitDefaultValue = false)]
        public string PhoneNumber { get; set; }

        [DataMember(Name = "countryCode", EmitDefaultValue = false)]
        public string Country { get; set; }

    }

    [DataContract]
    public class Address
    {
        [DataMember(Name = "city", EmitDefaultValue = false)]
        public string City { get; set; }

        [DataMember(Name = "postalZip", EmitDefaultValue = false)]
        public string Zipcode { get; set; }

        [DataMember(Name = "stateProv", EmitDefaultValue = false)]
        public string State { get; set; }
    }

    //Contact Security Phone Number
    public class SecIMSResponse
    {
        public string user_id { get; set; }

        public string security_phone_number { get; set; }

        public bool mfa_enabled { get; set; }
    }
    #endregion

}
