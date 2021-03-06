﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Management;
using LunchAndLearn.Model;
using LunchAndLearn.Model.DB_Models;
using LunchAndLearn.Model.DTOs;
using NUnit.Framework;
using Telerik.JustMock;

namespace LunchAndLearnService.Tests.LunchAndLearn.Management
{
  [TestFixture]
  public class RoomServiceTest
  {
    private RoomService _roomService;
    private List<RoomDto> _roomList;

    [SetUp]
    public void Init()
    {
      _roomList = new List<RoomDto>()
      {
        new RoomDto()
        {
          RoomId = 1,
          RoomDescription = "room description 1",
          RoomName = "room name 1"
        },
        new RoomDto()
        {
          RoomId = 2,
          RoomDescription = "room description 2",
          RoomName = "room name 2"
        },
        new RoomDto()
        {
          RoomId = 3,
          RoomDescription = "room description 3",
          RoomName = "room name 3"
        }
      };
    }

    [TearDown]
    public void CleanUp()
    {
      _roomList = null;
      _roomService = null;
    }

    [Test]
    public void CreateRoom_UnderNormalConditions_AddsRoomToRoomList()
    {
      //arrange
      var originalCountOfRooms = _roomList.Count;
      var roomToCreate = new RoomDto()
      {
        RoomId = 5,
        RoomDescription = "room description 5",
        RoomName = "room name 5"
      };

      var mockRepo = Mock.Create<IRoomRepository>();
      Mock.Arrange(() => mockRepo.Create(Arg.IsAny<Room>())).DoInstead(() => _roomList.Add(roomToCreate)).OccursOnce();

      _roomService = new RoomService(mockRepo);

      //act
      _roomService.Create(roomToCreate);
      var actualCountOfRooms = _roomList.Count;

      //assert
      Mock.Assert(mockRepo);
      Assert.That(actualCountOfRooms, Is.EqualTo(originalCountOfRooms + 1));
    }
  }
}
