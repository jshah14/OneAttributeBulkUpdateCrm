
namespace OneAttributeBulkUpload
{
    public enum AttributeType
    {
        String,
        Status,
        State,
        Picklist,
        PartyList,
        Owner,
        Money,
        Lookup,
        Integer,
        Double,
        Decimal,
        DateTime,
        Customer,
        Boolean,
        BigInt,
        Uniqueidentifier
    }

    public enum AllowedAttributeType
    {
        String,
        Status,
        State,
        Picklist,
        PartyList,
        Owner,
        Money,
        Lookup,
        Integer,
        Double,
        Decimal,
        DateTime,
        Customer,
        Boolean
    }

    public enum AllowedRefAttrType
    {
        Owner,
        Lookup,
        Customer,
        PartyList
    }
}
