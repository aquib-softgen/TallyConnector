﻿using MongoDB.Bson;
using System.Runtime.Serialization;

namespace TallyConnector.Core.Models;

public class TallyBaseObject
{
    //    [NotMapped]
    //    [XmlAnyElement()]
    //    public XmlElement[]? OtherFields
    //    {
    //        get; set;
    //    }

    //    [NotMapped]
    //    [XmlAnyAttribute]
    //    public XmlAttribute[]? OtherAttributes
    //    {
    //        get; set;

    /// <summary>
    /// Removes Null Childs that are created during xml deserilisation
    /// </summary>
    public virtual void RemoveNullChilds() { }
}

public class TallyXmlJson : TallyBaseObject
{
    /// <summary>
    /// Accepted Values //Create, Alter, Delete
    /// </summary>
    [NotMapped]
    [XmlAttribute(AttributeName = "Action")]
    public Action Action { get; set; }

    public string GetJson(bool Indented = false)
    {
        string Json = JsonSerializer.Serialize(
            this,
            GetType(),
            new JsonSerializerOptions()
            {
                WriteIndented = Indented,
                //DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                Converters = { new JsonStringEnumConverter(), new TallyDateJsonConverter() }
            }
        );
        return Json;
    }

    public string GetXML(XmlAttributeOverrides? attrOverrides = null, bool indent = false)
    {
        TextWriter textWriter = new StringWriter();
        XmlWriterSettings settings =
            new()
            {
                OmitXmlDeclaration = true,
                //NewLineChars = "&#13;&#10;", //If /r/n in Xml replace
                NewLineHandling = NewLineHandling.Entitize,
                Encoding = Encoding.Unicode,
                CheckCharacters = false,
                Indent = indent,
            };
        XmlSerializerNamespaces ns = new(new[] { XmlQualifiedName.Empty });

        XmlSerializer xmlSerializer =
            attrOverrides == null ? new(this.GetType()) : new(this.GetType(), attrOverrides);
        var writer = XmlWriter.Create(textWriter, settings);
        xmlSerializer.Serialize(writer, this, ns);
        return textWriter.ToString()!;
    }
}

[XmlRoot(ElementName = "OBJECTS")]
public class BasicTallyObject : TallyXmlJson, ITallyObject, IBasicTallyObject
{
    [JsonIgnore]
    public ObjectId? Id { get; set; }

    [JsonPropertyName("id")]
    public string IdStr => Id.ToString();

    [XmlElement(ElementName = "MASTERID")]
    public ulong? MasterId { get; set; }

    [XmlElement(ElementName = "GUID")]
    [Column(TypeName = $"nvarchar({Constants.GUIDLength})")]
    public string? GUID { get; set; }

    [XmlElement(ElementName = "REMOTEALTGUID")]
    [Column(TypeName = $"nvarchar({Constants.GUIDLength})")]
    public string? RemoteId { get; set; }

    [XmlElement(ElementName = "ALTERID")]
    public long? AlterId { get; set; }

    public void PrepareForExport() { }

    public override string ToString()
    {
        return GUID ?? string.Empty;
    }
}
