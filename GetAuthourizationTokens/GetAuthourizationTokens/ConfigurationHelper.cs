using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GetAuthorizationTokens
{
    public sealed class ConfigurationHelper
    {
        private static readonly ConfigurationHelper instance = new ConfigurationHelper();
        private ConfigurationHelper()
        {
        }
        private List<Entity> sysSettingsCln = null;
        private DateTime cacheExpiryDateTime = DateTime.MinValue;
        private int cacheTimeout = 0;

        /// <summary>
        /// Singleton Object
        /// </summary>
        public static ConfigurationHelper Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Returns all system setting records from either singleton object or CRM
        /// </summary>
        /// <param name="service"></param>
        /// <param name="tracingService."></param>
        /// <returns></returns>
        public List<Entity> GetAllSystemSettings(IOrganizationService service)
        {
            
            if (sysSettingsCln?.Count > 0 && cacheExpiryDateTime >= DateTime.UtcNow)
            {
               
                return sysSettingsCln;
            }
            
            try
            {
                var queryExpression = new QueryExpression()
                {
                    EntityName = Constants.ENTITY_SYSTEMSETTINGS,
                    ColumnSet = new ColumnSet(EntityAttributes.SYSTEMSETTINGS_ATTR_GROUP, EntityAttributes.SYSTEMSETTINGS_ATTR_KEY, EntityAttributes.SYSTEMSETTINGS_ATTR_LONGVALUE),
                    Criteria =
                {
                    Filters =
                        {
                            new FilterExpression
                            {FilterOperator = LogicalOperator.And,
                                Conditions =
                                {
                                    new ConditionExpression(EntityAttributes.COMMON_ATTR_STATECODE, ConditionOperator.Equal, 0)
                                }
                            }
                    }
                },
                    NoLock = true
                };
                EntityCollection qExpResult = service.RetrieveMultiple(queryExpression);
                //Set Retrieved system settings collection
                sysSettingsCln = qExpResult?.Entities?.Count > 0 ? qExpResult.Entities.ToList() : null;
                
                //Set Cache Validation Timeout
                SetCacheValidationTimeout();
            }
            catch (Exception ex)
            {
               
                throw;
            }

            return sysSettingsCln.ToList();
        }
        /// <summary>
        /// Function to retrieve all system settings by Group and Key
        /// </summary>
        public string GetSettingsByGroupKey(string groupName, string key, IOrganizationService service, ITracingService tracingService)
        {
            string strValue = null;
            try
            {
                List<Entity> sysSettings = GetAllSystemSettings(service);

                Entity entity = sysSettings?.Where(e => e.GetAttributeValue<string>(EntityAttributes.SYSTEMSETTINGS_ATTR_GROUP).Equals(groupName, StringComparison.InvariantCultureIgnoreCase) && e.GetAttributeValue<string>(EntityAttributes.SYSTEMSETTINGS_ATTR_KEY).Equals(key, StringComparison.InvariantCultureIgnoreCase))?.FirstOrDefault();

                if (!string.IsNullOrWhiteSpace(entity?.GetAttributeValue<string>(EntityAttributes.SYSTEMSETTINGS_ATTR_LONGVALUE)))
                {
                    strValue = entity.GetAttributeValue<string>(EntityAttributes.SYSTEMSETTINGS_ATTR_LONGVALUE);
                }
            }
            catch (Exception ex)
            {
                tracingService?.Trace($"Error: An error occured in GetSystemSettings method. Error Details: {ex.Message}");
            }
            return strValue;
        }

        /// <summary>
        /// Function to retrieve all system settings by Group
        /// </summary>
        public EntityCollection GetSettingsByGroup(string groupName, IOrganizationService service)
        {
            
            EntityCollection GetSettingsByGroup = new EntityCollection();
            try
            {
                List<Entity> sysSettings = GetAllSystemSettings(service);
                
                if (sysSettings?.Count > 0)
                {
                    GetSettingsByGroup.Entities.AddRange(sysSettings?.Where(e => e.GetAttributeValue<string>(EntityAttributes.SYSTEMSETTINGS_ATTR_GROUP).Equals(groupName, StringComparison.InvariantCultureIgnoreCase)));
                }
            }
            catch (Exception ex)
            {
                //tracingService?.Trace($"Error: An error occured in GetSystemSettings method. Error Details: {ex.Message}");
            }
            return GetSettingsByGroup;
        }

        /// <summary>
        /// Function to retrieve all system settings by Key(s)
        /// </summary>
        public EntityCollection GetSettingsByKey(IOrganizationService service, ITracingService tracingService, params string[] keys)
        {
            tracingService.Trace("Retreiving System Settings for Group: {0}", string.Join(",", keys));
            EntityCollection GetSettingsByKey = new EntityCollection();
            try
            {
                List<Entity> sysSettings = GetAllSystemSettings(service);
                foreach (string Key in keys)
                {
                    GetSettingsByKey.Entities.AddRange(sysSettings?.Where(e => e.GetAttributeValue<string>(EntityAttributes.SYSTEMSETTINGS_ATTR_KEY).Equals(Key, StringComparison.InvariantCultureIgnoreCase)));
                }
            }
            catch (Exception ex)
            {
                tracingService?.Trace($"Error: An error occured in GetSystemSettings method. Error Details: {ex.Message}");
            }

            return GetSettingsByKey;
        }
        /// <summary>
        /// Sets cacheExpiryDateTime based on the cacheValidationTimeout system setting
        /// </summary>
        private void SetCacheValidationTimeout()
        {
            try
            {
                string strTimeout = string.Empty;
                
                Entity entity = sysSettingsCln.Where(e => e.GetAttributeValue<string>(EntityAttributes.SYSTEMSETTINGS_ATTR_GROUP).Equals(EntityAttributes.SYSTEMSETTINGS_GRP, StringComparison.InvariantCultureIgnoreCase) && e.GetAttributeValue<string>(EntityAttributes.SYSTEMSETTINGS_ATTR_KEY).Equals(EntityAttributes.SYSTEMSETTINGS_DATA_CACHEVALIDATIONTIMEOUT, StringComparison.InvariantCultureIgnoreCase))?.FirstOrDefault();

                if (!string.IsNullOrWhiteSpace(entity?.GetAttributeValue<string>(EntityAttributes.SYSTEMSETTINGS_ATTR_LONGVALUE)))
                {
                    strTimeout = entity.GetAttributeValue<string>(EntityAttributes.SYSTEMSETTINGS_ATTR_LONGVALUE);
                    
                }
                if (string.IsNullOrWhiteSpace(strTimeout) || string.Equals(strTimeout, "0"))
                {
                   
                    cacheExpiryDateTime = DateTime.MinValue;
                }
                else if (int.TryParse(strTimeout, out cacheTimeout))
                {
                   
                    cacheExpiryDateTime = DateTime.UtcNow.AddMinutes(cacheTimeout);
                    
                }
                else
                {
                    
                    cacheExpiryDateTime = DateTime.MinValue;
                }
            }
            catch (Exception ex)
            {
               
                throw;
            }

        }
    }
}
