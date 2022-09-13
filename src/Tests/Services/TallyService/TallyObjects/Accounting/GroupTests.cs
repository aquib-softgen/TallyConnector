﻿using System.Xml.Linq;
using Tests.Services.TallyService;

namespace Tests.Services.TallyService.TallyObjects.Accounting;
internal class GroupTests : BaseTallyServiceTest
{

    [Test]
    public async Task CheckGetAllGroups()
    {

        var Groups = await _tallyService.GetObjectsAsync<TCMA.Group>(new() { FetchList = new() { "*" } });
        Assert.That(Groups, Is.Not.Null);
        Assert.That(Groups, Has.Count.EqualTo(73));
    }
    [Test]
    public async Task CheckGetAllGroups2()
    {

        var Groups = await _tallyService.GetAllObjectsAsync<TCMA.Group>(new() { FetchList = new() { "*" } });
        Assert.That(Groups, Is.Not.Null);
        Assert.That(Groups, Has.Count.EqualTo(73));
    }
    [Test]
    public async Task CheckGetAllGroupsbyPaginate()
    {
        List<TCMA.Group> Groups = new();
        var Stat = await _tallyService.GetMasterStatisticsAsync();
        var TotalCount = Stat.FirstOrDefault(c => c.Name == TCM.TallyObjectType.Groups.ToString()).Count;
        TCM.Pagination pagination = new(50, 100);
        for (int i = 0; i < pagination.TotalPages; i++)
        {
            var TGroups = await _tallyService.GetObjectsAsync<TCMA.Group>(new() { Pagination = pagination });
            Groups.AddRange(TGroups);
            pagination.NextPage();
        }
        Assert.That(Groups, Is.Not.Null);
        Assert.That(Groups, Has.Count.EqualTo(73));
    }

    [Test]
    public async Task CheckGroup_CRUD()
    {
        TCMA.Group group = new("Test NA")
        {
            AddlAllocType = TCM.AdAllocType.AppropriateByQty,
            IsCalculable = false
        };
        XmlDocument xmlDocument = new();
        XmlElement xmlElement = xmlDocument.CreateElement("Test");
        xmlElement.Value = "sdfg";
        //xmlElement.Attributes.na = "TallyUDF";
        group.OtherFields = new XmlElement[] { xmlElement };
        //Creating 
        TCM.TallyResult tallyResult = await _tallyService.PostGroupAsync(group);
        Assert.That(tallyResult.Status, Is.EqualTo(TCM.RespStatus.Sucess));
        //Reading
        var Tgroup = await _tallyService.GetGroupAsync<TCMA.Group>(group.Name);

        Assert.Multiple(() =>
        {
            Assert.That(Tgroup.Name, Is.EqualTo(group.Name));
            Assert.That(Tgroup.AddlAllocType, Is.EqualTo(group.AddlAllocType));
            Assert.That((bool)Tgroup.IsCalculable, Is.EqualTo((bool)group.IsCalculable));
        });

        Tgroup.AddlAllocType = TCM.AdAllocType.NotApplicable;
        Tgroup.IsCalculable = true;
        //Update 
        TCM.TallyResult updateResult = await _tallyService.PostGroupAsync(Tgroup);

        var Updatedgroup = await _tallyService.GetGroupAsync<TCMA.Group>(Tgroup.Name);

        Assert.Multiple(() =>
        {
            Assert.That(Updatedgroup.Name, Is.EqualTo(Tgroup.Name));
            Assert.That(Updatedgroup.AddlAllocType, Is.EqualTo(Tgroup.AddlAllocType));
            Assert.That((bool)Updatedgroup.IsCalculable, Is.EqualTo((bool)Tgroup.IsCalculable));
        });

        Updatedgroup.Action = TallyConnector.Core.Models.Action.Delete;
        //deleting
        TCM.TallyResult delResult = await _tallyService.PostGroupAsync(Updatedgroup);
        Assert.That(delResult.Status, Is.EqualTo(TCM.RespStatus.Sucess));

    }
}