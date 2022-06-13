using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace GetAuthorizationTokens
{
    public static class Constants
    {
        public const string CONSTANT_ACTION_GETSYSTEMSETTINGSAPI = "ent_GetSystemSetting";
        public const string CONSTANT_DECRYPTKEY = "&xvz7]k(Evd+8[<";
        public const string CONSTANT_MILOENCRYPTKEY = "premiumsolIdzipper3$";
        public const string ENTITY_IMSTOKEN = "ent_imstoken";
        public const string ENTITY_SYSTEMSETTINGS = "ent_systemsettings";
        public const string CONSTANT_IMSGROUP = "IMS";
        public const string CONSTANT_REQUESTMETHODPOST = "POST";
        public const string CONSTANT_REQUESTMETHODGET = "GET";
        public const string CONSTANT_REQUESTMETHODDELETE = "DELETE";
        public const string CONSTANT_CONTENTTYPE_JSON = "application/json";
    }

    public static class GetSystemSettingsParameters
    {
        public static string INPARAM_KEY = "Key";
        public static string INPARAM_GROUP = "Group";
        public static string OUTPARAM_RESULT = "Result";
        public static string OUTPARAM_ERROR = "Error";

        
    }
    public class SystemSettingResponse
    {
        [DataMember(EmitDefaultValue = false)]
        public string key { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string value { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string group { get; set; }
    }


    public static class EntityAttributes
    {
        // System Settings attributes
        public const string SYSTEMSETTINGS_GRP_MILO = "MILO";
        public const string SYSTEMSETTINGS_MILO_BASEURL = "BaseUrl";
        public const string SYSTEMSETTINGS_MILO_UPLOADATTACHMENTENDPOINT = "UploadAttachmentEndpoint";
        public const string SYSTEMSETTINGS_MILO_DOWNLOADATTACHMENTENDPOINT = "DownloadAttachmentEndpoint";
        public const string SYSTEMSETTINGS_MILO_DELETEATTACHMENTENDPOINT = "DeleteAttachmentEndpoint";
        public const string SYSTEMSETTINGS_AS_MINFILESIZEKEY = "MinFileSize";
        public const string SYSTEMSETTINGS_MILO_APIKEY = "ApiKey";
        public const string SYSTEMSETTINGS_GRP_ATTACHMENTSTORAGE = "AttachmentStorage";
        public const string SYSTEMSETTINGS_AS_SASTOKEN = "SASToken";
        public const string SYSTEMSETTINGS_AS_STORAGEACCOUNT = "StorageAccount";
        public const string SYSTEMSETTINGS_AS_STORAGEACCOUNTKEY = "StorageAccountKey";
        public const string SYSTEMSETTINGS_AS_STORAGEACCOUNTNAME = "StorageAccountName";
        public const string SYSTEMSETTINGS_AS_ENDPOINT = "StorageAccountEndPoint";
        public const string SYSTEMSETTINGS_AS_NOTESCONTAINER = "NotesContainer";
        public const string SYSTEMSETTINGS_AS_EMAILCONTAINER = "EmailContainer";
        public const string SYSTEMSETTINGS_ATTR_GROUP = "ent_group";
        public const string SYSTEMSETTINGS_ATTR_KEY = "ent_key";
        public const string SYSTEMSETTINGS_ATTR_LONGVALUE = "ent_longvalue";
        public const string SYSTEMSETTINGS_DATA_CACHEVALIDATIONTIMEOUT = "ssCacheValidTimeout";
        public const string SYSTEMSETTINGS_DATA_CLIENTID = "client_id";
        public const string SYSTEMSETTINGS_DATA_CLIENTSECRETE = "client_secret";
        public const string SYSTEMSETTINGS_DATA_CODE = "code";
        public const string SYSTEMSETTINGS_DATA_TOKENENDPOINT = "tokenEndpoint";
        public const string SYSTEMSETTINGS_GRP = "SYSTEM";
        public const string SYSTEMSETTINGS_BASEURL = "Base URL";
        public const string SYSTEMSETTINGS_DATA_COUNTRYENDPOINT = "countriesEndpoint";
        public const string SYSTEMSETTINGS_DATA_REGIONENDPOINT = "regionEndpoint";
        public const string SYSTEMSETTINGS_DATA_SECURITYPHONEENDPOINT = "contactsecurityphoneendpoint";
        public const string SYSTEMSETTINGS_DATA_ORGENDPOINT = "organizationEndpoint";
        public const string SYSTEMSETTINGS_GRP_SHAREPOINT = "SHAREPOINT";
        public const string SYSTEMSETTINGS_SP_BASEURL = "BaseUrl";
        public const string SYSTEMSETTINGS_SP_USERNAME = "username";
        public const string SYSTEMSETTINGS_SP_PASSWORD = "password";
        public const string SYSTEMSETTINGS_DATA_DOMAINSENDPOINT = "domainsEndpoint";
        public const string SYSTEMSETTINGS_DATA_ORGDETAILSENDPOINT = "orgDetailsEndpoint";
        public const string SYSTEMSETTINGS_DATA_ADMINPROFILEENDPOINT = "adminProfileEndpoint";
        public const string SYSTEMSETTINGS_DATA_DEFAULTOWNER = "DefaultOwner";
        public const string SYSTEMSETTINGS_DATA_ENTERPRISESERVICEADMINUSER = "enterpriseServiceAdminUser";
        public const string SYSTEMSETTINGS_DATA_SURVEYBASEURL = "surveyBaseURL";
        public const string SYSTEMSETTINGS_DATA_MARITZCXSURVEYBASEURL = "surveyBaseURL_MARITZCX";
        public const string SYSTEMSETTINGS_DATA_SURVEYREDIRECTURL = "surveyReDirectURL";
        public const string SYSTEMSETTINGS_DATA_DMECLOSECASESURVEY = "DME-CloseCaseSurvey";
        public const string SYSTEMSETTINGS_DATA_DXCLOSECASESURVEY = "DX-CloseCaseSurvey";
        public const string SYSTEMSETTINGS_DATA_CLOSECASESURVEY_AB_TEST = "CloseCaseSurvey-A/BTest";
        public const string SYSTEMSETTINGS_DATA_ENABLEMARITZCXSURVEY = "enableMaritzCXSurvey";
        public const string SYSTEMSETTINGS_DATA_MARITZDYNXLANGUAGEMAP = "MaritzDynxLanguageMap";
        public const string SYSTEMSETTINGS_DATA_SURVEYQUESTIONTRANSLATIONS = "SurveyQuestionTranslations";
        public const string SYSTEMSETTINGS_DATA_SURVEYCONFIGURATION = "SurveyConfiguration";
        public const string SURVEY_ATTR_SURVEYQUESTIONHTML = "SurveyQuestionHtml";
        public const string SYSTEMSETTINGS_DATA_CLOSECASESURVEYMCX = "DME_CloseCaseSurvey_MaritzCX";
        public const string SYSTEMSETTINGS_DATA_ANSENDPOINT = "ansNotificationEndpoint";
        public const string SYSTEMSETTINGS_DATA_ADMINPROFILEV1ENDPOINT = "adminProfileV1Endpoint";
        public const string SYSTEMSETTINGS_DATA_CONTACTREFRESHINTERVALINMINUTES = "contactRefreshIntervalInMinutes";
        public const string SYSTEMSETTINGS_SA_XAPIKEY = "x-api-key";
        public const string SYSTEMSETTINGS_SA_CUSTOMERSEARCHENDPOINT = "customerSearchEndpoint";
        public const string SYSTEMSETTINGS_GRP_SA = "SA";
        public const string SYSTEMSETTINGS_GRP_QUEUE = "QUEUE";
        public const string SYSTEMSETTINGS_QUEUE_ARCHIVE = "ArchiveQueue";
        public const string SYSTEMSETTINGS_FROMEMAIL = "FromEmail";
        public const string SYSTEMSETTINGS_QUEUE_ADOBEENTERPRISESUPPORT = "AdobeEnterpriseSupportQueue";
        public const string SYSTEMSETTINGS_DATA_JILENDPOINT = "jilEndPointURL";
        public const string SYSTEMSETTINGS_DATA_JILAPIKey = "jilAPIKey";
        public const string SYSTEMSETTINGS_DATA_UNIT = "unit";
        public const string SYSTEMSETTINGS_DATA_UNITGROUP = "unitgroup";
        public const string SYSTEMSETTINGS_ANONYMOUSORG = "anonymousOrgName";
        public const string SYSTEMSETTINGS_ANONYMOUSORGID = "anonymousOrgID";
        public const string SYSTEMSETTINGS_DATA_UNASSIGNEDUSER = "unassignedUser";
        public const string SYSTEMSETTINGS_WORKFLOWNAME_REFRESHCUSTOMER360 = "workflowRefreshCustomer360ASync";
        public const string SYSTEMSETTINGS_DATA_ORG_REFRESHINTERVALINMINUTES = "organizationRefreshIntervalInMinutes";
        public const string SYSTEMSETTINGS_DATA_C360_REFRESHINTERVALINMINUTES = "customerRefreshIntervalInMinutes";
        public const string SYSTEMSETTINGS_DATA_MPSGETENDPOINT = "mpsGetEndpoint";
        public const string SYSTEMSETTINGS_DATA_MPSPOSTENDPOINT = "mpsPostEndpoint";
        public const string SYSTEMSETTINGS_NOTIFICATION_GROUP = "NOTIFICATION";
        public const string SYSTEMSETTINGS_NOTIFICATION_KEY_EXPIRATIONPERIOD = "expirationPeriodInHours";
        public const string SYSTEMSETTINGS_NOTIFICATION_KEY_IS_CHROME_EXTN_DISABLED = "disableNotificationChromeExtension";
        public const string SYSTEMSETTINGS_NOTIFICATION_KEY_INTERVALINMINUTES = "pushNotificationIntervalInMinutes";
        public const string SYSTEMSETTINGS_DATA_ENABLEPROGRESSIVEPROFILE = "enableProgressiveProfileCheck";
        public const string SYSTEMSETTINGS_DATA_RENGAENDPOINT = "rengaEndpoint";
        public const string SYSTEMSETTINGS_DATA_RENGAAUTHTOKEN = "authToken";
        public const string SYSTEMSETTINGS_DATA_ENABLECAH = "enableCAH";
        public const string SYSTEMSETTINGS_DATA_ENABLENOTIFICATIONSUBSCRIPTIONS = "enableNotificationSubscriptions";
        public const string SYSTEMSETTINGS_DATA_ENABLEDOCUMENTMANAGEMENT = "enableDocumentManagement";
        public const string SYSTEMSETTINGS_DATA_ENABLEEMAILINADMINCONSOLE = "enableEmailActivityInAdminConsole";
        public const string SYSTEMSETTINGS_GRP_APPOINTMENTS = "APPOINTMENTS";
        public const string SYSTEMSETTINGS_DATA_APPOINTMENTORGANIZER = "appointmentsOrganizer";
        public const string SYSTEMSETTINGS_DATA_ENABLECASEESCALATIONSLARULE = "enableCaseEscalationSLARule";
        public const string SYSTEMSETTINGS_FEDRAMPORG = "SignFedRampOrgName";
        public const string SYSTEMSETTINGS_FEDRAMPORGGUID = "SignFedRampOrgGUID";
        public const string SYSTEMSETTINGS_GRP_FEDRAMP = "FEDRAMP";
        public const string SYSTEMSETTINGS_FEDRAMPADMIN = "FedRampAdminUserID";
        public const string SYSTEMSETTINGS_FEDRAMPUNASSIGNED = "FedRampUnAssignedUserID";
        public const string SYSTEMSETTINGS_FEDRAMPORGID = "SignFedRampOrgID";
        public const string SYSTEMSETTINGS_FEDRAMPPRODGUID = "SignFedRampPRODGUID";
        public const string SYSTEMSETTINGS_FEDRAMPEMAILQUEUE = "SignFedRampEmailQueueID";
        public const string SYSTEMSETTINGS_FEDRAMPSIGNPORTALLINKHTML = "AdobeSignPortalLinkHTML";
        public const string SYSTEMSETTINGS_DATA_FEDRAMPSIGNPORTALLINKPLACEHOLDER = "[FR-SignPortalLink]";
        public const string SYSTEMSETTINGS_DATA_ADMINEXLTEMPLATEPLACEHOLDERTEXT = "[AdminOrEXLFooter]";
        public const string SYSTEMSETTINGS_DATA_ADMINEXLCASELINKPLACEHOLDER = "[AdminOrEXLCaseLink]";
        public const string SYSTEMSETTINGS_EXLTEMPLATEKEY = "EXLEmailTemplatePlaceholder";
        public const string SYSTEMSETTINGS_ADMINEXLTEMPLATEKEY = "AdminConsoleTemplatePlaceholder";
        public const string SYSTEMSETTINGS_GRP_TEMPLATE = "TEMPLATE";
        public const string SYSTEMSETTINGS_GRP_TEMPLATE_DEFAULTLANGUAGE = "defaultLanguage";

        public const string SYSTEMSETTINGS_ETS_GROUP = "ETS";
        public const string SYSTEMSETTINGS_ETS_KEY_ENDPOINT = "etsEndpoint";
        public const string SYSTEMSETTINGS_WORKFLOWIMPERSONATINGUSER = "WorkflowImpersonatingUser";

        //Layer 7 System setting Attributes
        public const string SYSTEMSETTINGS_L7_GROUP = "L7";
        public const string SYSTEMSETTINGS_L7URL_JIRA = "JiraL7URL";
        public const string SYSTEMSETTINGS_L7PUSHCUSTOMERINFOURL_JIRA = "CustomerInfo_JIRA_URL";

        public const string SYSTEMSETTINGS_L7URL_SERVICENOW_CREATETICKET = "ServiceNow_CreateTicket_URL";
        public const string SYSTEMSETTINGS_L7URL_SERVICENOW_UPDATETICKET = "ServiceNow_UpdateTicket_URL";
        public const string SYSTEMSETTINGS_L7URL_TRANSACTIONLOGEVENT = "TransactionLog_URL";

        public const string SYSTEMSETTINGS_L7_API_KEY = "Layer7 API Key";
        public const string SYSTEMSETTINGS_L7_CLIENTID_KEY = "ServiceNow_CreateTicket_ClientKey";
        public const string SYSTEMSETTINGS_L7URL_SERVICENOW_NOTE = "ServiceNow_CreateNote_URL";
        public const string SYSTEMSETTINGS_SERVICENOW_TICKETURL_KEY = "ServiceNow_Ticket_URL";
        public const string SYSTEMSETTINGS_SERVICENOW_GROUP = "ServiceNow";
        public const string SYSTEMSETTINGS_SERVICENOWTERMINAL_KEY = "ServiceNowTerminationStatus";
        public const string SYSTEMSETTINGS_UCI_MODELDRIVENAPP_GROUP = "ModelDrivenApps";
        public const string SYSTEMSETTINGS_ENTERPRISEUCIAPPID_KEY = "EnterpriseUCIAppId";
        public const string SYSTEMSETTINGS_CRMRECORDBASEURL_KEY = "CRMRecordBaseUrl";
        public const string SYSTEMSETTINGS_ISUCIONLYMODE = "IsUCIOnlyMode";

        //Hoolihan Attributes
        public const string SYSTEMSETTINGS_L7URL_HOOLIHANCASEPUBLISHURL = "HoolihanCasePublishEvent_URL";

        // IMSToken attributes
        public const string IMSTOKEN_ATTR_EXPIRESON = "ent_expireson";
        public const double IMSTOKEN_ATTR_REFRESHTOKENEXPIRESONTIME = 1295999520;
        public const string IMSTOKEN_ATTR_REFRESHTOKENEXPIRESON = "ent_refreshtokenexpireson";
        public const string IMSTOKEN_ATTR_REFRESHTOKEN = "ent_refreshtoken";
        public const string IMSTOKEN_ATTR_ACCESSTOKEN = "ent_accesstoken";
        public const string IMSTOKEN_ATTR_TOKENTYPE = "ent_tokentype";
        public const string SYSTEMSETTINGS_DATA_TARGETCLIENT = "targetClient";
        public const string SYSTEMSETTINGS_DATA_CREATEENDPOINT = "createEndpoint";
        public const string SYSTEMSETTINGS_DATA_TARGETCLIENTCALLBACKURL = "targetClientCallbackUrl";

        //IMS Contact Role Option Sets
        public const string IMSCONTACTROLE_SYSTEMADMINISTRATOR = "org_admin";
        public const string IMSCONTACTROLE_SUPPORTADMINISTRATOR = "SUPPORT_ADMIN";
        public const string IMSCONTACTROLE_DEPLOYMENTADMINISTRATOR = "DEPLOYMENT_ADMIN";
        public const string IMSCONTACTROLE_PRODUCTADMINISTRATOR = "PRODUCT_ADMIN";
        public const string IMSCONTACTROLE_PRODUCTPROFILEADMINISTRATOR = "LICENSE_ADMIN";
        public const string IMSCONTACTROLE_USERGROUPADMINISTRATOR = "USER_GROUP_ADMIN";

        //Contact Attributes
        public const string CONTACT_ATTR_EMAIL = "emailaddress1";
        public const string CONTACT_ATTR_RENGAID = "ent_rengaid";
        public const string CONTACT_ATTR_STATE = "address1_stateorprovince";
        public const string CONTACT_ATTR_REGION = "ent_region";
        public const string CONTACT_ATTR_FNAME = "fullname";
        public const string CONTACT_ATTR_FIRSTNAME = "firstname";
        public const string CONTACT_ATTR_LASTNAME = "lastname";
        public const string CONTACT_ATTR_FULLNAME = "fullname";
        public const string CONTACT_ATTR_COUNTRY = "ent_country";
        public const string CONTACT_ATTR_ADOBEID = "emailaddress1";
        public const string CONTACT_ATTR_TELEPHONE = "telephone1";
        public const string CONTACT_ATTR_LANGUAGEPREFERENCE = "ent_languagepreference";
        public const string CONTACT_ATTR_IDTYPE = "ent_idtype";
        public const string CONTACT_ATTR_PHONENUMBERSECURITY = "ent_phonenumbersecurity";
        public const string CONTACT_ATTR_CITY = "address1_city";
        public const string CONTACT_ATTR_ZIPCODE = "address1_postalcode";
        public const string CONTACT_ATTR_CONTACTID = "contactid";
        public const string CONTACT_ATTR_CESSCORE = "ent_cesscorepercent";
        public const string CONTACT_ATTR_CSATSCORE = "ent_csatscorepercent";
        public const string CONTACT_ATTR_TIMEZONE = "ent_customertimezone";
        public const string CONTACT_ATTR_TOTALSURVEYCOUNT = "ent_totalsurveycount";
        public const string CONTACT_ATTR_ISGDPRREQUESTED = "ent_isgdprrequested";
        public const string CONTACT_ATTR_DONOTBULKEMAIL = "donotbulkemail";
        public const string CONTACT_ATTR_DONOTEMAIL = "donotemail";
        public const string CONTACT_ATTR_STATECODE = "statecode";
        public const string CONTACT_ATTR_DONOTCONTACT = "ent_donotcontact";
        public const string CONTACT_ATTR_EMAILMKTOPTEDIN = "ent_emailmarketingoptedin";
        public const string CONTACT_ATTR_PHONEMKTOPTEDIN = "ent_phonemarketingoptedin";
        public const string CONTACT_ATTR_MAILMKTOPTEDIN = "ent_mailmarketingoptedin";
        public const string CONTACT_ATTR_INSTRUCTIONALEMAILOPTIN = "ent_instructionalemailoptin";
        public const string CONTACT_ATTR_INSTRUCTIONALEMAILCONSENT = "ent_instructionalemailconsent";
        public const string CONTACT_ATTR_CONSENTLEGALDOC = "ent_consentlegalesedocument";
        public const string CONTACT_ATTR_COMMONCONSENT = "ent_commonconsent";
        public const string CONTACT_ATTR_EMAILCONSENT = "ent_emailconsent";
        public const string CONTACT_ATTR_PHONECONSENT = "ent_phoneconsent";
        public const string CONTACT_ATTR_MAILCONSENT = "ent_mailconsent";
        public const string CONTACT_ATTR_MPSPENDINGTEXT = "ent_mpspending";
        public const string CONTACT_ATTR_MPSPENDINGTEXTINSTRUCTIONALEMAIL = "ent_mpspendinginstructionalemail";
        public const string CONTACT_ATTR_OPTEDINSUPDATEDBYAGENTON = "ent_optinsupdatedbyagenton";
        public const string CONTACT_ATTR_LASTSYNCON = "ent_lastsyncon";
        public const string CONTACT_ATTR_PORTAL_USERNAME = "adx_identity_username";
        public const string CONTACT_ATTR_PORTAL_SECURITYSTAMP = "adx_identity_securitystamp";
        public const string CONTACT_ATTR_OWNERID = "ownerid";
        public const string CONTACT_ATTR_EXTERNALSYSTEM = "ent_externalsystem";


        //Country 
        public const string COUNTRY_ATTR_COUNTRYID = "ent_countryid";
        public const string COUNTRY_ATTR_COUNTRYCODE = "ent_countrycode";
        public const string COUNTRY_ATTR_COUNTRYISOCODE = "ent_countryisocode";
        public const string COUNTRY_ATTR_NAME = "ent_name";
        public const string COUNTRY_ATTR_STATECODE = "statecode";
        public const string COUNTRY_ATTR_DEFAULTLANGUAGE = "ent_defaultlanguage";

        //Region
        public const string REGION_ATTR_REGIONCODE = "ent_regioncode";
        public const string REGION_ATTR_COUNTRY = "ent_country";
        public const string REGION_ATTR_STATECODE = "statecode";
        public const string REGION_ATTR_NAME = "ent_name";

        // Common attributes
        public const string COMMON_ATTR_CREATEDON = "createdon";
        public const string COMMON_ATTR_MODIFIEDON = "modifiedon";
        public const string COMMON_ATTR_CREATEDBY = "createdby";
        public const string COMMON_ATTR_MODIFIEDBY = "modifiedby";
        public const string COMMON_ATTR_STATUSCODE = "statuscode";
        public const string COMMON_ATTR_STATECODE = "statecode";
        public const string COMMON_ATTR_OWNERID = "ownerid";
        public const string COMMON_ATTR_REGARDING = "regardingobjectid";
        public const string COMMON_ATTR_PROCESSID = "processid";
        public const string COMMON_ATTR_STARTTIME = "scheduledstart";
        public const string COMMON_ATTR_OVERRIDDENCREATEDON = "overriddencreatedon";
        public const string COMMON_ATTR_LASTSYNCON = "ent_lastsyncon";
        public const string COMMON_ATTR_ISMIGRATED = "ent_ismigrated";
        public const string COMMON_ATTR_CONTROLFLAG = "ent_controlflag";
        public const string COMMON_ATTR_PRIMARYFIELD_CUSTOM = "ent_name";
        public const string COMMON_ATTR_FROM = "from";
        public const string COMMON_ATTR_TO = "to";
        public const string COMMON_ATTR_CC = "cc";
        public const string COMMON_ATTR_SUBJECT = "subject";
        public const string COMMON_ATTR_OWNINGTEAM = "owningteam";
        public const string COMMON_ATTR_TEAMID = "teamid";

        //Goal Roll Up Query
        public const string GOALROLLUPQUERY_ATTR_FETCHXML = "fetchxml";
        public const string GOALROLLUPQUERY_ATTR_ID = "goalrollupqueryid";

        //SLA timer configuration
        public const string SLATIMERCONFIGURATION_ATTR_SLATYPE = "ent_slatype";
        public const string SLATIMERCONFIGURATION_ATTR_WARNTIME = "ent_warntime";
        public const string SLATIMERCONFIGURATION_ATTR_FAILTIME = "ent_failtime";
        public const string SLATIMERCONFIGURATION_ATTR_ELAPSEDTIME = "ent_elapsedtime";
        public const string SLATIMERCONFIGURATION_ATTR_ROLLUPQUERY = "ent_rollupquery";
        public const string SLATIMERCONFIGURATION_ATTR_ROUTINGTYPE = "ent_routingtype";
        public const string SLATIMERCONFIGURATION_ATTR_PRODUCTFAMILY = "ent_productfamily";

        //Sharepoint Site
        public const string SPSITE_ATTR_SERVICETYPE = "servicetype";
        public const string SPSITE_ATTR_ISDEFAULT = "isdefault";

        //Document Location
        public const string DOCUMENTLOCATION_ATTR_NAME = "name";
        public const string DOCUMENTLOCATION_ATTR_PARENTSITE = "parentsiteorlocation";
        public const string DOCUMENTLOCATION_ATTR_RELATIVEURL = "relativeurl";
        public const string DOCUMENTLOCATION_ATTR_REGARDINGOBJECTID = "regardingobjectid";

        //Case
        public const string CASE_ATTR_ADMINCONSOLEACCESS = "ent_adminconsoleaccess";
        public const string CASE_ATTR_TITLE = "title";
        public const string CASE_ATTR_ID = "ticketnumber";
        public const string CASE_ATTR_CUSTOMERID = "customerid";
        public const string CASE_ATTR_CONTACT = "ent_contact";
        public const string CASE_ATTR_CASETYPECODE = "casetypecode";
        public const string CASE_ATTR_PRIORITYCODE = "prioritycode";
        public const string CASE_ATTR_SEVERITYCODE = "severitycode";
        public const string CASE_ATTR_CASEORIGINCODE = "caseorigincode";
        public const string CASE_ATTR_CUSTOMERFIRSTNAME = "ent_customerfirstname";
        public const string CASE_ATTR_CUSTOMERLASTNAME = "ent_customerlastname";
        public const string CASE_ATTR_AGENTFIRSTNAME = "ent_agentfirstname";
        public const string CASE_ATTR_AGENTLASTNAME = "ent_agentlastname";
        public const string CASE_ATTR_DESCRIPTION = "description";
        public const string CASE_ATTR_PREFERREDPHONENUMBER = "ent_preferredphonenumber";
        public const string CASE_ATTR_PREFERREDEMAIL = "ent_preferredemail";
        public const string CASE_ATTR_PREFERREDSTARTTIME = "ent_custworkhrsstarttime";
        public const string CASE_ATTR_PREFERREDENDTIME = "ent_custworkhrsendtime";
        public const string CASE_ATTR_WATCHERS = "ent_ccemaillist";
        public const string CASE_ATTR_ADDITIONALCONTACTEMAIL = "ent_email";
        public const string CASE_ATTR_EXPERTSESSIONTOPIC = "ent_expertsessiontopic";
        public const string CASE_ATTR_EXPERTSESSIONTIME1 = "ent_expertsessiontime1";
        public const string CASE_ATTR_EXPERTSESSIONTIME2 = "ent_expertsessiontime2";
        public const string CASE_ATTR_EXPERTSESSIONTIME3 = "ent_expertsessiontime3";
        public const string CASE_ATTR_EXPERTSCHEDULETIME = "ent_expertsessionscheduledtime";
        public const string CASE_ATTR_ESCALATED = "isescalated";
        public const string CASE_ATTR_SHAREPOINTPATH = "ent_sharepointpath";
        public const string CASE_ATTR_INCIDENTID = "incidentid";
        public const string CASE_ATTR_RENGAID = "ent_rengaid";
        public const string CASE_ATTR_ORGID = "ent_orgid";
        public const string CASE_ATTR_RECORDTYPE = "ent_recordtype";
        public const string CASE_ATTR_PRODUCT = "productid";
        public const string CASE_ATTR_PREFERREDCUSTOMERTIMEZONE = "ent_preferredcustomertimezone";
        public const string CASE_ATTR_PREFERREDLANGUAGE = "ent_supportedlanguage";
        public const string CASE_ATTR_CLOSEDDATE = "ent_closeddate";
        public const string CASE_ATTR_OWNERID = "ownerid";
        public const string CASE_ATTR_CLOSECASEREASON = "ent_closecasereason";
        public const string CASE_ATTR_ESCALATIONREASON = "ent_escalationreason";
        public const string CASE_ATTR_REOPENCASEREASON = "ent_reopencasereason";
        public const string CASE_ATTR_LASTREOPENEDDATE = "ent_lastreopeneddate";
        public const string CASE_ATTR_ESCALATEDON = "escalatedon";
        public const string CASE_ATTR_ESCALATIONREASONSUMMARY = "ent_caseescalationsummary";
        public const string CASE_ATTR_CLOSEREASONSUMMARY = "ent_caseclosesummary";
        public const string CASE_ATTR_REOPENREASONSUMMARY = "ent_casereopensummary";
        public const string CASE_ATTR_CLOSEREASONCATEGORY = "ent_closereasoncategory";
        public const string CASE_ATTR_PROJECT = "ent_project";
        //public const string CASE_ATTR_REOPENSLAAPPLICABLE = "ent_reopenslaapplicable";
        //public const string CASE_ATTR_REOPENSLAMET = "ent_reopenslamet";
        public const string CASE_ATTR_UPDATESLA = "ent_updatecaseslaapplicable";
        public const string CASE_ATTR_UPDATECASESLAMET = "ent_updatecaseslamet";
        public const string CASE_ATTR_FIRSTRESPONSEAPPLICABLE = "ent_firstresponsestatus";
        public const string CASE_ATTR_FIRSTRESPONSESENT = "ent_firstresponseslamet";
        public const string CASE_ATTR_SLASTARTDATE = "ent_slastartdate";
        public const string CASE_ATTR_SLAUPDATEDATE = "ent_slaupdatedate";
        public const string CASE_ATTR_CASESTATUS = "statuscode";
        public const string CASE_ATTR_EMAILGUID = "ent_emailguid";
        public const string CASE_ATTR_CASESTATE = "statecode";
        public const string CASE_ATTR_ISSUEREASON = "ent_issuereason";
        public const string CASE_ATTR_CUSTOMER360 = "ent_customer";
        public const string CASE_ATTR_SURVEYINVITATIONLINK = "ent_surveyinvitationlink";
        public const string CASE_ATTR_QUEUE = "ent_queueid";
        public const string CASE_ATTR_SESSION_LINK = "ent_sessionlink";
        public const string CASE_ATTR_ROUTINGENABLED = "ent_routingenabled";
        public const string CASE_ATTR_ENVIRONMENT = "ent_environment";
        public const string CASE_ATTR_CONSOLEBUILD = "ent_consolebuild";
        public const string CASE_ATTR_SERVERBUILD = "ent_serverbuild";
        public const string CASE_ATTR_PRODUCTCOMPONENT = "ent_productcomponent";
        public const string CASE_ATTR_PRODUCTVERSION = "ent_productversion";
        public const string CASE_ATTR_INSTANCEURL = "ent_instanceurl";
        public const string CASE_ATTR_CASEINACTIVETIME = "ent_caseinactiveminutes";
        public const string CASE_ATTR_PRODUCTFAMILY = "ent_productfamily";
        public const string CASE_ATTR_PREVIOUSSTATUSREASON = "ent_previousstatusreason"; // DYNX-9708
        public const string CASE_ATTR_LEGACYCREATEDDATE = "ent_legacydatecreated";
        public const string CASE_ATTR_SUBCATEGORY = "ent_subcategory";
        public const string CASE_ATTR_LANGUAGE_STRING = "ent_langparam";
        public const string CASE_ATTR_SENTFORREVIEW = "ent_sentforreview";
        public const string CASE_ATTR_REVIEWSTATUS = "ent_reviewstatus";
        public const string CASE_ATTR_CONTROLFLAG = "ent_controlflag";
        public const string CASE_ATTR_TRANSACTIONID = "ent_originatingtransactionid";
        public const string CASE_ATTR_ISESCALATIONALLOWED = "ent_isescalationallowed";
        public const string CASE_ATTR_NEXTUPDATEDUE = "ent_nextupdatedue";
        public const string CASE_ATTR_SUBCHANNEL = "ent_subchannel";
        public const string CASE_ATTR_EXLCASELINK = "ent_exlcaselink";
        public const string CASE_ATTR_ADMINCONSOLECASELINK = "ent_adminconsolecaselink";

        //Case External Ticket
        public const string CASEEXTERNALTICKET_ATTR_TicketID = "ent_name";
        public const string CASEEXTERNALTICKET_ATTR_CASE = "ent_case";
        public const string CASEEXTERNALTICKET_ATTR_EXTERNALTICKET = "ent_externalticket";
        public const string CASEEXTERNALTICKET_ATTR_INFLUENCETHECASE = "ent_influencethecase";
        public const string CASEEXTERNALTICKET_ATTR_SOURCE = "ent_source";

        //Internal Subscriptions
        public const string INTERNALSUBSCRIPTION_ATTR_SUBEMAIL = "ent_subscriptionemail";
        public const string INTERNALSUBSCRIPTION_ATTR_SUBSCRIBER = "ent_subscriberid";
        public const string INTERNALSUBSCRIPTION_ATTR_ORGANIZATION = "ent_organizationid";
        public const string INTERNALSUBSCRIPTION_ATTR_PRODUCT = "ent_productid";
        public const string INTERNALSUBSCRIPTION_ATTR_PROJECT = "ent_projectid";
        public const string INTERNALSUBSCRIPTION_ATTR_PRIORITY = "ent_priority";
        //External Subscriptions
        public const string EXTERNALSUBSCRIPTION_ATTR_SUBEMAIL = "ent_subscriptionemail";
        public const string EXTERNALSUBSCRIPTION_ATTR_CONTACT = "ent_contactid";
        public const string EXTERNALSUBSCRIPTION_ATTR_ORGANIZATION = "ent_organizationid";
        public const string EXTERNALSUBSCRIPTION_ATTR_PRODUCT = "ent_productid";
        public const string EXTERNALSUBSCRIPTION_ATTR_PROJECT = "ent_projectid";
        public const string EXTERNALSUBSCRIPTION_ATTR_PRIORITY = "ent_priority";

        //Customer
        public const string CUSTOMER_ATTR_CONTACT = "ent_contact";
        public const string CUSTOMER_ATTR_ORG = "ent_organization";
        public const string CUSTOMER_ATTR_NAME = "ent_name";
        public const string CUSTOMER_ATTR_ROLE = "ent_role";
        public const string CUSTOMER_ATTR_CUSTOMERID = "ent_organizationcontactid";
        public const string CUSTOMER_ATTR_ORGID = "ent_orgid";
        public const string CUSTOMER_ATTR_RENGAID = "ent_rengaid";
        public const string CUSTOMER_ATTR_CREATEDON = "createdon";
        public const string CUSTOMER_ATTR_RELATIONSHIPTYPE = "ent_relationshiptype";
        public const string CUSTOMER_ATTR_OWNERID = "ownerid";
        //Org Attributes
        public const string ORG_ATTR_ORGID = "ent_orgid";
        public const string ORG_ATTR_ORGNAME = "name";
        public const string ORG_ATTR_VALUE = "ent_value";
        public const string ORG_ATTR_DOMAINS = "ent_domainnames";
        public const string ORG_ATTR_PARENTORGNAME = "ent_parentorgname";
        public const string ORG_ATTR_CITY = "address1_city";
        public const string ORG_ATTR_COUNTRY = "ent_country";
        public const string ORG_ATTR_ZIPCODE = "address1_postalcode";
        public const string ORG_ATTR_ID = "accountid";
        public const string ORG_ATTR_SOURCE = "ent_source";
        public const string ORG_ATTR_ACCOUNTSTATUS = "ent_accountstatus";
        public const string ORG_ATTR_DXACCOUNTSTATUS = "ent_dxaccountstatus";
        public const string ORG_ATTR_DXCUSTOMERSEGMENT = "ent_dxcustomersegment";
        public const string ORG_ATTR_DMECUSTOMERSEGMENT = "ent_dmecustomersegment";
        public const string ORG_ATTR_CLOUD = "ent_cloud";
        public const string ORG_ATTR_ACCOUNTTIER = "ent_accounttier";
        public const string ORG_ATTR_DXSUPPORTLEVEL = "ent_dxsupportlevel";
        public const string ORG_ATTR_CRITSIT = "ent_critsit";


        //customer notes
        public const string CUSTOMERNOTES_ATTR_DESCRIPTION = "description";
        public const string CUSTOMERNOTES_ATTR_RENGAID = "ent_createdbyrengaid";
        public const string CUSTOMERNOTES_ATTR_CREATEDBYFNAME = "ent_createdbyfname";
        public const string CUSTOMERNOTES_ATTR_CREATEDBYLNAME = "ent_createdbylname";
        public const string CUSTOMERNOTES_ATTR_COMMENTTYPE = "ent_type";
        public const string CUSTOMERNOTES_ATTR_COMMENTTYPE_COMMENT = "Comment";
        public const string CUSTOMERNOTES_ATTR_DIRECTIONCODE = "ent_directioncode";
        public const string CUSTOMERNOTES_ATTR_CASEKEY = "regardingobjectid";
        public const string CUSTOMERNOTES_ATTR_SUBJECT = "subject";
        public const string CUSTOMERNOTES_ATTR_ACTIVITYID = "activityid";
        public const string CUSTOMERNOTES_ATTR_CREATEDBYCONTACT = "ent_createdbycontact";
        public const string CUSTOMERNOTES_ATTR_COMMENTBY = "ent_createdbyfullname";
        public const string CUSTOMERNOTES_ATTR_CREATEDBY = "createdby";
        public const string CUSTOMERNOTES_ATTR_ISATTACHMENTNOTE = "ent_isattachmentnote";
        public const string CUSTOMERNOTES_ATTR_DOCUMENTPROCESSSTATUS = "ent_documentprocessstatus";
        public const string CUSTOMERNOTES_ATTR_SOURCETYPE = "ent_sourcetype";
        public const string CUSTOMERNOTES_ATTR_CREATEDBYEMAIL = "ent_createdbyemail";
        public const string CUSTOMERNOTES_ATTR_ATTACHMENTUNIQUEKEY = "ent_attachmentuniquekey";
        public const string CUSTOMERNOTES_KEY_ATTACHMENTUNIQUEKEY = "ent_attachmentkey";
        public const string CUSTOMERNOTES_ATTR_EMAILFORATTACHMENTSENT = "ent_emailforattachmentsent";

        // PhoneCall attributes
        public const string PHONECALL_ATTR_ACTIVITYID = "activityid";
        public const string PHONECALL_ATTR_TRANSACTIONID = "ent_originatingtransactionid";
        public const string PHONECALL_ATTR_CALLDURRATION = "ent_callduration";
        public const string PHONECALL_ATTR_SCHEDULEDSTART = "scheduledstart";
        public const string PHONECALL_ATTR_SCHEDULEDEND = "scheduledend";
        public const string PHONECALL_ATTR_HOLDTIME = "ent_holdtime";
        public const string PHONECALL_ATTR_TALKTIME = "ent_talktime";
        public const string PHONECALL_ATTR_PHONEQUEUE = "ent_phonequeue";
        public const string PHONECALL_ATTR_PHONEQUEUEWAITTIME = "ent_phonequeuewaittime";
        public const string PHONECALL_ATTR_NUMBERTRANSFERS = "ent_numbertransfers";
        public const string PHONECALL_ATTR_NUMBERTIMESHOLD = "ent_numbertimeshold";
        public const string PHONECALL_ATTR_CALLCENTERSITE = "ent_callcentersiteid";
        public const string PHONECALL_ATTR_CALLCENTERCODE = "ent_callcentercode";
        public const string PHONECALL_ATTR_PHONENUMBER = "phonenumber";
        public const string PHONECALL_ATTR_ISTRANSFER = "ent_istransfer";
        public const string PHONECALL_ATTR_DIRECTIONCODE = "directioncode";
        public const string PHONECALL_ATTR_AGENTEMAIL = "ent_agentemail";
        public const string PHONECALL_ATTR_DNIS = "ent_dnis";
        public const string PHONECALL_REGARDING = "regardingobjectid";
        public const string PHONECALL_CREATEDBY = "createdby";
        public const string PHONECALL_OWNER = "ownerid";
        public const string PHONECALL_ATTR_CALLID = "ent_callid";

        // Expert Session Topic Attributes
        public const string EXPERTSESSIONTOPIC_ATTR_CODE = "ent_code";
        public const string EXPERTSESSIONTOPIC_ATTR_VALUE = "ent_value";
        public const string EXPERTSESSIONTOPIC_ATTR_PRODUCT = "ent_product";

        //Product
        public const string PRODUCT_ATTR_PRODUCTCODE = "productnumber";
        public const string PRODUCT_ATTR_PRODUCTNAME = "name";
        public const string PRODUCT_ATTR_SUBJECT = "subjectid";
        public const string PRODUCT_ATTR_DESCRIPTION = "description";
        public const string PRODUCT_ATTR_ISFULFILLABLEITEM = "ent_isfulfillableitem";
        public const string PRODUCT_ATTR_FULFILLABLETYPE = "ent_fulfillabletypelist";
        public const string PRODUCT_ATTR_PRODUCTLEVEL = "ent_productlevel";
        public const string PRODUCT_ATTR_PRODUCTID = "productid";
        public const string PRODUCT_ATTR_UNITGROUP = "defaultuomscheduleid";
        public const string PRODUCT_ATTR_DEFAULTUNIT = "defaultuomid";
        public const string PRODUCT_ATTR_DECIMALSSUPPORTED = "quantitydecimal";
        public const string PRODUCT_ATTR_LICENSINGTECHNOLOGY = "ent_licensingtechnology";
        public const string PRODUCT_ATTR_PRODUCTFAMILY = "ent_productfamily";
        public const string PRODUCT_ATTR_ID = "productid";

        //Product Entitlements
        public const string ENTITLEMENT_ATTR_ENTITLEMENTID = "ent_productentitlementid";
        public const string ENTITLEMENT_ATTR_ORGANIZATION = "ent_organization";
        public const string ENTITLEMENT_ATTR_PURCHASEDQUANTITY = "ent_purchasedquantity";
        public const string ENTITLEMENT_ATTR_PROVISIONEDQUANTITY = "ent_provisionedquantity";
        public const string ENTITLEMENT_ATTR_DELEGATEDQUANTITY = "ent_delegatedquantity";
        public const string ENTITLEMENT_ATTR_CONTRACTSTARTDATE = "ent_contractstartdate";
        public const string ENTITLEMENT_ATTR_CONTRACTENDDATE = "ent_contractenddate";
        public const string ENTITLEMENT_ATTR_CONTRACTSTATUS = "ent_contractstatus";
        public const string ENTITLEMENT_ATTR_CONTRACTID = "ent_contractid";
        public const string ENTITLEMENT_ATTR_DEALREGNUMBER = "ent_dealregnumber";
        public const string ENTITLEMENT_ATTR_EXTERNALOFFERID = "ent_externalofferid";
        public const string ENTITLEMENT_ATTR_OFFERTYPE = "ent_licensetype";
        public const string ENTITLEMENT_ATTR_PRODUCT = "ent_productid";
        public const string ENTITLEMENT_ATTR_NAME = "ent_productentitlement";
        public const string ENTITLEMENT_ATTR_LICENSINGTECHNOLOGY = "ent_licensingtechnology";

        //Subject
        public const string SUBJECT_ATTR_TITLE = "title";

        //System User Attributes
        public const string SYSTEMUSER_ATTR_FIRSTNAME = "firstname";
        public const string SYSTEMUSER_ATTR_LASTNAME = "lastname";
        public const string SYSTEMUSER_ATTR_USERNAME = "domainname";
        public const string SYSTEMUSER_ATTR_EMAIL = "internalemailaddress";
        public const string SYSTEMUSER_ATTR_FULLNAME = "fullname";
        public const string SYSTEMUSER_ATTR_STATUS = "isdisabled";
        public const string SYSTEMUSER_ATTR_SYSTEMUSERID = "systemuserid";

        // Chat attributes
        public const string CHAT_ATTR_ACTIVITYID = "activityid";
        public const string CHAT_ATTR_TRANSACTIONID = "ent_originatingtransactionid";
        public const string CHAT_ATTR_SUBJECT = "subject";
        public const string CHAT_ATTR_DESCRIPTION = "description";
        public const string CHAT_ATTR_CALLCENTERCODE = "ent_callcentercode";
        public const string CHAT_ATTR_CALLCENTERSITE = "ent_callcentersite";
        public const string CHAT_ATTR_CALLCENTERSITENAME = "ent_callcentersitename";
        public const string CHAT_ATTR_CHATDURATION = "ent_chatduration";
        public const string CHAT_ATTR_CHATID = "ent_chatid";
        public const string CHAT_ATTR_TRANSFERNUMBER = "ent_chatnumberoftransfers";
        public const string CHAT_ATTR_PORTALSELECTION = "ent_chatportalselection";
        public const string CHAT_ATTR_CHATQUEUE = "ent_chatqueue";
        public const string CHAT_ATTR_TOTALQUEUEWAITTIME = "ent_chattotalqueuewaittime";
        public const string CHAT_ATTR_CHATTRANSCRIPT = "ent_transcript";
        public const string CHAT_ATTR_TURNSNUMBER = "ent_chatturnsnumber";
        public const string CHAT_ATTR_SCHEDULEDSTART = "scheduledstart";
        public const string CHAT_ATTR_SCHEDULEDEND = "scheduledend";
        public const string CHAT_ATTR_ACTUALSTART = "actualstart";
        public const string CHAT_ATTR_ACTUALEND = "actualend";

        // BomgarSession attributes
        public const string BOMGARSESSION_ATTR_CASEID = "bom_case_id";
        public const string BOMGARSESSION_ATTR_LSID = "bom_lsid";
        public const string BOMGARSESSION_ATTR_DURATION = "bom_duration";
        public const string BOMGARSESSION_ATTR_SESSIONRECORDINGURL = "bom_session_recording_view_url";
        public const string BOMGARSESSION_ATTR_STARTTIME = "bom_start_time";
        public const string BOMGARSESSION_ATTR_ENDTIME = "bom_end_time";
        public const string BOMGARSESSION_ATTR_CHATSESSIONURL = "bom_chatsessionviewurl";
        public const string BOMGARSESSION_ATTR_NAME = "bom_name";

        // Internal Notes Attributes
        public const string INTERNALNOTES_ATTR_REGARDINGOBJECTID = "regardingobjectid";
        public const string INTERNALNOTES_ATTR_TYPE = "ent_type";
        public const string INTERNALNOTES_ATTR_SUBJECT = "subject";
        public const string INTERNALNOTES_ATTR_REASONCODE = "ent_reasoncode";
        public const string INTERNALNOTES_ATTR_REASONSUMMARY = "ent_actionreasonsummary";
        public const string INTERNALNOTES_ATTR_CREATEDBYCONTACT = "ent_createdbycontact";
        public const string INTERNALNOTES_ATTR_CREATEDBYRENGAID = "ent_createdbyrengaid";
        public const string INTERNALNOTES_ATTR_CLOSEREASONCATEGORY = "ent_closereasoncategory";
        public const string INTERNALNOTES_ATTR_DIRECTIONCODE = "ent_directioncode";
        public const string INTERNALNOTES_ATTR_ACTIONBY = "ent_actionby";
        public const string INTERNALNOTES_ATTR_CREATEDBY = "createdby";
        public const string INTERNALNOTES_ATTR_SOURCETYPE = "ent_sourcetype";
        public const string INTERNALNOTES_ATTR_COMMENTID = "ent_commentid";

        // Case Escalation Attributes
        public const string CASEESCALATION_ATTR_NAME = "ent_name";
        public const string CASEESCALATION_ATTR_CASE = "ent_case";
        public const string CASEESCALATION_ATTR_ESCALATIONREASONCODE = "ent_caseescalationreasoncode";
        public const string CASEESCALATION_ATTR_ESCALATIONCOMMENTS = "ent_escescalationcomments";
        public const string CASEESCALATION_ATTR_ESCALATEDBYCONTACT = "ent_escalatedbycontact";
        public const string CASEESCALATION_ATTR_ESCALATEDBYRENGAID = "ent_escalatedbyrengaid";
        public const string CASEESCALATION_ATTR_ESCALATEDBY = "ent_escalatedby";
        public const string CASEESCALATION_ATTR_ESCALATIONSTATUS = "statuscode";
        public const string CASEESCALATION_ATTR_OWNERID = "ownerid";
        public const string CASEESCALATION_ATTR_CREATEDUSER = "createdby";
        public const string CASE_ATTR_ESCALATIONSLAMET = "ent_escalationslamet";
        public const string CASE_ATTR_ESCALATIONSLAAPPLICABLE = "ent_escalationslaapplicable";
        public const string CASEESCALATION_ATTR_ISSUESUMMARY = "ent_issuesummary";
        public const string CASEESCALATION_ATTR_CUSTOMERIMPACT = "ent_esccustomerimpact";
        public const string CASEESCALATION_ATTR_CORRECTIVEACTION = "ent_esccorrectiveaction";
        public const string CASEESCALATION_ATTR_ROOTCAUSE = "ent_escrootcause";
        public const string CASEESCALATION_ATTR_ESCALATIONCLOSEDATE = "ent_escalationclosedate";
        public const string CASEESCALATION_ATTR_STATUS = "statecode";
        public const string CASEESCALATION_ATTR_ESCALATIONSTATUSREASON = "ent_escalationstatusreason";
        public const string CASEESCALATION_ATTR_CASESUPPORTENGINEER = "ent_casesupportengineer";

        // GDPR Aucit Attributes
        public const string GDPR_ATTR_ACITONTYPE = "ent_actiontype";
        public const string GDPR_ATTR_CONTACTID = "ent_contactid";
        public const string GDPR_ATTR_ENDPOINTCODE = "ent_endpoint";
        public const string GDPR_ATTR_EVENTCODE = "ent_eventcode";
        public const string GDPR_ATTR_EVENTSUBCODE = "ent_eventsubcode";
        public const string GDPR_ATTR_EXCEPTIONBLOCK = "ent_exceptionblock";
        public const string GDPR_ATTR_ID = "ent_gdprauditid";
        public const string GDPR_ATTR_LASTREQUESTEDON = "ent_lastrequestedon";
        public const string GDPR_ATTR_MESSAGEBLOCK = "ent_messageblock";
        public const string GDPR_ATTR_REQUESTID = "ent_name";
        public const string GDPR_ATTR_NOTIFICATIONDATE = "ent_notificationdate";
        public const string GDPR_ATTR_NOTIFICATIONTYPE = "ent_notificationtype";
        public const string GDPR_ATTR_REQUESTCREATEDON = "ent_requestcreatedon";
        public const string GDPR_ATTR_REQUESTHINT = "ent_requesthint";
        public const string GDPR_ATTR_REQUESTSTATUS = "ent_requeststatus";
        public const string GDPR_ATTR_REQUESTTYPE = "ent_requesttype";
        public const string GDPR_ATTR_REQUESTUPDATEDON = "ent_requestupdatedon";
        //public const string GDPR_ATTR_EVENTTYPE = "ent_eventtype";
        public const string GDPR_ATTR_RETRYCOUNT = "ent_retrycount";
        public const string GDPR_ATTR_SERVICE = "ent_service";
        public const string GDPR_ATTR_SUBMITSTATUS = "ent_submitstatus";
        public const string GDPR_ATTR_DATAFORMAT = "ent_dataformat";

        // CASE Link Attributes
        public const string CASELINK_ATTR_LINKTYPE = "ent_linktype";
        public const string CASELINK_ATTR_CASEID = "ent_caseid";
        public const string CASELINK_ATTR_ID = "ent_caselinkid";
        public const string CASELINK_ATTR_URL = "ent_url";

        // Generic Attributes
        public const string GEN_PRIMARY_FIELD = "ent_name";
        public const string GEN_ATTR_VALUE = "ent_value";
        public const string GEN_ATTR_PRODUCT = "ent_product";
        public const string GEN_STATECODE = "statecode";
        public const string GEN_STATUSCODE = "statuscode";

        //Case Tag Attributes
        public const string CASETAG_ID = "ent_casetagid";
        public const string CASETAG_Name = "ent_name";
        public const string CASETAG_DESCRIPTION = "ent_description";
        public const string CASETAG_TAGTYPE = "ent_tagtype";
        public const string CASETAG_STATUS = "statuscode";
        public const string CASETAG_SCHEMANAME = "ent_tagschemaname";
        public const string CASETAG_STATECODE = "statecode";

        //Email Attributes
        public const string EMAIL_DIRECTIONCODE = "directioncode";
        public const string EMAIL_STATUSCODE = "statuscode";
        public const string EMAIL_REGARDING = "regardingobjectid";
        public const string EMAIL_ID = "activityid";
        public const string EMAIL_PARENTACTIVTYID = "parentactivityid";
        public const string EMAIL_ORIGINATINGEMAIL = "ent_originatingemail";
        public const string EMAIL_EMAILQUEUEDETAILS = "ent_emailqueuedetails";
        public const string EMAIL_AGENTREPLY = "ent_agentreply";
        public const string EMAIL_CREATEDBY = "createdby";
        public const string EMAIL_ISMANUAL = "ent_ismanual";
        public const string EMAIL_ISWORKFLOW = "isworkflowcreated";
        public const string EMAIL_ATTR_STATECODE = "statecode";
        public const string EMAIL_ATTR_STATUSCODE = "statuscode";
        public const string EMAIL_ATTR_DESCRIPTION = "description";
        public const string EMAIL_ATTR_DESCRIPTIONPLAINTEXT = "ent_descriptionplaintext";
        public const string EMAIL_ATTR_ISCOPYWATCHERS = "ent_iscopywatchers";
        public const string EMAIL_ATTR_ISCOPYADDITIONALCONTACT = "ent_iscopyadditionalcontact";
        public const string EMAIL_ATTR_ISCOPYNOTIFICATIONSUBSCRIBERS = "ent_iscopynotificationsubscribers";
        public const string EMAIL_ATTR_SUBJECT = "subject";
        public const string EMAIL_ATTR_ORIGINALQUEUE = "ent_originalqueueid";
        public const string EMAIL_ATTR_SENTON = "senton";
        public const string EMAIL_CREATEDBY_FIRSTNAME = "ent_createdbyfirstname";
        public const string EMAIL_CREATEDBY_LASTNAME = "ent_createdbylastname";
        public const string EMAIL_ISLEGITIMATECUSTOMER = "ent_islegitimatecustomer";

        //SLA Attributes
        public const string SLA_STATUS = "status";
        public const string SLA_NAME = "name";
        public const string SLA_WARNINGTIME = "warningtime";
        public const string SLA_FAILURETIME = "failuretime";
        public const string SLA_SUCCEEDEDON = "succeededon";
        public const string SLA_REGARDING = "regarding";
        public const string SLA_CREATEDDATE = "createdon";
        public const string SLA_PREVIOUSSTATUS = "ent_previousstatus";

        //SLA History Attributes
        public const string SLAHISTORY_CASE = "ent_case";
        public const string SLAHISTORY_ACTIVE = "statecode";
        public const string SLAHISTORY_NAME = "ent_name";
        public const string SLAHISTORY_TYPE = "ent_slatype";
        public const string SLAHISTORY_CREATEDDATE = "ent_customcreatedon";
        public const string SLAHISTORY_STATUS = "ent_slastatus";
        public const string SLAHISTORY_WARNINGTIME = "ent_slawarnedtime";
        public const string SLAHISTORY_FAILURETIME = "ent_slafailuretime";
        public const string SLAHISTORY_SUCCEEDEDTIME = "ent_slasucceededtime";

        //Survey Activity Attributes
        public const string SURVEYACTIVITY_INVITATIONLINK = "msdyn_invitationlink";
        public const string SURVEYACTIVITY_CLOSINGRESPONSE = "msdyn_closingresponse";
        public const string SURVEYACTIVITY_REGARDING = "regardingobjectid";
        public const string SURVEYACTIVITY_SURVEYID = "msdyn_surveyid";
        public const string SURVEYACTIVITY_TO = "to";
        public const string SURVEYACTIVITY_SCHEDULEDSTART = "scheduledstart";
        public const string SURVEYACTIVITY_SCHEDULEDEND = "scheduledend";
        public const string SURVEYACTIVITY_SUBJECT = "subject";


        //Survey Invite
        public const string SURVEYINVITE_INVITATIONLINK = "ent_invitationlink";
        public const string SURVEYINVITE_INVITATIONCODE = "ent_invitationcode";
        public const string SURVEYINVITE_CONTACT = "ent_contactid";

        //Attachment Metadata Attributes
        public const string ATTACHMENTMETADATA_ATTR_BLOBNAME = "ent_blobname";
        public const string ATTACHMENTMETADATA_ATTR_FILENAME = "ent_filename";
        public const string ATTACHMENTMETADATA_ATTR_FILESIZE = "ent_filesize";
        public const string ATTACHMENTMETADATA_ATTR_MIMETYPE = "ent_mimetype";
        public const string ATTACHMENTMETADATA_ATTR_SUBJECT = "ent_subject";
        public const string ATTACHMENTMETADATA_ATTR_DESCRIPTION = "ent_description";
        public const string ATTACHMENTMETADATA_ATTR_DOCUMENTTYPE = "ent_documenttype";
        public const string ATTACHMENTMETADATA_ATTR_DIRECTION = "ent_direction";
        public const string ATTACHMENTMETADATA_ATTR_RENGAID = "ent_rengaid";
        public const string ATTACHMENTMETADATA_ATTR_ACTIVITYMIMEATTACHMENTID = "ent_activitymimeattachmentid";
        public const string ATTACHMENTMETADATA_ATTR_UPLOADEDBY = "ent_uploadedby";
        public const string ATTACHMENTMETADATA_ATTR_REGARDINGOBJECTTYPE = "ent_regardingobjectidtype";
        public const string ATTACHMENTMETADATA_ATTR_REGARDINGOBJECTID = "ent_regardingobjectid";
        public const string ATTACHMENTMETADATA_ATTR_PARENTREGARDINGOBJECTTYPE = "ent_parentregardingobjectidtype";
        public const string ATTACHMENTMETADATA_ATTR_PARENTREGARDINGOBJECTID = "ent_parentregardingobjectid";
        public const string ATTACHMENTMETADATA_ATTR_STATUSCODE = "statuscode";
        public const string ATTACHMENTMETADATA_ATTR_STATECODE = "statecode";
        public const string ATTACHMENTMETADATA_ATTR_CREATEDON = "createdon";
        public const string ATTACHMENTMETADATA_ATTR_EXTERNALNOTEID = "ent_externalnoteid";

        //SharePoint Document Info Attributes
        public const string SHAREPOINTDOCINFO_ATTR_DIRECTIONCODE = "ent_directioncode";
        public const string SHAREPOINTDOCINFO_ATTR_UPLOADEDBY = "ent_uploadedby";
        public const string SHAREPOINTDOCINFO_ATTR_NAME = "ent_name";
        public const string SHAREPOINTDOCINFO_ATTR_RENGAID = "ent_rengaid";
        public const string SHAREPOINTDOCINFO_ATTR_UPLOADEDON = "ent_uploadedon";
        public const string SHAREPOINTDOCINFO_ATTR_EXTERNALNOTEID = "ent_externalnoteid";
        public const string SHAREPOINTDOCINFO_ATTR_FOLDERPATH = "ent_folderpath";
        public const string SHAREPOINTDOCINFO_ATTR_SPDOCINFOBATCH = "ent_sharepointdocinfobatch";
        public const string SHAREPOINTDOCINFO_ATTR_LOG = "ent_log";

        // Notification Attributes
        public const string NOTIFICATION_ATTR_CASE = "ent_case";
        public const string NOTIFICATION_ATTR_RECORDURL = "ent_caserecordurl";
        public const string NOTIFICATION_ATTR_RECIPIENTROLE = "ent_recipientrole";
        public const string NOTIFICATION_ATTR_NOTIFICATIONFOR = "ownerid";
        public const string NOTIFICATION_ATTR_NOTIFICATIONMESSAGE = "ent_notificationmessage";
        public const string NOTIFICATION_ATTR_NAME = "ent_name";
        public const string NOTIFICATION_ATTR_CHANNEL = "ent_channel";
        public const string NOTIFICATION_ATTR_EXPIRATIONON = "ent_expirationon";
        public const string NOTIFICATION_ATTR_LOG = "ent_log";
        public const string NOTIFICATION_ATTR_QUEUE = "ent_queueid";
        public const string NOTIFICATION_ATTR_GROUPID = "ent_groupid";
        public const string NOTIFICATION_ATTR_READON = "ent_readon";
        public const string NOTIFICATION_ATTR_READBY = "ent_readby";
        public const string NOTIFICATION_ATTR_NOTIFICATION_ID = "ent_notificationid";
        public const string NOTIFICATION_ATTR_DELIVEREDON = "ent_deliveredon";
        public const string NOTIFICATION_ATTR_MSG_CHANNEL = "ent_messagingchannel";

        // Notification Activity Attributes
        public const string NOTIFICATIONACTIVITY_ATTR_RECORDURL = "ent_recordurl";
        public const string NOTIFICATIONACTIVITY_ATTR_RECIPIENTROLE = "ent_recipientrole";
        public const string NOTIFICATIONACTIVITY_ATTR_NOTIFICATIONFOR = "ownerid";
        public const string NOTIFICATIONACTIVITY_ATTR_NOTIFICATIONMESSAGE = "ent_notificationmessage";
        public const string NOTIFICATIONACTIVITY_ATTR_SUBJECT = "subject";
        public const string NOTIFICATIONACTIVITY_ATTR_EXPIRATIONON = "scheduledend";
        public const string NOTIFICATIONACTIVITY_ATTR_LOG = "ent_log";
        public const string NOTIFICATIONACTIVITY_ATTR_GROUPID = "ent_groupid";
        public const string NOTIFICATIONACTIVITY_ATTR_READON = "ent_readon";
        public const string NOTIFICATIONACTIVITY_ATTR_READBY = "ent_readbyid";
        public const string NOTIFICATIONACTIVITY_ATTR_NOTIFICATION_ID = "activityid";
        public const string NOTIFICATIONACTIVITY_ATTR_DELIVEREDON = "ent_deliveredon";
        public const string NOTIFICATIONACTIVITY_ATTR_MSG_CHANNEL = "ent_messagingchannel";
        public const string NOTIFICATIONACTIVITY_ATTR_TYPE = "ent_type";
        public const string NOTIFICATIONACTIVITY_ATTR_NOTIFICATIONREGARDING = "ent_notificationregarding";
        public const string NOTIFICATIONACTIVITY_ATTR_DESCRIPTION = "description";
        public const string NOTIFICATIONACTIVITY_ATTR_STARTDATE = "scheduledstart";
        public const string NOTIFICATIONACTIVITY_ATTR_RELEASEDATE = "ent_releasedate";
        public const string NOTIFICATIONACTIVITY_ATTR_PRIORITY = "prioritycode";
        public const string NOTIFICATIONACTIVITY_ATTR_RECIPIENTUSERS = "resources";
        public const string NOTIFICATIONACTIVITY_ATTR_RECIPIENTQUEUES = "optionalattendees";
        public const string NOTIFICATIONACTIVITY_ATTR_PARENTACTIVITY = "ent_parentactivityid";
        public const string NOTIFICATIONACTIVITY_ATTR_RECIPIENTGUID = "ent_recipientguid";
        public const string NOTIFICATIONACTIVITY_ATTR_TARGETBUSINESSUNIT = "ent_targetbusinessunit";

        //ECC ID Entity Attributes
        public const string EXTERNALORG_ATTR_ORG = "ent_organizationid";
        public const string EXTERNALORG_ATTR_ID = "ent_externalorgid";

        //Adobe Contacts
        public const string ADOBECONTACT_ATTR_ID = "ent_adobecontactid";
        public const string ADOBECONTACT_ATTR_ROLE = "ent_role";
        public const string ADOBECONTACT_ATTR_EMAIL = "ent_emailaddress";
        public const string ADOBECONTACT_ATTR_PHONE = "ent_phonenumber";
        public const string ADOBECONTACT_ATTR_PERSONID = "ent_personid";
        public const string ADOBECONTACT_ATTR_SOURCE = "ent_source";

        //Org Adobe Contacts
        public const string ORGADOBECONTACT_ATTR_ORGANIZATION = "ent_organizationid";
        public const string ORGADOBECONTACT_ATTR_ADOBECONTACT = "ent_adobecontactid";
        public const string ORGADOBECONTACT_ATTR_ROLE = "ent_role";
        public const string ORGADOBECONTACT_ATTR_SOURCE = "ent_source";

        //External Orgs Attributes
        public const string EXTERNALORG_ENDUSERID = "ent_name";

        //Queue Attributes
        public const string QUEUE_ATTR_NAME = "name";
        public const string QUEUE_ATTR_QUEUEID = "queueid";
        public const string QUEUE_ATTR_QUEUEITEMID = "queueitemid";
        public const string QUEUE_ATTR_QUEUEMANAGER = "ownerid";
        public const string QUEUE_ATTR_QUEUECATEGORY = "ent_queuecategory";
        public const string QUEUE_ATTR_RANK = "ent_rank";
        public const string QUEUE_ATTR_BUSINESSUNIT = "ent_businessunit";
        public const string QUEUE_ATTR_INCOMINGEMAIL = "emailaddress";
        public const string QUEUE_ATTR_CATEGORY = "ent_category";

        //Processes Entity Attributes
        public const string PROCESS_ATTR_TYPE = "type";
        public const string PROCESS_ATTR_CATEGORY = "category";
        public const string PROCESS_ATTR_NAME = "name";
        public const string PROCESS_ATTR_STATECODE = "statecode";

        //Call Center Site Attributes
        public const string CALLCENTERSITE_ATTR_CALLCENTERCODE = "ent_callcentercode";

        //Activity Party Attributes
        public const string ACTIVITYPARTY_ATTR_PARTYID = "partyid";
        public const string ACTIVITYPARTY_ATTR_PARTICIPATIONTYPEMASK = "participationtypemask";
        public const string ACTIVITYPARTY_ATTR_ADDRESSUSED = "addressused";

        // User Settings Attributes
        public const string USERSETTINGS_ATTR_UILANGUAGEID = "uilanguageid";
        public const string USERSETTINGS_ATTR_SYSTEMUSERID = "systemuserid";
        public const string USERSETTINGS_ATTR_TIMEZONECODE = "timezonecode";

        //Queue Item Attributes
        public const string QUEUEITEM_ATTR_QUEUEITEMID = "queueitemid";
        public const string QUEUEITEM_ATTR_QUEUEID = "queueid";
        public const string QUEUEITEM_ATTR_OBJECTID = "objectid";
        public const string QUEUEITEM_ATTR_CREATEDON = "createdon";
        public const string QUEUEITEM_ATTR_CASEPRIORITY = "ent_priority";
        public const string QUEUEITEM_ATTR_CASEID = "ent_caseid";

        // Mutex Request Attributes
        public const string MUTEX_ATTR_ID = "ent_id";
        public const string MUTEX_ATTR_TYPE = "ent_type";

        // TimeZone attributes        
        public const string TIMEZONEDEFINATION_ATTR_STANDARDNAME = "standardname";
        public const string TIMEZONEDEFINATION_ATTR_TIMEZONECODE = "timezonecode";
        public const string TIMEZONEDEFINATION_ATTR_RETIREDORDER = "retiredorder";
        public const string TIMEZONEDEFINATION_ATTR_USERINTERFACENAME = "userinterfacename";

        // Activity Attirbutes
        public const string ACTIVITY_ATTR_SORTDATE = "sortdate";
        public const string ACTIVITY_ATTR_CREATEDON = "createdon";
        //public const string ACTIVITY_PHONECALL = "Microsoft.Dynamics.CRM.phonecall";
        //public const string ACTIVITY_BOMGARSESSION = "Microsoft.Dynamics.CRM.bom_session";
        //public const string ACTIVITY_CUSTOMERNOTE = "Microsoft.Dynamics.CRM.ent_customernote";
        //public const string ACTIVITY_INTERNALNOTE = "Microsoft.Dynamics.CRM.ent_internalnotes";
        //public const string ACTIVITY_CHAT = "Microsoft.Dynamics.CRM.ent_chat";
        public const string ACTIVITY_ATTR_ACTIVITYTYPE = "@odata.type";
        public const string ACTIVITY_PHONECALL = "phonecall";
        public const string ACTIVITY_BOMGARSESSION = "bom_session";
        public const string ACTIVITY_CUSTOMERNOTE = "ent_customernote";
        public const string ACTIVITY_INTERNALNOTE = "ent_internalnotes";
        public const string ACTIVITY_CHAT = "ent_chat";

        //Team Atributes
        public const string TEAM_ATTR_TEAMID = "teamid";
        public const string TEAM_ATTR_TEAMNAME = "name";
        public const string TEAM_ATTR_OWNINGTEAMTYPE = "ent_owningteamtype";

        //Role Attributes
        public const string ROLE_ATTR_ROLEID = "roleid";
        public const string ROLE_ATTR_ROLENAME = "name";

        //TeamMembership Attributes
        public const string TEAMMEMBERSHIPS_ATTR_SYSTEMUSER = "systemuserid";
        public const string TEAMMEMBERSHIPS_ATTR_TEAM = "teamid";

        //SystemUserRole Attributes
        public const string SYSTEMUSERROLE_ATTR_SYSTEMUSERROLEID = "systemuserroleid";
        public const string SYSTEMUSERROLE_ATTR_SYSTEMUSER = "systemuserid";
        public const string SYSTEMUSERROLE_ATTR_Role = "roleid";


        //Language Attributes
        public const string LANGUAGE_ATTR_LANGUAGENAME = "name";
        public const string LANGUAGE_ATTR_LANGUAGECODE = "code";
        public const string LANGUAGE_ATTR_LANGUAGEID = "localeid";

        //Team Role Attributes
        public const string TEAMROLE_ATTR_TEAMROLEID = "teamroleid";
        public const string TEAMROLE_ATTR_TEAM = "teamid";
        public const string TEAMROLE_ATTR_ROLE = "roleid";

        //Team Membership Attributes
        public const string TEAMMEMBERSHIP_ATTR_TEAMID = "teamid";
        public const string TEAMMEMBERSHIP_ATTR_TEAMMEMBERSHIPID = "teammembershipid";
        public const string TEAMMEMBERSHIP_ATTR_SYSTEMUSERID = "systemuserid";



        //Common Fields - Subscription
        public const string SUBSCRIPTION_COMMON_ATTR_SUBEMAIL = "ent_subscriptionemail";
        public const string SUBSCRIPTION_COMMON_ATTR_ORGANIZATION = "ent_organizationid";
        public const string SUBSCRIPTION_COMMON_ATTR_PRODUCT = "ent_productid";
        public const string SUBSCRIPTION_COMMON_ATTR_PROJECT = "ent_projectid";
        public const string SUBSCRIPTION_COMMON_ATTR_PRIORITY = "ent_priority";

        //Template Attributes
        public const string TEMPLATE_ATTR_TITLE = "title";

        //Organization - External Org N:N Relationship
        public const string ORG_EXTERNALORG_MANY_TO_MANY = "ent_organization_ent_externalorg";

        //Appointment attributes
        public const string APPOINTMENT_ATTR_SUBJECT = "subject";
        public const string APPOINTMENT_ATTR_LOCATION = "location";
        public const string APPOINTMENT_ATTR_DESCRIPTION = "description";
        public const string APPOINTMENT_ATTR_START_TIME = "scheduledstart";
        public const string APPOINTMENT_ATTR_END_TIME = "scheduledend";
        public const string APPOINTMENT_ATTR_CUSTOMER_TIMEZONE = "ent_preferredcustomertimezone";
        public const string APPOINTMENT_ATTR_CUSTOMER_START_TIME = "ent_customerstarttime";
        public const string APPOINTMENT_ATTR_CUSTOMER_END_TIME = "ent_customerendtime";
        public const string APPOINTMENT_ATTR_DURATION = "scheduleddurationminutes";
        public const string APPOINTMENT_ATTR_WORKINGHOURS_START_TIME = "ent_workinghoursstarttime";
        public const string APPOINTMENT_ATTR_WORKINGHOURS_END_TIME = "ent_workinghoursendtime";
        public const string APPOINTMENT_ATTR_ALL_DAY_EVENT = "isalldayevent";
        public const string APPOINTMENT_ATTR_REQUIREDATTENDEES = "requiredattendees";
        public const string APPOINTMENT_ATTR_AUTO_CREATED = "ent_isautocreated";
        public const string APPOINTMENT_ATTR_ORGANIZER = "organizer";

        //Project attributes
        public const string PROJECT_ATTR_PROJECT = "ent_project";
        public const string PROJECT_ATTR_ORGANIZATION = "ent_organization";
        public const string PROJECT_ATTR_PRODUCTFAMILY = "ent_productfamily";
        public const string PROJECT_ATTR_PROJECTCODE = "ent_projectcode";

        //External Ticket Attributes
        public const string EXTERNALTICKET_ATTR_TICKETID = "ent_name";
        public const string EXTERNALTICKET_ATTR_SOURCETYPE = "ent_sourcetype";
        public const string EXTERNALTICKET_ATTR_TICKETSTATUS = "ent_ticketstatus";
        public const string EXTERNALTICKET_ATTR_TITLE = "ent_title";
        public const string EXTERNALTICKET_ATTR_INFLUENCECASESTATUS = "ent_influencecasestatus";
        public const string EXTERNALTICKET_ATTR_SYSID = "ent_sysid";
        public const string EXTERNALTICKET_ATTR_TICKETURL = "ent_ticketurl";
        public const string EXTERNALTICKET_ATTR_ASSIGNEDTOEMAIL = "ent_assignedtoemailid";
        public const string EXTERNALTICKET_ATTR_CREATEDDATE = "ent_createddate";
        public const string EXTERNALTICKET_ATTR_ID = "ent_externalticketid";
        public const string EXTERNALTICKET_ATTR_RESOLUTION = "ent_resolution";

        //Product Version attributes
        public const string PRODUCTVERSION_ATTR_VERSION = "ent_version";

        //Auto Generated Activity attributes
        public const string AUTOGENERATEDACTIVITY_TICKETNUMBER = "ent_ticketnumber";
        public const string AUTOGENERATEDACTIVITY_INCIDENTID = "ent_incidentid";

        //Annotation attributes
        public const string ANNOTATION_ATTR_SUBJECT = "subject";
        public const string ANNOTATION_ATTR_NOTETEXT = "notetext";
        public const string ANNOTATION_ATTR_OBJECTID = "objectid";
        public const string ANNOTATION_ATTR_OBJECTTYPECODE = "objecttypecode";
        public const string ATTACHMENT_NOTE_SUBJECT_VALUE = "Attachment Note";
        public const string ANNOTATION_ATTR_DOCUMENTBODY = "documentbody";
        public const string ANNOTATION_ATTR_FILENAME = "filename";
        public const string ANNOTATION_ATTR_FILESIZE = "filesize";
        public const string ANNOTATION_ATTR_MIMETYPE = "mimetype";
        public const string ANNOTATION_ATTR_DOCUMENTFLAG = "isdocument";

        //Activity Mime Attachment
        public const string ACTIVITYMIMEATTACHMENT_ATTR_OBJECTID = "objectid";
        public const string ACTIVITYMIMEATTACHMENT_ATTR_FILESIZE = "filesize";
        public const string ACTIVITYMIMEATTACHMENT_ATTR_BODY = "body";
        public const string ACTIVITYMIMEATTACHMENT_ATTR_FILENAME = "filename";
        public const string ACTIVITYMIMEATTACHMENT_ATTR_MIMETYPE = "mimetype";

        //Attachment  attributes
        public const string ENTITY_ATTACHMENT_DOCUMENTBODY = "body";
        public const string ENTITY_ATTACHCMENT_FILENAME = "filename";
        //Token Cache attributes
        public const string SYSTEMSETTINGS_TOKENCACHE_NAME_SAS = "SharedAccessSignature";
        public const string SYSTEMSETTINGS_SAS_SIGNEDVERSION = "2019-12-12";
        public const string SYSTEMSETTINGS_SAS_SIGNEDSERVICES = "b";
        public const string SYSTEMSETTINGS_SAS_SIGNEDRESOURCETYPES = "sco";
        public const string SYSTEMSETTINGS_SAS_SIGNEDPERMISSIONS = "rwdlac";
        public const int SYSTEMSETTINGS_SAS_TTLDAYS = 1;
        public const string TOKENCACHE_NAME_VALUE_SAS = "SharedAccessSignature";
        public const string TOKENCACHE_ATTR_TOKENNAME = "ent_tokenname";
        public const string TOKENCACHE_ATTR_EXPIRESON = "ent_expireson";
        public const double TOKENCACHE_ATTR_REFRESHTOKENEXPIRESONTIME = 1295999520;
        public const string TOKENCACHE_ATTR_REFRESHTOKENEXPIRESON = "ent_refreshtokenexpireson";
        public const string TOKENCACHE_ATTR_REFRESHTOKEN = "ent_refreshtoken";
        public const string TOKENCACHE_ATTR_ACCESSTOKEN = "ent_accesstoken";

        //Channel Transaction/transactionlog Attributes
        public const string TRANSACTIONLOG_ATTR_TRANSACTIONID = "ent_transactionid";
        public const string TRANSACTIONLOG_ATTR_ID = "ent_transactionlogid";
        public const string TRANSACTIONLOG_ATTR_TICKETNUMBER = "ent_ticketnumber";
        public const string TRANSACTIONLOG_ATTR_CASEGUID = "ent_caseguid";
        public const string TRANSACTIONLOG_ATTR_EMAIL = "ent_email";
        public const string TRANSACTIONLOG_ATTR_PHONENUMBER = "ent_phonenumber";
        public const string TRANSACTIONLOG_ATTR_ORGID = "ent_orgid";
        public const string TRANSACTIONLOG_ATTR_TRANSFERFLAG = "ent_transferflag";
        public const string TRANSACTIONLOG_ATTR_CASEORIGINCODE = "ent_caseorigincode";

    }
}
