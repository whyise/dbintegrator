using System.Collections.Generic;

namespace Worker
{
    public class MappingObj
    {
        public string fname { get; set; }
        public string valueMap { get; set; }
        public string mapTo { get; set; }
    }

    public class SaveObject
    {
        public string ApiKey { get; set; }
        public List<DataObj> Datasets { get; set; }
    }

    public class DataObj
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsConfigured { get; set; }
        public bool IsEnabled { get; set; }

        public bool MultipleRU { get; set; }
        public string RUName { get; set; }
        public int PullFrequency { get; set; }

        public int ServerType { get; set; }
        public string Url { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public string Table { get; set; }

        public List<MappingObj> Fields { get; set; }
    }

    public class ConnectionReturn
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public string ServerName { get; set; }
        public string DBName { get; set; }
        public string Password { get; set; }
        public int ConnectionName { get; set; }
        public string ConnectionString { get; set; }
        public bool? States { get; set; }
        public List<DataField> DataFields { get; set; }
    }

    public class DataField
    {
        public int Id { get; set; }
        public string name { get; set; }
    }

    public class KeyValue
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class IntegrationObject
    {
        public string DSCode { get; set; }
        public bool MultipleRUs { get; set; }
        public string RUName { get; set; }
        public string AuthKey { get; set; }
        public string DS_ActivityParentCode { get; set; }
        public string FileName { get; set; }
    }

    public class ReturnMessage
    {
        public string FieldName { get; set; }
        public string Message { get; set; }
    }

    public class ReturnObject
    {
        public int totalRows { get; set; }
        public int acceptedRows { get; set; }
        public List<ReturnMessage> messages { get; set; }
    }
}